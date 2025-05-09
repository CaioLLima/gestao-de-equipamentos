using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ModuloFabricante
{
    class TelaFabricante
    {
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
    }
}
