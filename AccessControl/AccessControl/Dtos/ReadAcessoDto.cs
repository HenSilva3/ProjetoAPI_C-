using System.ComponentModel.DataAnnotations;

namespace AccessControl.Dtos;

public class ReadAcessoDto
{
    public int IdDeAcesso { get; set; }

    public string Documento { get; set; }
       
    public string Tipo { get; set; }
        
    public int Sala { get; set; }

    public DateTime Data { get; set; }


}
