using MovieModels.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieModels
{
    public class Genre : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
