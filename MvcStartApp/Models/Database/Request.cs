using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcStartApp.Models.Database
{
    [Table("Requests")]
    public class Request
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }
}
