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
            orcamento.Status = OrcamentoStatus.Pendente;

            return novoOrcamento;
        }
        
        public Orcamento AtualizarOrcamentoStatus(int id, OrcamentoStatus status)
        {
            Orcamento orcamento = new Orcamento(){};

//            orcamento = Orcamento.Where(Id = id);

            orcamento.Status = status;

            return orcamento;
        }
    }
}