using AccessControl.Models;
using Microsoft.AspNetCore.Mvc;


namespace AccessControl.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistroAcessoController : ControllerBase
{
    private static List<Acesso> acessos = new List<Acesso>();

    [HttpPost]
    public IActionResult RegistraEntrada(Acesso acesso)
    {
        acessos.Add(acesso);
        return CreatedAtAction(nameof(RecuperaAcessoPorDocumento), new { documento = acesso.Documento }, acesso);
    }

    [HttpGet]
    public IEnumerable<Acesso> RetornaAcessos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return acessos.Skip(skip).Take(take);
    }

    [HttpGet("{documento}")]
    public IEnumerable<Acesso> RecuperaAcessoPorDocumento(string documento)
    {
        return acessos.Where(acesso => acesso.Documento == documento);

    }
}

[ApiController]
[Route("[controller]")]
public class RegistropessoaController : ControllerBase
{
    private static List<Pessoa> pessoas = new List<Pessoa>();

    [HttpPost]
    public IActionResult RegistraEntrada(Pessoa pessoa)
    {
        pessoas.Add(pessoa);
        return CreatedAtAction(nameof(RecuperaPessoaPorDocumento), new { documento = pessoa.Documento }, pessoa);
    }

    [HttpGet]
    public IEnumerable<Pessoa> RetornaAcessos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return pessoas.Skip(skip).Take(take);
    }

    [HttpGet("{documento}")]
    public IActionResult RecuperaPessoaPorDocumento(string documento)
    {
        var pes = pessoas.FirstOrDefault(pessoa => pessoa.Documento == documento);
        if (pes == null) return NotFound();
        return Ok(pes);

    }
}
