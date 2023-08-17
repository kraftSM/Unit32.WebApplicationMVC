using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Unit32.WebApplicationMVC.Models
{
    [Table("Requests")]
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}
