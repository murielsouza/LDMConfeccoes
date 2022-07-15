using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LDMConfeccoes.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "O nome do produto deve ser informado")]
        [Display(Name = "Nome do Produto")]
        [StringLength(120, MinimumLength = 8, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A descrição do produto deve ser informada")]
        [Display(Name = "Descrição Curta do Produto")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "Descrição não pode exceder {1} caracteres")]
        public string DescricaoCurta { get; set; }
        [Required(ErrorMessage = "A descrição do produto deve ser informada")]
        [Display(Name = "Descrição Detalhada do Produto")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(256, ErrorMessage = "Descrição não pode exceder {1} caracteres")]
        public string DescricaoDetalhada { get; set; }
        [Required(ErrorMessage = "O preço do produto deve ser informado")]
        [Display(Name = "Preço do Produto")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve está entre 1 e 999.99")]
        public decimal Preco { get; set; }
        [Display(Name = "Caminho da imagem normal")]
        [StringLength(256, MinimumLength = 8, ErrorMessage = "O tamanho máximo é 256 caracteres")]
        public string ImagemUrl { get; set; }
        [Display(Name = "Caminho da imagem thumbnail")]
        [StringLength(256, MinimumLength = 8, ErrorMessage = "O tamanho máximo é 256 caracteres")]
        public string ImagemThumbnailUrl { get; set; }
        [Display(Name = "Preferido?")]
        public bool IsProdutoPreferido { get; set; }
        [Display(Name = "Tem estoque?")]
        public bool EmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }    


    }
}
