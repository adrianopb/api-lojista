using System.ComponentModel.DataAnnotations;

namespace ApiLojista.Enum
{
    public enum OrcamentoStatus
    {
        [Display(Name="Pendente")]
        Pendente = 1,
        [Display(Name="Aceito")]
        Aceito = 2,
        [Display(Name="Rejeitado")]
        Rejeitado = 3
    }
}