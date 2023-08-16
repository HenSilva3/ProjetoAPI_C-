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

    /// <summary>
    /// Adiciona um acesso ao banco de dados
    /// </summary>
    /// <param name="acessoDto">Objeto com os campos necessários para criação de um acesso</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult RegistraEntrada([FromBody] CreateAcessoDto acessoDto)
    {
        Acesso acesso = _mapper.Map<Acesso>(acessoDto);
        _context.Acessos.Add(acesso);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaAcessoPorDocumento), new { documento = acesso.Documento }, acesso);

    }

    /// <summary>
    /// Retorna os acessos realizados
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso haja registros no banco de dados</response>
    [HttpGet("RetornaAcessos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadAcessoDto> RetornaAcessos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadAcessoDto>>(_context.Acessos.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retorna os acessos realizados por uma determinada pessoa
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso haja registros no banco de dados</response>
    [HttpGet("RecuperaAcessoPorDocumento/{documento}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadAcessoDto> RecuperaAcessoPorDocumento(string documento)
    {
        return _mapper.Map<List<ReadAcessoDto>>(_context.Acessos.Where(acesso => acesso.Documento == documento));

    }

    /// <summary>
    /// Atualiza os dados do acesso utilizando o id 
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o acesso seja atualizado no banco de dados</response>
    [HttpPut("AtualizaAcesso/{idDeAcesso}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaAcesso(int idDeAcesso, [FromBody] UpdateAcessoDto acessoDto)
    {
        var acesso = _context.Acessos.FirstOrDefault(acesso => acesso.IdDeAcesso == idDeAcesso);
        if (acesso == null) return NotFound();
        _mapper.Map(acessoDto, acesso);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta o acesso do banco de dados
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o acesso seja deletado no banco de dados</response>
    [HttpDelete("DeletaAcesso/{idDeAcesso}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
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

    /// <summary>
    /// Adiciona um registro ao banco de dados
    /// </summary>
    /// <param name="pessoaDto">Objeto com os campos necessários para criação de um registro</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult RegistraPessoa([FromBody] CreatePessoaDto pessoaDto)
    {
        Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaPessoaPorDocumento), new { documento = pessoa.Documento }, pessoa);
    }

    /// <summary>
    /// Retorna pessoas registradas
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso haja registros no banco de dados</response>
    [HttpGet("RetornaPessoas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadPessoaDto> RetornaAcessos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadPessoaDto>>(_context.Pessoas.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retorna os registors de uma determinada pessoa
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso haja registros no banco de dados</response>
    [HttpGet("RecuperaPessoaPorDocumento/{documento}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult RecuperaPessoaPorDocumento(string documento)
    {
        var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Documento == documento);
        if (pessoa == null) return NotFound();
        var pessoaDto = _mapper.Map<ReadPessoaDto>(pessoa);
        return Ok(pessoaDto);

    }

    /// <summary>
    /// Atualiza os dados de uma pessoa 
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o dado seja atualizado no banco de dados</response>
    [HttpPut("AtualizaPessoa/{Documento}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaPessoa(string Documento, [FromBody] UpdatePessoaDto pessoaDto)
    {
        var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Documento == Documento);
        if (pessoa == null) return NotFound();
        _mapper.Map(pessoaDto, pessoa);
        _context.SaveChanges();
        return NoContent();

    }

    /// <summary>
    /// Deleta o registro de uma pessoa do banco de dados
    /// </summary>    
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o registro seja deletado no banco de dados</response>
    [HttpDelete("DeletaPessoa/{Documento}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeletaPessoa(string Documento)
    {
        var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Documento == Documento);
        if (pessoa == null) return NotFound();
        _context.Remove(pessoa);
        _context.SaveChanges();
        return NoContent();

    }
}
