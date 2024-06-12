using API_MDA_PrecioMedio.Models.Datos.DTO;
using API_MDA_PrecioMedio.Models.Datos.Repositorio.Operaciones;
using API_MDA_PrecioMedio.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_MDA_PrecioMedio.Models.Negocio.OperacionesVC
{
    public class OperacionesBO
    {
        public static List<PrecioMedioDTO> GetPrecioMedio(PrecioMedio precioMedio)
        {
            return Operaciones.GetPrecioMedio(precioMedio);
        }

    }
}