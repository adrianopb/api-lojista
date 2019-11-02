using System.ComponentModel.DataAnnotations;

namespace ApiLojista.Enum
{
    public enum PedidoStatus
    { 
        [Display(Name="Solicitado")]
        Solicitado = 1,
        [Display(Name="Em fabricação")]
        EmFabricacao = 2,
        [Display(Name="Finalizado")]
        Finalizado = 3, 
        [Display(Name="Despachado")]
        Despachado = 4
    }
}