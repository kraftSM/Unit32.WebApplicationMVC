using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.IO;
using Unit32.WebApplicationMVC.Models;
using Unit32.WebApplicationMVC.DL;
using System.Text;

namespace Unit32.WebApplicationMVC.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _repo;
        private readonly bool _logFileNameIsConst = true;//true
        private  bool _logFileNameIsBuilded = false;
        private string _logFileName;
        // Строка для публикации в лог

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IRequestRepository repo)
        {
            _next = next;
            _repo = repo;
            if (_logFileNameIsConst) _logFileName = "RequestLog.txt";
            else _logFileName = "RequestLog[].txt"; 

        }
        private void LogConsole(string logDT, string logURL)
        {
            Console.WriteLine($"[{logDT}]: New request to {logURL}");
        }
        private void buildLogFileName()
        {
            StringBuilder logFileName0 = new StringBuilder();
            logFileName0.Append(_logFileName);
            string fileTimeMark =DateTime.Now.ToString("yyyyMMdd_HHmm");
            logFileName0.Replace("[]", fileTimeMark);
            _logFileName = logFileName0.ToString();

            _logFileNameIsBuilded = true;
            Console.WriteLine($" Log File Name is {_logFileName}");
        }

        private async Task LogFile(string logDT, string logURL )
        {
            if (!_logFileNameIsConst && !_logFileNameIsBuilded)  buildLogFileName();

            string logMessage = $"[{logDT}]: New request to {logURL}{Environment.NewLine}";

            // Путь до лога (опять-таки, используем свойства IWebHostEnvironment)
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "RequestLog.txt");

            // Используем асинхронную запись в файл
            await File.AppendAllTextAsync(logFilePath, logMessage);
        }
      
        private async Task LogDb(DateTime logDate, String logUrl)
        {
            var request = new Request()
            {
                //Id = Guid.NewGuid(),
                Date = logDate,
                Url = logUrl
            };

            await _repo.AddRequest(request);
        }
        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            string logUrlAdress = $"http://{context.Request.Host.Value + context.Request.Path}";
            DateTime logTimeMark = DateTime.Now;

            LogConsole(logTimeMark.ToString(), logUrlAdress);
            //await LogFile(logTimeMark.ToString(), logUrlAdress); // запись в logFile отключена
            await LogDb(logTimeMark, logUrlAdress);
            
            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
