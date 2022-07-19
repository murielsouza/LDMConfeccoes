using LDMConfeccoes.Repositories.Interfaces;
using LDMConfeccoes.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LDMConfeccoes.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public IActionResult List()
        {
            //ViewData["Titulo"] = "Todos os Produtos";
            //var produtos = _produtoRepository.Produtos;
            //return View(produtos);
            var produtosListViewModel = new ProdutoListViewModel();
            produtosListViewModel.Produtos = _produtoRepository.Produtos;
            produtosListViewModel.CategoriaAtual = "Categoria Atual";
            var totalProdutos = produtosListViewModel.Produtos.Count();
            ViewBag.Total = totalProdutos;
            return View(produtosListViewModel);

        }
    }
}
