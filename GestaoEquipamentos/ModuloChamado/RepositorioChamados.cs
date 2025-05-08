using GestaoEquipamentos.ModuloEquipamento;

namespace GestaoEquipamentos.ModuloChamado
{
    public class RepositorioChamados
    {
        public Chamado[] chamados = new Chamado[100];
        public int contador = 0;
        public RepositorioEquipamentos repositorioEquipamento;
        public Equipamento[] equipamentos;

        public void RegistrarChamado()
        {
            Console.WriteLine($"\nRegistro de novo Equipamento");
            Chamado novoChamado = new Chamado();

            novoChamado.id = contador;
            Console.Write($"Titulo: ");
            novoChamado.titulo = Console.ReadLine();
            Console.Write($"Descrição: ");
            novoChamado.descricao = Console.ReadLine();
            Console.Write($"Data: ");
            novoChamado.data = Console.ReadLine();

            VisualizarEquipamento();

            Console.Write("Digite o ID do equipamento que deseja selecionar: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            novoChamado.equipamentos = repositorioEquipamento.SelecionarEquipamentoPorId(idEquipamento);
            Console.Write($"\nRegistro concluído.");
            Console.ReadLine();
            chamados[contador] = novoChamado;
            contador++;

        }
        public void VisualizarChamado()
        {
            Console.WriteLine($"\nVisualização de Chamado");

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10} | {4, -25}",
                "ID", "Título", "Descrição", "Data", "Equipamento"
            );

            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado e = chamados[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10} | {4, -25}",
                e.id, e.titulo, e.descricao, e.data, e.equipamentos.nome
            );
            }

            Console.Write($"\nInsira ENTER para continuar.");
            Console.ReadLine();
        }
        public void EditarChamado()
        {
            Console.WriteLine($"\nEdição de Chamado");

            VisualizarChamado();

            Console.Write("\nQual chamado deseja editar? Insira o ID: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado editarChamado = chamados[i];

                if (editarChamado.id == idSelecionado)
                {
                    Console.WriteLine("Qual deseja editar? \n 1 - Título \n 2 - Descrição \n 3 - Data \n 4 - Equipamento \n S - Sair");
                    char opcaoEscolhida = Convert.ToChar(Console.ReadLine());

                    if (opcaoEscolhida == 'S') break;
                    switch (opcaoEscolhida)
                    {
                        case '1':
                            Console.Write("Insira o novo título: ");
                            editarChamado.titulo = Console.ReadLine();
                            break;
                        case '2':
                            Console.Write("Insira a novo descrição: ");
                            editarChamado.descricao = Console.ReadLine();
                            break;
                        case '3':
                            Console.Write("Insira a nova data: ");
                            editarChamado.data = Console.ReadLine();
                            break;
                        case '4':
                            VisualizarEquipamento();

                            Console.Write("Digite o ID do equipamento que deseja selecionar: ");
                            int idEquipamento = Convert.ToInt32(Console.ReadLine());

                            editarChamado.equipamentos = repositorioEquipamento.SelecionarEquipamentoPorId(idEquipamento);
                            break;
                        

                    }
                }
                break;
            }

            Console.Write($"\nEdição concluída.");
            Console.ReadLine();
        }
        public void ExcluirChamado()
        {
            Console.WriteLine($"\nExclusão de Chamado");

            VisualizarChamado();

            Console.Write("Qual chamado deseja Excluir? Insira o ID: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado editarChamado = chamados[i];

                if (chamados[i] == null)
                    continue;

                if (editarChamado.id == idSelecionado)
                {
                    chamados[i] = null;
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
