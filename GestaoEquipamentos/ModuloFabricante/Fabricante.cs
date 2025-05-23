using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipamentos.ModuloChamado;
using GestaoEquipamentos.ModuloEquipamento;

namespace GestaoEquipamentos.ModuloFabricante
{
    public class Fabricante
    {
        public int id;
        public string nome;
        public string telefone;
        public string email;

        public Fabricante(string nome,string telefone, string email)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
        }
        public string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(nome))
                erros += "O nome é obrigatório!\n";

            else if (nome.Length < 2)
                erros += "O nome deve conter mais que 1 caractere!\n";

            if (!MailAddress.TryCreate(email, out _))
                erros += "O email deve conter um formato válido \"nome@provedor.com\"!\n";

            if (string.IsNullOrWhiteSpace(telefone))
                erros += "O telefone é obrigatório!\n";

            else if (telefone.Length < 9)
                erros += "O telefone deve conter no mínimo 9 caracteres!\n";

            return erros;
        }

        public void AtualizarRegistro(Fabricante fabricanteAtualizado)
        {
            this.nome = fabricanteAtualizado.nome;
            this.email = fabricanteAtualizado.email;
            this.telefone = fabricanteAtualizado.telefone;
        }
    }
}
