using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Domain.Identity
{
    public class CadastroUser : IdentityUser<int>
    {
        public string CPF { get; set; }
        public string Placa { get; set; }
        public int? AssociadoId { get; set; }

        [JsonIgnore]
        public Associado Associado { get; set; }

        public Endereco CriarEndereco(CadastroUser cadastroUser)
        {
            Endereco endereco = new Endereco()
            {
                Id = 0,
                CEP = cadastroUser.Associado.Endereco.CEP,
                Rua = cadastroUser.Associado.Endereco.Rua,
                Numero = cadastroUser.Associado.Endereco.Numero,
                Bairro = cadastroUser.Associado.Endereco.Bairro,
                Cidade = cadastroUser.Associado.Endereco.Cidade,
                Estado = cadastroUser.Associado.Endereco.Estado,
                Pais = cadastroUser.Associado.Endereco.Pais,
                Observacao = cadastroUser.Associado.Endereco.Observacao
            };

            return endereco;
        }

        public Carro CriarCarro(CadastroUser cadastroUser)
        {
            Carro carro = new Carro()
            {
                Id = 0,
                Placa = cadastroUser.Associado.Carro.Placa,
                Modelo = cadastroUser.Associado.Carro.Modelo
            };

            return carro;
        }

        public Associado CriarAssociado(CadastroUser cadastroUser)
        {
            Associado associado = new Associado() 
            {
                Id = 0,
                Nome = cadastroUser.Associado.Nome,
                CPF = cadastroUser.Associado.CPF,
                Telefone = cadastroUser.Associado.Telefone
            };

            return associado;
        }
    }
}
