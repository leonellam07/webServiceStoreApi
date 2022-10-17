using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace webServiceStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        //private IFactura _facturaRepository;
        //public FacturaController(IFactura factura) => _facturaRepository = factura;


        //[HttpGet]
        //public ActionResult<List<Factura>> Get(DateTime fecha)
        //{
        //    try
        //    {
        //        return StatusCode(200, _facturaRepository.GetAll(fecha));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);

        //    }
        //}

        //[HttpGet]
        //public ActionResult<List<Factura>> Get(int anio, int mes, bool? cancelados)
        //{
        //    try
        //    {
        //        return StatusCode(200, _facturaRepository.GetAll(anio, mes, cancelados));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);

        //    }
        //}

        //[HttpPost]
        //public ActionResult<Factura> Post(Factura factura)
        //{
        //    try
        //    {
        //        return StatusCode(200, _facturaRepository.Add(factura));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);

        //    }
        //}

        //[HttpPost]
        //public ActionResult<bool> Cancel(int id)
        //{
        //    try
        //    {
        //        return StatusCode(200, _facturaRepository.Cancel(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);

        //    }
        //}

    }
}
