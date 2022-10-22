using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Intefaces
{
    public interface ICadastroUserRepository
    {
        Task<IdentityResult> Register(CadastroUser cadastroUser);
        Task<CadastroUser> UserExist(string cpf);
        Task<SignInResult> Login(CadastroUser cadastroUser, string placa);
    }
}
