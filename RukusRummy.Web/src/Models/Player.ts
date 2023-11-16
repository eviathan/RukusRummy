import IDeck from "./Deck";

export interface IPlayer {
    name: string;
    isSpectator: boolean;
}

export interface IPlayerPreferencesCache {
    decks: Array<IDeck>;
}