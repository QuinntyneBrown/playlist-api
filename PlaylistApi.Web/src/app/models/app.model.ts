import { Playlist } from "./playlist.model";

export class App {
    public id: number;
    public name: string;
    public playlists: Array<Playlist> = [];
}