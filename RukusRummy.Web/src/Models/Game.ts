import IDeck from "./Deck";
import { IPlayer } from "./Player";

export interface ICreateGameRequest {
    name?: string;
    playerId: string;
    deckId: string;
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
    rounds: Array<IRound>;
    autoReveal: boolean;
    enableFunFeatures: boolean;
    showAverage: boolean;
    autoCloseSessionL: boolean;
    manageIssuesPermission: PlayerPermissionType;
    revealCardsPermission: PlayerPermissionType;
}

export interface IVoteTally {
    [key:string]: number | undefined
}

export interface IRound
{
    name: string;
    result: string;
    startDate: Date;
    endDate: Date;
    votes: IVoteTally;
    voteCount: number;
    average: string;
}