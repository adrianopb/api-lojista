using System.Collections.Generic;
using System.Linq;
using ApiLojista.Entidades;
using ApiLojista.Enum;

namespace ApiLojista.Negocios
{
    public class NotificacaoNegocio
    {
        public IEnumerable<Notificacao> ListaNotificacao()
        {
            return new List<Notificacao>()
            {
                Notificacao1(),
                Notificacao2()
            };
        }

        public Notificacao Notificacao1()
        {
            return new Notificacao()
            {
                Id = 3,
                IdPedido = 5,
                IdOrcamento = null
            };
        }

        public Notificacao Notificacao2()
        {
            return new Notificacao()
            {
                Id = 4,
                IdPedido = 52,
                IdOrcamento = 2
            };
        }
        
        public Notificacao CriarNotificacao(int idPedido)
        {
            Notificacao notificacao = new Notificacao()
            {
                Id = 1,
                IdPedido = idPedido,
                IdOrcamento = null
            };

            return notificacao;
        }

        public Notificacao BuscarNotificacao(int idNotificacao)
        {
            return ListaNotificacao().SingleOrDefault(q => q.Id == idNotificacao);
        }

        public Notificacao BuscarNotificacaoPorConteudo(int idPedido, int? idOrcamento)
        {
            return idOrcamento != null ? 
                ListaNotificacao().SingleOrDefault(q => q.IdPedido == idPedido && q.IdOrcamento == idOrcamento) : 
                ListaNotificacao().SingleOrDefault(q => q.IdPedido == idPedido);
        }
        
        public Notificacao AtualizarNotificacaoOrcamento(int idPedido, int idOrcamento)
        {
            Notificacao notificacao = BuscarNotificacaoPorConteudo(idPedido, idOrcamento);

            if (notificacao == null)
            {
                return null;
            }

            notificacao.IdOrcamento = idOrcamento;

            return notificacao;
        }
    }
}