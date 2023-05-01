using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_API.Data;
using Web_API.Models;


namespace Web_API.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        public IConfiguration _configuracion;
        private readonly ApparcaContexto _context;
        public UsuarioController(IConfiguration configuration, ApparcaContexto context)
        {
            _configuracion= configuration;
            _context = context;
        }

        


        [HttpPost]
        [Route("login")]
        public dynamic IniciarSesion(string email, string password)
        {

            var user = _context.Usuarios.FirstOrDefault(u => u.Correo == email);

            if (user == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = ""
                };
            }

            if (user.password != user.HashPassword(password))
            {
                return BadRequest("Contraseña incorrecta");
            }
            else
            {
                var jwt = _configuracion.GetSection("Jwt").Get<Jwt>();

                var claims = new[]
                {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim("correo", user.Correo)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: signIn
                        );

                return new
                {
                    success = true,
                    message = "Exito",
                    result = new JwtSecurityTokenHandler().WriteToken(token),
                    user
                };
            }

            
        }

        [HttpGet]
        [Route("ObtenerUsuarios")]
        public dynamic ObtenerUsuarios()
        {
            return Ok(_context.Usuarios.ToList());
        }

        [HttpPost]
        [Route("registro")]
        public dynamic Registrarse(string email, string password, string nombre)
        {
            Usuario user = new Usuario();
            user.Correo= email;
            user.password= password;
            user.Nombre= nombre;

            _context.Add(user);
            _context.SaveChanges();
            user = _context.Usuarios.FirstOrDefault(x => x.Correo == email);
            
            var jwt = _configuracion.GetSection("Jwt").Get<Jwt>();

            var claims = new[]
            {
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, jwt.Subject),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("Id", user.Id.ToString()),
            new Claim("correo", user.Correo)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signIn
                    );

            return new
            {
                success = true,
                message = "Exito",
                result = new JwtSecurityTokenHandler().WriteToken(token),
                user
            };


        }

        [HttpPost]
        [Route("validar")]
        [Authorize]
        public  dynamic ValidarToken()
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            try
            {
                if (identity.Claims.Count()==0)
                {
                    return new
                    {
                        success = false,
                        message = "Verificar token",
                        result = ""
                    };
                }

                //Usuario usuario = _context.Usuarios.FirstOrDefault(user => user.Id.ToString() == identity.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var claim = identity.Claims.FirstOrDefault(x => x.Type == "Id");
                string idValue = claim != null ? claim.Value : null;
                Usuario usuario = _context.Usuarios.FirstOrDefault(user => user.Id.ToString() == idValue);


                return new
                {
                    success = true,
                    message = "Exito",
                    result = usuario
                };
            }
            catch (Exception)
            {
                return new
                {
                    success = false,
                    message = "Catch",
                    result = ""
                };
            }
        }
    }
}
