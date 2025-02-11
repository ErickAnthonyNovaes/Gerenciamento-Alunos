using Entrada_e_Saída_de_Alunos.Models;
using Spectre.Console;

class Program
{
    public static List<Registro> solicitacoes = new List<Registro>();
    static void Main()
    {
        Console.Clear();
        while (true)
        {
            //pergunta ao usuário se ele é um Aluno ou Adm
            var opcao = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Bem-vindo. [green]O que deseja fazer hoje?[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Utilize as setas Up e Down do teclado para selecionar a opção desejada)[/]")
                    .AddChoices(new[] {
                        "Solicitar uma Entrada ou Saída", "Painel do Administrador"
                    }));

            if (opcao == "Solicitar uma Entrada ou Saída")
            {
                Console.Clear();
                Aluno();
            }

            else if (opcao == "Painel do Administrador")
            {
                Console.Clear();
                Administrador();
            }
        }
    }

    public static void Aluno()
    {
        Registro novaSolicitacao = new Registro();

        Console.Write("Insira seu nome completo: \n> ");
        novaSolicitacao.Nome = Console.ReadLine() ?? "";

        Console.Write("Insira sua Matrícula: \n> ");
        novaSolicitacao.Matricula = Convert.ToInt32(Console.ReadLine() ?? "");

        Console.Write("Qual o tipo de solicitação ([1]: Entrada/[2]: Saída): \n> ");
        novaSolicitacao.TipoSolicitacao = Convert.ToInt32(Console.ReadLine() ?? "");
        

        if (novaSolicitacao.TipoSolicitacao == 1)
        {
            Console.Clear();
            DateTime agora = DateTime.Now;
       
            //formata a hora para exibição
            string horaAtual = agora.ToString("HH:mm:ss");
            novaSolicitacao.DataHoraEvento = horaAtual;

            Console.Write("Insira o horário da saída (formato: HH:mm | Formato 24h): \n> ");
            string inputHora = Console.ReadLine();

            if (TimeSpan.TryParse(inputHora, out TimeSpan horaSaida))
            {
                Console.WriteLine($"Horário registrado: {horaSaida}");
            }
            else
            {
                Console.WriteLine("Formato inválido! Use HH:mm (ex: 14:30).");
                return;
            }

            novaSolicitacao.HoraSaida = inputHora;

            Console.WriteLine("Solicitação de Entrada realizada com sucesso!");

            Random random = new Random();

            novaSolicitacao.CodigoSolicitacao = random.Next(0000,9999);

            novaSolicitacao.Pendente = "Pendente";
            solicitacoes.Add(novaSolicitacao);
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }

        if (novaSolicitacao.TipoSolicitacao == 2)
        {
            Console.Clear();
            DateTime agora = DateTime.Now;
       
            //formata a hora para exibição
            string horaAtual = agora.ToString("HH:mm:ss");
            novaSolicitacao.DataHoraEvento = horaAtual;

            Console.Write("Insira o motivo da saída: \n> ");
            novaSolicitacao.Motivo = Console.ReadLine();
            
            Console.Write("Insira o horário de retorno (formato: HH:mm | Formato 24h): \n> ");
            string inputHora = Console.ReadLine();

            if (TimeSpan.TryParse(inputHora, out TimeSpan horaRetorno))
            {
                Console.WriteLine($"Horário registrado: {horaRetorno}");
            }
            else
            {
                Console.WriteLine("Formato inválido! Use HH:mm (ex: 14:30).");
                return;
            }

            novaSolicitacao.DataDeRetorno = inputHora;

            Console.WriteLine("Solicitação de Saída realizada com sucesso!");

            Random random = new Random();

            novaSolicitacao.CodigoSolicitacao = random.Next(0000,9999);

            novaSolicitacao.Pendente = "Pendente";
            solicitacoes.Add(novaSolicitacao);
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }
    }

    public static void Administrador()
    {
        while (true)
        {
            var opcao = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Painel do Administrador[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Utilize as setas Up e Down do teclado para selecionar a opção desejada)[/]")
                    .AddChoices(new[] {
                        "Gerenciar Solicitações", "Ver Solicitações Gerenciadas", "Sair"
                    }));

            if (opcao == "Gerenciar Solicitações")
            {
                GerenciarSolicitacoes();
            }
            else if (opcao == "Ver Solicitações Gerenciadas")
            {
                VerSolicitacoesGerenciadas();
            }
            else if (opcao == "Sair")
            {
                Console.Clear();
                break;
            }
        }
    }

    public static void GerenciarSolicitacoes()
    {
        if (solicitacoes.Count == 0)
        {
            Console.WriteLine("Nenhuma Solicitação ainda!");
            System.Threading.Thread.Sleep(1500);
            Console.Clear();
            return;
        }

        else
        {
            Console.WriteLine("Solicitações:");
            Console.WriteLine("[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]");
            foreach (var solicitacao in solicitacoes)
            {
                Console.WriteLine($"[CÓDIGO SOLICITAÇÃO]: {solicitacao.CodigoSolicitacao} \n/ Nome do Aluno: {solicitacao.Nome} /\n/ Matrícula do Aluno: {solicitacao.Matricula} /\n/ Tipo de Solicitação: [{solicitacao.TipoSolicitacao}] (Entrada: [1]/Saída: [2]) /\n/ Motivo: {solicitacao.Motivo} (Se estiver vazio, é uma Entrada) /\n/ Horário de Retorno: {solicitacao.DataDeRetorno} (Se estiver vazio, é uma Entrada) /\n/ Data da Solicitação: {solicitacao.DataHoraEvento} ---> Status: {solicitacao.Pendente}");
                Console.WriteLine("[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]");
            }
        }
        Console.Write("Insira o código da solicitação que deseja gerenciar: \n> ");
        string busca = Console.ReadLine();

        bool isNumero = int.TryParse(busca, out int CodigoSolicitacao);

        Registro Registro = solicitacoes.Find(p => isNumero && p.CodigoSolicitacao == CodigoSolicitacao);
        if (Registro != null)
        {
            Console.Clear();
            var opcao = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[blue1]Solicitação do aluno {Registro.Nome}[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Utilize as setas Up e Down do teclado para selecionar a opção desejada)[/]")
                    .AddChoices(new[] {
                        "Aprovar", "Recusar"
                    }));

            if (opcao == "Aprovar")
            {
                Console.WriteLine("Solicitação Aprovada!");

                Registro.Pendente = "Aprovado";
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
            }
            if (opcao == "Recusar")
            {
                Console.WriteLine("Solicitação Recusada!");

                Registro.Pendente = "Recusado";
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
            }
        }
    }

    public static void VerSolicitacoesGerenciadas()
    {
        if (solicitacoes.Count == 0)
        {
            Console.WriteLine("Nenhuma Solicitação ainda!");
        }

        else
        {
            Console.WriteLine("Solicitações:");
            Console.WriteLine("[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]");
            foreach (var solicitacao in solicitacoes)
            {
                Console.WriteLine($"[CÓDIGO SOLICITAÇÃO]: {solicitacao.CodigoSolicitacao} \n/ Nome do Aluno: {solicitacao.Nome} /\n/ Matrícula do Aluno: {solicitacao.Matricula} /\n/ Tipo de Solicitação: [{solicitacao.TipoSolicitacao}] (Entrada: [1]/Saída: [2]) /\n/ Motivo: {solicitacao.Motivo} (Se estiver vazio, é uma Entrada) /\n/ Horário de Retorno: {solicitacao.DataDeRetorno} (Se estiver vazio, é uma Entrada) /\n/ Data da Solicitação: {solicitacao.DataHoraEvento} ---> Status: {solicitacao.Pendente}");
                Console.WriteLine("[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]-[]");
            }
        }
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }
}