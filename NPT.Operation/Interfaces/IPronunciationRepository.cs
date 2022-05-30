using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NPT.Model.RequestModel;
using NPT.Model.ResponseModel;

namespace NPT.DataAccess.Interfaces
{
    public interface IPronunciationRepository
    {
        Task<UserPronunciationDetailsResponseModel> GetUserPronunciationDetails(UserPronunciationDetailsRequestModel request,string conn);

        Task<SaveCustomPronunciationResponseModel> SaveCustomPronunciation(SaveCustomPronunciationRequestModel request,string conn);

        Task<DeleteCustomPronunciationResponseModel> DeleteCustomPronunciation(DeleteCustomPronunciationRequestModel request,string conn);

        Task<OptOutResponseModel> OptOutfromPronunciationservice(OptOutRequestModel request, string strConnString);
    }
}
