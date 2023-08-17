using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.IO;
using Unit32.WebApplicationMVC.DL;
using Unit32.WebApplicationMVC.Models;

namespace Unit32.WebApplicationMVC.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IBlogRepository _repo;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IBlogRepository repo)
        {
            _next = next;
            _repo = repo;
        }
        private void LogConsole(HttpContext context)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }

        private async Task LogFile(HttpContext context)
        {
            string logFileName = "RequestLog.txt";
            //string logFileName = "RequestLog"+DateTime.Now.ToString("yyyyMMdd_HHmm")+ ".txt";
            // Строка для публикации в лог
            string logMessage = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";

            // Путь до лога (опять-таки, используем свойства IWebHostEnvironment)
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", logFileName);

            // Используем асинхронную запись в файл
            await File.AppendAllTextAsync(logFilePath, logMessage);
        }
        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            //// Добавим создание нового пользователя
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

            // Для логирования данных о запросе используем свойста объекта HttpContext
            //Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
            LogConsole(context);
            await LogFile(context);
            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
