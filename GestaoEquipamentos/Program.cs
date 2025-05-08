using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using GestaoEquipamentos.ModuloChamado;
using GestaoEquipamentos.ModuloEquipamento;

namespace GestaoEquipamentos;

internal class Program
{
    static void Main(string[] args)
    {
        RepositorioEquipamentos funcionario = new();
        TelaEquipamento telaEquipamento = new();
        TelaChamado telaChamado = new();

        RepositorioChamados funcionarioChamado = new()
        {
            repositorioEquipamento = funcionario,
            equipamentos = funcionario.equipamentos
        };

        
        while (true)
        {
            char opcaoTelaPrincipal = ApresentarTelaPrincipal();

            if (opcaoTelaPrincipal == 'S') break;

            if (opcaoTelaPrincipal == '1')
            {
                char opcaoEscolhida = telaEquipamento.SelecionarOperacao();

                if (opcaoEscolhida == 'S') continue;

                switch (opcaoEscolhida)
                {
                    case '1':
                        funcionario.RegistrarEquipamento();
                        break;
                    case '2':
                        funcionario.EditarEquipamento();
                        break;
                    case '3':
                        funcionario.VisualizarEquipamento();
                        break;
                    case '4':
                        funcionario.ExcluirEquipamento();
                        break;
                }
            }

            else if (opcaoTelaPrincipal == '2')
            {
                char opcaoEscolhida = telaChamado.SelecionarOperacao();

                if (opcaoEscolhida == 'S') continue;

                switch (opcaoEscolhida)
                {
                    case '1':
                        funcionarioChamado.RegistrarChamado();
                        break;
                    case '2':
                        funcionarioChamado.EditarChamado();
                        break;
                    case '3':
                        funcionarioChamado.VisualizarChamado();
                        break;
                    case '4':
                        funcionarioChamado.ExcluirChamado();
                        break;
                }
            }
        }
    }

    public static char ApresentarTelaPrincipal()
    {
        Console.Clear();

        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine();
        Console.WriteLine("Qual opção deseja escolher? \n 1 - Controle de Equipamentos \n 2 - Controle de Chamados \n S - Sair");
        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;
    }
}

