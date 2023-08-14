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
    public void RegistraEntrada(Pessoa pessoa)
    {
        pessoas.Add(pessoa);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pessoa>> RetornaAcessos()
    {
        return Ok(pessoas);
    }

    [HttpGet("{documento}")]
    public IEnumerable<Pessoa> RecuperaPessoaPorDocumento(string documento)
    {
        return pessoas.Where(pessoa => pessoa.Documento == documento);

    }
}
