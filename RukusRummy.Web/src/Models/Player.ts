import IDeck from "./Deck";

export interface IPlayer {
    id: string;
    name: string;
    isSpectator: boolean;
}

export interface IPlayerPreferencesCache {
    decks: Array<IDeck>;
}