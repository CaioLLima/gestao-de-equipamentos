using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipamentos.ModuloEquipamento;

namespace GestaoEquipamentos.ModuloFabricante
{
    class RepositorioFabricante
    {
        public Fabricante[] fabricantes = new Fabricante[100];
        public int contador = 0;
        public RepositorioEquipamentos repositorioEquipamento;
        public Equipamento[] equipamentos;

        public void RegistrarFabricante()
        {
            Console.WriteLine($"\nRegistro de novo Fabricante");
            Fabricante novoFabricante = new Fabricante();

            novoFabricante.id = contador;
            Console.Write($"Nome: ");
            novoFabricante.nome = Console.ReadLine();
            Console.Write($"Email: ");
            novoFabricante.email = Console.ReadLine();
            Console.Write($"Telefone: ");
            novoFabricante.telefone = Console.ReadLine();

            //VisualizarEquipamento();

            //Console.Write("Digite o ID do equipamento que deseja selecionar: ");
            //int idEquipamento = Convert.ToInt32(Console.ReadLine());

            //novoFabricante.equipamentos = repositorioEquipamento.SelecionarEquipamentoPorId(idEquipamento);
            Console.Write($"\nRegistro concluído.");
            Console.ReadLine();
            fabricantes[contador] = novoFabricante;
            contador++;

        }
        public void VisualizarFabricante()
        {
            Console.WriteLine($"\nVisualização de Fabricante");

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10}",
                "ID", "Nome", "Email", "Telefone"
            );

            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricante e = fabricantes[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10}",
                e.id, e.nome, e.email, e.telefone
            );
            }

            Console.Write($"\nInsira ENTER para continuar.");
            Console.ReadLine();
        }
        public void EditarFabricante()
        {
            Console.WriteLine($"\nEdição de Fabricante");

            VisualizarFabricante();

            Console.Write("\nQual Fabricante deseja editar? Insira o ID: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricante editarFabricante = fabricantes[i];

                if (editarFabricante.id == idSelecionado)
                {
                    Console.WriteLine("Qual deseja editar? \n 1 - Nome \n 2 - Email \n 3 - Telefone \n S - Sair");
                    char opcaoEscolhida = Convert.ToChar(Console.ReadLine());

                    if (opcaoEscolhida == 'S') break;
                    switch (opcaoEscolhida)
                    {
                        case '1':
                            Console.Write("Insira o novo nome: ");
                            editarFabricante.nome = Console.ReadLine();
                            break;
                        case '2':
                            Console.Write("Insira a novo email: ");
                            editarFabricante.email = Console.ReadLine();
                            break;
                        case '3':
                            Console.Write("Insira a nova telefone: ");
                            editarFabricante.telefone = Console.ReadLine();
                            break;
                    }
                }
                break;
            }

            Console.Write($"\nEdição concluída.");
            Console.ReadLine();
        }
        public void ExcluirFabricante()
        {
            Console.WriteLine($"\nExclusão de Fabricante");

            VisualizarFabricante();

            Console.Write("Qual Fabricante deseja Excluir? Insira o ID: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricante editarFabricante = fabricantes[i];

                if (fabricantes[i] == null)
                    continue;

                if (editarFabricante.id == idSelecionado)
                {
                    fabricantes[i] = null;
                }
                break;
            }
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

            Console.Write($"\nInsira ENTER para continuar.");
            Console.ReadLine();
        }
    }
}
