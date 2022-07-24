using LDMConfeccoes.Context;
using Microsoft.EntityFrameworkCore;

namespace LDMConfeccoes.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            this._context = context;
        }

        public string CarrinhoCompraID { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens  { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor> ()?.HttpContext.Session;
            
            //obtém um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //ontém ou gerao Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid ().ToString ();

            //atribui o id do carrinho da sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraID = carrinhoId
            };            
        }
        public void AdicionarAoCarrinho(Produto produto)
        {
            //verificar se item já existe
            var carrinhoCompraItem = _context.CarrinhoComprasItens.SingleOrDefault(
                s => s.Produto.ProdutoId == produto.ProdutoId &&
                s.CarrinhoCompraId == CarrinhoCompraID);
            if(carrinhoCompraItem == null) //item não exite
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraID,
                    Produto = produto,
                    Quantidade = 1
                };
                _context.CarrinhoComprasItens.Add(carrinhoCompraItem);
            }
            else //item já existe
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }
        public int RemoverDoCarrinho (Produto produto)
        {
            var carrinhoCompraItem = _context.CarrinhoComprasItens.SingleOrDefault(
                s => s.Produto.ProdutoId == produto.ProdutoId &&
                s.CarrinhoCompraId== CarrinhoCompraID);

            var quantidadeLocal = 0;

            if(carrinhoCompraItem != null)
            {
                if(carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoComprasItens.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }
        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            return CarrinhoCompraItens ?? (CarrinhoCompraItens = _context.CarrinhoComprasItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraID)
                .Include(s => s.Produto)
                .ToList());  
        }
        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoComprasItens
               .Where(c => c.CarrinhoCompraId == CarrinhoCompraID);
            _context.CarrinhoComprasItens.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }
        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoComprasItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraID)
                .Select(c => c.Produto.Preco * c.Quantidade)
                .Sum();
            return total;
        }
    }
}
