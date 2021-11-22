using CRUDHP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDHP.Repositories
{
    public class RepositorioAspirante : IRepositorioAspirante
    {
        private DatabaseContext _context;
        public RepositorioAspirante(DatabaseContext context)
        {
            _context = context;
        }
        public Aspirante AddAspirante(Aspirante aspirante)
        {
            if (aspirante.House == "Gryffindor" || aspirante.House == "Slytherin" ||
                aspirante.House == "Ravenclaw" || aspirante.House == "Hufflepuff")
            {
                _context.Aspirantes.Add(aspirante);
                _context.SaveChanges();

            }
            else
            {
                throw new Exception("The house you entered is not valid");
            }
            return aspirante;
        }

        public void DeleteAspirante(Aspirante aspirante)
        {
            _context.Aspirantes.Remove(aspirante);
            _context.SaveChanges();
             
        }

        public Aspirante EditAspirante(Aspirante aspirante)
        {
            var aspiranteExistente = GetAspirante(aspirante.Id);
            if (aspiranteExistente != null)
            {
                aspiranteExistente.Name = aspirante.Name;
                aspiranteExistente.LastName = aspirante.LastName;
                aspiranteExistente.Identification = aspirante.Identification;
                aspiranteExistente.Age = aspirante.Age;
                aspiranteExistente.House = aspirante.House;

                _context.Aspirantes.Update(aspiranteExistente);
                _context.SaveChanges();


            }

            return aspirante;
        }

        public List<Aspirante> GetAspirantes()
        {
            return _context.Aspirantes.ToList();
        }

        public Aspirante GetAspirante(int id)
        {
            var aspirante = _context.Aspirantes.Find(id);
            return aspirante;
        }
    }
}
