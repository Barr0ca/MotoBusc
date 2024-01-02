using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ava2Bim.Context;
using Microsoft.AspNetCore.Mvc;
using MotoBusc.Model;
using ava2Bim.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MotoBusc.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly ILogger<Avaliacao> _logger;
        private readonly ava2BimContext _context;

        public AvaliacaoController(ILogger<Avaliacao> logger, ava2BimContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name="GetAvaliacao")]
        public ActionResult<IEnumerable<Avaliacao>> Get()
        {
            var avaliacao = _context.Avaliacoes.ToList();
            if(avaliacao is null)
                return NotFound();

            return avaliacao;
        }

        [HttpGet("{id:int}", Name="Avaliacao")]
        public ActionResult<Avaliacao> Get(int id)
        {
            var avaliacao = _context.Avaliacoes.FirstOrDefault(u => u.Id == id);
            if(avaliacao is null)
                return NotFound("Avaliação não encontrada");

            return avaliacao;
        }

        [HttpPost]
        public ActionResult Post(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            _context.SaveChanges();

            return Ok(avaliacao);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Avaliacao avaliacao)
        {
            if(id != avaliacao.Id)
                return BadRequest();
            
            _context.Entry(avaliacao).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(avaliacao);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var avaliacao = _context.Avaliacoes.FirstOrDefault(u => u.Id == id);

            if(avaliacao is null)
                return NotFound();

            _context.Avaliacoes.Remove(avaliacao);
            _context.SaveChanges();

            return Ok(avaliacao);
        }
    }
}