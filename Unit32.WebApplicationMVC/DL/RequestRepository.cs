using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Unit32.WebApplicationMVC.Models;
//using Unit32.WebApplicationMVC.DL.LoggingRepository;


namespace Unit32.WebApplicationMVC.DL
{
    public class RequestRepository : IRequestRepository
    {
        // ссылка на контекст
        private BlogContext _сontext;
        public RequestRepository(BlogContext loggingContext)
        {
            _сontext = loggingContext;
        }

              

        public async Task<Request[]> GetRequest()
        {
            var request = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = "test"
            };
            return await _сontext.Request.ToArrayAsync();

        }
        public async Task AddRequest(Request request)
        {
            ////// Добавим создание нового пользователя
            //request.Date = DateTime.Now;
            request.Id = Guid.NewGuid();
            //request.Url = "TestURL";
            ////request.Url = _context.Host.Value + _context.Path;



            var rq = _сontext.Entry(request);
            if (rq.State == EntityState.Detached)
                await _сontext.Request.AddAsync(request);

            // Сохранение изенений
            await _сontext.SaveChangesAsync();
        }


    }
}
