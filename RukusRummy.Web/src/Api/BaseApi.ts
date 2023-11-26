import { convertObjectToQueryParams } from "../Utilities/StringUtilities";

export default class BaseApi  {

    protected baseUrl: string = process.env.NODE_ENV === "development" 
        ? 'http://localhost:5001/api'
        : '/api';

    protected apiUrl: string = "/";

    private constructApi = (path?: string, payload?: any): string => {        
        return `${this.baseUrl}${this.apiUrl}${path}${payload ? convertObjectToQueryParams(payload) : ''}`;
    }
        
    protected defaultHeaders = () => ({
        "Accept": "application/json",
        "Content-Type": "application/json"
    });

    private async parseResponse<TResponse>(response: Response): Promise<TResponse> {
        if (!response.ok) {
            throw new Error(`API Error: ${response.url} - ${response.status}`);
        }

        return (await response.json()) as TResponse;
    }

    protected async getAsync<TPayload, TResponse>(payload: TPayload | undefined = undefined, url: string = ""): Promise<TResponse> {
        const response = await fetch(this.constructApi(url, payload), { 
            method: "GET",
            headers: this.defaultHeaders(),
            credentials: "include",
        });

        return this.parseResponse<TResponse>(response);
    }

    protected async postAsync<TPayload>(payload: TPayload | undefined = undefined, url: string = "") {
        await fetch(this.constructApi(url), { 
            method: "POST",
            headers: this.defaultHeaders(),
            credentials: "include",
            body: JSON.stringify(payload)
        });
    }

    protected async postWithResponseAsync<TPayload, TResponse>(payload: TPayload | undefined = undefined, url: string = ""): Promise<TResponse> {
        const response = await fetch(this.constructApi(url), { 
            method: "POST",
            headers: this.defaultHeaders(),
            credentials: "include",
            body: JSON.stringify(payload)
        });

        return this.parseResponse<TResponse>(response);
    }

    protected async putAsync<TPayload>(payload: TPayload | undefined = undefined, url: string = ""): Promise<void> {
        const response = await fetch(this.constructApi(url), { 
            method: "PUT",
            headers: this.defaultHeaders(),
            credentials: "include",
            body: JSON.stringify(payload)
        });
        
        return this.parseResponse<void>(response);
    }

    protected async putWithResponseAsync<TPayload, TResponse>(payload: TPayload | undefined = undefined, url: string = ""): Promise<TResponse> {
        const response = await fetch(this.constructApi(url), { 
            method: "PUT",
            headers: this.defaultHeaders(),
            credentials: "include",
            body: JSON.stringify(payload)
        });
        
        return this.parseResponse<TResponse>(response);
    }

    protected async deleteAsync<TPayload>(payload: TPayload | undefined = undefined, url: string = ""): Promise<void> {
        const response = await fetch(this.constructApi(url, payload), { 
            method: "DELETE",
            headers: this.defaultHeaders(),
            credentials: "include",
        });

        return this.parseResponse<void>(response);  
    }
}
