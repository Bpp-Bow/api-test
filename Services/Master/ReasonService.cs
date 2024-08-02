using N_Health_API.Models.Master;
using N_Health_API.ServicesInterfece.Master;

namespace N_Health_API.Services.Master
{
    public class ReasonService : IReasonService
    {
        public bool Add(ReasonModel reason)
        {
            throw new NotImplementedException();
        }

        public bool ChangeActive(int reasonId, bool isActive)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int reasonId)
        {
            throw new NotImplementedException();
        }

        public string DownloadTemplate()
        {
            throw new NotImplementedException();
        }

        public string Export()
        {
            throw new NotImplementedException();
        }

        public bool Import(Stream fileStream)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReasonModel> List()
        {
            throw new NotImplementedException();
        }

        public bool Update(ReasonModel reason)
        {
            throw new NotImplementedException();
        }
    }
}
