export default class BaseApi  {

    protected baseUrl: string = process.env.NODE_ENV === "development" 
        ? 'http://localhost:5001/api'
        : '/api';

    protected apiUrl: string = "/";

    private constructApi = (path?: string): string => 
        `${this.baseUrl}${this.apiUrl}${path}`;
        

    protected defaultHeaders = () => ({
        "Accept": "application/json",
        "Content-Type": "application/json"
    });

    protected async getAsync<TPayload, TResponse>(payload: TPayload | undefined = undefined, url: string = ""): Promise<TResponse> {
        const response = await fetch(this.constructApi(url), { 
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
        });

        if (!response.ok) {
            throw new Error(`Api Error: ${url}:\n${JSON.stringify(payload, null, 4)}`);
        }

        return (await response.json()) as TResponse;    
    }
}
