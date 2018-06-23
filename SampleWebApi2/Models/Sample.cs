using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_CRUD.Models
{
    public class Sample
    {
        [Required]
        public string Id { get; set; }       
        public int ApplicationId { get; set; }
        public string Type { get; set; }
        public string Summery { get; set; }
        public decimal Amount { get; set; }
        public DateTime PostingDate { get; set; }
        public bool IsCleared { get; set; }
        public DateTime ClearedDate { get; set; }

    }
}