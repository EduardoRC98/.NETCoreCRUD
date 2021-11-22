using CRUDHP.Entities;
using System.Collections.Generic;

namespace CRUDHP.Repositories
{
    public interface IRepositorioAspirante
    {
        List<Aspirante> GetAspirantes();
        Aspirante GetAspirante(int id);

        Aspirante AddAspirante( Aspirante aspirante );

        void DeleteAspirante(Aspirante aspirante );

        Aspirante EditAspirante(Aspirante aspirante);
    }
}
