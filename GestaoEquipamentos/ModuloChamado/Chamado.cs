using GestaoEquipamentos.Compartilhado;
using GestaoEquipamentos.ModuloEquipamento;

namespace GestaoEquipamentos.ModuloChamado
{
    public class Chamado : EntidadeBase
    {
        public string titulo;
        public string data;
        public Equipamento equipamento;
        public string descricao;

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Chamado chamadoAtualizado = (Chamado)registroAtualizado;

            this.titulo = chamadoAtualizado.titulo;
            this.data = chamadoAtualizado.data;
            this.descricao = chamadoAtualizado.descricao;
            this.equipamento = chamadoAtualizado.equipamento;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(titulo))
                erros += "O campo \"Nome\" é obrigatório.\n";

            else if (titulo.Length < 3)
                erros += "O campo \"Nome\" precisa conter ao menos 3 caracteres.\n";

            if (descricao.Length > 4)
                erros += "O campo \"Descrição\" deve ser maior que quatro caracteres.\n";

            if (data.Length > 4)
                erros += "O campo \"Data de Fabricação\" deve conter uma data passada.\n";

            return erros;
        }
    }
     
    }
