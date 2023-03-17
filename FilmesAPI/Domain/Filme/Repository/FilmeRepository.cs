using FilmesApi.Domain.Filme.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class FilmeRepository : DbContext
{
    public FilmeRepository(DbContextOptions<FilmeRepository> opts) : base(opts)
    {

    }

    public DbSet<FilmeEntity> Filmes { get; set; }
}
