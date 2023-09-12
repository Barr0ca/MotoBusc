using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ava2Bim.Model;

namespace ava2Bim.Controllers;

[ApiController]
[Route("[controller]")]

public class EmpresaController : ControllerBase
{
    [HttpGet(Name = "empresas")]

    public List<Empresa> GetEmpresas()
    {
        List<Empresa> empresas = new List<Empresa>();
        List<Motoqueiro> motoqueirosAquino = new List<Motoqueiro>();
        List<Motoqueiro> motoqueirosRei = new List<Motoqueiro>();
        List<Motoqueiro> motoqueirosQuiosque = new List<Motoqueiro>();

        empresas.Add(new Empresa{
            Nome = "Mototáxi da Praça Aquino",
            Numero = "996559940",
            Whatsapp = "996559940",
            Rua = "Rua Aquino Batista",
            Motoqueiros = motoqueirosAquino
        });
        empresas.Add(new Empresa{
            Nome = "Mototáxi da Praça do Rei",
            Numero = "998344412",
            Whatsapp = "997780121",
            Rua = "Rua João Pedrosa",
            Motoqueiros = motoqueirosRei 
        });
        empresas.Add(new Empresa{
            Nome = "Mototáxi do Quiosque",
            Numero = "993341766",
            Whatsapp = "998764432",
            Rua = "Rua da Varanda",
            Motoqueiros = motoqueirosQuiosque
        });

        motoqueirosAquino.Add(new Motoqueiro{
            Nome = "Pedro"
        });
        motoqueirosAquino.Add(new Motoqueiro{
            Nome = "João"
        });
        motoqueirosAquino.Add(new Motoqueiro{
            Nome = "Chico"
        });
        motoqueirosRei.Add(new Motoqueiro{
            Nome = "Messi"
        });
        motoqueirosRei.Add(new Motoqueiro{
            Nome = "Timótio"
        });
        motoqueirosRei.Add(new Motoqueiro{
            Nome = "Zé Paulo"
        });
        motoqueirosQuiosque.Add(new Motoqueiro{
            Nome = "Paulo"
        });
        motoqueirosQuiosque.Add(new Motoqueiro{
            Nome = "Tonhão"
        });
        motoqueirosQuiosque.Add(new Motoqueiro{
            Nome = "Franscisco"
        });

        return empresas;
    }
}
