# ---- Build Web ----
FROM node:16 AS react-builder

WORKDIR /app
COPY ./RukusRummy.Web ./
RUN npm install
RUN npm run build


# ---- Build Api ----
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS api-builder

WORKDIR /src
COPY ./ ./
RUN dotnet restore RukusRummy.Api/RukusRummy.Api.csproj
RUN dotnet publish RukusRummy.Api/RukusRummy.Api.csproj -c Release -o /app

# ---- Build Identity ----
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS identity-builder

# WORKDIR /src
# COPY ./ ./
# RUN dotnet restore RukusRummy.Identity/RukusRummy.Identity.csproj
# RUN dotnet publish RukusRummy.Identity/RukusRummy.Identity.csproj -c Release -o /app

# ---- Final Stage with Nginx ----
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final

# Install nginx and supervisor
RUN echo "Acquire::Check-Valid-Until \"false\";\nAcquire::AllowInsecureRepositories \"true\";\nAcquire::AllowDowngradeToInsecureRepositories \"true\";" > /etc/apt/apt.conf.d/99no-check-valid-until \
&& apt-get update && apt-get install -y nginx supervisor


# Copy built React app
COPY --from=react-builder /app/build /usr/share/nginx/html

# Copy built .NET apps
COPY --from=api-builder /app /api-app
# COPY --from=identity-builder /app /identity-app

# Copy SSL certificates
COPY ./certs/domain.key /etc/nginx/certs/domain.key
COPY ./certs/domain.crt /etc/nginx/certs/domain.crt
COPY ./certs/passphrase.txt /etc/nginx/certs/passphrase.txt

# Setup Nginx
COPY nginx.conf /etc/nginx/nginx.conf

# Supervisor Config
COPY supervisord.conf /etc/supervisor/conf.d/supervisord.conf

CMD ["/usr/bin/supervisord"]