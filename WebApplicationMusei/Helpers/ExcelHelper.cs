﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMusei.Models.Entities;

namespace WebApplicationMusei.Helpers
{
    public static class ExcelHelper
    {
        public static MemoryStream CreateExcelMuseiList(List<Museo> musei)
        {
            //string excelpath = PathHelper.GetPathUploads() + "\\musei.xlsx";//Server.MapPath("~/UploadExcel/" + DateTime.UtcNow.Date.ToString() + ".xlsx");  
            //FileInfo finame = new FileInfo(excelpath);
            //if (File.Exists(excelpath))
            //{
            //    File.Delete(excelpath);
            //}
            //using (ExcelPackage excel = new ExcelPackage(memoryStream))

            var memoryStream = new MemoryStream();

            using (ExcelPackage excel = new ExcelPackage(memoryStream))
            {
                var sheetcreate = excel.Workbook.Worksheets.Add("Musei");
                sheetcreate.Cells[1, 1].Value = "Identificativo";
                sheetcreate.Cells[1, 2].Value = "Denominazione";
                sheetcreate.Cells[1, 3].Value = "Citta";

                for (int i = 0; i < musei.Count; i++)
                {
                    sheetcreate.Cells[i + 2, 1].Value = musei[i].Id;
                    sheetcreate.Cells[i + 2, 2].Value = musei[i].Denominazione;
                    sheetcreate.Cells[i + 2, 3].Value = musei[i].Citta.Nome;
                }

                //sheetcreate.Cells[1, 1, 1, 25].Style.Font.Bold = true;
                excel.Save();
                //excel.SaveAs(memoryStream);

                //var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
                //workSheet.Cells[1, 1].LoadFromCollection(data, true);  
            }
            return memoryStream;
            //throw new Exception("Errore non è stato possibile creare il file excel");
        }

    }
}
