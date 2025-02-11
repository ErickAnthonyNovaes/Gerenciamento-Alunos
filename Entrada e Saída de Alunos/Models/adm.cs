using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entrada_e_Saída_de_Alunos.Abstract;

namespace Entrada_e_Saída_de_Alunos.Models
{
    public class Adm: AdministracaoPainel
    {
        public void Solicitacao()
        {
            if (SolicitacaoAprov == true)
            {
                Console.WriteLine("A solicitação foi aprovada!");
            }
            else 
            {
                Console.WriteLine("A solicitação foi negada!");
            }
        }
    }
}