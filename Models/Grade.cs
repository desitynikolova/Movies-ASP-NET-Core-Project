using Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Grade : BaseModel
    {
        public double Score { get; set; }
        public string Comment { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
