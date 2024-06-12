using API_MDA_PrecioMedio.Models.Datos.DTO;
using API_MDA_PrecioMedio.Models.DTO;
using API_MDA_PrecioMedio.Models.Negocio;
using API_MDA_PrecioMedio.Models.Negocio.OperacionesVC;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_MDA_PrecioMedio.Controllers
{
    public class PrecioMedioController : ApiController
    {
        [HttpPost]
        // GET api/<controller>/5
        [Route("GetPrecioMedio")]

        public HttpResponseMessage GetPrecioMedio(PrecioMedio precioMedio)
        {
            DTOAPIResponse dTOAPIResponse = new DTOAPIResponse();
            List<PrecioMedioDTO> listValues = new List<PrecioMedioDTO>();
            DateTime fecha = DateTime.Now;
            string cadenaResult;

            try
            {
                LogManager.LogInfo("API_MDA_PrecioMedio PrecioMedioController (GetPrecioMedio) : Inicio " + Newtonsoft.Json.JsonConvert.SerializeObject(precioMedio));
                PrecioMedioDTO valueDumy = new PrecioMedioDTO();
                valueDumy.DES_ERROR = string.Empty;
                valueDumy.MTO_PRECIOMEDIO = 100;
                valueDumy.NOM_INSTRUMENTO = "";
                valueDumy.IND_ERROR = 0;
                valueDumy.FEC_VALOR = DateTime.ParseExact(fecha.ToString("dd-MM-yyyy"), "dd-MM-yyyy", null);
                valueDumy.FEC_HORA = fecha.ToString("HH:mm:ss", CultureInfo.InvariantCulture);

                listValues.Add(valueDumy);
                //listValues = OperacionesBO.GetPrecioMedio(precioMedio);
                dTOAPIResponse.data = Newtonsoft.Json.JsonConvert.SerializeObject(listValues);
                dTOAPIResponse.code = listValues.Count() == 0 ? "1": (listValues.Count() > 0 ? listValues[0].IND_ERROR.ToString():"0") ;
                dTOAPIResponse.message = listValues.Count() == 0 ? "Instrumento no encontrado" : (listValues.Count() > 0 ? listValues[0].DES_ERROR : "");
                dTOAPIResponse.timestamp = fecha.ToString("o", CultureInfo.InvariantCulture);
                dTOAPIResponse.param = "";
            }
            catch (Exception ex)
            {
                dTOAPIResponse.code = "1";
                dTOAPIResponse.message = ex.Message;
                dTOAPIResponse.timestamp = fecha.ToString("o", CultureInfo.InvariantCulture);
                dTOAPIResponse.param = "";
            }

            cadenaResult = Newtonsoft.Json.JsonConvert.SerializeObject(dTOAPIResponse);

            LogManager.LogInfo("API_MDA_PrecioMedio PrecioMedioController (GetPrecioMedio) : salida " + Newtonsoft.Json.JsonConvert.SerializeObject(cadenaResult));


            return new HttpResponseMessage((dTOAPIResponse.code != "0" ? HttpStatusCode.InternalServerError : HttpStatusCode.OK))
            {
                Content = new StringContent(cadenaResult, System.Text.Encoding.UTF8, "application/json")
            };
        }

    }
}
