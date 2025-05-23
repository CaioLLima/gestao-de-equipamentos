using GestaoChamados.ModuloChamado;
using GestaoEquipamentos.Compartilhado;
using GestaoEquipamentos.ModuloChamado;
using GestaoEquipamentos.ModuloEquipamento;

namespace GestaoChamados.ModuloChamado
{
    public class TelaChamado
    {
        public RepositorioEquipamentos repositorioEquipamentos;
        public RepositorioChamados repositorioChamados;
        public TelaChamado(RepositorioEquipamentos repoEquipamentos, RepositorioChamados repoChamados)
        {
            repositorioEquipamentos = repoEquipamentos;
            repositorioChamados = repoChamados;
        }
        public char SelecionarOperacao()
        {
            Console.Clear();
            Console.WriteLine("Controle de Chamados");
            Console.WriteLine("O que deseja realizar?");
            Console.WriteLine("1 - Registrar chamados");
            Console.WriteLine("2 - Editar chamados");
            Console.WriteLine("3 - Visualizar chamados");
            Console.WriteLine("4 - Excluir chamados");
            Console.WriteLine("S - Sair");

            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];
            return opcaoEscolhida;
        }
        public void RegistrarChamado()
        {
            Console.WriteLine($"\nRegistro de novo Chamado");
            Chamado chamado = ObterDados();

            repositorioChamados.CadastrarRegistro(chamado);

        }
        public void VisualizarChamado()
        {
            Console.WriteLine($"\nVisualização de Chamado");

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10} | {4, -10}",
                "ID", "Titulo", "Data", "Descrição", "Equipamento"
            );
            EntidadeBase[] chamados = repositorioChamados.SelecionarRegistros();

            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado e = (Chamado)chamados[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -10} | {3, -10} | {4, -10}",
                e.id, e.titulo, e.data, e.descricao, e.equipamento.nome
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

            Chamado chamadoAtualizado = ObterDados();


            bool conseguiuEditar = repositorioChamados.EditarRegistro(idSelecionado, chamadoAtualizado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi possível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nChamado \"{chamadoAtualizado.titulo}\" editado com sucesso!");
            Console.ReadLine();
        }
        public void ExcluirChamado()
        {
            Console.WriteLine($"\nExclusão de Chamado");

            VisualizarChamado();

            Console.Write("\nQual chamado deseja Excluir? Insira o ID: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());
            bool conseguiuExcluir = repositorioChamados.ExcluirRegistro(idSelecionado);

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Não foi possível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nChamado excluído com sucesso!");
            Console.ReadLine();
        }
        public Chamado ObterDados()
        {
            Console.Write($"Titulo: ");
            string titulo = Console.ReadLine();
            Console.Write($"Data: ");
            string data = Console.ReadLine();
            Console.Write($"Descrição ");
            string descricao = Console.ReadLine();

            VisualizarEquipamentos();

            Console.Write("Digite o ID do equipamento que deseja selecionar: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            EntidadeBase equipamentoSelecionado = repositorioEquipamentos.SelecionarRegistroPorId(idEquipamento);

            Chamado chamado = new Chamado();
            chamado.titulo = titulo;
            chamado.descricao = descricao;
            chamado.data = data;
            chamado.equipamento = (Equipamento)equipamentoSelecionado;

            return chamado;

        }
        public void VisualizarEquipamentos()
        {
            Console.WriteLine();

            Console.WriteLine("Visualização de Equipamentos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
                "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );

            EntidadeBase[] equipamentos = repositorioEquipamentos.SelecionarRegistros();

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = (Equipamento)equipamentos[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
                    e.id, e.nome, e.preco.ToString("C2"), e.numSerie, e.fabricante, e.data
                );
            }

            Console.ReadLine();
        }
    }
}
