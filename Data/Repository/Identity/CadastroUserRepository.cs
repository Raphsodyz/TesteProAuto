using Data.Context;
using Domain.Entities;
using Domain.Identity;
using Domain.Intefaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Identity
{
    public class CadastroUserRepository : ICadastroUserRepository
    {
        protected readonly UserManager<CadastroUser> _userManager;
        protected readonly SignInManager<CadastroUser> _signInManager;
        protected readonly CadastroContext _cadastroContext;

        public CadastroUserRepository(UserManager<CadastroUser> userManager,
                                  SignInManager<CadastroUser> signInManager,
                                  CadastroContext cadastroContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cadastroContext = cadastroContext;
        }

        public async Task<IdentityResult> Register(CadastroUser cadastroUser)
        {
            return await _userManager.CreateAsync(cadastroUser, cadastroUser.CPF);
        }

        public async Task<CadastroUser> UserExist(string cpf)
        {
            return await _cadastroContext.Users.Where(c => c.CPF == cpf).FirstAsync();
        }

        public async Task<SignInResult> Login(CadastroUser cadastroUser, string placa)
        {
            return await _signInManager.CheckPasswordSignInAsync(cadastroUser, placa, true);
        }
    }
}
