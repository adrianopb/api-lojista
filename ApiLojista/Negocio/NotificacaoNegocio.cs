﻿using ApiLojista.Entidades;

namespace ApiLojista.Negocios
{
    public class NotificacaoNegocio
    {
        public Notificacao CriarNotificacao(int idPedido)
        {
            Notificacao notificacao = new Notificacao()
            {
                //TODO: decidir melhor como o Id será implementado
                Id = 1,
                IdPedido = idPedido,
                IdOrcamento = null
            };

            return notificacao;
        }
        
        public Notificacao AtualizarNotificacaoOrcamento(int idPedido, int idOrcamento)
        {
            Notificacao notificacao = new Notificacao()
            {
                
            };

            //Pesquisar na lista
//            Notificacao notificacao = Notificacao.Where(idOrcamento && idPedido);

            notificacao.IdOrcamento = idOrcamento;

            return notificacao;
        }
    }
}