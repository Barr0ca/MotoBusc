using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ava2Bim.Model;
using ava2Bim.Context;
using Microsoft.EntityFrameworkCore;

namespace ava2Bim.Controllers;

[ApiController]
[Route("[controller]")]

public class MotoqueiroController : ControllerBase
{
    private readonly ILogger<MotoqueiroController> _logger;
    private readonly ava2BimContext _context;

    public MotoqueiroController(ILogger<MotoqueiroController> logger, ava2BimContext context)
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

}
