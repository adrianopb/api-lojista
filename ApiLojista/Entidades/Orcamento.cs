﻿using ApiAtacadista.Entidades;
 using ApiLojista.Enum;

namespace ApiLojista.Entidades
{
    public class Orcamento
    {
        public int Id { get; set; }
        public OrcamentoStatus Status { get; set; }
        public Preco Preco { get; set; }
        public int IdPedido { get; set; }
    }
}