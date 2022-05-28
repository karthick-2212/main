export interface pronunciationUserDetailRequestModel {
    loggedinId: string,
};

export interface pronunciationUserDetailResponseModel {
    loggedinId: string,
    employeeId: string,
    firstname: string,
    lastname: string,
    fullname: string,
    emailAddress: string,
    phone: string,
    managername: string,
    isAdmin: boolean,
    isCustomPronunciationAvailable: boolean,
    customPronunciation: string,
    lastUpdatedDate: Date,
    createdby:string,
    overrideStandardPronunciation:boolean,
    comments:string,
    lanid:string
};

export interface saveCustomPronunciationRequestModel {
    loggedinId: string,
    employeeId: string,
    customPronunciationVoiceAsBase64: string,
    overrideStandardPronunciation: boolean,
    comments: string,
    isupdate:boolean
}
export interface saveCustomPronunciationResponseModel {
    success: boolean,
    customPronunciation: string,
    overrideStandardPronunciation: boolean,
    comments: string
}