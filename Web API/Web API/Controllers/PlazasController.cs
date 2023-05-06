using Microsoft.AspNetCore.Mvc;
using Web_API.Data;
using Web_API.Models;
using Microsoft.Extensions.Http;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("Plazas")]
    public class PlazasController : Controller
    {
        public IConfiguration _configuracion;
        private readonly ApparcaContexto _context;
        public PlazasController(IConfiguration configuration, ApparcaContexto context)
        {
            _configuracion= configuration;
            _context = context;
        }
        [HttpPost]
        [Route("Crear")]
        public IActionResult CrearPlaza(IFormFile file)
        {
            
            return StatusCode(422);
        }

        

        [HttpGet]
        [Route("Todas")]
        public ActionResult ObtenerPlazas()
        {

            List<Plaza> plazas = new List<Plaza>();

            Random rnd = new Random();

            double minLat = 36.00000; // Límite inferior de la latitud de España
            double maxLat = 43.79182; // Límite superior de la latitud de España
            double minLon = -9.30178; // Límite inferior de la longitud de España
            double maxLon = 3.03981; // Límite superior de la longitud de España

            for (int i = 0; i<1000; i++)
            {
                double lat = rnd.NextDouble() * (maxLat - minLat) + minLat;
                double lon = rnd.NextDouble() * (maxLon - minLon) + minLon;


                plazas.Add(new Plaza
                {
                    Id = i,
                    //Latitud = lat.ToString().Replace(",", "."),
                    //Longitud = lon.ToString().Replace(",", "."),
                });
            }
            var plazasN = plazas.OrderBy(r => Guid.NewGuid()).Take(100);
            return Ok(plazasN);
        }

        [HttpGet]
        [Route("Details")]
        public ActionResult ObtenerPlaza(int id)
        {
            Plaza plaza = _context.Plazas.Find(id);

            if(plaza == null)
            {
                return BadRequest();
            }
            
            return Ok(plaza);
        }


        [HttpGet]
        [Route("Filtrado")]
        public ActionResult FiltrarPlazas(string latitudMaxima, string latitudMinima, string longitudMaxima, string longitudMinima)
        {
            FiltroPlaza filtros = new FiltroPlaza(latitudMaxima, latitudMinima, longitudMaxima, longitudMinima);

            
            List<Plaza> plazas = _context.Plazas.ToList();
            /*List<Plaza> plazas = new List<Plaza>();
            Random rnd = new Random();

            double minLat = 36.00000; // Límite inferior de la latitud de España
            double maxLat = 43.79182; // Límite superior de la latitud de España
            double minLon = -9.30178; // Límite inferior de la longitud de España
            double maxLon = 3.03981; // Límite superior de la longitud de España

            for (int i = 0; i<1000; i++)
            {
                double lat = rnd.NextDouble() * (maxLat - minLat) + minLat;
                double lon = rnd.NextDouble() * (maxLon - minLon) + minLon;

                plazas.Add(new Plaza
                {
                    Id = i,
                    Latitud = lat,
                    Longitud = lon,
                    Direccion = "Calle clara campoamor, 5",
                    HoraInicio = "09:00",
                    HoraFinal = "17:00",
                    PrecioMes = 25
                });
            }*/

            

            plazas = plazas.Where(plaza => (plaza.Latitud<= filtros.LatitudMaxima) && (plaza.Latitud >= filtros.LatitudMinima)).ToList();
            plazas = plazas.Where(plaza => (plaza.Longitud<= filtros.LongitudMaxima) && (plaza.Longitud >= filtros.LongitudMinima)).ToList();


            var plazasN = plazas.OrderBy(r => Guid.NewGuid()).Take(25).ToList();
            
            /*
            plazasN.Add(new Plaza
            {
                Id = 10000,
                Latitud = 38.379955,
                Longitud = -0.429092,
                Direccion = "Calle clara campoamor, 7",
                HoraInicio = "08:00",
                HoraFinal = "12:00",
                PrecioMes = 50
            });*/

            return Ok(plazasN);
        }

        [HttpGet]
        [Route("MisPlazas")]
        public IActionResult MisPlazas()
        {
            var usuariosController = new UsuarioController(_configuracion, _context);
            usuariosController.ControllerContext = ControllerContext;

            // Llamar al método ValidarToken en UsuariosController
            var resultado = usuariosController.ValidarToken();

            if (resultado.success)
            {
                Usuario arrendador = _context.Usuarios.Find(resultado.result.Id);
                List<Plaza> plazasUsuario = _context.Plazas.Where(plaza => plaza.ArrendadorId == arrendador.Id).ToList();

                return Ok(plazasUsuario);
            }
            else
            {
                return StatusCode(422);
            }  
        }

        [HttpPost]
        public async Task<IActionResult> CrearPlaza([FromForm] PlazaRequest plazaR, IFormFile file)
        {
            var usuariosController = new UsuarioController(_configuracion, _context);
            usuariosController.ControllerContext = ControllerContext;

            // Llamar al método ValidarToken en UsuariosController
            var resultado = usuariosController.ValidarToken();

            if (resultado.success)
            {
                try
                {
                    byte[] imageData;
                    using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        imageData = ms.ToArray();

                    }

                    Usuario arrendador = _context.Usuarios.Find(resultado.result.Id);
                    Plaza plaza = new Plaza
                    {
                        ArrendadorId = arrendador.Id,
                        Direccion = plazaR.direccion + ", " + plazaR.numero + ", " + plazaR.localidad + ", " +plazaR.cp,
                        Latitud = double.Parse(plazaR.latitud),
                        Longitud = double.Parse(plazaR.longitud),
                        Descripcion = plazaR.descripcion,
                        Ancho = int.Parse(plazaR.ancho),
                        Largo = int.Parse(plazaR.largo),
                        FechaInicio = plazaR.fechaInicio,
                        FechaFinal = plazaR.fechaFinal,
                        PrecioMando = float.Parse(plazaR.precioMando),
                        PrecioMes = float.Parse(plazaR.precioMes),
                        HoraInicio = plazaR.startTime,
                        HoraFinal = plazaR.endTime,
                        Imagen = imageData
                    };
                    //plaza.Id = _context.Plazas.OrderBy(plaza => plaza.Id).FirstOrDefault().Id + 1;
                    _context.Plazas.Add(plaza);
                    _context.SaveChanges();

                    return Ok();
                }
                catch (Exception ex)
                {
                    // Devolver un error 500 si ocurre algún problema en el servidor
                    return StatusCode(500, ex.Message);
                }
            }
            return StatusCode(422);
        }

    }
    public class PlazaRequest
    {
        public string direccion { get; set; }
        public string cp { get; set; }
        public string localidad { get; set; }
        public string numero { get; set; }
        public string ancho { get; set; }
        public string largo { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string precioMes { get; set; }
        public string precioMando { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFinal { get; set; }
        public string descripcion { get; set; }
    }
}
