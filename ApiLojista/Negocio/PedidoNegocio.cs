using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ApiLojista.Entidades;
using ApiLojista.Enum;
using ApiLojista.Entidades;

namespace ApiLojista.Negocios
{
    public class PedidoNegocio
    {
        public IEnumerable<Pedido> ListaPedido()
        {
            return new List<Pedido>()
            {
                Pedido1(),
                Pedido2()
            };
        }

        public Pedido Pedido1()
        {
            return new Pedido()
            {
                CodigoProduto = 12345,
                Id = 3,
                Observacao = "Pedido exemplar de número 1",
                PedidoStatus = PedidoStatus.Solicitado,
                Quantidade = 5
            };
        }

        public Pedido Pedido2()
        {
            return new Pedido()
            {
                CodigoProduto = 6225,
                Id = 5,
                Observacao = "Pedido exemplar de número 2",
                PedidoStatus = PedidoStatus.Despachado,
                Quantidade = 2
            };
        }
        
        public Pedido AtualizarPedidoStatus(int idPedido, int status)
        {
            Pedido pedido = BuscarPedido(idPedido);
            pedido.PedidoStatus = (PedidoStatus)status;

            return pedido;
        }

        public Pedido BuscarPedido(int idPedido)
        {
            Pedido pedido = ListaPedido().SingleOrDefault(q => q.Id == idPedido);

            return pedido;
        }
        
        
        public Pedido CriarPedido(Pedido pedido)
        {
            Pedido novoPedido = new Pedido()
            {
                Id = 1,
                CodigoProduto = pedido.CodigoProduto,
                Observacao = pedido.Observacao,
                PedidoStatus = PedidoStatus.Solicitado,
                Quantidade = pedido.Quantidade
            };

            return novoPedido;
        }
    }
}