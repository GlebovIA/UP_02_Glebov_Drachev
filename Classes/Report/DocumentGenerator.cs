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

        // Вспомогательная функция для переноса текста
        private string[] WrapText(string text, int maxWidth, XFont font, XGraphics graphics)
        {
            if (string.IsNullOrEmpty(text)) return new[] { "" };

            double textWidth = graphics.MeasureString(text, font).Width;
            if (textWidth <= maxWidth) return new[] { text };

            var words = text.Split(' ');
            var lines = new System.Collections.Generic.List<string>();
            string currentLine = "";

            foreach (var word in words)
            {
                string testLine = string.IsNullOrEmpty(currentLine) ? word : currentLine + " " + word;
                double testWidth = graphics.MeasureString(testLine, font).Width;

                if (testWidth <= maxWidth)
                {
                    currentLine = testLine;
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentLine))
                    {
                        lines.Add(currentLine);
                    }
                    currentLine = word;
                }
            }

            if (!string.IsNullOrEmpty(currentLine))
            {
                lines.Add(currentLine);
            }

            return lines.ToArray();
        }

        public void GenerateRetakeReferral(int studentId, int disciplineId)
        {
            var student = _studentsContext.Students.Include(s => s.StudGroup).FirstOrDefault(s => s.Id == studentId);
            var discipline = _disciplinesContext.Disciplines.Include(d => d.Teacher).FirstOrDefault(d => d.Id == disciplineId);
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
            XFont headerFont = new XFont("Arial", 14, XFontStyleEx.Bold);
            XFont font = new XFont("Arial", 10);

            graphics.DrawString("Направление на пересдачу", headerFont, XBrushes.Black, new XRect(0, 20, page.Width, 20), XStringFormats.Center);

            int width = (int)(page.Width - 40 - 5) / 2;
            int yOffset = 60;

            graphics.DrawRectangle(new XSolidBrush(XColors.LightGray), 20, yOffset, (width + 5) * 2, 25 * 7);
            graphics.DrawRectangle(new XSolidBrush(XColors.White), 20, yOffset, width, 20);
            graphics.DrawRectangle(new XSolidBrush(XColors.White), 25 + width, yOffset, width, 20);
            graphics.DrawString("Поле", font, XBrushes.Black, new XRect(20, yOffset, width, 20), XStringFormats.Center);
            graphics.DrawString("Значение", font, XBrushes.Black, new XRect(25 + width, yOffset, width, 20), XStringFormats.Center);

            yOffset += 25;

            var fields = new[]
            {
                ("Студент", $"{student.Surname} {student.Name} {student.Lastname ?? ""}"),
                ("Группа", student.StudGroup.Name),
                ("Дисциплина", discipline.Name),
                ("Преподаватель", $"{discipline.Teacher.Surname} {discipline.Teacher.Name} {discipline.Teacher.Lastname ?? ""}"),
                ("Оценка", mark.Mark),
                ("Дата пересдачи", DateTime.Now.AddDays(7).ToString("dd.MM.yyyy"))
            };

            foreach (var (field, value) in fields)
            {
                graphics.DrawRectangle(new XSolidBrush(XColors.White), 20, yOffset, width, 20);
                graphics.DrawRectangle(new XSolidBrush(XColors.White), 25 + width, yOffset, width, 20);
                graphics.DrawString(field, font, XBrushes.Black, new XRect(20, yOffset, width, 20), XStringFormats.Center);
                graphics.DrawString(value, font, XBrushes.Black, new XRect(25 + width, yOffset, width, 20), XStringFormats.Center);
                yOffset += 25;
            }

            string filePath = Environment.CurrentDirectory + $"\\RetakeReferral_{studentId}_{disciplineId}.pdf";
            document.Save(filePath);
            MessageBox.Show("Направление на пересдачу успешно сгенерировано.");
        }

        public void GenerateAttendanceSummary(int studentId)
        {
            var student = _studentsContext.Students.Include(s => s.StudGroup).FirstOrDefault(s => s.Id == studentId);
            var absences = _absencesContext.Absences.Include(a => a.Discipline).Where(a => a.StudentId == studentId).ToList();

            if (student == null)
            {
                MessageBox.Show("Студент не найден.");
                return;
            }

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Сводка посещения занятий";
            PdfPage page = document.AddPage();
            XGraphics graphics = XGraphics.FromPdfPage(page);
            XFont headerFont = new XFont("Arial", 14, XFontStyleEx.Bold);
            XFont font = new XFont("Arial", 10);

            graphics.DrawString("Сводка посещения занятий", headerFont, XBrushes.Black, new XRect(0, 20, page.Width, 20), XStringFormats.Center);

            // Информация о студенте и группе в виде текста
            int yOffset = 60;

            string studentText = $"Студент: {student.Surname} {student.Name} {student.Lastname ?? ""}";
            string[] wrappedStudentText = WrapText(studentText, (int)(page.Width - 40), font, graphics);
            for (int line = 0; line < wrappedStudentText.Length; line++)
            {
                graphics.DrawString(wrappedStudentText[line], font, XBrushes.Black, new XRect(20, yOffset + line * 20, page.Width - 40, 20), XStringFormats.TopLeft);
            }
            yOffset += wrappedStudentText.Length * 20;

            string groupText = $"Группа: {student.StudGroup.Name}";
            string[] wrappedGroupText = WrapText(groupText, (int)(page.Width - 40), font, graphics);
            for (int line = 0; line < wrappedGroupText.Length; line++)
            {
                graphics.DrawString(wrappedGroupText[line], font, XBrushes.Black, new XRect(20, yOffset + line * 20, page.Width - 40, 20), XStringFormats.TopLeft);
            }
            yOffset += wrappedGroupText.Length * 20 + 20; // Добавляем отступ перед списком пропусков

            // Отображение данных о пропусках в виде текста
            if (absences.Count == 0)
            {
                graphics.DrawString("Пропусков нет", font, XBrushes.Black, new XRect(20, yOffset, page.Width - 40, 20), XStringFormats.TopLeft);
                yOffset += 20;
            }
            else
            {
                foreach (var absence in absences)
                {
                    string text = $"Дисциплина: {absence.Discipline.Name}, Дата: {absence.Date.ToString("dd.MM.yyyy HH:mm")}, Опоздание: {absence.DelayMinutes} мин, Причина: {absence.ExplanatoryNote ?? "Не указана"}";
                    string[] wrappedText = WrapText(text, (int)(page.Width - 40), font, graphics);

                    // Отрисовка текста построчно
                    for (int line = 0; line < wrappedText.Length; line++)
                    {
                        graphics.DrawString(wrappedText[line], font, XBrushes.Black, new XRect(20, yOffset + line * 20, page.Width - 40, 20), XStringFormats.TopLeft);
                    }
                    yOffset += wrappedText.Length * 20 + 10; // Добавляем небольшой отступ между записями
                }
            }

            string filePath = Environment.CurrentDirectory + $"\\AttendanceSummary_{studentId}.pdf";
            document.Save(filePath);
            MessageBox.Show("Сводка посещения занятий успешно сгенерирована.");
        }

        public void GenerateAttendanceSummaryForAllStudents()
        {
            var students = _studentsContext.Students.Include(s => s.StudGroup).ToList();
            var absences = _absencesContext.Absences.Include(a => a.Discipline).ToList();

            if (!students.Any())
            {
                MessageBox.Show("Студенты не найдены.");
                return;
            }

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Сводка посещения занятий для всех студентов";
            PdfPage page = document.AddPage();
            XGraphics graphics = XGraphics.FromPdfPage(page);
            XFont headerFont = new XFont("Arial", 12, XFontStyleEx.Bold);
            XFont font = new XFont("Arial", 8);

            graphics.DrawString("Сводка посещения занятий для всех студентов", headerFont, XBrushes.Black, new XRect(0, 20, page.Width, 20), XStringFormats.Center);

            // Таблица для всех студентов
            string[] headers = { "Студент", "Дисциплина", "Дата", "Опоздание (мин)", "Причина" };
            int[] maxWidths = new int[headers.Length];

            // Вычисляем максимальную длину текста для каждого столбца
            for (int i = 0; i < headers.Length; i++)
            {
                int headerWidth = headers[i].Length;
                int dataWidth = 0;
                if (i == 0) dataWidth = students.Any() ? students.Max(s => $"{s.Surname} {s.Name}".Length) : 0;
                else if (i == 1) dataWidth = absences.Any() ? absences.Max(a => a.Discipline.Name.Length) : 0;
                else if (i == 2) dataWidth = absences.Any() ? absences.Max(a => a.Date.ToString("dd.MM.yyyy HH:mm").Length) : 0;
                else if (i == 3) dataWidth = absences.Any() ? absences.Max(a => a.DelayMinutes.ToString().Length) : 0;
                else if (i == 4) dataWidth = absences.Any() ? absences.Max(a => (a.ExplanatoryNote ?? "Не указана").Length) : 0;
                maxWidths[i] = Math.Max(headerWidth, dataWidth);
            }

            // Вычисляем пропорции столбцов
            int totalMaxWidth = maxWidths.Sum();
            int totalAvailableWidth = 595 - 20 - 20 - (headers.Length - 1) * 10;
            int[] columnWidths = new int[headers.Length];
            for (int i = 0; i < headers.Length; i++)
            {
                columnWidths[i] = (int)((double)maxWidths[i] / totalMaxWidth * totalAvailableWidth);
            }

            int totalWidth = columnWidths.Sum() + (headers.Length - 1) * 10;
            int startX = 20;
            int yOffset = 60;

            // Отрисовка заголовков таблицы (с фоном, но без границ ячеек)
            graphics.DrawRectangle(new XSolidBrush(XColors.LightGray), startX, yOffset, totalWidth, 25);
            int currentX = startX;
            for (int i = 0; i < headers.Length; i++)
            {
                graphics.DrawString(headers[i], font, XBrushes.Black, new XRect(currentX, yOffset, columnWidths[i], 20), XStringFormats.Center);
                currentX += columnWidths[i] + 10;
            }

            yOffset += 25;

            // Отрисовка данных таблицы (без границ)
            foreach (var student in students)
            {
                var studentAbsences = absences.Where(a => a.StudentId == student.Id).ToList();
                if (studentAbsences.Any())
                {
                    foreach (var absence in studentAbsences)
                    {
                        string[] cellTexts = new string[]
                        {
                            $"{student.Surname} {student.Name}",
                            absence.Discipline.Name,
                            absence.Date.ToString("dd.MM.yyyy HH:mm"),
                            absence.DelayMinutes.ToString(),
                            absence.ExplanatoryNote ?? "Не указана"
                        };

                        int maxLines = 1;
                        string[][] wrappedTexts = new string[cellTexts.Length][];
                        for (int i = 0; i < cellTexts.Length; i++)
                        {
                            wrappedTexts[i] = WrapText(cellTexts[i], columnWidths[i], font, graphics);
                            maxLines = Math.Max(maxLines, wrappedTexts[i].Length);
                        }

                        int rowHeight = 20 * maxLines;

                        currentX = startX;
                        for (int i = 0; i < headers.Length; i++)
                        {
                            for (int line = 0; line < wrappedTexts[i].Length; line++)
                            {
                                graphics.DrawString(wrappedTexts[i][line], font, XBrushes.Black, new XRect(currentX, yOffset + line * 20, columnWidths[i], 20), XStringFormats.Center);
                            }
                            currentX += columnWidths[i] + 10;
                        }

                        yOffset += rowHeight;

                        if (yOffset > 800)
                        {
                            page = document.AddPage();
                            graphics = XGraphics.FromPdfPage(page);
                            yOffset = 20;
                            graphics.DrawString("Сводка посещения занятий для всех студентов (продолжение)", headerFont, XBrushes.Black, new XRect(0, 20, page.Width, 20), XStringFormats.Center);
                            yOffset = 60;
                            graphics.DrawRectangle(new XSolidBrush(XColors.LightGray), startX, yOffset, totalWidth, 25);
                            currentX = startX;
                            for (int i = 0; i < headers.Length; i++)
                            {
                                graphics.DrawString(headers[i], font, XBrushes.Black, new XRect(currentX, yOffset, columnWidths[i], 20), XStringFormats.Center);
                                currentX += columnWidths[i] + 10;
                            }
                            yOffset += 25;
                        }
                    }
                }
                else
                {
                    string noAbsencesText = $"{student.Surname} {student.Name}: Пропусков нет";
                    string[] wrappedText = WrapText(noAbsencesText, totalWidth, font, graphics);
                    int rowHeight = 20 * wrappedText.Length;

                    for (int line = 0; line < wrappedText.Length; line++)
                    {
                        graphics.DrawString(wrappedText[line], font, XBrushes.Black, new XRect(startX, yOffset + line * 20, totalWidth, 20), XStringFormats.TopLeft);
                    }
                    yOffset += rowHeight;

                    if (yOffset > 800)
                    {
                        page = document.AddPage();
                        graphics = XGraphics.FromPdfPage(page);
                        yOffset = 20;
                        graphics.DrawString("Сводка посещения занятий для всех студентов (продолжение)", headerFont, XBrushes.Black, new XRect(0, 20, page.Width, 20), XStringFormats.Center);
                        yOffset = 60;
                    }
                }
            }

            string filePath = Environment.CurrentDirectory + "\\AttendanceSummary_All.pdf";
            document.Save(filePath);
            MessageBox.Show("Сводка посещения для всех студентов успешно сгенерирована.");
        }

        public void GenerateAbsenceReport()
        {
            var absences = _absencesContext.Absences
                .Include(a => a.Student)
                .ThenInclude(s => s.StudGroup)
                .Include(a => a.Discipline)
                .ToList();

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Отчет по опозданиям";
            PdfPage page = document.AddPage();
            XGraphics graphics = XGraphics.FromPdfPage(page);
            XFont headerFont = new XFont("Arial", 14, XFontStyleEx.Bold);
            XFont font = new XFont("Arial", 10);

            graphics.DrawString("Отчет по опозданиям", headerFont, XBrushes.Black, new XRect(0, 20, page.Width, 20), XStringFormats.Center);

            string[] headers = { "№", "Студент", "Дисциплина", "Дата", "Опоздание (мин)" };
            int[] maxWidths = new int[headers.Length];

            for (int i = 0; i < headers.Length; i++)
            {
                int headerWidth = headers[i].Length;
                int dataWidth = 0;
                if (i == 0) dataWidth = absences.Any() ? absences.Max(a => a.Id.ToString().Length) : 0;
                else if (i == 1) dataWidth = absences.Any() ? absences.Max(a => $"{a.Student.Surname} {a.Student.Name}".Length) : 0;
                else if (i == 2) dataWidth = absences.Any() ? absences.Max(a => a.Discipline.Name.Length) : 0;
                else if (i == 3) dataWidth = absences.Any() ? absences.Max(a => a.Date.ToString("dd.MM.yyyy HH:mm").Length) : 0;
                else if (i == 4) dataWidth = absences.Any() ? absences.Max(a => a.DelayMinutes.ToString().Length) : 0;
                maxWidths[i] = Math.Max(headerWidth, dataWidth);
            }

            int totalMaxWidth = maxWidths.Sum();
            int totalAvailableWidth = 595 - 20 - 20 - (headers.Length - 1) * 10;
            int[] columnWidths = new int[headers.Length];
            for (int i = 0; i < headers.Length; i++)
            {
                columnWidths[i] = (int)((double)maxWidths[i] / totalMaxWidth * totalAvailableWidth);
            }

            int totalWidth = columnWidths.Sum() + (headers.Length - 1) * 10;
            int startX = 20;
            int yOffset = 60;

            graphics.DrawRectangle(new XSolidBrush(XColors.LightGray), startX, yOffset, totalWidth, 25);
            int currentX = startX;
            for (int i = 0; i < headers.Length; i++)
            {
                graphics.DrawRectangle(new XSolidBrush(XColors.White), currentX, yOffset, columnWidths[i], 20);
                graphics.DrawString(headers[i], font, XBrushes.Black, new XRect(currentX, yOffset, columnWidths[i], 20), XStringFormats.Center);
                currentX += columnWidths[i] + 10;
            }

            yOffset += 25;

            if (absences.Count == 0)
            {
                graphics.DrawRectangle(new XSolidBrush(XColors.White), startX, yOffset, totalWidth, 20);
                graphics.DrawString("Опозданий нет", font, XBrushes.Black, new XRect(startX, yOffset, totalWidth, 20), XStringFormats.Center);
            }
            else
            {
                for (int i = 0; i < absences.Count; i++)
                {
                    string[] cellTexts = new string[]
                    {
                        absences[i].Id.ToString(),
                        $"{absences[i].Student.Surname} {absences[i].Student.Name}",
                        absences[i].Discipline.Name,
                        absences[i].Date.ToString("dd.MM.yyyy HH:mm"),
                        absences[i].DelayMinutes.ToString()
                    };

                    int maxLines = 1;
                    string[][] wrappedTexts = new string[cellTexts.Length][];
                    for (int j = 0; j < cellTexts.Length; j++)
                    {
                        wrappedTexts[j] = WrapText(cellTexts[j], columnWidths[j], font, graphics);
                        maxLines = Math.Max(maxLines, wrappedTexts[j].Length);
                    }

                    int rowHeight = 20 * maxLines;

                    currentX = startX;
                    for (int j = 0; j < headers.Length; j++)
                    {
                        graphics.DrawRectangle(new XSolidBrush(XColors.White), currentX, yOffset, columnWidths[j], rowHeight);
                        for (int line = 0; line < wrappedTexts[j].Length; line++)
                        {
                            graphics.DrawString(wrappedTexts[j][line], font, XBrushes.Black, new XRect(currentX, yOffset + line * 20, columnWidths[j], 20), XStringFormats.Center);
                        }
                        currentX += columnWidths[j] + 10;
                    }

                    yOffset += rowHeight;
                }
            }

            string filePath = Environment.CurrentDirectory + "\\AbsenceReport.pdf";
            document.Save(filePath);
            MessageBox.Show("Отчет по опозданиям успешно сгенерирован.");
        }
    }
}