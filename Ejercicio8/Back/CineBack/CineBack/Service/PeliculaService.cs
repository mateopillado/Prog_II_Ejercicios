using Azure.Core;
using CineBack.Data.Models;
using CineBack.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBack.Service
{
    public interface IPeliculaService
    {
        Task<List<Pelicula>> GetAll();

        Task<Pelicula> GetById(int id);

        Task Save(Pelicula pelicula);

        Task Delete(int id);

        Task Update(Pelicula pelicula);

        Task<List<Pelicula>> GetAllFechas(int date1, int date2);
    }
    public class PeliculaService : IPeliculaService
    {

        private readonly IPeliculaRepository _Repository;

        public PeliculaService(IPeliculaRepository peliculaRepository)
        {
            _Repository = peliculaRepository;
        }

        public async Task Delete(int id)
        {
            await _Repository.Delete(id);
        }

        public async Task<List<Pelicula>> GetAll()
        {
            return await _Repository.GetAll();
        }

        public async Task<List<Pelicula>> GetAllFechas(int date1, int date2)
        {
            return await _Repository.GetAllFechas(date1, date2);
        }

        public async Task<Pelicula> GetById(int id)
        {
            return await _Repository.GetById(id);
        }

        public async Task Save(Pelicula pelicula)
        {
            await _Repository.Save(pelicula);
        }

        public async Task Update(Pelicula pelicula)
        {
            await _Repository.Update(pelicula);
        }
    }
}
