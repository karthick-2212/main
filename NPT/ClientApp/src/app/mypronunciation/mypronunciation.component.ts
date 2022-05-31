import { Component, OnInit } from '@angular/core';
import * as RecordRTC from 'recordrtc';
import { DomSanitizer } from '@angular/platform-browser';
import { Pronunciationservice } from 'src/app/services/pronunciation.service';
import { standardpronunciationRequestModel } from 'src/app/models/standardpronunciationmodel';
import { pronunciationUserDetailRequestModel, pronunciationUserDetailResponseModel, saveCustomPronunciationRequestModel, saveCustomPronunciationResponseModel } from 'src/app/models/pronunciationuserDetailsmodel'
import { deleterpronunciationRequestmodel, deleterpronunciationResponseModel } from 'src/app/models/deletepronunciationmodel';
import { optoutRequestModel, optoutResponseModel } from 'src/app/models/optoutpronunciationmodel';
declare var jQuery: any;
import { GlobalFunctions } from '../Global';

@Component({
  selector: 'app-mypronunciation',
  templateUrl: './mypronunciation.component.html',
  styleUrls: ['./mypronunciation.component.css']
})

export class MypronunciationComponent implements OnInit {
  private record: any;
  public recording: boolean = false;
  public url: any;
  public error: any;
  public ismyInfoHidden: boolean = false;
  public ispronunciationHidden: boolean = false;
  public isstandardpronunciationHidden: boolean = false;
  public loggedinUserID: string;

  standardpronunciation: any;
  standardpronunciationrequest: standardpronunciationRequestModel;
  pronunciationUserDetailrequest: pronunciationUserDetailRequestModel;
  pronunciationUserDetailresponse: pronunciationUserDetailResponseModel;

  saveCustomPronunciationrequest: saveCustomPronunciationRequestModel;
  saveCustomPronunciationresponse: saveCustomPronunciationResponseModel;

  deleterpronunciationrrequest: deleterpronunciationRequestmodel;
  deleterpronunciationresponse: deleterpronunciationResponseModel;

  optoutrequest: optoutRequestModel;
  optoutresponse: optoutResponseModel;

  selectedcountry: string = "";
  selectedvoicespeed: string = "Slow";
  txtcomments: string = '';
  OverrideStandardPronunciation: boolean = true;
  optoutpronunciationservice: boolean = false;
  showloader: boolean = false;
  audioSource: string = '';
  constructor(private domSanitizer: DomSanitizer, private pronunciationservice: Pronunciationservice) { }

  ngOnInit() {

    this.loggedinUserID = sessionStorage.getItem('loggedUser');
    this.showloader = true;
    this.initvariables();
    this.getProunciationUserDetails();
  }
  initvariables() {
    this.pronunciationUserDetailresponse =
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
      customPronunciation: '',
      lastUpdatedDate: null,
      createdby: '',
      comments: '',
      overrideStandardPronunciation: true,
      lanid: '',
      optOutPronunciationService: false
    }
    this.saveCustomPronunciationrequest =
    {
      loggedinId: '',
      employeeId: '',
      overrideStandardPronunciation: null,
      customPronunciationVoiceAsBase64: '',
      isupdate: false,
      comments: '',
      optOutPronunciationService: false

    }
    this.saveCustomPronunciationresponse =
    {
      success: null,
      customPronunciation: '',
      overrideStandardPronunciation: null,
      comments: '',
    }
  }
  public onOverrideStandardPronunciationoptChanged(val: boolean) {
    this.OverrideStandardPronunciation = val;
  }

  getProunciationUserDetails() {

    this.pronunciationUserDetailrequest = {
      loggedinId: this.loggedinUserID
    }
    this.pronunciationservice.GetProunciationUserDetails(this.pronunciationUserDetailrequest).subscribe(res => {
      this.pronunciationUserDetailresponse = res;
      this.optoutpronunciationservice = this.pronunciationUserDetailresponse.optOutPronunciationService;
      this.showloader = false;
      if (this.pronunciationUserDetailresponse.isCustomPronunciationAvailable) {
        this.ViewprocessRecording(this.pronunciationUserDetailresponse.customPronunciation);
        this.saveCustomPronunciationrequest.customPronunciationVoiceAsBase64 = "data:audio/wav;base64," + this.pronunciationUserDetailresponse.customPronunciation;
      }
    });
  }
  getStandardPronunciation() {
    this.standardpronunciationrequest =
    {
      employeeID: this.pronunciationUserDetailresponse.employeeId,
      fullName: this.pronunciationUserDetailresponse.fullname,
      country: this.selectedcountry,
      voicespeed: this.selectedvoicespeed
    }
    this.standardpronunciation = this.pronunciationservice.GetStandardPronunciation(this.standardpronunciationrequest);
  }

  editPronunciation() {
    this.txtcomments = this.pronunciationUserDetailresponse.comments;
    this.OverrideStandardPronunciation = this.pronunciationUserDetailresponse.overrideStandardPronunciation;
    this.saveCustomPronunciationrequest.isupdate = true;
    jQuery("#exampleModalCenter").modal('show');
  }
  saveProunciationUserDetails() {
    /* AssignValues */

    this.saveCustomPronunciationrequest.loggedinId = this.loggedinUserID;
    this.saveCustomPronunciationrequest.employeeId = this.pronunciationUserDetailresponse.employeeId;
    this.saveCustomPronunciationrequest.overrideStandardPronunciation = this.OverrideStandardPronunciation;
    this.saveCustomPronunciationrequest.optOutPronunciationService = this.optoutpronunciationservice;
    if (!this.saveCustomPronunciationrequest.isupdate && this.optoutpronunciationservice == null) {
      this.saveCustomPronunciationrequest.isupdate = false;
    }
    else
      this.saveCustomPronunciationrequest.isupdate = true;
    this.saveCustomPronunciationrequest.comments = this.txtcomments;
    if (!GlobalFunctions.IsNullorEmpty(this.saveCustomPronunciationrequest.customPronunciationVoiceAsBase64)) {
      this.pronunciationservice.SaveProunciationUserDetails(this.saveCustomPronunciationrequest).subscribe(res => {

        this.saveCustomPronunciationresponse = res;
        jQuery("#exampleModalCenter").modal('hide');
        this.showloader = true;
        this.getProunciationUserDetails();
        this.url = '';
      });
    }
    else {
      alert('Please record the Pronunciation.')
    }
  }

  deletePronunciation() {
    if (confirm('Are you sure to Delete ?')) {
      this.deleterpronunciationrrequest = {
        deletingRecordEmployeeId: this.pronunciationUserDetailresponse.employeeId,
        loggedinUserId: this.loggedinUserID
      }
      this.pronunciationservice.deletePronunciation(this.deleterpronunciationrrequest).subscribe(res => {
        this.deleterpronunciationresponse = res;
        this.showloader = true;
        this.getProunciationUserDetails();
      });
    }
  }

  optoutfrompronunciationchange(val: any) {
    this.optoutrequest =
    {
      isoptedout: val.checked,
      loggedinuserId: this.loggedinUserID,
      employeeid: this.pronunciationUserDetailresponse.employeeId
    }
    if (val.checked == true) {
      if (confirm('Are you sure to Opt out of Pronunciation Service ?')) {
        this.pronunciationservice.optoutfromPronunciation(this.optoutrequest).subscribe(res => {
          this.optoutresponse = res;
        });
      }
    }
    else if (val.checked == false) {
      if (confirm('Are you sure to disable from  Opt Out Pronunciation Service ?')) {
        this.pronunciationservice.optoutfromPronunciation(this.optoutrequest).subscribe(res => {
          this.optoutresponse = res;
        });
      }
    }

  }

  sanitize(url: string) {
    return this.domSanitizer.bypassSecurityTrustUrl(url);
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
}
