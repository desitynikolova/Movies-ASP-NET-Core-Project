using Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Grade : BaseModel
    {
        [Range(0, 5)]
        [Required]
        public double Score { get; set; }
        [Required]
        public string Comment { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
