using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LDMConfeccoes.Models
{
    [Table("Categorias")] //só para reforcar mesmo, no DbSet já define
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [StringLength(120, ErrorMessage = "O tamanho máximo é 120 caracteres")]
        [Required(ErrorMessage = "O nome da categoria deve ser informado")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [StringLength(256, ErrorMessage = "A Descrição não pode exceder 256 caracteres")]
        [Required(ErrorMessage = "A descrição da categoria deve ser informada")]
        [Display(Name = "Descrição")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        public string Descricao { get; set; }

        public List<Produto> Produtos { get; set; } 
    }
}
