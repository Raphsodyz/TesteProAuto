using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Identity;
using Domain.Intefaces;
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
        private readonly ICadastroUserRepository _cadastroUserRepository;
        private readonly IMapper _mapper;

        public CadastroUserApplication(ICadastroUserRepository cadastroUserRepository, IMapper mapper)
        {
            _cadastroUserRepository = cadastroUserRepository;
            _mapper = mapper;
        }

        public async Task<string> JWT(CadastroUser cadastroUser)
        {
            return await _cadastroUserRepository.JWT(cadastroUser);
        }

        public async Task<SignInResult> Login(LoginDTO loginDTO)
        {
            var user = await _cadastroUserRepository.UserExist(_mapper.Map<CadastroUser>(loginDTO).CPF);
            
            if (user == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            
            var access = await _cadastroUserRepository.Login(user, _mapper.Map<CadastroUser>(loginDTO).Placa);
            
            if (access.Succeeded)
            {
                return SignInResult.Success;
            }

            throw new Exception("Não é possível se logar no momento.");
        }

        public async Task<IdentityResult> Register(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<CadastroUser>(registerDTO);
            var register = await _cadastroUserRepository.Register(user);

            if (register.Succeeded)
            {
                return IdentityResult.Success;
            }
            else
                throw new Exception("Criação de contas está disponível.");
        }

        public async Task<CadastroUser> UserExist(string cpf)
        {
            return await _cadastroUserRepository.UserExist(cpf);
        }
    }
}
