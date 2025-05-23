namespace GestaoEquipamentos.ModuloEquipamento
{
    public class TelaEquipamento
    {
        public RepositorioEquipamentos repositorioEquipamento = new();
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

            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];
            return opcaoEscolhida;
        }
        public void RegistrarEquipamento()
        {
            Console.WriteLine($"\nRegistro de novo Equipamento");
            Equipamento equipamento = ObterDados();

            repositorioEquipamento.CadastrarEquipamento(equipamento);

        }
        public void VisualizarEquipamento()
        {
            Console.WriteLine($"\nVisualização de Equipamento");

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10} | {4, -25} | {5, -20}",
                "ID", "Nome", "Preço", "Número de série", "Fabricante", "Data"
            );
            Equipamento[] equipamentos = repositorioEquipamento.SelecionarEquipamentos();

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
        public void EditarEquipamento()
        {
            Console.WriteLine($"\nEdição de Equipamento");

            VisualizarEquipamento();

            Console.Write("\nQual equipamento deseja editar? Insira o ID: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoAtualizado = ObterDados();

            bool conseguiuEditar = repositorioEquipamento.EditarEquipamentos(idSelecionado, equipamentoAtualizado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi possível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nEquipamento \"{equipamentoAtualizado.nome}\" editado com sucesso!");
            Console.ReadLine();

            
        }
        public void ExcluirEquipamento()
        {
            Console.WriteLine($"\nExclusão de Equipamento");

            VisualizarEquipamento();

            Console.Write("\nQual equipamento deseja Excluir? Insira o ID: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioEquipamento.ExcluirEquipamento(idSelecionado);

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Não foi possível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nEquipamento excluído com sucesso!");
            Console.ReadLine();
        }  
        public Equipamento ObterDados()
        {
            Equipamento equipamento = new Equipamento();

            Console.Write($"Nome: ");
            equipamento.nome = Console.ReadLine();
            Console.Write($"Preço: ");
            equipamento.preco = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Número de série: ");
            equipamento.numSerie = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Data: ");
            equipamento.data = Console.ReadLine();
            Console.Write($"Fabricante: ");
            equipamento.fabricante = Console.ReadLine();
            Console.Write($"\nRegistro concluído.");
            Console.ReadLine();
            
            return equipamento;

        }

    }
}
