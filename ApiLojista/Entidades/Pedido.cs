﻿using ApiLojista.Enum;

namespace ApiLojista.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public int CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }
        public PedidoStatus PedidoStatus { get; set; }
    }
}