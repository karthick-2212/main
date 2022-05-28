import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { roleRequestModel, roleResponsemodel} from 'src/app/models/rolemodel'

@Injectable()
export class RoleService{

    url: string = '';
    constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.url = baseUrl;
    }

    GetUserRoles(param:roleRequestModel):Observable<roleResponsemodel>
    {
        var httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        let apiurl = this.url + 'api/role/GetUserRoles/v1'
        return this.httpClient.post<roleResponsemodel>(apiurl, param, httpOptions);
    }
}
