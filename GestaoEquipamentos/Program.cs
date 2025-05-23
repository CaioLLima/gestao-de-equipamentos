using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using GestaoChamados.ModuloChamado;
using GestaoEquipamentos.ModuloChamado;
using GestaoEquipamentos.ModuloEquipamento;
using GestaoEquipamentos.ModuloFabricante;
using GestaoFabricantes.ModuloFabricante;

namespace GestaoEquipamentos;

internal class Program
{
    static void Main(string[] args)
    {
        RepositorioEquipamentos repositorioEquipamentos = new();
        RepositorioChamados repositorioChamados = new();
        RepositorioFabricante repositorioFabricante = new();

        TelaEquipamento telaEquipamento = new();
        telaEquipamento.repositorioEquipamento = repositorioEquipamentos;
        TelaFabricante telaFabricante = new(repositorioFabricante);
        TelaChamado telaChamado = new(repositorioEquipamentos, repositorioChamados);
        
        
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
                        telaEquipamento.RegistrarEquipamento();
                        break;
                    case '2':
                        telaEquipamento.EditarEquipamento();
                        break;
                    case '3':
                        telaEquipamento.VisualizarEquipamento();
                        break;
                    case '4':
                        telaEquipamento.ExcluirEquipamento();
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
                        telaChamado.RegistrarChamado();
                        break;
                    case '2':
                        telaChamado.EditarChamado();
                        break;
                    case '3':
                        telaChamado.VisualizarChamado();
                        break;
                    case '4':
                        telaChamado.ExcluirChamado();
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
                        telaFabricante.RegistrarFabricante();
                        break;
                    case '2':
                        telaFabricante.EditarFabricante();
                        break;
                    case '3':
                        telaFabricante.VisualizarFabricante();
                        break;
                    case '4':
                        telaFabricante.ExcluirFabricante();
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

