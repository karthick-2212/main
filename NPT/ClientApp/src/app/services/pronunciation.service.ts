import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { standardpronunciationRequestModel } from 'src/app/models/standardpronunciationmodel';
import { pronunciationUserDetailRequestModel, pronunciationUserDetailResponseModel, saveCustomPronunciationRequestModel, saveCustomPronunciationResponseModel } from 'src/app/models/pronunciationuserDetailsmodel'
import { getpronunciationRequestModel, getpronunciationResponseModel } from 'src/app/models/getpronunciationmodel'
import { deleterpronunciationRequestmodel, deleterpronunciationResponseModel } from 'src/app/models/deletepronunciationmodel';
import { optoutRequestModel, optoutResponseModel } from 'src/app/models/optoutpronunciationmodel';
@Injectable()
export class Pronunciationservice {

    url: string = '';
    constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.url = baseUrl;
    }

    GetStandardPronunciation(param: standardpronunciationRequestModel) {
        var httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        let apiurl = this.url + 'api/pronunciation/GetStandardPronunciation/v1'
        return this.httpClient.post<any>(apiurl, param, httpOptions).subscribe({
            next: data => {
                console.log(data);
            },
            error: error => {
                console.error('There was an error!', error);
            }
        })
    }

    GetProunciationUserDetails(param: pronunciationUserDetailRequestModel): Observable<pronunciationUserDetailResponseModel> {
        var httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        let apiurl = this.url + 'api/pronunciation/GetUserPronunciationDetails/v1'
        return this.httpClient.post<pronunciationUserDetailResponseModel>(apiurl, param, httpOptions);
    }

    SaveProunciationUserDetails(param: saveCustomPronunciationRequestModel): Observable<saveCustomPronunciationResponseModel> {
        var httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        let apiurl = this.url + 'api/pronunciation/SaveCustomPronunciation/v1'
        return this.httpClient.post<saveCustomPronunciationResponseModel>(apiurl, param, httpOptions);
    }

    getPronunciation(param: getpronunciationRequestModel): Observable<getpronunciationResponseModel> {
        var httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        let apiurl = this.url + 'api/pronunciation/GetPronunciation/v1'
        return this.httpClient.post<getpronunciationResponseModel>(apiurl, param, httpOptions);
    }

    deletePronunciation(param: deleterpronunciationRequestmodel): Observable<deleterpronunciationResponseModel> {
        var httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        let apiurl = this.url + 'api/pronunciation/DeleteCustomPronunciation/v1'
        return this.httpClient.post<deleterpronunciationResponseModel>(apiurl, param, httpOptions);
    }

    optoutfromPronunciation(param: optoutRequestModel): Observable<optoutResponseModel> {
        var httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        let apiurl = this.url + 'api/pronunciation/OptOutPronunciation/v1'
        return this.httpClient.post<optoutResponseModel>(apiurl, param, httpOptions);
    }
}
