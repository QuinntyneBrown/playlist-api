import { Action } from "@ngrx/store";
import { ADD_PLAYLIST_SUCCESS, GET_PLAYLIST_SUCCESS, REMOVE_PLAYLIST_SUCCESS } from "../../../constants";
import { initialState } from "../../initial-state";
import { AppState } from "../../app-state";
import { Playlist } from "../../../models";
import { addOrUpdate, pluckOut } from "../../../utilities";

export const playlistsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case ADD_PLAYLIST_SUCCESS:
            var entities: Array<Playlist> = state.playlists;
            var entity: Playlist = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { playlists: entities });

        case GET_PLAYLIST_SUCCESS:
            var entities: Array<Playlist> = state.playlists;
            var newOrExistingPlaylists: Array<Playlist> = action.payload;
            for (let i = 0; i < newOrExistingPlaylists.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingPlaylists[i] });
            }                                    
            return Object.assign({}, state, { playlists: entities });

        case REMOVE_PLAYLIST_SUCCESS:
            var entities: Array<Playlist> = state.playlists;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { playlists: entities });

        default:
            return state;
    }
}

