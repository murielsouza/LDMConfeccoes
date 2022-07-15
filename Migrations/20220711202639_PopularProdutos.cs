using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LDMConfeccoes.Migrations
{
    public partial class PopularProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos (CategoriaId, DescricaoCurta, DescricaoDetalhada, EmEstoque, ImagemThumbnailUrl, ImagemUrl, IsProdutoPreferido, Nome, Preco)" +
                "VALUES(2, 'Camisa Xadrez Masc GG', 'Camiseta Xadrez Masculina Tamanho GG Cor Preto/Branco Gola Alta', 1, 'https://static.netshoes.com.br/produtos/camisa-xadrez-new-era-united-in-sport-manga-longa-masculina/26/IJX-7258-026/IJX-7258-026_zoom1.jpg?ts=1585153070', 'https://static.netshoes.com.br/produtos/camisa-xadrez-new-era-united-in-sport-manga-longa-masculina/26/IJX-7258-026/IJX-7258-026_zoom1.jpg', 1, 'CAMISA XADREZ MASCULINA', 149.99)");
            migrationBuilder.Sql("INSERT INTO Produtos (CategoriaId, DescricaoCurta, DescricaoDetalhada, EmEstoque, ImagemThumbnailUrl, ImagemUrl, IsProdutoPreferido, Nome, Preco)" +
                "VALUES(2, 'Camisa Listrada Masc GG', 'Camiseta Listrada Masculina Tamanho GG Cor Preto/Branco Gola Alta', 1, 'https://http2.mlstatic.com/D_NQ_NP_673306-MLB48764865480_012022-W.jpg', 'https://http2.mlstatic.com/D_NQ_NP_673306-MLB48764865480_012022-W.jpg', 0, 'CAMISA XADREZ MASCULINA', 119.99)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
