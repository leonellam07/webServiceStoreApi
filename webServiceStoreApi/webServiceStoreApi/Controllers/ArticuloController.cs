using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace webServiceStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        //private IArticulo _articuloRepository;
        //public ArticuloController(IArticulo articulo) => _articuloRepository = articulo;

        //[HttpGet]
        //public ActionResult<List<Articulo>> Get()
        //{
        //    try
        //    {
        //        return StatusCode(200, _articuloRepository.GetAll());
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);

        //    }
        //}

        //[HttpGet]
        //public ActionResult<Articulo> Get(string code)
        //{
        //    try
        //    {
        //        return StatusCode(200, _articuloRepository.Find(code));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);

        //    }
        //}


        //[HttpPost]
        //public ActionResult<Articulo> Post(Articulo articulo)
        //{
        //    try
        //    {
        //        return StatusCode(200, _articuloRepository.Add(articulo));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);

        //    }
        //}

        //[HttpPost]
        //public ActionResult<Articulo> Cancel(string code)
        //{
        //    try
        //    {
        //        return StatusCode(200, _articuloRepository.Cancel(code));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);

        //    }
        //}

        //[HttpPut]
        //public ActionResult<bool> Put(Articulo articulo)
        //{
        //    try
        //    {
        //        return StatusCode(200, _articuloRepository.Update(articulo));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);

        //    }
        //}
    }
}
