using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace GestaoEquipamentos
{
    public class ControleEquipamentos
    {
        public Equipamento[] equipamentos;
        public int contador = 0;
        // public RepositorioEquipamentos repositorioEquipamento = new RepositorioEquipamentos();
        public void RegistrarEquipamento()
        {
            Console.WriteLine($"\nRegistro de novo Equipamento");
            Equipamento novoEquipamento = new Equipamento();


            Console.Write($"ID: ");
            novoEquipamento.id = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Nome: ");
            novoEquipamento.nome = Console.ReadLine();
            Console.Write($"Preço: ");
            novoEquipamento.preco = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Número de série: ");
            novoEquipamento.numSerie = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Data: ");
            novoEquipamento.data = Console.ReadLine();
            Console.Write($"Fabricante: ");
            novoEquipamento.fabricante = Console.ReadLine();
            Console.Write($"\nRegistro concluído.");
            Console.ReadLine();
            equipamentos[contador] = novoEquipamento;
            //repositorioEquipamento.equipamentos[0] = novoEquipamento;
            contador++;

        }
        public void VisualizarEquipamento()
        {
            Console.WriteLine($"\nVisualização de Equipamento");

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10} | {4, -25} | {5, -20}",
                "ID", "Nome", "Preço", "Número de série", "Fabricante", "Data"
            );

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10} | {4, -25} | {5, -20}",
                e.id, e.nome, e.preco.ToString("C2"), e.numSerie, e.fabricante, e.data
            );
            }

            Console.Write($"\nInsira ENTER para sair.");
            Console.ReadLine();
        }

        public void EditarEquipamento(int idSelecionado)
        {
            Console.WriteLine($"\nEdição de Equipamento");

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento editarEquipamento = equipamentos[i];

                if (editarEquipamento.id == idSelecionado)
                {
                    Console.WriteLine("Qual deseja editar? \n 1 - Nome \n 2 - Preço \n 3 - Número de Série \n 4 - Fabricante \n 5 - Data \n S - Sair");
                    char opcaoEscolhida = Convert.ToChar(Console.ReadLine());

                    if (opcaoEscolhida == 'S') break;
                    switch (opcaoEscolhida)
                    {
                        case '1':
                            Console.Write("Insira o novo nome: ");
                            editarEquipamento.nome = Console.ReadLine();
                            break;
                        case '2':
                            Console.Write("Insira o novo preço: ");
                            editarEquipamento.preco = Convert.ToDouble(Console.ReadLine());
                            break;
                        case '3':
                            Console.Write("Insira o novo número de série: ");
                            editarEquipamento.numSerie = Convert.ToInt32(Console.ReadLine());
                            break;
                        case '4':
                            Console.Write("Insira o novo fabricante: ");
                            editarEquipamento.fabricante = Console.ReadLine();
                            break;
                        case '5':
                            Console.Write("Insira a novo data: ");
                            editarEquipamento.data = Console.ReadLine();
                            break;

                    }
                }
                break;
            }

            Console.Write($"\nEdição concluída.");
            Console.ReadLine();
        }

        public void ExcluirEquipamento(int id)
        {
            Equipamento equipamentoAtual = equipamentos[0];
        }

    }
    public class Equipamento
    {
        public int id = 12;
        public string nome = "teste";
        public double preco = 10.50;
        public int numSerie = 1212;
        public string data = "25/10/1999";
        public string fabricante = "Neereu";


    }
    public class RepositorioEquipamentos
    {
        public Equipamento[] equipamentos = new Equipamento[100];
    }
    public class TelaEquipamento
    {

        public char SelecionarOperacao()
        {
            Console.Clear();
            Console.WriteLine("Controle de Equipamentos");
            Console.WriteLine("O que deseja realizar?");
            Console.WriteLine("1 - Registrar equipamento");
            Console.WriteLine("2 - Editar equipamento");
            Console.WriteLine("3 - Visualizar equipamento");
            Console.WriteLine("4 - Excluir equipamento");
            Console.WriteLine("S - Sair");

            return Console.ReadLine().ToUpper()[0];
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ControleEquipamentos funcionario = new();
            funcionario.equipamentos = new Equipamento[100];

            TelaEquipamento telaEquipamento = new();

            while (true)
            {
                char opcaoEscolhida = telaEquipamento.SelecionarOperacao();

                if (opcaoEscolhida == 'S') break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        funcionario.RegistrarEquipamento();
                        break;
                    case '2':
                        Console.Write("Qual equipamento deseja editar? Insira o ID: ");
                        funcionario.EditarEquipamento(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case '3':
                        Console.Write("Lista de Equipamentos Cadastrados.");
                        funcionario.VisualizarEquipamento();
                        break;
                    case '4':
                        Console.Write("Qual equipamento deseja excluir? Insira o ID: ");
                        funcionario.ExcluirEquipamento(Convert.ToInt32(Console.ReadLine()));
                        break;
                }

            }

            TelaEquipamento opcao = new();
            opcao.SelecionarOperacao();


            Console.ReadLine();
        }
    }
}
