using Core.Dto;

namespace Core.Service
{
    public interface IAutorService
    {
        IEnumerable<Autor> GetAll();

        IEnumerable<AutorDto> GetByName(string nome);
    }
}
