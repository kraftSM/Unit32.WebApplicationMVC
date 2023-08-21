using Microsoft.AspNetCore.Mvc;
using System;
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
            //Console.WriteLine($"LogRqController : _repo.GetRequest();");            
            var requests = await _repo.GetRequest();
            //Console.WriteLine($"LogRqController : _repo.GetRequest() equests.Length=" + requests.Length);
            return View(requests);
            //return View();

        }
    }
}
