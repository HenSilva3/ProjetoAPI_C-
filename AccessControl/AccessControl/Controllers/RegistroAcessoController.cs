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

    [HttpGet("RetornaAcessos")]
    public IEnumerable<ReadAcessoDto> RetornaAcessos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadAcessoDto>>(_context.Acessos.Skip(skip).Take(take));
    }

    [HttpGet("RecuperaAcessoPorDocumento/{documento}")]
    public IEnumerable<ReadAcessoDto> RecuperaAcessoPorDocumento(string documento)
    {
        return _mapper.Map<List<ReadAcessoDto>>(_context.Acessos.Where(acesso => acesso.Documento == documento));

    }

    [HttpPut("AtualizaAcesso/{idDeAcesso}")]
    public IActionResult AtualizaAcesso(int idDeAcesso, [FromBody] UpdateAcessoDto acessoDto)
    {
        var acesso = _context.Acessos.FirstOrDefault(acesso => acesso.IdDeAcesso == idDeAcesso);
        if (acesso == null) return NotFound();
        _mapper.Map(acessoDto, acesso);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("DeletaAcesso/{idDeAcesso}")]
    public IActionResult DeletaAcesso(int idDeAcesso)
    {
        var acesso = _context.Acessos.FirstOrDefault(acesso => acesso.IdDeAcesso == idDeAcesso);
        if (acesso == null) return NotFound();
        _context.Remove(acesso);
        _context.SaveChanges();
        return NoContent();
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

    [HttpGet("RetornaPessoas")]
    public IEnumerable<ReadPessoaDto> RetornaAcessos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadPessoaDto>>(_context.Pessoas.Skip(skip).Take(take));
    } 

    [HttpGet("RecuperaPessoaPorDocumento/{documento}")]
    public IActionResult RecuperaPessoaPorDocumento(string documento)
    {
        var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Documento == documento);
        if (pessoa == null) return NotFound();
        var pessoaDto = _mapper.Map<ReadPessoaDto>(pessoa);
        return Ok(pessoaDto);

    }

    [HttpPut("AtualizaPessoa/{Documento}")]
    public IActionResult AtualizaPessoa(string Documento, [FromBody] UpdatePessoaDto pessoaDto)
    {
        var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Documento == Documento);
        if (pessoa == null) return NotFound();
        _mapper.Map(pessoaDto, pessoa);
        _context.SaveChanges();
        return NoContent();

    }

    [HttpDelete("DeletaPessoa/{Documento}")]
    public IActionResult DeletaPessoa(string Documento)
    {
        var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Documento == Documento);
        if (pessoa == null) return NotFound();
        _context.Remove(pessoa);
        _context.SaveChanges();
        return NoContent();

    }
}
