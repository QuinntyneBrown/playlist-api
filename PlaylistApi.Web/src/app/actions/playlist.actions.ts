import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { PlaylistService } from "../services";
import { AppState, AppStore } from "../store";
import { ADD_PLAYLIST_SUCCESS, GET_PLAYLIST_SUCCESS, REMOVE_PLAYLIST_SUCCESS } from "../constants";
import { Playlist } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class PlaylistActions {
    constructor(private _playlistService: PlaylistService, private _store: AppStore) { }

    public add(playlist: Playlist) {
        const newGuid = guid();
        this._playlistService.add(playlist)
            .subscribe(book => {
                this._store.dispatch({
                    type: ADD_PLAYLIST_SUCCESS,
                    payload: playlist
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._playlistService.get()
            .subscribe(playlists => {
                this._store.dispatch({
                    type: GET_PLAYLIST_SUCCESS,
                    payload: playlists
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._playlistService.remove({ id: options.id })
            .subscribe(playlist => {
                this._store.dispatch({
                    type: REMOVE_PLAYLIST_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._playlistService.getById({ id: options.id })
            .subscribe(playlist => {
                this._store.dispatch({
                    type: GET_PLAYLIST_SUCCESS,
                    payload: [playlist]
                });
                return true;
            });
    }
}
