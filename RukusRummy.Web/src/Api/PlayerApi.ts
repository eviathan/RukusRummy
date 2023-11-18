import BaseApi from "./BaseApi";
import { IPlayer } from "../Models/Player";

export default class PlayerApi extends BaseApi {
  protected apiUrl: string = "/player";
  
  async add(request: { gameId: string } & IPlayer): Promise<string> {
    return await this.postAsync(request);
  }

  // ------------------------------------------------------------------------------------
  // TODO: Implment these on the backend to support new player selection workflow
  // NOTE: When calling this from the inital modal we just want to create a new 
  // player but when calling from the modal that pops up in the session page after
  // a game has been created we will also want to call the latter 
  // Might want to deprecate the previous add method
  // ------------------------------------------------------------------------------------
  async createNewPlayer(name: string, isSpectator: boolean): Promise<IPlayer> {
    return await this.postAsync({ name, isSpectator });
  }
  
  async addPlayerToGame(playerId: string, gameId: string): Promise<IPlayer> {
    return await this.getAsync(undefined, `${playerId}/game/${gameId}`);
  }
  // ------------------------------------------------------------------------------------
  
  async getCurrentPlayer(): Promise<IPlayer> {
    return await this.getAsync(undefined, "/current-player");
  }

  async addDeck(request: { playerId: string, deckId: string }): Promise<void> {
    return await this.postAsync(request, "/deck");
  }
}