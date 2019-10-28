﻿using ApiLojista.Entidades;
using ApiLojista.Enum;

namespace ApiLojista.Negocios
{
    public class PedidoNegocio
    {
        public Pedido CriarPedido(Pedido pedido)
        {
            Pedido novoPedido = new Pedido()
            {
                //TODO: decidir melhor como o Id será implementado
                Id = 1,
                CodigoProduto = pedido.CodigoProduto,
                Observacao = pedido.Observacao,
            };

            return novoPedido;
        }
        
        public Pedido AtualizarPedidoStatus(int idPedido, PedidoStatus status)
        {
            Pedido pedido = new Pedido() {};

            //Pesquisar na lista
//            Pedido pedido = Pedido.Where(idPedido);

            pedido.PedidoStatus = status;

            return pedido;
        }
    }
}