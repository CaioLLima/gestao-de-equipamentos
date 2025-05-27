using GestaoEquipamentos.Compartilhado;
using GestaoFabricantes.ModuloFabricante;

namespace GestaoEquipamentos.ModuloEquipamento
{
    public class TelaEquipamento : TelaBase
    {
        public RepositorioEquipamentos repositorioEquipamento = new();

        public TelaEquipamento(RepositorioEquipamentos repositorioF) : base("Equipamento", repositorioF)
        {
            repositorioEquipamento = repositorioF;
        }
        
        public void RegistrarRegistro()
        {
            Console.WriteLine($"\nRegistro de novo Equipamento");
            Equipamento equipamento = ObterDados();

            repositorioEquipamento.CadastrarRegistro(equipamento);

        }
        public override void VisualizarRegistros()
        {
            Console.WriteLine($"\nVisualização de Equipamento");

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10} | {4, -25} | {5, -20}",
                "ID", "Nome", "Preço", "Número de série", "Fabricante", "Data"
            );
            EntidadeBase[] equipamentos = repositorioEquipamento.SelecionarRegistros();

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = (Equipamento)equipamentos[i];

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
        public void EditarRegistros()
        {
            Console.WriteLine($"\nEdição de Equipamento");

            VisualizarRegistros();

            Console.Write("\nQual equipamento deseja editar? Insira o ID: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoAtualizado = ObterDados();

            bool conseguiuEditar = repositorioEquipamento.EditarRegistro(idSelecionado, equipamentoAtualizado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi possível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nEquipamento \"{equipamentoAtualizado.nome}\" editado com sucesso!");
            Console.ReadLine();

            
        }
        public void ExcluirRegistros()
        {
            Console.WriteLine($"\nExclusão de Equipamento");

            VisualizarRegistros();

            Console.Write("\nQual equipamento deseja Excluir? Insira o ID: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioEquipamento.ExcluirRegistro(idSelecionado);

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Não foi possível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nEquipamento excluído com sucesso!");
            Console.ReadLine();
        }  
        protected override Equipamento ObterDados()
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
