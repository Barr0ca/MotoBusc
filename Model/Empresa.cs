using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotoBusc.Model;

namespace ava2Bim.Model;

public class Empresa
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Numero { get; set; }
    public string? Whatsapp { get; set; }
    public string? Endereco { get; set; }
    public string? Avaliacao { get; set; }
    public List<Motoqueiro> Motoqueiros { get; set; }
    public List<Avaliacao> Avaliacoes { get; set; }

    public Empresa(){
        Motoqueiros = new List<Motoqueiro>();
        Avaliacoes = new List<Avaliacao>();
    }
}