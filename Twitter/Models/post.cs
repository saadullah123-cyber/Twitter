using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class post
    {
        [Key]
        public int ID { get; set; }
        public string Message { get; set; }
    }
}
