using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoBusc.DTO
{
    public class UsuarioDTO
    {
        public String? Email { get; set; }

        public String? Senha { get; set; }

        public String? ConfirmeSenha { get; set; }
    }
}