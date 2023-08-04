import BaseApi from "./BaseApi";

export default class TestApi extends BaseApi {
	protected apiUrl: string = "/test";

	async get(): Promise<string> {
		return await this.getAsync();
	}
}
