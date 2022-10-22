using Data.Context;
using Domain.Entities;
using Domain.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class AssociadoRepository : Repository<Associado>, IAssociadoRepository
    {
        public AssociadoRepository(CadastroContext cadastroContext): base(cadastroContext)
        {

        }
        public override bool Exist(int id)
        {
            return _cadastroContext.Associados.Any(a => a.Id == id);
        }

        public override async Task<Associado> Find(int id)
        {
            return await _cadastroContext.Associados.FindAsync(id);
        }

        public override async Task<Associado> Get(int id)
        {
            return await _cadastroContext.Associados.Include(a => a.Endereco)
                .Include(a => a.Endereco).Where(a => a.Id == id).FirstAsync();
        }

        public override async Task<List<Associado>> GetAll()
        {
            return await _cadastroContext.Associados.Include(a => a.Endereco)
                .Include(a => a.Endereco).ToListAsync();
        }

        public override async void Delete(int id)
        {
            var entity = await _cadastroContext.Associados.FindAsync(id);
            _cadastroContext.Associados.Remove(entity);
        }
    }
}
