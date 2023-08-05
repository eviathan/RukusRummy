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
    name: string;
    deck: string;
    players: Array<string>;
    rounds: Array<string>;
    autoReveal: boolean;
    enableFunFeatures: boolean;
    manageIssuesPermission: PlayerPermissionType;
    revealCardsPermission: PlayerPermissionType;
}