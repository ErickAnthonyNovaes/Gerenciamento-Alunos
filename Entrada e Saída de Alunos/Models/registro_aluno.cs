using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entrada_e_Saída_de_Alunos.Abstract;

namespace Entrada_e_Saída_de_Alunos.Models
{
    public class Registro: SolicitacoesAluno
    {
        public int? Matricula { get; set; }
        public string? DataHoraEvento { get; set;}
        public string? Motivo { get; set; }
        public string? HoraSaida { get; set; }
        public DateOnly? DataSolicitacao { get; set; }
        public string? DataDeRetorno { get; set; }

        public void SolicitacaoDoAluno()
        {
            Console.WriteLine("Foi enviado sua solicitação ao Administrador!");
        }
    }
}