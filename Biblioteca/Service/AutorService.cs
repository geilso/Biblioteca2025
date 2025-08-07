using Core;
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

        public Autor? Get(uint id)
        {
            return context.Autors.Find(id);
        }

        public IEnumerable<Autor> GetAll()
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
    }
}
