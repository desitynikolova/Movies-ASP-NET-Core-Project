using Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Director : BaseModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Nationality { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
