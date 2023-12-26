using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ava2Bim.Model;
using MotoBusc.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ava2Bim.Context;

public class    ava2BimContext : IdentityDbContext
{
    public ava2BimContext(DbContextOptions options) : base(options) {}
    public DbSet<Empresa>? Empresas { get; set; }
    public DbSet<Motoqueiro>? Motoqueiros { get; set; }
    public DbSet<Usuario>? Usuarios { get; set; }
    public DbSet<Avaliacao>? Avaliacoes { get; set; }
}
