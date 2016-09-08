import { Action } from "@ngrx/store";
import { ADD_APP_SUCCESS, GET_APP_SUCCESS, REMOVE_APP_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { App } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const appsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case ADD_APP_SUCCESS:
            var entities: Array<App> = state.apps;
            var entity: App = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { apps: entities });

        case GET_APP_SUCCESS:
            var entities: Array<App> = state.apps;
            var newOrExistingApps: Array<App> = action.payload;
            for (let i = 0; i < newOrExistingApps.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingApps[i] });
            }                                    
            return Object.assign({}, state, { apps: entities });

        case REMOVE_APP_SUCCESS:
            var entities: Array<App> = state.apps;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { apps: entities });

        default:
            return state;
    }
}

