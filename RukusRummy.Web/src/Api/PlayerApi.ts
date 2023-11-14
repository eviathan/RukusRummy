import BaseApi from "./BaseApi";
import { IPlayer } from "../Models/Game";

export default class PlayerApi extends BaseApi {
    protected apiUrl: string = "/player";

    async add(request: { gameId: string } & IPlayer): Promise<string> {
      return await this.postAsync(request);
    }

    async getCurrentPlayer(): Promise<IPlayer> {
      return await this.getAsync(undefined,"/current-player");
    }
}