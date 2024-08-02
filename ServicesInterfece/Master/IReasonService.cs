using N_Health_API.Models.Master;

namespace N_Health_API.ServicesInterfece.Master
{
    public interface IReasonService
    {
        IEnumerable<ReasonModel> List();
        bool Add(ReasonModel reason);
        bool Update(ReasonModel reason);
        bool Delete(int reasonId);
        bool ChangeActive(int reasonId, bool isActive);
        string DownloadTemplate();
        string Export();
        bool Import(Stream fileStream);

    }
}
