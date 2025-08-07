using Core.Dto;

namespace Core.Service
{
    public interface IAutorService
    {
        IEnumerable<Autor> GetAll();

        IEnumerable<Autor> GetByNome(string nome);
    }
}
