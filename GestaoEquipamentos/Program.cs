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
        RepositorioFabricante repositorioFabricante = new RepositorioFabricante();
        RepositorioEquipamentos repositorioEquipamento = new RepositorioEquipamentos();
        RepositorioChamados repositorioChamado = new RepositorioChamados();

        TelaFabricante telaFabricante = new TelaFabricante(repositorioFabricante);

        TelaEquipamento telaEquipamento = new TelaEquipamento(
            repositorioEquipamento
        );

        TelaChamado telaChamado = new TelaChamado(repositorioEquipamento,repositorioChamado);



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
                        telaEquipamento.RegistrarRegistro();
                        break;
                    case '2':
                        telaEquipamento.EditarRegistro();
                        break;
                    case '3':
                        telaEquipamento.VisualizarRegistros();
                        break;
                    case '4':
                        telaEquipamento.ExcluirRegistro();
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
                        telaChamado.RegistrarRegistro();
                        break;
                    case '2':
                        telaChamado.EditarRegistro();
                        break;
                    case '3':
                        telaChamado.VisualizarRegistros();
                        break;
                    case '4':
                        telaChamado.ExcluirRegistro();
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
                        telaFabricante.RegistrarRegistro();
                        break;
                    case '2':
                        telaFabricante.EditarRegistro();
                        break;
                    case '3':
                        telaFabricante.VisualizarRegistros();
                        break;
                    case '4':
                        telaFabricante.ExcluirRegistro();
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

