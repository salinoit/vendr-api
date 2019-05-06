using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;

using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Vendr.Application.Controllers
{
    [Route("api/[controller]")]
    public class ZaptPayController : Controller
    {

        [AllowAnonymous]
        [HttpGet]
        public async Task<object> PagamentoBoleto()
        {
            var client = new HttpClient();
            string privateKey = "vendr1";
            string uri = "https://devzaptpay.automatiza.net/api/transacao/gerarLinkPagamento";
            string source = string.Format("{0:yyyytMMdd}", System.DateTime.Now) + privateKey + System.DateTime.Now.Day.ToString("d2");
            string hash = "";
            string user = "zaptpaydev";
            string pass = "Z@PT123.pay";

            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, source);
            }

            var dados = new
            {
                cPub = "v1",
                cHash = hash.ToUpper(),
                idUsuarioCredito = "5",
                valor = "5.932,75",
                diasValidade = "3",
                identificador = "38"
            };

            var sender = new JsonContent(dados);
            client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue(
            "Basic", Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
               $"{user}:{pass}")));

            var retorno = await client.PostAsync(uri, sender);
            var contents = await retorno.Content.ReadAsStringAsync();
            return Ok(contents);

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }


    public class JsonContent : StringContent
    {
        public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        { }
    }

}


//var byteArray = Encoding.ASCII.GetBytes("username:password1234");
//client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
//client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "encrypted zaptpaydev/Z@PT123.pay");
