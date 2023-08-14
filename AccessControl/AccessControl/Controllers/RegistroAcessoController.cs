using AccessControl.Data;
using AccessControl.Models;
using Microsoft.AspNetCore.Mvc;


namespace AccessControl.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistroAcessoController : ControllerBase
{
    private ControleAcessoContex _context;

    public RegistroAcessoController(ControleAcessoContex context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult RegistraEntrada(Acesso acesso)
    {
        _context.Acessos.Add(acesso);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaAcessoPorDocumento), new { documento = acesso.Documento }, acesso);
    }

    [HttpGet]
    public IEnumerable<Acesso> RetornaAcessos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _context.Acessos.Skip(skip).Take(take);
    }

    [HttpGet("{documento}")]
    public IEnumerable<Acesso> RecuperaAcessoPorDocumento(string documento)
    {
        return _context.Acessos.Where(acesso => acesso.Documento == documento);

    }
}

[ApiController]
[Route("[controller]")]
public class RegistroPessoaController : ControllerBase
{
    private ControleAcessoContex _context;

    public RegistroPessoaController(ControleAcessoContex contex)
    {
        _context = contex;
    }

    [HttpPost]
    public IActionResult RegistraEntrada(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);
        return CreatedAtAction(nameof(RecuperaPessoaPorDocumento), new { documento = pessoa.Documento }, pessoa);
    }

    [HttpGet]
    public IEnumerable<Pessoa> RetornaAcessos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _context.Pessoas.Skip(skip).Take(take);
    }

    [HttpGet("{documento}")]
    public IActionResult RecuperaPessoaPorDocumento(string documento)
    {
        var pes = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Documento == documento);
        if (pes == null) return NotFound();
        return Ok(pes);

    }
}
