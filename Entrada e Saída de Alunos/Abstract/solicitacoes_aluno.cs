using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entrada_e_Saída_de_Alunos.Abstract
{
    public abstract class SolicitacoesAluno
    {
        public string? Nome { get; set; }
        public string? Solicitacao { get; set;}
        public string? Pendente { get; set;}
        public int? TipoSolicitacao { get; set; }
        public int? CodigoSolicitacao { get; set;}
    }
}