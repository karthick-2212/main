using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NPT.Model.RequestModel;
using Microsoft.CognitiveServices.Speech;
using NPT.DataAccess.Repository;
using Microsoft.Extensions.Configuration;

namespace NPT.Controllers
{

    [ApiController]
    public class PronunicationController : ControllerBase
    {

        private IConfiguration Configuration;

        public PronunicationController(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }


        public int Rate { get; set; }

        PronunciationRepository repo = new PronunciationRepository();


        [Route("api/pronunciation/GetStandardPronunciation/v1")]
        [HttpPost]
        public async Task<HttpResponse> GetStandardPronunciation([FromBody] CustomPronunciationRequestModel requestModel)
        {
            string YourSubscriptionKey = Configuration.GetValue<string>("appsettings:AzureSubcriptionKeys:SubscriptionKey"); 
            string YourServiceRegion = Configuration.GetValue<string>("appsettings:AzureSubcriptionKeys:ServiceRegion");

            var speechConfig = SpeechConfig.FromSubscription(YourSubscriptionKey, YourServiceRegion);
            var speechSynthesizer = new SpeechSynthesizer(speechConfig);
            try
            {
                speechConfig.SpeechSynthesisVoiceName = requestModel.Country;

                using (speechSynthesizer = new SpeechSynthesizer(speechConfig))
                {
                    var speechSynthesisResult = await speechSynthesizer.SpeakTextAsync(requestModel.FullName);

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                speechSynthesizer.Dispose();
            }

            return null;

        }

        static void OutputSpeechSynthesisResult(SpeechSynthesisResult speechSynthesisResult, string text)
        {
            switch (speechSynthesisResult.Reason)
            {
                case ResultReason.SynthesizingAudioCompleted:
                    Console.WriteLine($"Speech synthesized for text: [{text}]");
                    break;
                case ResultReason.Canceled:
                    var cancellation = SpeechSynthesisCancellationDetails.FromResult(speechSynthesisResult);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                        Console.WriteLine($"CANCELED: Did you set the speech resource key and region values?");
                    }
                    break;
                default:
                    break;
            }
        }

        [Route("api/pronunciation/GetUserPronunciationDetails/v1")]
        [HttpPost]
        public async Task<ActionResult> GetUserPronunciationDetails([FromBody] UserPronunciationDetailsRequestModel request)
        {
            try
            {
                string Conn = Configuration.GetConnectionString("NPTContextConnection");
                return Ok(await repo.GetUserPronunciationDetails(request, Conn));
            }
            catch (Exception)
            {
                throw;
            }

        }


        [Route("api/pronunciation/SaveCustomPronunciation/v1")]
        [HttpPost]
        public async Task<ActionResult> SaveCustomPronunciation([FromBody] SaveCustomPronunciationRequestModel request)
        {
            try
            {
                string Conn = Configuration.GetConnectionString("NPTContextConnection");
                return Ok(await repo.SaveCustomPronunciation(request, Conn));
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Route("api/pronunciation/GetPronunciation/v1")]
        [HttpPost]
        public async Task<ActionResult> GetPronunciation([FromBody] GetPronunciationRequestmodel request)
        {
            try
            {
                string Conn = Configuration.GetConnectionString("NPTContextConnection");
                return Ok(await repo.GetPronunciation(request, Conn));
            }
            catch (Exception)
            {
                throw;
            }

            

        }

        [Route("api/pronunciation/DeleteCustomPronunciation/v1")]
        [HttpPost]
        public async Task<ActionResult> DeleteCustomPronunciation([FromBody] DeleteCustomPronunciationRequestModel request)
        {
            try
            {
                string Conn = Configuration.GetConnectionString("NPTContextConnection");
                return Ok(await repo.DeleteCustomPronunciation(request,Conn));
            }
            catch (Exception)
            {
                throw;
            }

        }

    }

}
