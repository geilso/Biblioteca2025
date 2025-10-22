using Core.Dto;

namespace Core.Service
{
    public interface IAutorService
    {
        int Create(Autor autor);
        void Edit(Autor autor);
        void Delete(uint id);
        Autor Get(uint id);
        IEnumerable<Autor> GetAll();
        IEnumerable<AutorDto> GetByName(string nome);
    }
}
