using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AccessControl.Dtos;

public class UpdateAcessoDto
{
    
    [Required(ErrorMessage = "Documento é obrigatório")]
    public string Documento { get; set; }

    [Required(ErrorMessage = "Tipo do acesso é obrigatório")]
    [StringLength(20, ErrorMessage = "O tamanho do nome não pode exceder 20 caracteres")]
    public string Tipo { get; set; }

    [Required(ErrorMessage = "Informar a sala é obrigatório")]
    public int Sala { get; set; }

    



}
