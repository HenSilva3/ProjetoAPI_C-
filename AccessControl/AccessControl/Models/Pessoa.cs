
using System.ComponentModel.DataAnnotations;

namespace AccessControl.Models;

public class Pessoa
{
    [Key]
    [Required]
    public string Documento { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MaxLength(20, ErrorMessage = "O tamanho do nome não pode exceder 20 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A categoria é obrigadotória")]   
    public string Categoria { get; set; }

    



}
