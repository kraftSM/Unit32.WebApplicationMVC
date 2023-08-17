using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Unit32.WebApplicationMVC.Models;

namespace Unit32.WebApplicationMVC.DL
{
    public class BlogRepository : IBlogRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public BlogRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task<User[]> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }
        public async Task AddUser(User user)
        {
            //// Добавим создание нового пользователя
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();

            //var newUser = new User()
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "Andrey",
            //    LastName = "Petrov",
            //    JoinDate = DateTime.Now
            //};

            //// Добавим в базу
            //await _repo.AddUser(newUser);
            // Выведем результат
            //Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} was successfully added on {newUser.JoinDate}");
            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }
        
    }
}
