import BaseApi from "./BaseApi";
import { IPlayer } from "../Models/Player";

export default class PlayerApi extends BaseApi {
  protected apiUrl: string = "/player";
  
  async add(request: { gameId: string } & IPlayer): Promise<string> {
    return await this.postWithResponseAsync(request);
  }

  async createNewPlayer(name: string, isSpectator: boolean): Promise<IPlayer> {
    return await this.postWithResponseAsync({ name, isSpectator });
  }
  
  async addPlayerToGame(playerId: string, gameId: string): Promise<string> {
    return await this.postWithResponseAsync(undefined, `/${playerId}/game/${gameId}`);
  }
  
  async getCurrentPlayer(): Promise<IPlayer> {
    return await this.getAsync(undefined, "/current-player");
  }

  async addDeck(request: { playerId: string, deckId: string }): Promise<void> {
    return await this.postWithResponseAsync(request, "/deck");
  }
}