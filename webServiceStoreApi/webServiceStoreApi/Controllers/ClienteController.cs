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
        public ClienteController(ICliente cliente) => _clienteRepository = cliente;

        [HttpGet]
        public ActionResult<List<Cliente>> GetAll()
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

        //[HttpGet]
        //public ActionResult<Cliente> Get(int id)
        //{
        //    try
        //    {
        //        return StatusCode(200, _clienteRepository.Find(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);

        //    }
        //}


        //[HttpPost]
        //public ActionResult<Cliente> Post(Cliente cliente)
        //{
        //    try
        //    {
        //        return StatusCode(200, _clienteRepository.Add(cliente));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        //[HttpPut]
        //public ActionResult<bool> Put(Cliente cliente)
        //{
        //    try
        //    {
        //        return StatusCode(200, _clienteRepository.Update(cliente));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

    }
}
