using MovieModels.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieModels
{
    public class Director : BaseModel
    {
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
