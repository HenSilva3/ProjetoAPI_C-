using AutoMapper;
using AccessControl.Data;
using AccessControl.Dtos;
using AccessControl.Models;
using Microsoft.AspNetCore.Mvc;


namespace AccessControl.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistraAcessoController : ControllerBase
{
    private ControleAcessoContex _context;
    private IMapper _mapper;

    public RegistraAcessoController(ControleAcessoContex context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult RegistraEntrada([FromBody] CreateAcessoDto acessoDto)
    {
        Acesso acesso = _mapper.Map<Acesso>(acessoDto);
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
public class RegistraPessoaController : ControllerBase
{
    private ControleAcessoContex _context;
    private IMapper _mapper;

    public RegistraPessoaController(ControleAcessoContex contex, IMapper mapper)
    {
        _context = contex;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult RegistraPessoa([FromBody] CreatePessoaDto pessoaDto)
    {
        Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();
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
