using CRUDHP.Entities;
using CRUDHP.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CRUDHP.Controllers
{
   
    [ApiController]
    public class AspiranteController : Controller
    {
        
        private IRepositorioAspirante IrepositorioAspirante;

        public AspiranteController(IRepositorioAspirante repositorioAspirante)
        {
            IrepositorioAspirante = repositorioAspirante;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAspirantes()
        {
            return Ok(IrepositorioAspirante.GetAspirantes());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetAspirante(int id)
        {
            var aspirante = IrepositorioAspirante.GetAspirante(id);
            if (aspirante != null)
            {
                return Ok(aspirante);
            }

            return NotFound($"Aspirante con ID: {id} no se consiguio");

        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetAspirantes(Aspirante aspirantes)
        {
            IrepositorioAspirante.AddAspirante(aspirantes);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + aspirantes.Id,
                aspirantes);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteAspirante(int id)
        {
            var aspirante = IrepositorioAspirante.GetAspirante(id);


            if (aspirante != null)
            {
                IrepositorioAspirante.DeleteAspirante(aspirante);
                return Ok();
            }

            return NotFound($"Aspirante con ID: {id} no se consiguio");
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditAspirante(int id, Aspirante aspirante)
        {
            var aspiranteExistente = IrepositorioAspirante.GetAspirante(id);


            if (aspiranteExistente != null)
            {
                aspirante.Id = aspiranteExistente.Id;
                IrepositorioAspirante.EditAspirante(aspirante);
                
            }

            return Ok(aspirante);
        }

    }
}
