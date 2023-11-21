using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ava2Bim.Context;
using Microsoft.AspNetCore.Mvc;
using MotoBusc.Model;
using ava2Bim.Model;
using Microsoft.EntityFrameworkCore;

namespace MotoBusc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<Usuario> _logger;
        private readonly ava2BimContext _context;

        public UsuarioController(ILogger<Usuario> logger, ava2BimContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name="GetUsuario")]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var usuarios = _context.Usuarios.ToList();
            if(usuarios is null)
                return NotFound();

            return usuarios;
        }

        [HttpGet("{id:int}", Name="Usuario")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if(usuario is null)
                return NotFound("Usuário não encontrado");

            return usuario;
        }

        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Ok(usuario);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Usuario usuario)
        {
            if(id != usuario.Id)
                return BadRequest();
            
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(usuario);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);

            if(usuario is null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return Ok(usuario);
        }
    }
}