# Details

Date : 2023-11-18 20:15:18

Directory /Users/brian/Dev/Web/RukusRummy

Total : 199 files,  34028 codes, 368 comments, 1702 blanks, all 36098 lines

[Summary](results.md) / Details / [Diff Summary](diff.md) / [Diff Details](diff-details.md)

## Files
| filename | language | code | comment | blank | total |
| :--- | :--- | ---: | ---: | ---: | ---: |
| [.dockerignore](/.dockerignore) | Ignore | 7 | 6 | 6 | 19 |
| [Dockerfile](/Dockerfile) | Docker | 22 | 15 | 15 | 52 |
| [README.md](/README.md) | Markdown | 24 | 0 | 17 | 41 |
| [RukusRummy.Api/Controllers/DeckController.cs](/RukusRummy.Api/Controllers/DeckController.cs) | C# | 80 | 0 | 12 | 92 |
| [RukusRummy.Api/Controllers/GameController.cs](/RukusRummy.Api/Controllers/GameController.cs) | C# | 122 | 0 | 18 | 140 |
| [RukusRummy.Api/Controllers/PlayerController.cs](/RukusRummy.Api/Controllers/PlayerController.cs) | C# | 115 | 34 | 36 | 185 |
| [RukusRummy.Api/Extensions/IServiceCollectionExtensions.cs](/RukusRummy.Api/Extensions/IServiceCollectionExtensions.cs) | C# | 37 | 0 | 5 | 42 |
| [RukusRummy.Api/Hubs/GameHub.cs](/RukusRummy.Api/Hubs/GameHub.cs) | C# | 41 | 10 | 9 | 60 |
| [RukusRummy.Api/Program.cs](/RukusRummy.Api/Program.cs) | C# | 43 | 1 | 14 | 58 |
| [RukusRummy.Api/Properties/launchSettings.json](/RukusRummy.Api/Properties/launchSettings.json) | JSON | 41 | 0 | 1 | 42 |
| [RukusRummy.Api/RukusRummy.Api.csproj](/RukusRummy.Api/RukusRummy.Api.csproj) | XML | 14 | 0 | 5 | 19 |
| [RukusRummy.Api/WeatherForecast.cs](/RukusRummy.Api/WeatherForecast.cs) | C# | 8 | 0 | 5 | 13 |
| [RukusRummy.Api/appsettings.Development.json](/RukusRummy.Api/appsettings.Development.json) | JSON | 8 | 0 | 1 | 9 |
| [RukusRummy.Api/appsettings.json](/RukusRummy.Api/appsettings.json) | JSON | 9 | 0 | 1 | 10 |
| [RukusRummy.BusinessLogic/Defaults.cs](/RukusRummy.BusinessLogic/Defaults.cs) | C# | 28 | 0 | 1 | 29 |
| [RukusRummy.BusinessLogic/Models/DTOs/AddPlayerDTO.cs](/RukusRummy.BusinessLogic/Models/DTOs/AddPlayerDTO.cs) | C# | 13 | 0 | 3 | 16 |
| [RukusRummy.BusinessLogic/Models/DTOs/CreateGameDTO.cs](/RukusRummy.BusinessLogic/Models/DTOs/CreateGameDTO.cs) | C# | 19 | 0 | 1 | 20 |
| [RukusRummy.BusinessLogic/Models/DTOs/DeckDTO.cs](/RukusRummy.BusinessLogic/Models/DTOs/DeckDTO.cs) | C# | 20 | 0 | 5 | 25 |
| [RukusRummy.BusinessLogic/Models/DTOs/GameDTO.cs](/RukusRummy.BusinessLogic/Models/DTOs/GameDTO.cs) | C# | 21 | 0 | 11 | 32 |
| [RukusRummy.BusinessLogic/Models/DTOs/PickCardDTO.cs](/RukusRummy.BusinessLogic/Models/DTOs/PickCardDTO.cs) | C# | 14 | 0 | 4 | 18 |
| [RukusRummy.BusinessLogic/Models/Deck.cs](/RukusRummy.BusinessLogic/Models/Deck.cs) | C# | 13 | 0 | 3 | 16 |
| [RukusRummy.BusinessLogic/Models/Entity.cs](/RukusRummy.BusinessLogic/Models/Entity.cs) | C# | 11 | 0 | 1 | 12 |
| [RukusRummy.BusinessLogic/Models/Game.cs](/RukusRummy.BusinessLogic/Models/Game.cs) | C# | 21 | 0 | 11 | 32 |
| [RukusRummy.BusinessLogic/Models/GameNotificationType.cs](/RukusRummy.BusinessLogic/Models/GameNotificationType.cs) | C# | 7 | 0 | 0 | 7 |
| [RukusRummy.BusinessLogic/Models/GameStateType.cs](/RukusRummy.BusinessLogic/Models/GameStateType.cs) | C# | 8 | 0 | 0 | 8 |
| [RukusRummy.BusinessLogic/Models/Player.cs](/RukusRummy.BusinessLogic/Models/Player.cs) | C# | 13 | 1 | 4 | 18 |
| [RukusRummy.BusinessLogic/Models/PlayerPermissionType.cs](/RukusRummy.BusinessLogic/Models/PlayerPermissionType.cs) | C# | 8 | 0 | 0 | 8 |
| [RukusRummy.BusinessLogic/Repositories/DeckMemoryRepository.cs](/RukusRummy.BusinessLogic/Repositories/DeckMemoryRepository.cs) | C# | 44 | 0 | 13 | 57 |
| [RukusRummy.BusinessLogic/Repositories/GameMemoryRepository.cs](/RukusRummy.BusinessLogic/Repositories/GameMemoryRepository.cs) | C# | 54 | 3 | 12 | 69 |
| [RukusRummy.BusinessLogic/Repositories/IRepository.cs](/RukusRummy.BusinessLogic/Repositories/IRepository.cs) | C# | 15 | 0 | 5 | 20 |
| [RukusRummy.BusinessLogic/Repositories/PlayerMemoryRepository.cs](/RukusRummy.BusinessLogic/Repositories/PlayerMemoryRepository.cs) | C# | 44 | 0 | 12 | 56 |
| [RukusRummy.BusinessLogic/Repositories/RoundMemoryRepository.cs](/RukusRummy.BusinessLogic/Repositories/RoundMemoryRepository.cs) | C# | 48 | 0 | 13 | 61 |
| [RukusRummy.BusinessLogic/Round.cs](/RukusRummy.BusinessLogic/Round.cs) | C# | 20 | 1 | 7 | 28 |
| [RukusRummy.BusinessLogic/RukusRummy.BusinessLogic.csproj](/RukusRummy.BusinessLogic/RukusRummy.BusinessLogic.csproj) | XML | 10 | 0 | 4 | 14 |
| [RukusRummy.BusinessLogic/Services/DeckService.cs](/RukusRummy.BusinessLogic/Services/DeckService.cs) | C# | 63 | 0 | 11 | 74 |
| [RukusRummy.BusinessLogic/Services/GameService.cs](/RukusRummy.BusinessLogic/Services/GameService.cs) | C# | 131 | 1 | 21 | 153 |
| [RukusRummy.BusinessLogic/Services/PlayerService.cs](/RukusRummy.BusinessLogic/Services/PlayerService.cs) | C# | 48 | 0 | 10 | 58 |
| [RukusRummy.Identity/Config.cs](/RukusRummy.Identity/Config.cs) | C# | 40 | 2 | 11 | 53 |
| [RukusRummy.Identity/Data/ApplicationDbContext.cs](/RukusRummy.Identity/Data/ApplicationDbContext.cs) | C# | 15 | 3 | 4 | 22 |
| [RukusRummy.Identity/Data/Migrations/20211227182747_Users.Designer.cs](/RukusRummy.Identity/Data/Migrations/20211227182747_Users.Designer.cs) | C# | 200 | 1 | 67 | 268 |
| [RukusRummy.Identity/Data/Migrations/20211227182747_Users.cs](/RukusRummy.Identity/Data/Migrations/20211227182747_Users.cs) | C# | 197 | 0 | 23 | 220 |
| [RukusRummy.Identity/Data/Migrations/ApplicationDbContextModelSnapshot.cs](/RukusRummy.Identity/Data/Migrations/ApplicationDbContextModelSnapshot.cs) | C# | 198 | 1 | 67 | 266 |
| [RukusRummy.Identity/HostingExtensions.cs](/RukusRummy.Identity/HostingExtensions.cs) | C# | 55 | 4 | 14 | 73 |
| [RukusRummy.Identity/Models/ApplicationUser.cs](/RukusRummy.Identity/Models/ApplicationUser.cs) | C# | 5 | 3 | 5 | 13 |
| [RukusRummy.Identity/Pages/Account/AccessDenied.cshtml](/RukusRummy.Identity/Pages/Account/AccessDenied.cshtml) | ASP.NET Razor | 10 | 0 | 0 | 10 |
| [RukusRummy.Identity/Pages/Account/AccessDenied.cshtml.cs](/RukusRummy.Identity/Pages/Account/AccessDenied.cshtml.cs) | C# | 8 | 0 | 2 | 10 |
| [RukusRummy.Identity/Pages/Account/Login/Index.cshtml](/RukusRummy.Identity/Pages/Account/Login/Index.cshtml) | ASP.NET Razor | 79 | 0 | 10 | 89 |
| [RukusRummy.Identity/Pages/Account/Login/Index.cshtml.cs](/RukusRummy.Identity/Pages/Account/Login/Index.cshtml.cs) | C# | 156 | 17 | 30 | 203 |
| [RukusRummy.Identity/Pages/Account/Login/InputModel.cs](/RukusRummy.Identity/Pages/Account/Login/InputModel.cs) | C# | 12 | 2 | 8 | 22 |
| [RukusRummy.Identity/Pages/Account/Login/LoginOptions.cs](/RukusRummy.Identity/Pages/Account/Login/LoginOptions.cs) | C# | 8 | 0 | 1 | 9 |
| [RukusRummy.Identity/Pages/Account/Login/ViewModel.cs](/RukusRummy.Identity/Pages/Account/Login/ViewModel.cs) | C# | 15 | 2 | 5 | 22 |
| [RukusRummy.Identity/Pages/Account/Logout/Index.cshtml](/RukusRummy.Identity/Pages/Account/Logout/Index.cshtml) | ASP.NET Razor | 14 | 0 | 3 | 17 |
| [RukusRummy.Identity/Pages/Account/Logout/Index.cshtml.cs](/RukusRummy.Identity/Pages/Account/Logout/Index.cshtml.cs) | C# | 68 | 16 | 16 | 100 |
| [RukusRummy.Identity/Pages/Account/Logout/LoggedOut.cshtml](/RukusRummy.Identity/Pages/Account/Logout/LoggedOut.cshtml) | ASP.NET Razor | 26 | 0 | 4 | 30 |
| [RukusRummy.Identity/Pages/Account/Logout/LoggedOut.cshtml.cs](/RukusRummy.Identity/Pages/Account/Logout/LoggedOut.cshtml.cs) | C# | 26 | 1 | 6 | 33 |
| [RukusRummy.Identity/Pages/Account/Logout/LoggedOutViewModel.cs](/RukusRummy.Identity/Pages/Account/Logout/LoggedOutViewModel.cs) | C# | 8 | 2 | 4 | 14 |
| [RukusRummy.Identity/Pages/Account/Logout/LogoutOptions.cs](/RukusRummy.Identity/Pages/Account/Logout/LogoutOptions.cs) | C# | 6 | 0 | 2 | 8 |
| [RukusRummy.Identity/Pages/Ciba/All.cshtml](/RukusRummy.Identity/Pages/Ciba/All.cshtml) | ASP.NET Razor | 47 | 0 | 1 | 48 |
| [RukusRummy.Identity/Pages/Ciba/All.cshtml.cs](/RukusRummy.Identity/Pages/Ciba/All.cshtml.cs) | C# | 26 | 2 | 7 | 35 |
| [RukusRummy.Identity/Pages/Ciba/Consent.cshtml](/RukusRummy.Identity/Pages/Ciba/Consent.cshtml) | ASP.NET Razor | 90 | 0 | 9 | 99 |
| [RukusRummy.Identity/Pages/Ciba/Consent.cshtml.cs](/RukusRummy.Identity/Pages/Ciba/Consent.cshtml.cs) | C# | 183 | 8 | 27 | 218 |
| [RukusRummy.Identity/Pages/Ciba/ConsentOptions.cs](/RukusRummy.Identity/Pages/Ciba/ConsentOptions.cs) | C# | 9 | 2 | 4 | 15 |
| [RukusRummy.Identity/Pages/Ciba/Index.cshtml](/RukusRummy.Identity/Pages/Ciba/Index.cshtml) | ASP.NET Razor | 26 | 0 | 5 | 31 |
| [RukusRummy.Identity/Pages/Ciba/Index.cshtml.cs](/RukusRummy.Identity/Pages/Ciba/Index.cshtml.cs) | C# | 29 | 2 | 7 | 38 |
| [RukusRummy.Identity/Pages/Ciba/InputModel.cs](/RukusRummy.Identity/Pages/Ciba/InputModel.cs) | C# | 8 | 2 | 2 | 12 |
| [RukusRummy.Identity/Pages/Ciba/ViewModel.cs](/RukusRummy.Identity/Pages/Ciba/ViewModel.cs) | C# | 26 | 2 | 6 | 34 |
| [RukusRummy.Identity/Pages/Ciba/_ScopeListItem.cshtml](/RukusRummy.Identity/Pages/Ciba/_ScopeListItem.cshtml) | ASP.NET Razor | 46 | 0 | 1 | 47 |
| [RukusRummy.Identity/Pages/Consent/ConsentOptions.cs](/RukusRummy.Identity/Pages/Consent/ConsentOptions.cs) | C# | 9 | 2 | 4 | 15 |
| [RukusRummy.Identity/Pages/Consent/Index.cshtml](/RukusRummy.Identity/Pages/Consent/Index.cshtml) | ASP.NET Razor | 100 | 0 | 8 | 108 |
| [RukusRummy.Identity/Pages/Consent/Index.cshtml.cs](/RukusRummy.Identity/Pages/Consent/Index.cshtml.cs) | C# | 185 | 11 | 28 | 224 |
| [RukusRummy.Identity/Pages/Consent/InputModel.cs](/RukusRummy.Identity/Pages/Consent/InputModel.cs) | C# | 9 | 2 | 2 | 13 |
| [RukusRummy.Identity/Pages/Consent/ViewModel.cs](/RukusRummy.Identity/Pages/Consent/ViewModel.cs) | C# | 26 | 2 | 5 | 33 |
| [RukusRummy.Identity/Pages/Consent/_ScopeListItem.cshtml](/RukusRummy.Identity/Pages/Consent/_ScopeListItem.cshtml) | ASP.NET Razor | 46 | 0 | 1 | 47 |
| [RukusRummy.Identity/Pages/Device/DeviceOptions.cs](/RukusRummy.Identity/Pages/Device/DeviceOptions.cs) | C# | 10 | 2 | 4 | 16 |
| [RukusRummy.Identity/Pages/Device/Index.cshtml](/RukusRummy.Identity/Pages/Device/Index.cshtml) | ASP.NET Razor | 129 | 2 | 11 | 142 |
| [RukusRummy.Identity/Pages/Device/Index.cshtml.cs](/RukusRummy.Identity/Pages/Device/Index.cshtml.cs) | C# | 174 | 9 | 28 | 211 |
| [RukusRummy.Identity/Pages/Device/InputModel.cs](/RukusRummy.Identity/Pages/Device/InputModel.cs) | C# | 10 | 0 | 1 | 11 |
| [RukusRummy.Identity/Pages/Device/Success.cshtml](/RukusRummy.Identity/Pages/Device/Success.cshtml) | ASP.NET Razor | 10 | 0 | 3 | 13 |
| [RukusRummy.Identity/Pages/Device/Success.cshtml.cs](/RukusRummy.Identity/Pages/Device/Success.cshtml.cs) | C# | 11 | 0 | 2 | 13 |
| [RukusRummy.Identity/Pages/Device/ViewModel.cs](/RukusRummy.Identity/Pages/Device/ViewModel.cs) | C# | 19 | 0 | 3 | 22 |
| [RukusRummy.Identity/Pages/Device/_ScopeListItem.cshtml](/RukusRummy.Identity/Pages/Device/_ScopeListItem.cshtml) | ASP.NET Razor | 34 | 0 | 1 | 35 |
| [RukusRummy.Identity/Pages/Diagnostics/Index.cshtml](/RukusRummy.Identity/Pages/Diagnostics/Index.cshtml) | ASP.NET Razor | 58 | 0 | 3 | 61 |
| [RukusRummy.Identity/Pages/Diagnostics/Index.cshtml.cs](/RukusRummy.Identity/Pages/Diagnostics/Index.cshtml.cs) | C# | 21 | 0 | 5 | 26 |
| [RukusRummy.Identity/Pages/Diagnostics/ViewModel.cs](/RukusRummy.Identity/Pages/Diagnostics/ViewModel.cs) | C# | 21 | 2 | 7 | 30 |
| [RukusRummy.Identity/Pages/Extensions.cs](/RukusRummy.Identity/Pages/Extensions.cs) | C# | 25 | 11 | 7 | 43 |
| [RukusRummy.Identity/Pages/ExternalLogin/Callback.cshtml](/RukusRummy.Identity/Pages/ExternalLogin/Callback.cshtml) | ASP.NET Razor | 15 | 0 | 4 | 19 |
| [RukusRummy.Identity/Pages/ExternalLogin/Callback.cshtml.cs](/RukusRummy.Identity/Pages/ExternalLogin/Callback.cshtml.cs) | C# | 140 | 27 | 28 | 195 |
| [RukusRummy.Identity/Pages/ExternalLogin/Challenge.cshtml](/RukusRummy.Identity/Pages/ExternalLogin/Challenge.cshtml) | ASP.NET Razor | 15 | 0 | 4 | 19 |
| [RukusRummy.Identity/Pages/ExternalLogin/Challenge.cshtml.cs](/RukusRummy.Identity/Pages/ExternalLogin/Challenge.cshtml.cs) | C# | 34 | 3 | 8 | 45 |
| [RukusRummy.Identity/Pages/Grants/Index.cshtml](/RukusRummy.Identity/Pages/Grants/Index.cshtml) | ASP.NET Razor | 86 | 0 | 4 | 90 |
| [RukusRummy.Identity/Pages/Grants/Index.cshtml.cs](/RukusRummy.Identity/Pages/Grants/Index.cshtml.cs) | C# | 68 | 0 | 12 | 80 |
| [RukusRummy.Identity/Pages/Grants/ViewModel.cs](/RukusRummy.Identity/Pages/Grants/ViewModel.cs) | C# | 17 | 0 | 2 | 19 |
| [RukusRummy.Identity/Pages/Home/Error/Index.cshtml](/RukusRummy.Identity/Pages/Home/Error/Index.cshtml) | ASP.NET Razor | 30 | 0 | 6 | 36 |
| [RukusRummy.Identity/Pages/Home/Error/Index.cshtml.cs](/RukusRummy.Identity/Pages/Home/Error/Index.cshtml.cs) | C# | 30 | 2 | 7 | 39 |
| [RukusRummy.Identity/Pages/Home/Error/ViewModel.cs](/RukusRummy.Identity/Pages/Home/Error/ViewModel.cs) | C# | 13 | 2 | 5 | 20 |
| [RukusRummy.Identity/Pages/Index.cshtml](/RukusRummy.Identity/Pages/Index.cshtml) | ASP.NET Razor | 30 | 0 | 3 | 33 |
| [RukusRummy.Identity/Pages/Index.cshtml.cs](/RukusRummy.Identity/Pages/Index.cshtml.cs) | C# | 13 | 0 | 3 | 16 |
| [RukusRummy.Identity/Pages/Redirect/Index.cshtml](/RukusRummy.Identity/Pages/Redirect/Index.cshtml) | ASP.NET Razor | 12 | 0 | 3 | 15 |
| [RukusRummy.Identity/Pages/Redirect/Index.cshtml.cs](/RukusRummy.Identity/Pages/Redirect/Index.cshtml.cs) | C# | 18 | 0 | 4 | 22 |
| [RukusRummy.Identity/Pages/SecurityHeadersAttribute.cs](/RukusRummy.Identity/Pages/SecurityHeadersAttribute.cs) | C# | 35 | 12 | 8 | 55 |
| [RukusRummy.Identity/Pages/Shared/_Layout.cshtml](/RukusRummy.Identity/Pages/Shared/_Layout.cshtml) | ASP.NET Razor | 23 | 0 | 7 | 30 |
| [RukusRummy.Identity/Pages/Shared/_Nav.cshtml](/RukusRummy.Identity/Pages/Shared/_Nav.cshtml) | ASP.NET Razor | 27 | 0 | 6 | 33 |
| [RukusRummy.Identity/Pages/Shared/_ValidationSummary.cshtml](/RukusRummy.Identity/Pages/Shared/_ValidationSummary.cshtml) | ASP.NET Razor | 7 | 0 | 0 | 7 |
| [RukusRummy.Identity/Pages/_ViewImports.cshtml](/RukusRummy.Identity/Pages/_ViewImports.cshtml) | ASP.NET Razor | 2 | 0 | 1 | 3 |
| [RukusRummy.Identity/Pages/_ViewStart.cshtml](/RukusRummy.Identity/Pages/_ViewStart.cshtml) | ASP.NET Razor | 3 | 0 | 1 | 4 |
| [RukusRummy.Identity/Program.cs](/RukusRummy.Identity/Program.cs) | C# | 24 | 18 | 7 | 49 |
| [RukusRummy.Identity/Properties/launchSettings.json](/RukusRummy.Identity/Properties/launchSettings.json) | JSON | 12 | 0 | 0 | 12 |
| [RukusRummy.Identity/RukusRummy.Identity.csproj](/RukusRummy.Identity/RukusRummy.Identity.csproj) | XML | 16 | 0 | 4 | 20 |
| [RukusRummy.Identity/SeedData.cs](/RukusRummy.Identity/SeedData.cs) | C# | 81 | 0 | 7 | 88 |
| [RukusRummy.Identity/appsettings.json](/RukusRummy.Identity/appsettings.json) | JSON | 16 | 0 | 1 | 17 |
| [RukusRummy.Identity/buildschema.bat](/RukusRummy.Identity/buildschema.bat) | Batch | 2 | 0 | 2 | 4 |
| [RukusRummy.Identity/buildschema.sh](/RukusRummy.Identity/buildschema.sh) | Shell Script | 2 | 1 | 3 | 6 |
| [RukusRummy.Identity/wwwroot/css/site.css](/RukusRummy.Identity/wwwroot/css/site.css) | CSS | 34 | 0 | 6 | 40 |
| [RukusRummy.Identity/wwwroot/css/site.min.css](/RukusRummy.Identity/wwwroot/css/site.min.css) | CSS | 1 | 0 | 0 | 1 |
| [RukusRummy.Identity/wwwroot/css/site.scss](/RukusRummy.Identity/wwwroot/css/site.scss) | SCSS | 42 | 0 | 9 | 51 |
| [RukusRummy.Identity/wwwroot/duende-logo.svg](/RukusRummy.Identity/wwwroot/duende-logo.svg) | XML | 1 | 0 | 0 | 1 |
| [RukusRummy.Identity/wwwroot/js/signin-redirect.js](/RukusRummy.Identity/wwwroot/js/signin-redirect.js) | JavaScript | 1 | 0 | 1 | 2 |
| [RukusRummy.Identity/wwwroot/js/signout-redirect.js](/RukusRummy.Identity/wwwroot/js/signout-redirect.js) | JavaScript | 6 | 0 | 1 | 7 |
| [RukusRummy.Identity/wwwroot/lib/bootstrap/README.md](/RukusRummy.Identity/wwwroot/lib/bootstrap/README.md) | Markdown | 144 | 0 | 66 | 210 |
| [RukusRummy.Identity/wwwroot/lib/bootstrap4-glyphicons/css/bootstrap-glyphicons.css](/RukusRummy.Identity/wwwroot/lib/bootstrap4-glyphicons/css/bootstrap-glyphicons.css) | CSS | 803 | 5 | 2 | 810 |
| [RukusRummy.Identity/wwwroot/lib/bootstrap4-glyphicons/css/bootstrap-glyphicons.min.css](/RukusRummy.Identity/wwwroot/lib/bootstrap4-glyphicons/css/bootstrap-glyphicons.min.css) | CSS | 1 | 5 | 0 | 6 |
| [RukusRummy.Identity/wwwroot/lib/bootstrap4-glyphicons/fonts/glyphicons/glyphicons-halflings-regular.svg](/RukusRummy.Identity/wwwroot/lib/bootstrap4-glyphicons/fonts/glyphicons/glyphicons-halflings-regular.svg) | XML | 288 | 0 | 0 | 288 |
| [RukusRummy.Identity/wwwroot/lib/bootstrap4-glyphicons/maps/glyphicons-fontawesome.css](/RukusRummy.Identity/wwwroot/lib/bootstrap4-glyphicons/maps/glyphicons-fontawesome.css) | CSS | 2,945 | 2 | 0 | 2,947 |
| [RukusRummy.Identity/wwwroot/lib/bootstrap4-glyphicons/maps/glyphicons-fontawesome.less](/RukusRummy.Identity/wwwroot/lib/bootstrap4-glyphicons/maps/glyphicons-fontawesome.less) | Less | 3,620 | 2 | 269 | 3,891 |
| [RukusRummy.Identity/wwwroot/lib/bootstrap4-glyphicons/maps/glyphicons-fontawesome.min.css](/RukusRummy.Identity/wwwroot/lib/bootstrap4-glyphicons/maps/glyphicons-fontawesome.min.css) | CSS | 1 | 0 | 0 | 1 |
| [RukusRummy.Identity/wwwroot/lib/jquery/README.md](/RukusRummy.Identity/wwwroot/lib/jquery/README.md) | Markdown | 39 | 0 | 24 | 63 |
| [RukusRummy.Test.Unit/GameService_GetGameAsync.cs](/RukusRummy.Test.Unit/GameService_GetGameAsync.cs) | C# | 49 | 5 | 8 | 62 |
| [RukusRummy.Test.Unit/RukusRummy.Test.Unit.csproj](/RukusRummy.Test.Unit/RukusRummy.Test.Unit.csproj) | XML | 24 | 0 | 6 | 30 |
| [RukusRummy.Test.Unit/Usings.cs](/RukusRummy.Test.Unit/Usings.cs) | C# | 1 | 0 | 0 | 1 |
| [RukusRummy.Web/README.md](/RukusRummy.Web/README.md) | Markdown | 26 | 0 | 21 | 47 |
| [RukusRummy.Web/build/asset-manifest.json](/RukusRummy.Web/build/asset-manifest.json) | JSON | 15 | 0 | 0 | 15 |
| [RukusRummy.Web/build/index.html](/RukusRummy.Web/build/index.html) | HTML | 1 | 0 | 0 | 1 |
| [RukusRummy.Web/build/manifest.json](/RukusRummy.Web/build/manifest.json) | JSON | 25 | 0 | 1 | 26 |
| [RukusRummy.Web/build/static/css/main.e6c13ad2.css](/RukusRummy.Web/build/static/css/main.e6c13ad2.css) | CSS | 1 | 1 | 0 | 2 |
| [RukusRummy.Web/build/static/js/787.ee9b3a7e.chunk.js](/RukusRummy.Web/build/static/js/787.ee9b3a7e.chunk.js) | JavaScript | 1 | 1 | 0 | 2 |
| [RukusRummy.Web/build/static/js/main.e8027a63.js](/RukusRummy.Web/build/static/js/main.e8027a63.js) | JavaScript | 1 | 2 | 0 | 3 |
| [RukusRummy.Web/package-lock.json](/RukusRummy.Web/package-lock.json) | JSON | 19,264 | 0 | 1 | 19,265 |
| [RukusRummy.Web/package.json](/RukusRummy.Web/package.json) | JSON | 54 | 0 | 1 | 55 |
| [RukusRummy.Web/public/index.html](/RukusRummy.Web/public/index.html) | HTML | 20 | 23 | 1 | 44 |
| [RukusRummy.Web/public/manifest.json](/RukusRummy.Web/public/manifest.json) | JSON | 25 | 0 | 1 | 26 |
| [RukusRummy.Web/src/Api/BaseApi.ts](/RukusRummy.Web/src/Api/BaseApi.ts) | TypeScript | 60 | 0 | 16 | 76 |
| [RukusRummy.Web/src/Api/DeckApi.ts](/RukusRummy.Web/src/Api/DeckApi.ts) | TypeScript | 27 | 0 | 7 | 34 |
| [RukusRummy.Web/src/Api/GameApi.ts](/RukusRummy.Web/src/Api/GameApi.ts) | TypeScript | 20 | 0 | 7 | 27 |
| [RukusRummy.Web/src/Api/PlayerApi.ts](/RukusRummy.Web/src/Api/PlayerApi.ts) | TypeScript | 20 | 8 | 6 | 34 |
| [RukusRummy.Web/src/Api/TestApi.ts](/RukusRummy.Web/src/Api/TestApi.ts) | TypeScript | 7 | 0 | 3 | 10 |
| [RukusRummy.Web/src/Components/Buttons/StartNewGameButton.scss](/RukusRummy.Web/src/Components/Buttons/StartNewGameButton.scss) | SCSS | 0 | 0 | 1 | 1 |
| [RukusRummy.Web/src/Components/Buttons/StartNewGameButton.tsx](/RukusRummy.Web/src/Components/Buttons/StartNewGameButton.tsx) | TypeScript JSX | 12 | 0 | 7 | 19 |
| [RukusRummy.Web/src/Components/Dropdown/Dropdown.scss](/RukusRummy.Web/src/Components/Dropdown/Dropdown.scss) | SCSS | 66 | 0 | 12 | 78 |
| [RukusRummy.Web/src/Components/Dropdown/Dropdown.tsx](/RukusRummy.Web/src/Components/Dropdown/Dropdown.tsx) | TypeScript JSX | 48 | 0 | 12 | 60 |
| [RukusRummy.Web/src/Components/Hand/Hand.scss](/RukusRummy.Web/src/Components/Hand/Hand.scss) | SCSS | 57 | 0 | 11 | 68 |
| [RukusRummy.Web/src/Components/Hand/Hand.tsx](/RukusRummy.Web/src/Components/Hand/Hand.tsx) | TypeScript JSX | 54 | 0 | 10 | 64 |
| [RukusRummy.Web/src/Components/Header/CreateGamePageHeader.tsx](/RukusRummy.Web/src/Components/Header/CreateGamePageHeader.tsx) | TypeScript JSX | 8 | 0 | 2 | 10 |
| [RukusRummy.Web/src/Components/Header/Header.scss](/RukusRummy.Web/src/Components/Header/Header.scss) | SCSS | 33 | 2 | 7 | 42 |
| [RukusRummy.Web/src/Components/Header/Header.tsx](/RukusRummy.Web/src/Components/Header/Header.tsx) | TypeScript JSX | 45 | 1 | 8 | 54 |
| [RukusRummy.Web/src/Components/Header/LandingPageHeader.tsx](/RukusRummy.Web/src/Components/Header/LandingPageHeader.tsx) | TypeScript JSX | 7 | 4 | 3 | 14 |
| [RukusRummy.Web/src/Components/Header/SessionPageHeader.tsx](/RukusRummy.Web/src/Components/Header/SessionPageHeader.tsx) | TypeScript JSX | 16 | 5 | 3 | 24 |
| [RukusRummy.Web/src/Components/Layout.scss](/RukusRummy.Web/src/Components/Layout.scss) | SCSS | 11 | 0 | 1 | 12 |
| [RukusRummy.Web/src/Components/Layout.tsx](/RukusRummy.Web/src/Components/Layout.tsx) | TypeScript JSX | 22 | 0 | 6 | 28 |
| [RukusRummy.Web/src/Components/Modal/ChooseYourNameModal.scss](/RukusRummy.Web/src/Components/Modal/ChooseYourNameModal.scss) | SCSS | 10 | 0 | 1 | 11 |
| [RukusRummy.Web/src/Components/Modal/ChooseYourNameModal.tsx](/RukusRummy.Web/src/Components/Modal/ChooseYourNameModal.tsx) | TypeScript JSX | 31 | 6 | 11 | 48 |
| [RukusRummy.Web/src/Components/Modal/CreateACustomDeckModal.scss](/RukusRummy.Web/src/Components/Modal/CreateACustomDeckModal.scss) | SCSS | 15 | 0 | 2 | 17 |
| [RukusRummy.Web/src/Components/Modal/CreateACustomDeckModal.tsx](/RukusRummy.Web/src/Components/Modal/CreateACustomDeckModal.tsx) | TypeScript JSX | 88 | 0 | 15 | 103 |
| [RukusRummy.Web/src/Components/Modal/Modal.scss](/RukusRummy.Web/src/Components/Modal/Modal.scss) | SCSS | 21 | 0 | 1 | 22 |
| [RukusRummy.Web/src/Components/Modal/Modal.tsx](/RukusRummy.Web/src/Components/Modal/Modal.tsx) | TypeScript JSX | 11 | 0 | 2 | 13 |
| [RukusRummy.Web/src/Components/PlayedCard/PlayedCard.scss](/RukusRummy.Web/src/Components/PlayedCard/PlayedCard.scss) | SCSS | 48 | 0 | 4 | 52 |
| [RukusRummy.Web/src/Components/PlayedCard/PlayedCard.tsx](/RukusRummy.Web/src/Components/PlayedCard/PlayedCard.tsx) | TypeScript JSX | 32 | 0 | 10 | 42 |
| [RukusRummy.Web/src/Components/Sections/HeroSection.scss](/RukusRummy.Web/src/Components/Sections/HeroSection.scss) | SCSS | 45 | 2 | 5 | 52 |
| [RukusRummy.Web/src/Components/Sections/HeroSection.tsx](/RukusRummy.Web/src/Components/Sections/HeroSection.tsx) | TypeScript JSX | 24 | 0 | 5 | 29 |
| [RukusRummy.Web/src/Components/Table/Table.scss](/RukusRummy.Web/src/Components/Table/Table.scss) | SCSS | 61 | 1 | 9 | 71 |
| [RukusRummy.Web/src/Components/Table/Table.tsx](/RukusRummy.Web/src/Components/Table/Table.tsx) | TypeScript JSX | 59 | 1 | 12 | 72 |
| [RukusRummy.Web/src/Components/TextInput/TextInput.scss](/RukusRummy.Web/src/Components/TextInput/TextInput.scss) | SCSS | 109 | 2 | 19 | 130 |
| [RukusRummy.Web/src/Components/TextInput/TextInput.tsx](/RukusRummy.Web/src/Components/TextInput/TextInput.tsx) | TypeScript JSX | 34 | 0 | 8 | 42 |
| [RukusRummy.Web/src/Components/Timer/Timer.scss](/RukusRummy.Web/src/Components/Timer/Timer.scss) | SCSS | 36 | 0 | 3 | 39 |
| [RukusRummy.Web/src/Components/Timer/Timer.tsx](/RukusRummy.Web/src/Components/Timer/Timer.tsx) | TypeScript JSX | 10 | 0 | 3 | 13 |
| [RukusRummy.Web/src/Components/Toggle/Toggle.scss](/RukusRummy.Web/src/Components/Toggle/Toggle.scss) | SCSS | 61 | 2 | 10 | 73 |
| [RukusRummy.Web/src/Components/Toggle/Toggle.tsx](/RukusRummy.Web/src/Components/Toggle/Toggle.tsx) | TypeScript JSX | 17 | 0 | 5 | 22 |
| [RukusRummy.Web/src/Contexts/ApiContext.tsx](/RukusRummy.Web/src/Contexts/ApiContext.tsx) | TypeScript JSX | 32 | 0 | 5 | 37 |
| [RukusRummy.Web/src/Contexts/AppContext.tsx](/RukusRummy.Web/src/Contexts/AppContext.tsx) | TypeScript JSX | 79 | 3 | 14 | 96 |
| [RukusRummy.Web/src/Contexts/GameHubContext.tsx](/RukusRummy.Web/src/Contexts/GameHubContext.tsx) | TypeScript JSX | 30 | 0 | 9 | 39 |
| [RukusRummy.Web/src/Models/Deck.ts](/RukusRummy.Web/src/Models/Deck.ts) | TypeScript | 5 | 0 | 0 | 5 |
| [RukusRummy.Web/src/Models/Game.ts](/RukusRummy.Web/src/Models/Game.ts) | TypeScript | 51 | 0 | 8 | 59 |
| [RukusRummy.Web/src/Models/Player.ts](/RukusRummy.Web/src/Models/Player.ts) | TypeScript | 9 | 0 | 2 | 11 |
| [RukusRummy.Web/src/Pages/CreateGame.scss](/RukusRummy.Web/src/Pages/CreateGame.scss) | SCSS | 17 | 0 | 3 | 20 |
| [RukusRummy.Web/src/Pages/CreateGamePage.tsx](/RukusRummy.Web/src/Pages/CreateGamePage.tsx) | TypeScript JSX | 179 | 0 | 22 | 201 |
| [RukusRummy.Web/src/Pages/LandingPage.tsx](/RukusRummy.Web/src/Pages/LandingPage.tsx) | TypeScript JSX | 9 | 0 | 4 | 13 |
| [RukusRummy.Web/src/Pages/SessionPage.scss](/RukusRummy.Web/src/Pages/SessionPage.scss) | SCSS | 26 | 1 | 4 | 31 |
| [RukusRummy.Web/src/Pages/SessionPage.tsx](/RukusRummy.Web/src/Pages/SessionPage.tsx) | TypeScript JSX | 67 | 2 | 14 | 83 |
| [RukusRummy.Web/src/Utilities/StringUtilities.ts](/RukusRummy.Web/src/Utilities/StringUtilities.ts) | TypeScript | 12 | 0 | 3 | 15 |
| [RukusRummy.Web/src/assets/logo-black.svg](/RukusRummy.Web/src/assets/logo-black.svg) | XML | 109 | 1 | 1 | 111 |
| [RukusRummy.Web/src/index.scss](/RukusRummy.Web/src/index.scss) | SCSS | 68 | 0 | 11 | 79 |
| [RukusRummy.Web/src/index.tsx](/RukusRummy.Web/src/index.tsx) | TypeScript JSX | 29 | 6 | 6 | 41 |
| [RukusRummy.Web/src/logo.svg](/RukusRummy.Web/src/logo.svg) | XML | 1 | 0 | 0 | 1 |
| [RukusRummy.Web/src/react-app-env.d.ts](/RukusRummy.Web/src/react-app-env.d.ts) | TypeScript | 0 | 1 | 1 | 2 |
| [RukusRummy.Web/src/reportWebVitals.ts](/RukusRummy.Web/src/reportWebVitals.ts) | TypeScript | 13 | 0 | 3 | 16 |
| [RukusRummy.Web/src/setupTests.ts](/RukusRummy.Web/src/setupTests.ts) | TypeScript | 1 | 4 | 1 | 6 |
| [RukusRummy.Web/src/variables.scss](/RukusRummy.Web/src/variables.scss) | SCSS | 1 | 0 | 0 | 1 |
| [RukusRummy.Web/tsconfig.json](/RukusRummy.Web/tsconfig.json) | JSON with Comments | 26 | 0 | 1 | 27 |
| [nginx.conf](/nginx.conf) | Properties | 41 | 10 | 10 | 61 |
| [supervisord.conf](/supervisord.conf) | Properties | 17 | 8 | 4 | 29 |

[Summary](results.md) / Details / [Diff Summary](diff.md) / [Diff Details](diff-details.md)