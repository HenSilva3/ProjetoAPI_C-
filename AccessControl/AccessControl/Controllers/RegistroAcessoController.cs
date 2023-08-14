using AccessControl.Models;
using Microsoft.AspNetCore.Mvc;


namespace AccessControl.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistroAcessoController : ControllerBase
{
    private static List<Acesso> acessos = new List<Acesso>();

    [HttpPost]
    public void RegistraEntrada(Acesso acesso)
    {
        acessos.Add(acesso);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Acesso>> RetornaAcessos()
    {
        return Ok(acessos);
    }
}
