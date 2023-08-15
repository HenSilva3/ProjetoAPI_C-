using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AccessControl.Models;

public class Acesso
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdDeAcesso { get; set; }

    [Required(ErrorMessage = "Documento é obrigatório")]
    public string Documento { get; set; }
     

    [Required(ErrorMessage = "Tipo do acesso é obrigatório")]
    [MaxLength(20, ErrorMessage = "O tamanho do nome não pode exceder 20 caracteres")]
    public string Tipo { get; set; }

     

    [Required(ErrorMessage = "Informar a sala é obrigatório")]
    public int Sala { get; set; }

    public string? Data { get; set; }


    public string? Hora { get; set; }



}

