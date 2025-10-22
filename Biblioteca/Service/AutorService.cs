using Core;
using Core.Dto;
using Core.Service;
using Microsoft.EntityFrameworkCore;



namespace Service
{
    public class AutorService : IAutorService
    {
        private readonly BibliotecaContext context;

        public AutorService(BibliotecaContext context)
        {
            this.context = context;
        }

        public int Create(Autor autor)
        {
            if (autor.DataNascimento.Year < 1000)
                throw new ServiceException("O ano de nascimento de autor deve ser maior do que 1000. Favor informar nova data.");

            context.Add(autor);
            context.SaveChanges();
            return (int)autor.Id;
        }

        public void Delete(uint id)
        {
            var autor = context.Autors.Find(id);
            if (autor != null)
            {
                context.Remove(autor);
                context.SaveChanges();
            }
        }

        public void Edit(Autor autor)
        {
            if (autor.DataNascimento.Year < 1000)
                throw new ServiceException("O ano de nascimento de autor deve ser maior do que 1000. Favor informar nova data.");

            context.Update(autor);
            context.SaveChanges();
        }

        public Autor Get(uint id)
        {
            return context.Autors.Find(id);
        }

        /// <summary>
        /// Buscar todos os autores cadastrados
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        IEnumerable<Autor> IAutorService.GetAll()
        {
            return context.Autors.AsNoTracking();
        }

        public IEnumerable<Autor> GetByNome(string nomeAutor)
        {
            var query = from autor in context.Autors
                        where autor.Nome.Contains(nomeAutor)
                        select autor;
            return query.AsNoTracking().ToList();
        }

        /// <summary>
        /// Busca nomes dos atuores iniciando pelo nome passado
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        IEnumerable<AutorDto> IAutorService.GetByName(string nome)
        {
            var query = from Autor autor in context.Autors
                        orderby autor.Nome descending
                        select new AutorDto()
                        {
                            Id = autor.Id,
                            Nome = autor.Nome
                        };
            return query.AsNoTracking();
        }
    }
}
