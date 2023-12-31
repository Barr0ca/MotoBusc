using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MotoBusc.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        
        public string? Nome { get; set; }

        public string? Localizacao { get; set; }

        public List<Avaliacao> Avaliacoes { get; set; }

        public Usuario(){
            Avaliacoes = new List<Avaliacao>();
        }
    }
}