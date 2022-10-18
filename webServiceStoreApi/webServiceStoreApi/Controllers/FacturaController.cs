using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace webServiceStoreApi.Controllers
{
  
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private IFactura _facturaRepository;
        public FacturaController(IFactura factura) => _facturaRepository = factura;



        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult<List<Factura>> GetAll()
        {
            try
            {
                return StatusCode(200, _facturaRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/[controller]/search")]
        public ActionResult<Factura> GetById(int id)
        {
            try
            {
                return StatusCode(200, _facturaRepository.Find(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }


        [HttpPost]
        [Route("api/[controller]")]
        public ActionResult<Factura> Post([FromBody]Factura factura)
        {
            try
            {
                return StatusCode(200, _facturaRepository.Add(factura));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        [HttpPut]
        [Route("api/[controller]")]
        public ActionResult<bool> Put(Factura factura)
        {
            try
            {
                return StatusCode(200, _facturaRepository.Update(factura));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        [HttpPost]
        [Route("api/[controller]/cancel")]
        public ActionResult<bool> Cancel(int id)
        {
            try
            {
                return StatusCode(200, _facturaRepository.Cancel(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

    }
}
