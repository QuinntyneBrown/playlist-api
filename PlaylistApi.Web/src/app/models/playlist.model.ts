import { PlaylistItem } from "./playlist-item.model";

export class Playlist {
    public id: number;
    public name: string;
    public playlistItems: Array<PlaylistItem> = [];
}