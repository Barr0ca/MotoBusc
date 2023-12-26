using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ava2Bim.Model;
using ava2Bim.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ava2Bim.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
[Route("[controller]")]

public class MotoqueiroController : ControllerBase
{
    private readonly ILogger<Motoqueiro> _logger;
    private readonly ava2BimContext _context;

    public MotoqueiroController(ILogger<Motoqueiro> logger, ava2BimContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name="GetMotoqueiro")]
    public ActionResult<IEnumerable<Motoqueiro>> Get()
    {
        var motoqueiros = _context.Motoqueiros.ToList();
        if(motoqueiros is null)
            return NotFound();
        
        return motoqueiros;
    }

    [HttpGet("{id:int}", Name = "Motoqueiro")]
    public ActionResult<Motoqueiro> Get(int id)
    {
        var motoqueiro = _context.Motoqueiros.FirstOrDefault(p => p.Id == id);
        if(motoqueiro is null)
            return NotFound("Motoqueiro não encontrado");

        return motoqueiro;
    }

    [HttpPost]
    public ActionResult Post(Motoqueiro motoqueiros)
    {
        _context.Motoqueiros.Add(motoqueiros);
        _context.SaveChanges();

        return Ok(motoqueiros);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Motoqueiro motoqueiros)
    {
        if(id != motoqueiros.Id)
            return BadRequest();

        _context.Entry(motoqueiros).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(motoqueiros);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id){
        var motoqueiro = _context.Motoqueiros.FirstOrDefault(p => p.Id == id);

        if(motoqueiro is null)
            return NotFound();

        _context.Motoqueiros.Remove(motoqueiro);
        _context.SaveChanges();

        return Ok(motoqueiro);
    }
}
