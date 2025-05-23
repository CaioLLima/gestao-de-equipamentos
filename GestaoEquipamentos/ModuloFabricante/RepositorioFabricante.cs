using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipamentos.Compartilhado;
using GestaoEquipamentos.ModuloEquipamento;
using GestaoEquipamentos.ModuloFabricante;
using GestaoFabricantes.ModuloFabricante;

namespace GestaoFabricantes.ModuloFabricante
{
    public class RepositorioFabricante : RepositorioBase
    {
        private Fabricante[] fabricantes = new Fabricante[100];
        private int contador;
       
        public void CadastrarFabricante(Fabricante fabricante)
        {
            fabricante.id = contador;
            fabricantes[contador] = fabricante;
            contador++;
        }
        public bool EditarFabricante(int idSelecionado, Fabricante fabricanteAtualizado)
        {
            Fabricante fabricante = SelecionarFabricantePorId(idSelecionado);

            if (fabricante == null)
                return false;

            fabricante.AtualizarRegistro(fabricanteAtualizado);
            
            return true;
        }
        public bool ExcluirFabricante(int idSelecionado)
        {
            for (int i = 0; i < fabricantes.Length; i++)
            {
                if (fabricantes[i] == null)
                    continue;

                if (fabricantes[i].id == idSelecionado)
                {
                    fabricantes[i] = null;

                    return true;
                }
            }

            return false;
        }
        public Fabricante[] SelecionarFabricantes()
        {
            return fabricantes;
        }
        public Fabricante SelecionarFabricantePorId(int idSelecionado)
        {
            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricante e = fabricantes[i];

                if (e == null)
                    continue;

                if (e.id == idSelecionado)
                    return e;
            }

            return null;
        }
    }
}
