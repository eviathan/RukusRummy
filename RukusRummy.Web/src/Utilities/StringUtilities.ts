interface QueryParams {
    [key: string]: string | number | boolean | null | undefined;
}

export function convertObjectToQueryParams(obj: QueryParams): string {
    let queryParams: string[] = [];

    for (const [key, value] of Object.entries(obj)) {
        if (value !== null && value !== undefined) {
            queryParams.push(`${encodeURIComponent(key)}=${encodeURIComponent(value.toString())}`);
        }
    }

    return queryParams.length ? `?${queryParams.join('&')}` : '';
}