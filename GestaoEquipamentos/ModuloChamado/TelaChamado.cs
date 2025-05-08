namespace GestaoEquipamentos.ModuloChamado
{
    public class TelaChamado
    {
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
    }
}
