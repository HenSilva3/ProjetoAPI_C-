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

    [Required]
    public string Data { get; }

    [Required]
    public string Hora { get; }

    [Required(ErrorMessage = "Informar a sala é obrigatório")]
    public int Sala { get; set; }

    public Acesso()
    {
        Data = DateTime.Now.ToString("yyyy-MM-dd");
        Hora = DateTime.Now.ToString("HH:mm:ss");
    }

}

