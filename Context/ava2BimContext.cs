using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ava2Bim.Model;

namespace ava2Bim.Context;

public class ava2BimContext : DbContext
{
    public ava2BimContext(DbContextOptions options) : base(options) {}
    public DbSet<Empresa>? Alunos { get; set; }
    public DbSet<Motoqueiro>? Cursos { get; set; }
}
