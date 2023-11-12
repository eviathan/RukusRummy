export interface ICreateGameRequest {
    name?: string;
    deck?: string;
    revealCardsPermission?: string;
    manageIssuesPermission?: string;
    autoReveal: boolean;
    enableFunFeatures: boolean;
    showAverage: boolean;
}

export enum PlayerPermissionType {
    AllPlayers,
    JustMe
}

export interface IGame {
    id: string;
    name: string;
    deck: string;
    players: Array<string>;
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