export interface getpronunciationRequestModel {
    loggedinuserId: string,
    employeeid: string,
    fullName: string,
    country: string,
    voicespeed: string,
    iscustomPronunciationAvailable: boolean,
    isoverrideStandardPronunciation: boolean
};
export interface getpronunciationResponseModel {
    success: boolean,
    custompronunciation: string,
    comments:string
};