import BaseApi from "./BaseApi";

export default class DeckApi extends BaseApi {
	protected apiUrl: string = "/deck";

	async create(name: string, values: string): Promise<string> {
		return await this.postAsync({
			name,
			values
		});
	}

	async get(name: string, values: string): Promise<string> {
		return await this.getAsync({
			name,
			values
		});
	}

	async getAll(name: string, values: string): Promise<string> {
		return await this.getAsync();
	}

	async update(name: string, values: string): Promise<string> {
		return "";
	}

	async delete(name: string, values: string): Promise<string> {
		return "";
	}
}
