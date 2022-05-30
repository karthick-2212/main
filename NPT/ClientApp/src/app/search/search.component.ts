import { Component, OnInit } from '@angular/core';
import { Searchservice } from 'src/app/services/search.servics';
import { Pronunciationservice } from 'src/app/services/pronunciation.service';
import { searchRequestModel, searchResponseModel } from 'src/app/models/searchmodel'
import { GlobalFunctions } from '../Global';
import { getpronunciationRequestModel, getpronunciationResponseModel } from 'src/app/models/getpronunciationmodel';
import { DomSanitizer } from '@angular/platform-browser';
import * as RecordRTC from 'recordrtc';
declare var jQuery: any;
import { saveCustomPronunciationRequestModel, saveCustomPronunciationResponseModel } from 'src/app/models/pronunciationuserDetailsmodel'
import { deleterpronunciationRequestmodel, deleterpronunciationResponseModel } from 'src/app/models/deletepronunciationmodel';
import { standardpronunciationRequestModel } from 'src/app/models/standardpronunciationmodel';
@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {


  constructor(private searchservice: Searchservice, private pronunciationservice: Pronunciationservice, private domSanitizer: DomSanitizer) { }

  public issearchInfoHidden: boolean = false;
  public showSearchresult: boolean = false;
  public audioSource: any;

  public OverrideStandardPronunciation: boolean = true;
  txtcomments: string = '';
  showloader: boolean = false;
  public loggedinUserID: string;
  public isadmin: boolean = false;
  public Isoptedout: boolean = false;
  private record: any;
  public recording: boolean = false;
  public url: any;
  public error: any;
  public selectedcountry: string = "";

  searchrequest: searchRequestModel;
  searchresponse: searchResponseModel;

  getpronunciationrequest: getpronunciationRequestModel;
  getpronunciationresponse: getpronunciationResponseModel;

  saveCustomPronunciationrequest: saveCustomPronunciationRequestModel;
  saveCustomPronunciationresponse: saveCustomPronunciationResponseModel;

  deleterpronunciationrrequest: deleterpronunciationRequestmodel;
  deleterpronunciationresponse: deleterpronunciationResponseModel;

  standardpronunciationrequest: standardpronunciationRequestModel;

  ngOnInit(): void {

    this.loggedinUserID = sessionStorage.getItem('loggedUser');
    this.isadmin = (sessionStorage.getItem('isadmin') == "true") ? true : false;
    this.initvariables();
  }

  search() {
    if (!GlobalFunctions.IsNullorEmpty(this.searchrequest.searchtxt)) {
      this.searchservice.SearchPronunciation(this.searchrequest).subscribe(res => {
        if (res != null && res != undefined) {
          this.searchresponse = res;
          this.Isoptedout = false;
          if (this.searchresponse.optOutPronunciationService) {
            this.Isoptedout = true;
          }
          else {
            this.showSearchresult = true;
            if (res.isCustomPronunciationAvailable && (res.overrideStandardPronunciation || this.isadmin)) {
              this.ViewprocessRecording(this.searchresponse.customPronunciation);
              this.saveCustomPronunciationrequest.customPronunciationVoiceAsBase64 = this.searchresponse.customPronunciation;
            }
          }
        }
      });
    } else {
      alert('Please enter a Valid text to search !')

    }
  }
  sanitize(url: string) {
    return this.domSanitizer.bypassSecurityTrustUrl(url);
  }
  listenStandardPronunciation() {

    this.standardpronunciationrequest =
    {
      employeeID: this.searchresponse.employeeId,
      fullName: this.searchresponse.fullname,
      country: this.selectedcountry,
      voicespeed: "Slow"
    }
    this.pronunciationservice.GetStandardPronunciation(this.standardpronunciationrequest);

  }

  saveProunciationUserDetails() {
    /* AssignValues */

    this.saveCustomPronunciationrequest.loggedinId = this.loggedinUserID;
    this.saveCustomPronunciationrequest.employeeId = this.searchresponse.employeeId;
    this.saveCustomPronunciationrequest.overrideStandardPronunciation = this.OverrideStandardPronunciation;
    if (this.saveCustomPronunciationrequest.isupdate != null) {
      if (this.saveCustomPronunciationrequest.isupdate)
        this.saveCustomPronunciationrequest.isupdate = true;
      else
        this.saveCustomPronunciationrequest.isupdate = false;
    } else
      this.saveCustomPronunciationrequest.isupdate = false;

    this.saveCustomPronunciationrequest.comments = this.txtcomments;
    this.pronunciationservice.SaveProunciationUserDetails(this.saveCustomPronunciationrequest).subscribe(res => {

      this.saveCustomPronunciationresponse = res;
      jQuery("#exampleModalCenter").modal('hide');
      this.showloader = true;
      this.url = '';
      this.search();

    });
  }
  deletePronunciation() {
    if (confirm('Are you sure to Delete ?')) {
      this.deleterpronunciationrrequest = {
        deletingRecordEmployeeId: this.searchresponse.employeeId,
        loggedinUserId: this.loggedinUserID
      }
      this.pronunciationservice.deletePronunciation(this.deleterpronunciationrrequest).subscribe(res => {
        this.deleterpronunciationresponse = res;
        alert('Successfully Deleted !');
        this.showSearchresult = false;
      });
    }
  }

  editPronunciation() {
    this.txtcomments = this.getpronunciationresponse.comments;
    this.OverrideStandardPronunciation = this.searchresponse.overrideStandardPronunciation;
    this.saveCustomPronunciationrequest.isupdate = true;
    jQuery("#exampleModalCenter").modal('show');
  }

  ViewprocessRecording(byte: any) {

    let binary = this.convertDataURIToBinary(byte);
    let blob = new Blob([binary], { type: 'audio/wav' });
    let blobUrl = URL.createObjectURL(blob);
    this.audioSource = blobUrl;
  }


  convertDataURIToBinary(dataURI: any) {
    var raw = window.atob(dataURI);
    var rawLength = raw.length;
    var array = new Uint8Array(new ArrayBuffer(rawLength));

    for (let i = 0; i < rawLength; i++) {
      array[i] = raw.charCodeAt(i);
    }
    return array;
  }

  initvariables() {

    this.searchrequest =
    {
      searchtxt: '',
      lanId: ''
    }

    this.searchresponse =
    {
      loggedinId: '',
      employeeId: '',
      firstname: '',
      lastname: '',
      fullname: '',
      emailAddress: '',
      phone: '',
      managername: '',
      isAdmin: false,
      isCustomPronunciationAvailable: false,
      lastUpdatedDate: null,
      overrideStandardPronunciation: false,
      customPronunciation: '',
      createdby: '',
      comments: '',
      lanid: '',
      optOutPronunciationService: false
    }

    this.getpronunciationresponse = {
      success: false,
      custompronunciation: null,
      comments: ''
    }
    if (this.isadmin) {
      this.saveCustomPronunciationrequest =
      {
        loggedinId: '',
        employeeId: '',
        overrideStandardPronunciation: null,
        customPronunciationVoiceAsBase64: '',
        isupdate: null,
        comments: ''
      }
      this.saveCustomPronunciationresponse =
      {
        success: null,
        customPronunciation: '',
        overrideStandardPronunciation: null,
        comments: ''
      }
    }
  }
  public onOverrideStandardPronunciationoptChanged(val: boolean) {
    this.OverrideStandardPronunciation = val;
  }
  initiateRecording() {
    this.url = '';
    this.recording = true;
    let mediaConstraints = {
      video: false,
      audio: true
    };
    navigator.mediaDevices
      .getUserMedia(mediaConstraints)
      .then(this.successCallback.bind(this), this.errorCallback.bind(this));
  }
  /**
  * Will be called automatically.
  */
  successCallback(stream: any) {
    var options = {
      mimeType: "audio/wav",
      numberOfAudioChannels: 1
    };
    //Start Actuall Recording
    var StereoAudioRecorder = RecordRTC.StereoAudioRecorder;
    this.record = new StereoAudioRecorder(stream, options);
    this.record.record();
  }
  /**
  * Stop recording.
  */
  stopRecording() {
    this.recording = false;
    this.record.stop(this.processRecording.bind(this));
  }
  /**
  * processRecording Do what ever you want with blob
  * @param  {any} blob Blog
  */
  processRecording(blob: any) {
    this.url = URL.createObjectURL(blob);
    this.convertBlobtobyte(blob);
  }

  convertBlobtobyte(blob) {
    var reader = new FileReader();
    reader.readAsDataURL(blob);
    reader.onloadend = () => {
      this.saveCustomPronunciationrequest.customPronunciationVoiceAsBase64 = reader.result.toString();
    };
  }
  /**
  * Process Error.
  */
  errorCallback(error: any) {
    this.error = 'Can not play audio in your browser';
  }
}
