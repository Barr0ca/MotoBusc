using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ava2Bim.Model;

namespace ava2Bim.Controllers;

[ApiController]
[Route("[controller]")]

public class MotoqueiroController : ControllerBase
{
    [HttpGet(Name = "motoqueiros")]

    public List<Motoqueiro> GetMotoqueiros()
    {
        List<Motoqueiro> motoqueiros = new List<Motoqueiro>();

        motoqueiros.Add(new Motoqueiro{
            Nome = "Chico"
        });
                motoqueiros.Add(new Motoqueiro{
            Nome = "João"
        });
                motoqueiros.Add(new Motoqueiro{
            Nome = "Paulo"
        });

        return motoqueiros;
    } 
}
