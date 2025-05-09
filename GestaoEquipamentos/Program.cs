using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using GestaoEquipamentos.ModuloChamado;
using GestaoEquipamentos.ModuloEquipamento;
using GestaoEquipamentos.ModuloFabricante;

namespace GestaoEquipamentos;

internal class Program
{
    static void Main(string[] args)
    {
        RepositorioEquipamentos repositorioEquipamento = new();
        TelaEquipamento telaEquipamento = new();
        TelaChamado telaChamado = new();
        TelaFabricante telaFabricante = new();
        RepositorioChamados repositorioChamado = new()
        {
            repositorioEquipamento = repositorioEquipamento,
            equipamentos = repositorioEquipamento.equipamentos
        };

        RepositorioFabricante repositorioFabricante = new()
        {
            repositorioEquipamento = repositorioEquipamento,
            equipamentos = repositorioEquipamento.equipamentos
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
                        repositorioEquipamento.RegistrarEquipamento();
                        break;
                    case '2':
                        repositorioEquipamento.EditarEquipamento();
                        break;
                    case '3':
                        repositorioEquipamento.VisualizarEquipamento();
                        break;
                    case '4':
                        repositorioEquipamento.ExcluirEquipamento();
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
                        repositorioChamado.RegistrarChamado();
                        break;
                    case '2':
                        repositorioChamado.EditarChamado();
                        break;
                    case '3':
                        repositorioChamado.VisualizarChamado();
                        break;
                    case '4':
                        repositorioChamado.ExcluirChamado();
                        break;
                }
            }
            else if (opcaoTelaPrincipal == '3')
            {
                char opcaoEscolhida = telaFabricante.SelecionarOperacao();

                if (opcaoEscolhida == 'S') continue;

                switch (opcaoEscolhida)
                {
                    case '1':
                        repositorioFabricante.RegistrarFabricante();
                        break;
                    case '2':
                        repositorioFabricante.EditarFabricante();
                        break;
                    case '3':
                        repositorioFabricante.VisualizarFabricante();
                        break;
                    case '4':
                        repositorioFabricante.ExcluirFabricante();
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
        Console.WriteLine("Qual opção deseja escolher? \n 1 - Controle de Equipamentos \n 2 - Controle de Chamados \n 3 - Controle de Fabricantes \n S - Sair");
        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;
    }
}

