using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Note_example.Database.ModelsDto;

namespace Note_example.Database
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteDto>(entity =>
            {
                entity.HasKey(note => note.Id);
                entity.ToTable("Notes");
            });

            modelBuilder.Entity<NoteDto>()
                .HasOne<AuthorDto>(s => s.Author)
                .WithMany(n => n.Notes)
                .HasForeignKey(s => s.AuthorId);

            modelBuilder.Entity<AuthorDto>(entity =>
            {
                entity.HasKey(author => author.Id);
                entity.ToTable("Authors");
            });

            //feed init data 
            modelBuilder.Entity<AuthorDto>()
                .HasData(
                    new AuthorDto
                    {
                        Id = 1,
                        FirstName = "John",
                        Surname = "Doe"
                    },
                    new AuthorDto
                    {
                        Id = 2,
                        FirstName = "Doe",
                        Surname = "John"

                    });

            modelBuilder.Entity<NoteDto>()
                .HasData(
                    new NoteDto
                    {
                        Id = 1,
                        Title = "Lorem",
                        Text = "Lorem ipsum dolor sit amet",
                        AuthorId = 1
                    },
                    new NoteDto
                    {
                        Id = 2,
                        Title = "Lorem 2",
                        Text = "Lorem ipsum dolor sit amet.",
                        AuthorId = 2
                    });
        }

        public DbSet<NoteDto> Notes { get; set; }
        public DbSet<AuthorDto> Authors { get; set; }
    }
}
