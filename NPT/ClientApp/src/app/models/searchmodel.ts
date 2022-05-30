export interface searchRequestModel
{
    searchtxt:string,
    lanId:string
};

export interface searchResponseModel
{
    loggedinId:string,
    employeeId:string,
    firstname:string,
    lastname:string,
    fullname:string,
    emailAddress:string,
    phone:string,
    managername:string,
    isAdmin:boolean,
    isCustomPronunciationAvailable:boolean,
    lastUpdatedDate:Date,
    customPronunciation: string,
    createdby:string,
    overrideStandardPronunciation:boolean,
    comments:string,
    lanid:string,
    optOutPronunciationService:boolean
    //CustomPronunciation:BinaryType[]
};