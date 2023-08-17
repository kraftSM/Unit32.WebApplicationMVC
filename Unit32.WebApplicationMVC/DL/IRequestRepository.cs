using System.Threading.Tasks;
using Unit32.WebApplicationMVC.Models;

namespace Unit32.WebApplicationMVC.DL
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequest();
    }
}
