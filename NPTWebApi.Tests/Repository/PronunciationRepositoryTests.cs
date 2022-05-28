using Xunit;
using Moq;
using NPT.DataAccess.Repository;
using NPT.Model.RequestModel;
using NPT.Model.ResponseModel;

namespace NPTWebApi.Tests.Repository
{
    public class PronunciationRepositoryTests
    {
        private MockRepository mockRepository;

        public PronunciationRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private PronunciationRepository CreatePronunciationRepository()
        {
            return new PronunciationRepository();
        }
    }
}
