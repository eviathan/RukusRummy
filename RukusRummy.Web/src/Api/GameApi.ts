import BaseApi from "./BaseApi";

export default class GameApi extends BaseApi {
    protected apiUrl: string = "/game";

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
