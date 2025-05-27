namespace GestaoEquipamentos.Compartilhado
{
    public abstract class TelaBase
    {
        protected string nomeEntidade;
        protected RepositorioBase repositorio;

        protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
        {
            this.nomeEntidade = nomeEntidade;
            this.repositorio = repositorio;
        }

        public char SelecionarOperacao()
        {
            Console.Clear();
            Console.WriteLine("Controle de Chamados");
            Console.WriteLine("O que deseja realizar?");
            Console.WriteLine($"1 - Registrar {nomeEntidade}");
            Console.WriteLine($"2 - Editar {nomeEntidade}");
            Console.WriteLine($"3 - Visualizar {nomeEntidade}");
            Console.WriteLine($"4 - Excluir {nomeEntidade}");
            Console.WriteLine("S - Sair");

            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];
            return opcaoEscolhida;
        }

        public void CadastrarRegistro()
        {

            Console.WriteLine($"Cadastro de {nomeEntidade}");

            Console.WriteLine();

            EntidadeBase novoRegistro = ObterDados();

            string erros = novoRegistro.Validar();

            if (erros.Length > 0)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(erros);
                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

                CadastrarRegistro();

                return;
            }

            repositorio.CadastrarRegistro(novoRegistro);

            Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
            Console.ReadLine();
        }

        public void EditarRegistro()
        {

            Console.WriteLine($"Edição de {nomeEntidade}");

            Console.WriteLine();

            VisualizarRegistros();

            Console.Write("Digite o id do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            EntidadeBase registroAtualizado = ObterDados();

            repositorio.EditarRegistro(idSelecionado, registroAtualizado);

            Console.WriteLine($"\n{nomeEntidade} editado com sucesso!");
            Console.ReadLine();
        }

        public void ExcluirRegistro()
        {

            Console.WriteLine($"Exclusão de {nomeEntidade}");

            Console.WriteLine();

            VisualizarRegistros();

            Console.Write("Digite o id do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            repositorio.ExcluirRegistro(idSelecionado);

            Console.WriteLine($"\n{nomeEntidade} excluído com sucesso!");
            Console.ReadLine();
        }

        public abstract void VisualizarRegistros();

        protected abstract EntidadeBase ObterDados();
    }
}
