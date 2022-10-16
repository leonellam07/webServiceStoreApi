using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace webServiceStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ICliente _clienteRepository;
        public ClienteController(ICliente cliente)
        {
            _clienteRepository = cliente;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            try
            {
                return StatusCode(200, _clienteRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

    }
}
