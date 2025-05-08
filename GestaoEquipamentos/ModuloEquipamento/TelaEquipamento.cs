namespace GestaoEquipamentos.ModuloEquipamento
{
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

            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];
            return opcaoEscolhida;
        }

    }
}
