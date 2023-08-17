using System.Threading.Tasks;
using Unit32.WebApplicationMVC.Models;

namespace Unit32.WebApplicationMVC.DL
{
    public interface IRequest
    {
        Task AddRequest(Request request);
    }
}
