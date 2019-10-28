﻿using System.ComponentModel.DataAnnotations;

namespace ApiLojista.Enum
{
    public enum OrcamentoStatus
    {
        [Display(Name="Pendente")]
        Pendente,
        [Display(Name="Aceito")]
        Aceito,
        [Display(Name="Rejeitado")]
        Rejeitado
    }
}