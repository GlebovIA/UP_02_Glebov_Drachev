using Microsoft.EntityFrameworkCore;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Linq;
using System.Windows;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Reporting
{
    public class DocumentGenerator
    {
        private readonly StudentsContext _studentsContext;
        private readonly DisciplinesContext _disciplinesContext;
        private readonly MarksContext _marksContext;
        private readonly AbsencesContext _absencesContext;

        public DocumentGenerator()
        {
            _studentsContext = new StudentsContext();
            _disciplinesContext = new DisciplinesContext();
            _marksContext = new MarksContext();
            _absencesContext = new AbsencesContext();
        }

        public void GenerateRetakeReferral(int studentId, int disciplineId)
        {
            var student = _studentsContext.Students
                .Include(s => s.StudGroup)
                .FirstOrDefault(s => s.Id == studentId);
            var discipline = _disciplinesContext.Disciplines
                .Include(d => d.Teacher)
                .FirstOrDefault(d => d.Id == disciplineId);
            var mark = _marksContext.Marks
                .Include(m => m.Lesson)
                .ThenInclude(l => l.DisciplineProgram)
                .ThenInclude(dp => dp.Discipline)
                .FirstOrDefault(m => m.StudentId == studentId && m.Lesson.DisciplineProgram.DisciplineId == disciplineId);

            if (student == null || discipline == null || mark == null || mark.Mark != "2")
            {
                MessageBox.Show("Невозможно сгенерировать направление: данные не найдены или предмет сдан.");
                return;
            }

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Направление на пересдачу";
            PdfPage page = document.AddPage();
            XGraphics graphics = XGraphics.FromPdfPage(page);
            XFont headerFont = new XFont("Arial", 16, XFontStyleEx.Bold);
            XFont font = new XFont("Arial", 12);

            graphics.DrawString("Направление на пересдачу", headerFont, XBrushes.Black, new XRect(0, 20, page.Width, 20), XStringFormats.Center);
            graphics.DrawString($"Студент: {student.Surname} {student.Name} {student.Lastname ?? ""}", font, XBrushes.Black, new XRect(40, 60, page.Width, 20), XStringFormats.TopLeft);
            graphics.DrawString($"Группа: {student.StudGroup.Name}", font, XBrushes.Black, new XRect(40, 80, page.Width, 20), XStringFormats.TopLeft);
            graphics.DrawString($"Дисциплина: {discipline.Name}", font, XBrushes.Black, new XRect(40, 100, page.Width, 20), XStringFormats.TopLeft);
            graphics.DrawString($"Преподаватель: {discipline.Teacher.Surname} {discipline.Teacher.Name} {discipline.Teacher.Lastname ?? ""}", font, XBrushes.Black, new XRect(40, 120, page.Width, 20), XStringFormats.TopLeft);
            graphics.DrawString($"Оценка: {mark.Mark}", font, XBrushes.Black, new XRect(40, 140, page.Width, 20), XStringFormats.TopLeft);
            graphics.DrawString($"Дата пересдачи: {DateTime.Now.AddDays(7).ToString("dd.MM.yyyy")}", font, XBrushes.Black, new XRect(40, 160, page.Width, 20), XStringFormats.TopLeft);

            string filePath = Environment.CurrentDirectory + $"\\RetakeReferral_{studentId}_{disciplineId}.pdf";
            document.Save(filePath);
            MessageBox.Show("Направление на пересдачу успешно сгенерировано.");
        }

        public void GenerateAttendanceSummary(int studentId)
        {
            var student = _studentsContext.Students
                .Include(s => s.StudGroup)
                .FirstOrDefault(s => s.Id == studentId);
            var absences = _absencesContext.Absences
                .Include(a => a.Discipline)
                .Where(a => a.StudentId == studentId)
                .ToList();

            if (student == null)
            {
                MessageBox.Show("Студент не найден.");
                return;
            }

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Сводка посещения занятий";
            PdfPage page = document.AddPage();
            XGraphics graphics = XGraphics.FromPdfPage(page);
            XFont headerFont = new XFont("Arial", 16, XFontStyleEx.Bold);
            XFont font = new XFont("Arial", 12);

            graphics.DrawString("Сводка посещения занятий", headerFont, XBrushes.Black, new XRect(0, 20, page.Width, 20), XStringFormats.Center);
            graphics.DrawString($"Студент: {student.Surname} {student.Name} {student.Lastname ?? ""}", font, XBrushes.Black, new XRect(40, 60, page.Width, 20), XStringFormats.TopLeft);
            graphics.DrawString($"Группа: {student.StudGroup.Name}", font, XBrushes.Black, new XRect(40, 80, page.Width, 20), XStringFormats.TopLeft);
            graphics.DrawString("Пропуски:", font, XBrushes.Black, new XRect(40, 100, page.Width, 20), XStringFormats.TopLeft);

            if (absences.Count == 0)
            {
                graphics.DrawString("Пропусков нет.", font, XBrushes.Black, new XRect(40, 120, page.Width, 20), XStringFormats.TopLeft);
            }
            else
            {
                int yOffset = 120;
                foreach (var absence in absences)
                {
                    graphics.DrawString($"- Дисциплина: {absence.Discipline.Name}", font, XBrushes.Black, new XRect(40, yOffset, page.Width, 20), XStringFormats.TopLeft);
                    yOffset += 20;
                    graphics.DrawString($"  Дата: {absence.Date.ToString("dd.MM.yyyy HH:mm")}", font, XBrushes.Black, new XRect(40, yOffset, page.Width, 20), XStringFormats.TopLeft);
                    yOffset += 20;
                    graphics.DrawString($"  Опоздание: {absence.DelayMinutes} мин.", font, XBrushes.Black, new XRect(40, yOffset, page.Width, 20), XStringFormats.TopLeft);
                    yOffset += 20;
                    graphics.DrawString($"  Причина: {absence.ExplanatoryNote ?? "Не указана"}", font, XBrushes.Black, new XRect(40, yOffset, page.Width, 20), XStringFormats.TopLeft);
                    yOffset += 30;
                }
            }

            string filePath = Environment.CurrentDirectory + $"\\AttendanceSummary_{studentId}.pdf";
            document.Save(filePath);
            MessageBox.Show("Сводка посещения занятий успешно сгенерирована.");
        }
    }
}