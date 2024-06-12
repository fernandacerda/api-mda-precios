using API_MDA_PrecioMedio.Models.Datos.DTO;
using API_MDA_PrecioMedio.Models.DTO;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_MDA_PrecioMedio.Models.Datos.Repositorio.Operaciones
{
    public  class Operaciones
    {
        private const string MDA_GETPRECIOMEDIO_PR = "MDA.MDA_GETPRECIOMEDIO_PR";

        public static List<PrecioMedioDTO> GetPrecioMedio(PrecioMedio precioMedio)
        {
            List<PrecioMedioDTO> Value = new List<PrecioMedioDTO>();

            // Crea el contexto genérico de base de datos
            GenericRepositoyDB contextDBRepository = new GenericRepositoyDB();

            try
            {
                // Carga los parámetros de entrada
                //List<Parameter> inputParameters = new List<Parameter>
                //{
                //    new Parameter { name = "EN_IDINSTRUMENTO", type = OracleDbType.Decimal, value = precioMedio.ID_INSTRUMENTO },
                //    new Parameter { name = "EV_NOMINSTRUMENTO", type = OracleDbType.Varchar2, value = precioMedio.NOM_INSTRUMENTO },
                //    new Parameter { name = "EV_FECVALOR", type = OracleDbType.Varchar2, value = (precioMedio.FEC_VALOR == null ? null : precioMedio.FEC_VALOR.ToString("yyyyMMdd") ) }
                //};
                List<Parameter> inputParameters = new List<Parameter>
                {
                    new Parameter { name = "EV_NOMINSTRUMENTO", type = OracleDbType.Varchar2, value = precioMedio.NOM_INSTRUMENTO }
                };

                // Carga los parámetros de salida
                List<Parameter> outParameters = new List<Parameter>
                {
                    new Parameter { name = "RC_DATOS", isCursor = true }
                };

                // Apertura de conexión
                contextDBRepository.openConnection();

                // Ejecuta procedimiento de Selección
                contextDBRepository.execProcedure(inputParameters, MDA_GETPRECIOMEDIO_PR, ref outParameters);

                // Cargar Datos
                Value = listGetPrecioMedio(((OracleDataReader)outParameters[0].value));

            }
            catch //(Exception e)
            {
                throw;
            }
            finally
            {
                // Cierre de comexión
                contextDBRepository.closeConnection();
            }

            return Value;
        }

        #region ListgetPrepagos
        private static List<PrecioMedioDTO> listGetPrecioMedio(OracleDataReader dr)
        {
            List<PrecioMedioDTO> listValues = new List<PrecioMedioDTO>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    PrecioMedioDTO values = new PrecioMedioDTO();
                    values.FEC_VALOR = dr.GetDateTime(0);
                    values.FEC_HORA = dr.GetString(1);
                    values.NOM_INSTRUMENTO = dr.GetString(2);
                    values.MTO_PRECIOMEDIO = dr.GetDecimal(3);
                    values.IND_ERROR = dr.GetDecimal(4);
                    values.DES_ERROR = dr.GetString(5);

                    listValues.Add(values);
                }
            }
            return listValues;
        }
        #endregion


    }
}