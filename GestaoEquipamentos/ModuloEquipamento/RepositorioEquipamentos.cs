namespace GestaoEquipamentos.ModuloEquipamento
{
    public class RepositorioEquipamentos
    {
        public int contador = 0;
        public Equipamento[] equipamentos = new Equipamento[100];
        public void CadastrarEquipamento(Equipamento equipamento)
        {
            equipamento.id = contador;
            equipamentos[contador] = equipamento;
            contador++;
        }
        public bool EditarEquipamentos(int idSelecionado, Equipamento equipamentoAtualizado)
        {
            Equipamento equipamento = SelecionarEquipamentoPorId(idSelecionado);

            if (equipamento == null)
                return false;

            equipamento.nome = equipamentoAtualizado.nome;
            equipamento.numSerie = equipamentoAtualizado.numSerie;
            equipamento.preco = equipamentoAtualizado.preco;
            equipamento.data = equipamentoAtualizado.data;
            equipamento.fabricante = equipamentoAtualizado.fabricante;

            return true;
        }
        public bool ExcluirEquipamento(int idSelecionado)
        {
            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i] == null)
                    continue;

                if (equipamentos[i].id == idSelecionado)
                {
                    equipamentos[i] = null;

                    return true;
                }
            }

            return false;
        }
        public Equipamento[] SelecionarEquipamentos()
        {
            return equipamentos;
        }
        public Equipamento SelecionarEquipamentoPorId(int idSelecionado)
        {
            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                if (e.id == idSelecionado)
                    return e;
            }

            return null;
        }
    }
}
