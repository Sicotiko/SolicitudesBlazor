using ClosedXML.Excel;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services
{
    public class Export
    {
        public async Task<byte[]> ToExcel(string Titulo, List<BlazorApp1.Shared.Modelo.OT.OrdenTrabajo> Ordenes)
        {
            MemoryStream stream = new MemoryStream();
            await Task.Run(() =>
            {

                XLWorkbook Libro = new XLWorkbook();
                Libro.Properties.Title = Titulo;

                IXLWorksheet Hoja = Libro.Worksheets.Add();



                //for (int col = 0; col < Headers.Length; col++)
                //{
                //    Hoja.Cell(1, col + 1).Value = Headers[col];
                //}
                bool EscribirHeaders = true;
                int QPorPaginas = 35;
                int AnchoEnColumnas = 4;
                int ColumnaActual = 0;
                int filaActual = 2;
                for (int fila = 1; fila < Ordenes.Count() - 1; fila++)
                {

                    if (EscribirHeaders)
                    {
                        //Headers
                        Hoja.Cell(1, 1 + ColumnaActual).Value = "Movil";
                        Hoja.Cell(1, 2 + ColumnaActual).Value = "AM";
                        Hoja.Cell(1, 3 + ColumnaActual).Value = "PM";
                        Hoja.Cell(1, 4 + ColumnaActual).Value = "Comuna";
                        EscribirHeaders = false;
                    }


                    //Movil
                    Hoja.Cell(filaActual, 1 + ColumnaActual).Value = new string(Ordenes[fila - 1].Movil.Codigo.ToString().Reverse().Take(3).Reverse().ToArray());
                    //AM
                    Hoja.Cell(filaActual, 2 + ColumnaActual).Value = Ordenes[fila - 1].TipoHorario.ToString();
                    //PM
                    Hoja.Cell(filaActual, 3 + ColumnaActual).Value = Ordenes[fila - 1].TipoHorario.ToString();
                    //Comuna
                    Hoja.Cell(filaActual, 4 + ColumnaActual).Value = Ordenes[fila - 1].Comuna?.Nombre;

                    filaActual++;
                    ColumnaActual = filaActual == QPorPaginas ? ColumnaActual + AnchoEnColumnas : ColumnaActual;
                    EscribirHeaders = filaActual == QPorPaginas ? true : false;
                    filaActual = filaActual == QPorPaginas ? 2 : filaActual;
                }

                Libro.SaveAs(stream);
            });

            return stream.ToArray();
            //await js.InvokeVoidAsync("BlazorDownloadFile", $"{Titulo}.xlsx",stream.ToArray());
        }
    }
}
