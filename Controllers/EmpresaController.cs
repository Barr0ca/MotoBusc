using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ava2Bim.Model;
using ava2Bim.Context;

namespace ava2Bim.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly ILogger<Empresa> _Logger;

        private readonly ava2BimContext _context;

        public EmpresaController(ILogger<Empresa> logger, ava2BimContext context){
            _Logger = logger;
            _context = context;
        }
    
        [HttpGet(Name = "empresas")]

        public ActionResult<IEnumerable<Empresa>> Get()
        {
            var empresas = _context.Empresas.ToList();
            if(empresas is null)
                return NotFound();
                
            return empresas;
        }

        [HttpGet("{id:int}", Name = "GetEmpresa")]

        public ActionResult<Empresa> Get(int id)
        {
            var empresas = _context.Empresas.FirstOrDefault(p => p.Id == id);
            if(empresas is null)
                return NotFound("Empresa não encontrado");
                
            return empresas;
        }

        [HttpPost]

        public ActionResult Post(Empresa empresa){
            _context.Empresas.Add(empresa);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetEmpresa",
                new{ id = empresa.Id},
                empresa);
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, Empresa empresa)
        {
            if(id != empresa.Id)
                return BadRequest();
                
            _context.Entry(empresa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(empresa);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var empresa = _context.Empresas.FirstOrDefault(p => p.Id == id);

            if(empresa is null)
                return NotFound();
            
            _context.Empresas.Remove(empresa);
            _context.SaveChanges();

            return Ok(empresa);
        }
    }
}
