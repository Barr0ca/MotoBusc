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

        public int Nota { get; set; }

        public string? Usuario { get; set; }
    }
}