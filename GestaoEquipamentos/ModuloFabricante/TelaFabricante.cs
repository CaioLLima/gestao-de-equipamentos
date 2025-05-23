using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipamentos.Compartilhado;
using GestaoEquipamentos.ModuloFabricante;
using GestaoFabricantes.ModuloFabricante;

namespace GestaoFabricantes.ModuloFabricante
{
    public class TelaFabricante
    {
        private RepositorioFabricante repositorioFabricante = new();

        public TelaFabricante(RepositorioFabricante repositorioF)
        {
            repositorioFabricante = repositorioF;
        }
        public char SelecionarOperacao()
        {
            Console.Clear();
            Console.WriteLine("Controle de Chamados");
            Console.WriteLine("O que deseja realizar?");
            Console.WriteLine("1 - Registrar fabricante");
            Console.WriteLine("2 - Editar fabricante");
            Console.WriteLine("3 - Visualizar fabricantes");
            Console.WriteLine("4 - Excluir fabricante");
            Console.WriteLine("S - Sair");

            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];
            return opcaoEscolhida;
        }
        public void RegistrarFabricante()
        {
            Console.WriteLine($"\nRegistro de novo Fabricante");
            Fabricante fabricante = ObterDados();

            string erros = fabricante.Validar();

            if (erros.Length > 0)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(erros);
                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

                RegistrarFabricante();

                return;
            }
            repositorioFabricante.CadastrarRegistro(fabricante);
        }
        public void VisualizarFabricante()
        {
            Console.WriteLine($"\nVisualização de Fabricante");

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10}",
                "ID", "Nome", "Email", "Telefone"
            );
            EntidadeBase[] fabricantes = repositorioFabricante.SelecionarRegistros();
            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricante e = (Fabricante)fabricantes[i];

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

            Fabricante editarFabricante = ObterDados();

            Console.WriteLine("Qual deseja editar? \n 1 - Nome \n 2 - Email \n 3 - Telefone \n S - Sair");
            char opcaoEscolhida = Convert.ToChar(Console.ReadLine());

            if (opcaoEscolhida == 'S') return;
            switch (opcaoEscolhida)
            {
                case '1':
                    Console.Write("Insira o novo nome: ");
                    editarFabricante.nome = Console.ReadLine();
                    break;
                case '2':
                    Console.Write("Insira o novo email: ");
                    editarFabricante.email = Console.ReadLine();
                    break;
                case '3':
                    Console.Write("Insira o novo telefone: ");
                    editarFabricante.telefone = Console.ReadLine();
                    break;
            }
            repositorioFabricante.EditarRegistro(idSelecionado, editarFabricante);

            Console.Write($"\nEdição concluída.");
            Console.ReadLine();
        }
        public void ExcluirFabricante()
        {
            Console.WriteLine($"\nExclusão de Fabricante");

            VisualizarFabricante();

            Console.Write("\nQual Fabricante deseja Excluir? Insira o ID: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            repositorioFabricante.ExcluirRegistro(idSelecionado);

            Console.WriteLine($"Fabricante excluído com sucesso.");
            Console.ReadLine();
        }
        private Fabricante ObterDados()
        {
            Console.Write($"Nome: ");
            string nome = Console.ReadLine();
            Console.Write($"Telefone: ");
            string telefone = Console.ReadLine(); 
            Console.Write($"Email: ");
            string email = Console.ReadLine();

            Fabricante fabricante = new Fabricante(nome, telefone, email);

            Console.ReadLine();

            return fabricante;

        }
    }
}
