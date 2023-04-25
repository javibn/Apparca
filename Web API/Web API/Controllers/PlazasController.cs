using Microsoft.AspNetCore.Mvc;
using Web_API.Data;
using Web_API.Models;

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
        [Route("Filtrado")]
        public ActionResult FiltrarPlazas(string latitudMaxima, string latitudMinima, string longitudMaxima, string longitudMinima)
        {
            FiltroPlaza filtros = new FiltroPlaza(latitudMaxima, latitudMinima, longitudMaxima, longitudMinima);

            List<Plaza> plazas = new List<Plaza>();
            //List<Plaza> plazas = _context.Plazas.ToList();

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
            }

            

            plazas = plazas.Where(plaza => (plaza.Latitud<= filtros.LatitudMaxima) && (plaza.Latitud >= filtros.LatitudMinima)).ToList();
            plazas = plazas.Where(plaza => (plaza.Longitud<= filtros.LongitudMaxima) && (plaza.Longitud >= filtros.LongitudMinima)).ToList();


            var plazasN = plazas.OrderBy(r => Guid.NewGuid()).Take(25).ToList();
            plazasN.Add(new Plaza
            {
                Id = 10000,
                Latitud = 38.379955,
                Longitud = -0.429092,
                Direccion = "Calle clara campoamor, 7",
                HoraInicio = "08:00",
                HoraFinal = "12:00",
                PrecioMes = 50
            });

            return Ok(plazasN);
        }
    }
}
