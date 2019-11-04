﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApiLojista.Entidades;
 using ApiLojista.Enum;
 using ApiLojista.Negocios;
 using Microsoft.AspNetCore.Http;
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
        
        /// <summary>
        /// Recebe orcamento do atacadista
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<Notificacao> Post([FromBody]Orcamento orcamento)
        {
            //Função de criar orcamento
            Orcamento novoOrcamento = _orcamentoNegocio.CriarOrcamento(orcamento);

            if (novoOrcamento == null)
            {
                return StatusCode(500);
            }
            
            //Função de atualizar notificação -> modelo : notificação -> paramentro id orcamento
            Notificacao notificacao = _notificacaoNegocio.AtualizarNotificacaoOrcamento(orcamento.IdPedido, orcamento.Id);
            
            return Ok(notificacao);
        }
        
        /// <summary>
        /// Atualiza status do orcamento (aceitar ou rejeitar)
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Orcamento>> Put(int id, [FromBody]int status)
        {
            Orcamento orcamento = new Orcamento();
            
            
            if (_orcamentoNegocio.BuscarOrcamento(id) == null)
            {
                return NotFound();
            }
            
            //Função de atualizar orcamento -> modelo : orcamento -> paramentro id orcamento   (aceito)
            orcamento = _orcamentoNegocio.AtualizarOrcamentoStatus(id, status);

            //Função de atualizar o orçamento na API do atacadista
            var respostaOrcamento = await client.PostAsJsonAsync(_URLAtualizacaoOrcamento + "/" + id, status);
            var respostaOrcamentoString = await respostaOrcamento.Content.ReadAsStringAsync();

            if (!respostaOrcamento.IsSuccessStatusCode)
            {
                throw new Exception(respostaOrcamentoString);
            }
            
            return Ok(orcamento);
        }
    }
}