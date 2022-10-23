using Application.DTOs;

namespace Application.Interfaces
{
    public interface IAssociadoApplication : IApplication<AssociadoDTO>
    {
        Task<AssociadoDTO> GetByCPF(string cpf);
    }
}
