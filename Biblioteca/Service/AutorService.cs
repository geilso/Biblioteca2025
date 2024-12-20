using Core;
using Core.Dto;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AutorService : IAutorService
    {
        private readonly BibliotecaContext context;


        public AutorService(BibliotecaContext context)
        {
            this.context = context;
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
