using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityTypeConfigurations
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey(tcm => new { tcm.MovieId, tcm.GenreId });

            builder.HasOne(tcm => tcm.Movie)
                .WithMany(t => t.MovieGenres)
                .HasForeignKey(tcm => tcm.MovieId);

            builder.HasOne(tcm => tcm.Genre)
                .WithMany(tc => tc.MovieGenres)
                .HasForeignKey(tcm => tcm.GenreId);
        }
    }
}

