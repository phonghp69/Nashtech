using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment8.Models
{
    public class PersonModel
    {
         public Guid Id { get;  set; }
        [Required]
        public string Title {get; set;}
        [Required]
        public bool IsCompleted {get; set;}
    }
}