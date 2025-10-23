using Core;
using Core.Service;
using Core.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
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

        public DatatableResponse GetDataPage(DatatableRequest request)
        {
            var autores = context.Autors.AsNoTracking();
            if (!string.IsNullOrEmpty(request.Search))
            {
                autores = autores.Where(a => a.Nome.Contains(request.Search));
            }
            var totalRecords = autores.Count();
            var pagedAutores = autores
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();
            return new DatatableResponse
            {
                Data = pagedAutores,
                TotalRecords = totalRecords
            };
        }
    }
}
