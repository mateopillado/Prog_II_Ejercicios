using CineBack.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBack.Repository
{

    public interface IPeliculaRepository
    {
        Task<List<Pelicula>> GetAll();

        Task<Pelicula> GetById(int id);

        Task Save(Pelicula pelicula);

        Task Delete(int id);

        Task Update(Pelicula pelicula);

        Task<List<Pelicula>> GetAllFechas(int date1, int date2);

    }


    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly CineContext _Context;

        public PeliculaRepository(CineContext context)
        {
           _Context = context;
        }

        public async Task Delete(int id)
        {
            var devuelto = await _Context.Peliculas.FindAsync(id);
            if (devuelto == null) return;

            _Context.Peliculas.Remove(devuelto);
            await _Context.SaveChangesAsync();

        }

        public async Task<List<Pelicula>> GetAll()
        {
            return await _Context.Peliculas.Where(p => p.Estreno == true).ToListAsync();
        }

        public async Task<List<Pelicula>> GetAllFechas(int date1, int date2)
        {
            return await _Context.Peliculas.Where(p => p.Anio > date1 && p.Anio < date2).ToListAsync();
        }

        public async Task<Pelicula> GetById(int id)
        {
            return await _Context.Peliculas.FindAsync(id);
        }

        public async Task Save(Pelicula pelicula)
        {
            await _Context.Peliculas.AddAsync(pelicula);
            await _Context.SaveChangesAsync();
        }

        public async Task Update(Pelicula pelicula)
        {
            var devuelto = await _Context.Peliculas.FindAsync(pelicula.Id);
            if (devuelto == null) return;

            _Context.Entry(devuelto).CurrentValues.SetValues(pelicula);
            await _Context.SaveChangesAsync();

        }
    }
}
