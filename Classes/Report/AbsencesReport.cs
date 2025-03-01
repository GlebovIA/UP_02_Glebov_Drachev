using UP_02_Glebov_Drachev.Models;
using System.Windows;
using System.Collections.Generic;
using UP_02_Glebov_Drachev.Contexts;
using Microsoft.EntityFrameworkCore;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.UniversalAccessibility.Drawing;
using System;
using System.Diagnostics;
using System.Linq;

namespace UP_02_Glebov_Drachev.Reporting
{
    public class AbsenceReport
    {
        private static AbsencesContext _context;

        public static void GenerateReport()
        {
            _context = new AbsencesContext();
            MessageBox.Show("Отчет сформирован");

            // Получаем все опоздания
            List<AbsencesModel> absences = _context.Absences.Include(a => a.Student)
                                  .ThenInclude(s => s.StudGroup)
                                  .Include(a => a.Discipline).ToList();

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Отчет по опозданиям";
            PdfPage page = document.AddPage();
            XGraphics graphics = XGraphics.FromPdfPage(page);
            XFont headerFont = new XFont("Arial", 16, XFontStyleEx.Bold);
            XFont underHeaderfont = new XFont("Arial", 16);
            XFont font = new XFont("Arial", 14);
            graphics.DrawString("Отчет по опозданиям", headerFont, XBrushes.Black, new XRect(0, 20, page.Width, 20), XStringFormats.Center);

            graphics.DrawString("Опоздания студентов:", underHeaderfont, XBrushes.Black, new XRect(40, 80, page.Width, 20), XStringFormats.CenterLeft);

            int width = (Convert.ToInt32(page.Width.Value) - 20 * 2 - 30) / 5;

            graphics.DrawRectangle(new XSolidBrush(XColors.LightGray), 15, 125, (width + 5) * 5 + 5, 25 * (absences.Count + 1) + 5);

            graphics.DrawRectangle(new XSolidBrush(XColors.White), 20, 130, width, 20);
            graphics.DrawRectangle(new XSolidBrush(XColors.White), 20 + width + 5, 130, width, 20);
            graphics.DrawRectangle(new XSolidBrush(XColors.White), 20 + (width + 5) * 2, 130, width, 20);
            graphics.DrawRectangle(new XSolidBrush(XColors.White), 20 + (width + 5) * 3, 130, width, 20);
            graphics.DrawRectangle(new XSolidBrush(XColors.White), 20 + (width + 5) * 4, 130, width, 20);

            graphics.DrawString("№", font, XBrushes.Black, new XRect(20, 130, width, 20), XStringFormats.Center);
            graphics.DrawString("Студент", font, XBrushes.Black, new XRect(20 + width + 5, 130, width, 20), XStringFormats.Center);
            graphics.DrawString("Дисциплина", font, XBrushes.Black, new XRect(20 + (width + 5) * 2, 130, width, 20), XStringFormats.Center);
            graphics.DrawString("Дата", font, XBrushes.Black, new XRect(20 + (width + 5) * 3, 130, width, 20), XStringFormats.Center);
            graphics.DrawString("Опоздание", font, XBrushes.Black, new XRect(20 + (width + 5) * 4, 130, width, 20), XStringFormats.Center);

            for(int i = 0; i < absences.Count; i++)
            {
                graphics.DrawRectangle(new XSolidBrush(XColors.White), 20, 130 + 25 * (i + 1), width, 20);
                graphics.DrawRectangle(new XSolidBrush(XColors.White), 20 + width + 5, 130 + 25 * (i + 1), width, 20);
                graphics.DrawRectangle(new XSolidBrush(XColors.White), 20 + (width + 5) * 2, 130 + 25 * (i + 1), width, 20);
                graphics.DrawRectangle(new XSolidBrush(XColors.White), 20 + (width + 5) * 3, 130 + 25 * (i + 1), width, 20);
                graphics.DrawRectangle(new XSolidBrush(XColors.White), 20 + (width + 5) * 4, 130 + 25 * (i + 1), width, 20);

                graphics.DrawString(absences[i].Id.ToString(), font, XBrushes.Black, new XRect(20, 130 + 25 * (i + 1), width, 20), XStringFormats.Center);
                graphics.DrawString(absences[i].Student.Surname.ToString(), font, XBrushes.Black, new XRect(20 + width + 5, 130 + 25 * (i + 1), width, 20), XStringFormats.Center);
                graphics.DrawString(absences[i].Discipline.Name.ToString(), font, XBrushes.Black, new XRect(20 + (width + 5) * 2, 130 + 25 * (i + 1), width, 20), XStringFormats.Center);
                graphics.DrawString(absences[i].Date.ToString("yyyy-MM-dd"), font, XBrushes.Black, new XRect(20 + (width + 5) * 3, 130 + 25 * (i + 1), width, 20), XStringFormats.Center);
                graphics.DrawString(absences[i].DelayMinutes.ToString(), font, XBrushes.Black, new XRect(20 + (width + 5) * 4, 130 + 25 * (i + 1), width, 20), XStringFormats.Center);
            }

            document.Save(Environment.CurrentDirectory + "\\ReportPage.pdf");
            MessageBox.Show("Отчет успешно сгенерирован.");
        }
    }
}
