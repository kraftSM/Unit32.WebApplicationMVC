﻿using Microsoft.EntityFrameworkCore;

namespace Unit32.WebApplicationMVC.Models
{
    /// <summary>
    /// Класс контекста, предоставляющий доступ к сущностям базы данных
    /// </summary>
    public sealed class BlogContext : DbContext
    {
        /// Ссылка на таблицу Users
        public DbSet<User> Users { get; set; }

        /// Ссылка на таблицу UserPosts
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<UserPost> Requests { get; set; }

        // Логика взаимодействия с таблицами в БД
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

