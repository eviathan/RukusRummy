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

    protected async getAsync<TPayload, TResponse>(payload: TPayload | undefined = undefined, url: string = ""): Promise<TResponse> {
        const response = await fetch(this.constructApi(url, payload), { 
            method: "GET",
            headers: this.defaultHeaders(),
            credentials: "same-origin", 
        });

        if (!response.ok) {
            throw new Error(`Api Error: ${url}:\n${JSON.stringify(payload, null, 4)}`);
        }
        return (await response.json()) as TResponse;    
    }

    protected async postAsync<TPayload, TResponse>(payload: TPayload | undefined = undefined, url: string = ""): Promise<TResponse> {
        const response = await fetch(this.constructApi(url), { 
            method: "POST",
            headers: this.defaultHeaders(),
            credentials: "same-origin",
            body: JSON.stringify(payload)
        });

        if (!response.ok) {
            throw new Error(`Api Error: ${url}:\n${JSON.stringify(payload, null, 4)}`);
        }

        return (await response.json()) as TResponse;    
    }

    protected async putAsync<TPayload, TResponse>(payload: TPayload | undefined = undefined, url: string = ""): Promise<TResponse> {
        const response = await fetch(this.constructApi(url), { 
            method: "PUT",
            headers: this.defaultHeaders(),
            credentials: "same-origin",
            body: JSON.stringify(payload)
        });

        if (!response.ok) {
            throw new Error(`Api Error: ${url}:\n${JSON.stringify(payload, null, 4)}`);
        }

        return (await response.json()) as TResponse;    
    }

    protected async deleteAsync<TPayload, TResponse>(payload: TPayload | undefined = undefined, url: string = ""): Promise<TResponse> {
        const response = await fetch(this.constructApi(url, payload), { 
            method: "DELETE",
            headers: this.defaultHeaders(),
            credentials: "same-origin", 
        });

        if (!response.ok) {
            throw new Error(`Api Error: ${url}:\n${JSON.stringify(payload, null, 4)}`);
        }
        return (await response.json()) as TResponse;    
    }
}
