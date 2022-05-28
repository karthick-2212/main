import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { searchRequestModel, searchResponseModel} from 'src/app/models/searchmodel'

@Injectable()
export class Searchservice {

    url: string = '';
    constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.url = baseUrl;
    }

    SearchPronunciation(param:searchRequestModel):Observable<searchResponseModel>
    {
        var httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        let apiurl = this.url + 'api/search/SearchPronunciationDetails/v1'
        return this.httpClient.post<searchResponseModel>(apiurl, param, httpOptions);
    }
}
