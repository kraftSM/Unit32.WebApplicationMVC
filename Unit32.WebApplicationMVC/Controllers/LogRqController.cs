using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Unit32.WebApplicationMVC.DL;

namespace Unit32.WebApplicationMVC.Controllers
{
    public class LogRqController : Controller
    {
        // ссылка на репозиторий
        private readonly IRequestRepository _repo;

        public LogRqController(IRequestRepository repo)
        {
            _repo = repo;
        }

        // Сделаем метод асинхронным
        public async Task<IActionResult> Index()
        {
            //var requests = await _repo.GetRequest();
            //return View(requests);
            return View();

        }
    }
}
