import IDeck from "./Deck";

export interface IPlayer {
    id: string;
    name: string;
    isSpectator: boolean;
    decks: Array<IDeck>;
}

export interface IPlayerPreferencesCache {
    decks: Array<IDeck>;
}