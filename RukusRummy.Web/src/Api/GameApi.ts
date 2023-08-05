import BaseApi from "./BaseApi";
import { ICreateGameRequest, IGame } from "../Models/Game";

export default class GameApi extends BaseApi {
    protected apiUrl: string = "/game";

    async create(request: ICreateGameRequest): Promise<string> {
		return await this.postAsync(request);
	}

	async get(id: string): Promise<IGame> {
		return await this.getAsync(null, `/${id}`);
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
