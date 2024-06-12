using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_MDA_PrecioMedio.Models.Datos.DTO
{
    public class PrecioMedioDTO
    {
        public DateTime? FEC_VALOR { get; set; }
        public string FEC_HORA { get; set; }
        public string NOM_INSTRUMENTO { get; set; }
        public decimal? MTO_PRECIOMEDIO { get; set; }
        public decimal IND_ERROR { get; set; }
        public string DES_ERROR { get; set; }
    }

    /*          FROM (  SELECT FEC_VALOR,
                         VME_HORA,
                         VME_NEMOTECNICO,
                         VME_VALOR_PROMEDIO
                    FROM MDA.MDA_RA_VALOR_TIFMUT*/
}