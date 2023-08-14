using AccessControl.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Data;

public class ControleAcessoContex : DbContext
{
    public ControleAcessoContex(DbContextOptions<ControleAcessoContex> opts) : base(opts)
    {
        
    }
    public DbSet<Acesso> Acessos { get; set; }

    public DbSet<Pessoa> Saidas { get; set; }

}
