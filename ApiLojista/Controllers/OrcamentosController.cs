﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApiLojista.Entidades;
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
        private readonly string _URLCriacaoOrcamento = "https://localhost:5000/v1/orcamento";
        
        [HttpPost]
        public async Task<ActionResult<Orcamento>> Post([FromBody]Orcamento orcamento)
        {
            //Função de criar orcamento
            Orcamento novoOrcamento = _orcamentoNegocio.CriarOrcamento(orcamento);
            
            //TODO: chamar função de verificar se notificação existe
            
            //Função de atualizar notificação -> modelo : notificação -> paramentro id orcamento
//            Notificacao notificacao = _notificacaoNegocio.AtualizarNotificacaoOrcamento(idPedido, orcamento.Id);

            //Função de criar o orçamento na API do lojista
            var respostaOrcamento = await client.PostAsJsonAsync(_URLCriacaoOrcamento, orcamento);
            var respostaOrcamentoString = await respostaOrcamento.Content.ReadAsStringAsync();

            if (!respostaOrcamento.IsSuccessStatusCode)
            {
                throw new Exception(respostaOrcamentoString);
            }
            
            return Ok(novoOrcamento);
        }
        
        [HttpPost]
        public IActionResult Put([FromBody]Pedido pedido, string status)
        {
            //TODO: função de verificar status orcamento = pendente (genérico) -> modelo : orcamento -> paramentros id orcamento, string status
            
            //TODO: função de atualizar orcamento -> modelo : orcamento -> paramentro id orcamento   (aceito)
            
            //TODO: função de atualizar notificação -> modelo : notificação -> paramentro id orcamento, id pedido
            
            return Ok();
        }
    }
}