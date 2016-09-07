import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { AppService } from "../services";
import { AppState, AppStore } from "../store";
import { ADD_APP_SUCCESS, GET_APP_SUCCESS, REMOVE_APP_SUCCESS } from "../constants";
import { App } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class AppActions {
    constructor(private _appService: AppService, private _store: AppStore) { }

    public add(app: App) {
        const newGuid = guid();
        this._appService.add(app)
            .subscribe(book => {
                this._store.dispatch({
                    type: ADD_APP_SUCCESS,
                    payload: app
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._appService.get()
            .subscribe(apps => {
                this._store.dispatch({
                    type: GET_APP_SUCCESS,
                    payload: apps
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._appService.remove({ id: options.id })
            .subscribe(app => {
                this._store.dispatch({
                    type: REMOVE_APP_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._appService.getById({ id: options.id })
            .subscribe(app => {
                this._store.dispatch({
                    type: GET_APP_SUCCESS,
                    payload: [app]
                });
                return true;
            });
    }
}
