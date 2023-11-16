import IDeck from "./Deck";
import { IPlayer } from "./Player";

export interface ICreateGameRequest {
    name?: string;
    deck?: string;
    revealCardsPermission?: string;
    manageIssuesPermission?: string;
    autoReveal: boolean;
    enableFunFeatures: boolean;
    showAverage: boolean;
}

export interface ICreateDeckRequest {
    name?: string;
    values?: string;
}

export enum PlayerPermissionType {
    AllPlayers,
    JustMe
}

export enum GameStateType {
    RoundActive,
    RoundFinished
}


export interface IGame {
    id: string;
    name: string;
    state: GameStateType;
    deck: IDeck;
    players: Array<IPlayer>;
    rounds: Array<string>;
    autoReveal: boolean;
    enableFunFeatures: boolean;
    showAverage: boolean;
    autoCloseSessionL: boolean;
    manageIssuesPermission: PlayerPermissionType;
    revealCardsPermission: PlayerPermissionType;
}

