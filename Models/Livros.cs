using System.ComponentModel.DataAnnotations;
namespace biblioteca.Models;

public class Livro
{
  [Key]
  public int Id { get; set; }
  [Required]
  [StringLength(100)]
  [Display(Name = "Autor")]
  [ErrorMessage = "O nome do autor deve conter entre 1 e 100 caracteres."]

  public string Titulo { get; set; }
  [Required]
  [StringLength(100)]
  [Display(Name = "Autor")]
  [ErrorMessage = "O nome do autor deve conter entre 1 e 100 caracteres."]
  public string Autor { get; set; }
}