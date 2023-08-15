using System.ComponentModel.DataAnnotations;

namespace AccessControl.Dtos;

public class ReadPessoaDto
{
    public string Documento { get; set; }

    public string Nome { get; set; }
        
    public string Categoria { get; set; }
}
