using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoBusc.Model
{
    public class Avaliacao
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public Avaliacao(){
            Usuarios = new List<Usuario>();
        }
    }
}