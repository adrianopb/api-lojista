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
    public class PedidosController : ControllerBase
    {
        private PedidoNegocio _pedidoNegocio = new PedidoNegocio();
        private static readonly HttpClient client = new HttpClient();
        private readonly string _URLCriacaoPedido = "https://localhost:5001/v1/pedido";
        
        [HttpPost]
        public async Task<ActionResult<Pedido>> Post([FromBody]Pedido pedido)
        {
            Pedido novoPedido = new Pedido();
            
            //Função de criar o pedido (api lojista)
            novoPedido = _pedidoNegocio.CriarPedido(pedido);
            
            //Função de criar o pedido (api atacadista)
            var respostaCriacaoPedido = await client.PostAsJsonAsync(_URLCriacaoPedido, novoPedido);
            var respostaCriacaoPedidoString = await respostaCriacaoPedido.Content.ReadAsStringAsync();
            
            if (!respostaCriacaoPedido.IsSuccessStatusCode)
            {
                throw new Exception(respostaCriacaoPedidoString);
            }

            return Ok(novoPedido);
        }
        
        [HttpPut("{id}/status")]
        public ActionResult Put([FromRoute]int id, [FromBody]PedidoStatus status)
        {
            //TODO: função de atualizar o status do pedido
            return Ok(_pedidoNegocio.AtualizarPedidoStatus(id, status));
        }
    }
}
