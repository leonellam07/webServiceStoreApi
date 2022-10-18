using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace webServiceStoreApi.Controllers
{
   
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private IArticulo _articuloRepository;
        public ArticuloController(IArticulo articulo) => _articuloRepository = articulo;

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult<List<Articulo>> Get()
        {
            try
            {
                return StatusCode(200, _articuloRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/[controller]/search")]
        public ActionResult<Articulo> Get(string code)
        {
            try
            {
                return StatusCode(200, _articuloRepository.Find(code));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }


        [HttpPost]
        [Route("api/[controller]")]
        public ActionResult<Articulo> Post(Articulo articulo)
        {
            try
            {
                return StatusCode(200, _articuloRepository.Add(articulo));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        [HttpPost]
        [Route("api/[controller]/cancel")]
        public ActionResult<Articulo> Cancel(string code)
        {
            try
            {
                return StatusCode(200, _articuloRepository.Cancel(code));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        [HttpPut]
        [Route("api/[controller]")]
        public ActionResult<bool> Put(Articulo articulo)
        {
            try
            {
                return StatusCode(200, _articuloRepository.Update(articulo));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }
    }
}
