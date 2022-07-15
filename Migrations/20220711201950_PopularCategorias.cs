using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LDMConfeccoes.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao)" +
                "VALUES('Acessórios', 'Produtos acessórios para o corpo e cabeça')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao)" +
                "VALUES('Roupas', 'Roupas de todos os tipos e gêneros')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");    
        }
    }
}
