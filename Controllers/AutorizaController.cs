using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MotoBusc.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace MotoBusc.Controllers;

[ApiController]
[Route("[controller]")]
public class AutorizaController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AutorizaController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    [HttpGet]
    public ActionResult<string> Get()
    {
        return "AutorizaController :: Acessado em : "
            + DateTime.Now.ToLongDateString();
    }
    
    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser([FromBody] UsuarioDTO model)
    {
        var user = new IdentityUser
        {
            UserName = model.Email,
            Email = model.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, model.Senha);
        if(!result.Succeeded)
            return BadRequest(result.Errors);
    
        await _signInManager.SignInAsync(user, false);
        // return Ok(GeraToken(model));
        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] UsuarioDTO user)
    {
        var result = await _signInManager.PasswordSignInAsync
        (
            user.Email,
            user.Senha,
            isPersistent: false,
            lockoutOnFailure: false
        );

        if(result.Succeeded)
            return Ok();
        else
        {
            ModelState.AddModelError(string.Empty, "Login Inválido...");
            return BadRequest(ModelState);
        }
    }
}