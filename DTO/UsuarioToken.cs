using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoBusc.DTO
{
    public class UsuarioToken
    {
        public bool Autenticacao { get; set; }

        public DateTime Expiracao { get; set; }

        public String? Token { get; set; }

        public String? Mensagem { get; set; }
    }
}