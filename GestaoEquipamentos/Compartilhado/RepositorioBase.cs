using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipamentos.ModuloFabricante;

namespace GestaoEquipamentos.Compartilhado
{
    public class RepositorioBase
    {
        private EntidadeBase[] registros = new EntidadeBase[100];
        private int contador;

        public void CadastrarRegistro(EntidadeBase registro)
        {
            registro.id = contador;
            registros[contador] = registro;
            contador++;
        }
        public bool EditarRegistro(int idSelecionado, EntidadeBase registroAtualizado)
        {
            EntidadeBase registro = SelecionarRegistroPorId(idSelecionado);

            if (registro == null)
                return false;

            registro.AtualizarRegistro(registroAtualizado);

            return true;
        }
        public bool ExcluirRegistro(int idSelecionado)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                    continue;

                if (registros[i].id == idSelecionado)
                {
                    registros[i] = null;

                    return true;
                }
            }

            return false;
        }
        public EntidadeBase[] SelecionarRegistros()
        {
            return registros;
        }
        public EntidadeBase SelecionarRegistroPorId(int idSelecionado)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                EntidadeBase e = registros[i];

                if (e == null)
                    continue;

                if (e.id == idSelecionado)
                    return e;
            }

            return null;
        }
    }
}
