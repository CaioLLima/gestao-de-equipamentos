using GestaoChamados.ModuloChamado;
using GestaoEquipamentos.ModuloChamado;

namespace GestaoChamados.ModuloChamado
{
    public class RepositorioChamados
    {
        public Chamado[] chamados = new Chamado[100];
        public int contador = 0;

        public void CadastrarChamado(Chamado chamado)
        {
            chamado.id = contador;
            chamados[contador] = chamado;
            contador++;
        }
        public bool EditarChamados(int idSelecionado, Chamado chamadoAtualizado)
        {
            Chamado chamado = SelecionarChamadoPorId(idSelecionado);

            if (chamado == null)
                return false;

            chamado.titulo = chamadoAtualizado.titulo;
            chamado.data = chamadoAtualizado.data;
            chamado.descricao = chamadoAtualizado.descricao;
            

            return true;
        }
        public bool ExcluirChamado(int idSelecionado)
        {
            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] == null)
                    continue;

                if (chamados[i].id == idSelecionado)
                {
                    chamados[i] = null;

                    return true;
                }
            }

            return false;
        }
        public Chamado[] SelecionarChamados()
        {
            return chamados;
        }
        public Chamado SelecionarChamadoPorId(int idSelecionado)
        {
            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado e = chamados[i];

                if (e == null)
                    continue;

                if (e.id == idSelecionado)
                    return e;
            }

            return null;
        }
    }
}
