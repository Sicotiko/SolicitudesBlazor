using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Retiros
{
    public enum TipoIncidencias
    {

        Ninguna,
        [Description("Envio Retornado a Planta")]
        Envio_Retornado_a_Planta = 0955,
        [Description("Estado No Disponible")]
        Estado_No_Disponible = 0956,
        [Description("Informacion De Envio Anulada")]
        Informacion_De_Envio_Anulada = 0957,
        [Description("Excepcion")]
        Excepcion = 0958,
        [Description("Se Realizo Primer Intento")]
        Se_Realizo_Primer_Intento = 0959,
        [Description("Se Realizo Segundo Intento")]
        Se_Realizo_Segundo_Intento = 0960,
        [Description("Se Realizo Ultimo Intento")]
        Se_Realizo_Ultimo_Intento = 0961,
        [Description("Excepcion Accion Requerida")]
        Excepcion_Accion_Requerida = 0962,
        [Description("Bulto Retirado por Transportista")]
        Bulto_Retirado_por_Transportista = 0966,
        [Description("Re-Etiquetado ECI")]
        Re_Etiquetado_ECI = 0968,
        [Description("Rescate Rezago")]
        Rescate_Rezago = 0971,
        [Description("Rescate Fallido")]
        Rescate_Fallido = 0972,
        [Description("No Rezagable CEP")]
        No_Rezagable_CEP = 0973,
        [Description("No Rezagable INT")]
        No_Rezagable_INT = 0974,
        [Description("No Rezagable Postal")]
        No_Rezagable_Postal = 0975,
        [Description("Saldo Por Clasificar Regiones")]
        Saldo_Por_Clasificar_Regiones = 0992,
        [Description("Saldo de Regiones Por Capacidad")]
        Saldo_de_Regiones_Por_Capacidad = 0994,
        [Description("Envio Mal Ruteado")]
        Envio_Mal_Ruteado = 7208,
        [Description("Ausente en el Retiro")]
        Ausente_en_el_Retiro = 8103,
        [Description("Retiro Rehusado por Correos")]
        Retiro_Rehusado_por_Correos = 8201,
        [Description("Retiro Rehusado por Contacto Cliente")]
        Retiro_Rehusado_por_Contacto_Cliente = 8502,
        [Description("Sin Tiempo Para Retirar")]
        Sin_Tiempo_Para_Retirar = 8507,
        [Description("Requiere Medios Adicionales Para Retirar")]
        Requiere_Medios_Adicionales_Para_Retirar = 8509,
        [Description("Sin Preparacion de Carga")]
        Sin_Preparacion_de_Carga = 8510,
        [Description("Sin Carga Para Retiro")]
        Sin_Carga_Para_Retiro = 8511,
        [Description("Carga No Corresponde a Retiro")]
        Carga_No_Corresponde_a_Retiro = 8512,
        [Description("Anulacion de Retiro")]
        Anulacion_de_Retiro = 8513,
        [Description("Inbound China Warehouse")]
        Inbound_China_Warehouse = 9800
    }
}
