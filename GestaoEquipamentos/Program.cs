using System.Globalization;

namespace GestaoEquipamentos
{
   public class ControleEquipamentos
    {
        public Equipamento[] equipamentos;
        public int contador = 0;
        public void RegistrarEquipamentos()
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

            equipamentos[contador] = novoEquipamento;
            contador++;

        }
        public void VisualizarEquipamentos(int id)
        {
            Console.WriteLine($"\nVisualização de Equipamento");

            Equipamento equipamentoAtual = equipamentos[0];

            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Nome: {equipamentoAtual.nome}");
            Console.WriteLine($"Preço: {equipamentoAtual.preco}");
            Console.WriteLine($"Número de série: {equipamentoAtual.numSerie}");
            Console.WriteLine($"Data: {equipamentoAtual.data}");
            Console.WriteLine($"Fabricante: {equipamentoAtual.fabricante}");           
        }

        public void EditarEquipamentos(int id)
        {
            Console.WriteLine($"\nEdição de Equipamento");

            Equipamento equipamentoAtual = equipamentos[0];

            Console.Write($"ID: {id} ");
            Console.Write($"Nome: ");
            equipamentoAtual.nome = Console.ReadLine();
            Console.Write($"Preço: ");
            equipamentoAtual.preco = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Número de série: ");
            equipamentoAtual.numSerie = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Data: ");
            equipamentoAtual.data = Console.ReadLine();
            Console.Write($"Fabricante: ");
            equipamentoAtual.fabricante = Console.ReadLine();
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
    internal class Program
    {
        static void Main(string[] args)
        {
            ControleEquipamentos funcionario = new();

            funcionario.equipamentos = new Equipamento[100];
            funcionario.RegistrarEquipamentos();
            funcionario.VisualizarEquipamentos(12);
            funcionario.EditarEquipamentos(12);
            funcionario.VisualizarEquipamentos(12);

            Console.ReadLine();
        }
    }
}
