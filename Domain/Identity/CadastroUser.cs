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
    }
}
