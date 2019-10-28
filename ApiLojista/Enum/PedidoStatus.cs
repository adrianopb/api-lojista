﻿using System.ComponentModel.DataAnnotations;

namespace ApiLojista.Enum
{
    public enum PedidoStatus
    { 
        [Display(Name="Solicitado")]
        Solicitado,
        [Display(Name="Em fabricação")]
        EmFabricacao,
        [Display(Name="Finalizado")]
        Finalizado, 
        [Display(Name="Despachado")]
        Despachado
    }
}