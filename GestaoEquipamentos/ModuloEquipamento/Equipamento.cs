using GestaoEquipamentos.Compartilhado;

namespace GestaoEquipamentos.ModuloEquipamento;

public class Equipamento : EntidadeBase
{
    public string nome;
    public double preco;
    public int numSerie;
    public string data;
    public string fabricante;

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Equipamento equipamentoAtualizado = (Equipamento)registroAtualizado;

        this.nome = equipamentoAtualizado.nome;
        this.preco = equipamentoAtualizado.preco;
        this.numSerie = equipamentoAtualizado.numSerie;
        this.fabricante = equipamentoAtualizado.fabricante;
        this.data = equipamentoAtualizado.data;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(nome))
            erros += "O campo \"Nome\" é obrigatório.\n";

        else if (nome.Length < 3)
            erros += "O campo \"Nome\" precisa conter ao menos 3 caracteres.\n";

        if (preco <= 0)
            erros += "O campo \"Preço de Aquisição\" deve ser maior que zero.\n";

        if (data.Length > 4)
            erros += "O campo \"Data de Fabricação\" deve conter uma data passada.\n";

        return erros;
    }
}


