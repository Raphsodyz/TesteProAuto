using Application.DTOs;
using Application.Interfaces;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CadastroUserApplication : ICadastroUserApplication
    {
        public Task<SignInResult> Login(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> Register(RegisterDTO registerDTO)
        {
            throw new NotImplementedException();
        }

        public Task<CadastroUser> UserExist(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
