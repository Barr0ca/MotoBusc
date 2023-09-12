using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ava2Bim.Model;

public class Empresa
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Numero { get; set; }
    public string? Whatsapp { get; set; }
    public string? Rua { get; set; }
    public List<Motoqueiro> Motoqueiros { get; set; }

    public Empresa(){
        Motoqueiros = new List<Motoqueiro>();
    }
}