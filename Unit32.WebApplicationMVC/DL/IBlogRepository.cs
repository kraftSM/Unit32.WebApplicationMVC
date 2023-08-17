using System.Threading.Tasks;
using Unit32.WebApplicationMVC.Models;

namespace Unit32.WebApplicationMVC.DL
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
    }
}
