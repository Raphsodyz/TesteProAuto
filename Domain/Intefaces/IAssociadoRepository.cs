using Domain.Entities;

namespace Domain.Intefaces
{
    public interface IAssociadoRepository : IRepository<Associado>
    {
        Task<Associado> GetByCPF(string cpf);
    }
}
