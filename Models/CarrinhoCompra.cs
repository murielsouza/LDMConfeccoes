using LDMConfeccoes.Context;

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
        public List<CarrinhoCompraItem> CarrinhoCompraItenss  { get; set; }

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
    }
}
