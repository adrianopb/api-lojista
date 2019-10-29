﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApiLojista.Entidades;
 using ApiLojista.Enum;
 using ApiLojista.Negocios;
using Microsoft.AspNetCore.Mvc;

namespace ApiLojista.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class OrcamentosController : Controller
    {
        private OrcamentoNegocio _orcamentoNegocio = new OrcamentoNegocio();
        private NotificacaoNegocio _notificacaoNegocio = new NotificacaoNegocio();
        private static readonly HttpClient client = new HttpClient();
        private readonly string _URLAtualizacaoOrcamento = "https://localhost:5000/v1/orcamentos";
        
        [HttpPost]
        public ActionResult<Notificacao> Post([FromBody]Orcamento orcamento)
        {
            //Função de criar orcamento
            Orcamento novoOrcamento = _orcamentoNegocio.CriarOrcamento(orcamento);
            
            //Função de atualizar notificação -> modelo : notificação -> paramentro id orcamento
            Notificacao notificacao = _notificacaoNegocio.AtualizarNotificacaoOrcamento(orcamento.IdPedido, orcamento.Id);
            
            return Ok(notificacao);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Orcamento>> Put(int id, [FromBody]OrcamentoStatus status)
        {
            //TODO: função de verificar status orcamento = pendente (genérico) -> modelo : orcamento -> paramentros id orcamento, string status
            
            //TODO: função de atualizar orcamento -> modelo : orcamento -> paramentro id orcamento   (aceito)
            _orcamentoNegocio.AtualizarOrcamentoStatus(id, status);

            //Função de atualizar o orçamento na API do atacadista
            var respostaOrcamento = await client.PostAsJsonAsync(_URLAtualizacaoOrcamento + "/" + id, status);
            var respostaOrcamentoString = await respostaOrcamento.Content.ReadAsStringAsync();

            if (!respostaOrcamento.IsSuccessStatusCode)
            {
                throw new Exception(respostaOrcamentoString);
            }
            
            return Ok();
        }
    }
}