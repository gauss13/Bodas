using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reportes
{
   public class AgendaR
    {


        public System.IO.MemoryStream Mensual()
        {
            // rutafolder
            var ruta = "";
            var nombreArchivo = "";

            // Stream memory
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            //Crear el documento de excel de timbrados
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Recibos Timbrados");

            worksheet.Cell(2, 1).Value = "Demo1";
            worksheet.Cell(2, 2).Value = "Demo2";
            worksheet.Cell(2, 3).Value = "Demo3";

            var fileName = ruta + nombreArchivo;

            workbook.SaveAs(ms);

            return ms;
            //return ms.ToArray();
        }

    }
}
