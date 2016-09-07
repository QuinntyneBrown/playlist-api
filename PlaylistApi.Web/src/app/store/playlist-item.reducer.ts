import { Action } from "@ngrx/store";
import { ADD_PLAYLIST_ITEM_SUCCESS, GET_PLAYLIST_ITEM_SUCCESS, REMOVE_PLAYLIST_ITEM_SUCCESS } from "../../../constants";
import { initialState } from "../../initial-state";
import { AppState } from "../../app-state";
import { PlaylistItem } from "../../../models";
import { addOrUpdate, pluckOut } from "../../../utilities";

export const playlistItemsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case ADD_PLAYLIST_ITEM_SUCCESS:
            var entities: Array<PlaylistItem> = state.playlistItems;
            var entity: PlaylistItem = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { playlistItems: entities });

        case GET_PLAYLIST_ITEM_SUCCESS:
            var entities: Array<PlaylistItem> = state.playlistItems;
            var newOrExistingPlaylistItems: Array<PlaylistItem> = action.payload;
            for (let i = 0; i < newOrExistingPlaylistItems.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingPlaylistItems[i] });
            }                                    
            return Object.assign({}, state, { playlistItems: entities });

        case REMOVE_PLAYLIST_ITEM_SUCCESS:
            var entities: Array<PlaylistItem> = state.playlistItems;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { playlistItems: entities });

        default:
            return state;
    }
}

