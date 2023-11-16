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
    deck: string;
    players: Array<IPlayer>;
    rounds: Array<string>;
    autoReveal: boolean;
    enableFunFeatures: boolean;
    showAverage: boolean;
    autoCloseSessionL: boolean;
    manageIssuesPermission: PlayerPermissionType;
    revealCardsPermission: PlayerPermissionType;
}

export interface IPlayer {
    name: string;
    isSpectator: boolean;
}