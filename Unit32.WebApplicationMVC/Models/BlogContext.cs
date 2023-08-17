using Microsoft.EntityFrameworkCore;
using Unit32.WebApplicationMVC.DL;

namespace Unit32.WebApplicationMVC.Models
{
    /// <summary>
    /// Класс контекста, предоставляющий доступ к сущностям базы данных
    /// </summary>
    public sealed class BlogContext : DbContext
    {
        // Ссылка на таблицу Users - пользователи       
        public DbSet<User> Users { get; set; }

        // Ссылка на таблицу UserPosts - сообщения пользователей
        public DbSet<UserPost> UserPosts { get; set; }

        // Логика взаимодействия с таблицами в БД - (операции сконтекстом БД при создании приложения)
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

