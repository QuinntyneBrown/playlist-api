import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { PlaylistItemService } from "../services";
import { AppState, AppStore } from "../store";
import { ADD_PLAYLIST_ITEM_SUCCESS, GET_PLAYLIST_ITEM_SUCCESS, REMOVE_PLAYLIST_ITEM_SUCCESS } from "../constants";
import { PlaylistItem } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class PlaylistItemActions {
    constructor(private _playlistItemService: PlaylistItemService, private _store: AppStore) { }

    public add(playlistItem: PlaylistItem) {
        const newGuid = guid();
        this._playlistItemService.add(playlistItem)
            .subscribe(book => {
                this._store.dispatch({
                    type: ADD_PLAYLIST_ITEM_SUCCESS,
                    payload: playlistItem
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._playlistItemService.get()
            .subscribe(playlistItems => {
                this._store.dispatch({
                    type: GET_PLAYLIST_ITEM_SUCCESS,
                    payload: playlistItems
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._playlistItemService.remove({ id: options.id })
            .subscribe(playlistItem => {
                this._store.dispatch({
                    type: REMOVE_PLAYLIST_ITEM_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._playlistItemService.getById({ id: options.id })
            .subscribe(playlistItem => {
                this._store.dispatch({
                    type: GET_PLAYLIST_ITEM_SUCCESS,
                    payload: [playlistItem]
                });
                return true;
            });
    }
}
