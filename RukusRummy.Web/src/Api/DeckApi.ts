import BaseApi from "./BaseApi";

export default class DeckApi extends BaseApi {
	protected apiUrl: string = "/deck";

	async create(name: string, values: string): Promise<string> {
		return await this.postAsync({
			name,
			values
		});
	}

	async get(id: string): Promise<string> {
		return await this.getAsync(null, `/${id}`);
	}

	async getAll(): Promise<string> {
		return await this.getAsync();
	}

	async update(id: string, name: string, values: string): Promise<void> {
		await this.putAsync({
            id,
            name,
            values
        });
	}

	async delete(id: string): Promise<void> {
        await this.deleteAsync({ id })
	}
}
