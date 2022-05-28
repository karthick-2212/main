using System;
using System.Collections.Generic;
using System.Text;
using NPT.Model.RequestModel;
using NPT.Model.ResponseModel;
using System.Threading.Tasks;

namespace NPT.DataAccess.Interfaces
{
    public interface ISearchRepository
    {
          Task<SearchResponseModel> SearchPronunciationDetails(SearchRequestModel request,string Conn);
    }
}
