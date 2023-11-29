import IDeck from "../Models/Deck";
import BaseApi from "./BaseApi";

export default class DeckApi extends BaseApi {
	protected apiUrl: string = "/deck";

	async create(name: string, values: string): Promise<IDeck> {
		return await this.postWithResponseAsync({
			name,
			values
		});
	}

	async get(id: string): Promise<string> {
		return await this.getAsync(undefined, `/${id}`);
	}

	async getAll(): Promise<Array<IDeck>> {
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
