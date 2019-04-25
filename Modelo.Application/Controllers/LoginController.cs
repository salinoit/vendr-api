using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using Vendr.Infra.CrossCutting.Identity.Models;
using Vendr.Domain.Entities;
using Vendr.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Vendr.Application.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        [AllowAnonymous]
        [HttpPost]
        public object Post(
           [FromBody]UserIdentity user,
           [FromServices]SigningConfigurations signingConfigurations,
           [FromServices]TokenConfigurations tokenConfigurations,
           [FromServices]IRepositoryAsync<Perfil> _perfilRepository)

        {
            bool credenciaisValidas = false;
           
            Vendr.Domain.Dto.UsuarioDto selectedUser = null;


            if (user != null && !String.IsNullOrWhiteSpace(user.email) )
            {
                string[] inc = {"Vendedor","Consumidor" };

                //williamzz@ig.com.br
                List<Perfil> v =(List<Perfil>) _perfilRepository.GetAllAsync(filter:o=>o.Email==user.email , includes: inc).Result.ToList();

                var selected =(Perfil) v.FirstOrDefault();
                

                try
                {
                    selectedUser = new Domain.Dto.UsuarioDto();
                    selectedUser.id = selected.IdPerfil;
                    selectedUser.nome = selected.Nome;
                    selectedUser.email = selected.Email;
                    selectedUser.celular = selected.Fone;
                    selectedUser.senha = user.password;
                    selectedUser.foto = selected.Foto;
                    credenciaisValidas = true;
                }
                catch(Exception ex)
                {
                    credenciaisValidas = false;
                }                               
            }

            if (credenciaisValidas)
            {

                
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.email, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.email)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                
                var sucess=new
                {
                    user=selectedUser,
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
                

                return Ok(sucess);

            }
            else
            {                
                var error=new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
                return BadRequest(error);
            }
        }       
             
        protected override void Dispose(bool disposing)
        {            
            base.Dispose(disposing);
        }
    }
}
