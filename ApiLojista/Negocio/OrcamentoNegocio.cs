﻿using ApiLojista.Entidades;
using ApiLojista.Enum;

namespace ApiLojista.Negocios
{
    public class OrcamentoNegocio
    {
        public Orcamento CriarOrcamento(Orcamento orcamento)
        {
            Orcamento novoOrcamento = new Orcamento(){};

            novoOrcamento = orcamento;

            return novoOrcamento;
        }
    }
}