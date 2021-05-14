using Models.Abstractions;
using System.Collections.Generic;

namespace Models
{
    public class Movie : BaseModel
    { 
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        // 1 to Many
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        // 1 to Many
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        // Many To Many
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
