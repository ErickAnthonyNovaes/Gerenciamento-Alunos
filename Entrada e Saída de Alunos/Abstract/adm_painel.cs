using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entrada_e_Saída_de_Alunos.Abstract
{
    public abstract class AdministracaoPainel
    {
        public bool? SolicitacaoAprov { get; set;}
        public string? TempoFora { get; set; }
    }
}