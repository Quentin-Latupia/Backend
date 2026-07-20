using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsUtilisateur
{
    public partial class formCalendrier : Form
    {
        private class SlotInfo
        {
            public RectangleF Rect;
            public DateTime Start;
            public DateTime End;
            public int DayIndex; // 0 = today
        }

        private List<SlotInfo> visibleSlots = new List<SlotInfo>();
        private int selectedSlot = -1;
        private int hoverSlot = -1;
        // Configuration du calendrier
        private readonly TimeSpan SlotDuration = TimeSpan.FromMinutes(90); // durée d'une case
        private readonly TimeSpan SlotSpacing = TimeSpan.FromMinutes(15); // espacement entre cases
        private readonly int HoursToShow = 12; // nombre d'heures affichées verticalement
        private readonly int StartHour = 8; // heure de début (8h00)

        public formCalendrier()
        {
            InitializeComponent();
        }

        private void panelCalendar_Resize(object sender, EventArgs e)
        {
            panelCalendar.Invalidate();
        }

        private void panelCalendar_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(panelCalendar.BackColor);

            int width = panelCalendar.ClientSize.Width;
            int height = panelCalendar.ClientSize.Height;

            // marges
            int leftMargin = 60; // espace pour labels horaires
            int topOffset = 30; // espace réservé pour en-têtes (jours / checkbox)
            if (this.chkWeekView != null)
            {
                topOffset = Math.Max(topOffset, this.chkWeekView.Height + 12);
            }

            // calcul de la hauteur d'une minute en pixels (zone utile sans l'en-tête)
            double totalMinutes = HoursToShow * 60.0;
            double pxPerMinute = (height - topOffset) / totalMinutes;

            // dessiner les lignes horaires principales (toutes les heures)
            using (var penLine = new Pen(Color.LightGray))
            using (var penSlot = new Pen(Color.Black, 1.2f))
            using (var brushText = new SolidBrush(Color.Black))
            using (var font = new Font("Segoe UI", 9))
            {
                // reset des slots visibles
                visibleSlots.Clear();
                for (int h = 0; h <= HoursToShow; h++)
                {
                    int y = (int)Math.Round(topOffset + h * 60 * pxPerMinute);
                    g.DrawLine(penLine, leftMargin, y, width, y);
                    // label horaire à gauche
                    var hour = StartHour + h;
                    var label = (hour % 24).ToString("D2") + ":00";
                    g.DrawString(label, font, brushText, 4, y - 8);
                }
                // si vue semaine
                if (this.chkWeekView != null && this.chkWeekView.Checked)
                {
                    int days = 7;
                    float contentWidth = width - leftMargin - 8;
                    float colW = contentWidth / days;

                    // en-têtes de jour
                    for (int d = 0; d < days; d++)
                    {
                        float x = leftMargin + d * colW;
                        string dayLabel = DateTime.Today.AddDays(d).ToString("ddd dd/MM");
                        g.DrawString(dayLabel, font, brushText, x + 4, 4);
                        g.DrawLine(penLine, x, topOffset, x, height);
                    }

                    // dessiner les cases par colonne
                    for (int d = 0; d < days; d++)
                    {
                        DateTime colStart = DateTime.Today.AddDays(d).AddHours(StartHour);
                        DateTime colEnd = colStart.AddHours(HoursToShow);
                        DateTime cursor = colStart;
                        int slotIndex = 0;
                        while (cursor < colEnd)
                        {
                            var slotStart = cursor;
                            var slotEnd = slotStart + SlotDuration;
                            if (slotEnd > colEnd) slotEnd = colEnd;

                            double minutesFromStart = (slotStart - DateTime.Today).TotalMinutes - StartHour * 60.0;
                            double minutesToEnd = (slotEnd - DateTime.Today).TotalMinutes - StartHour * 60.0;
                            float y1 = (float)(topOffset + minutesFromStart * pxPerMinute);
                            float y2 = (float)(topOffset + minutesToEnd * pxPerMinute);

                            RectangleF rect = new RectangleF(leftMargin + d * colW + 4, y1 + 2, colW - 8, Math.Max(4, y2 - y1 - 4));

                            // enregistrer le slot
                            visibleSlots.Add(new SlotInfo { Rect = rect, Start = slotStart, End = slotEnd, DayIndex = d });

                            // dessin avec prise en compte de la sélection / hover
                            bool isSelected = (visibleSlots.Count - 1) == selectedSlot;
                            bool isHover = (visibleSlots.Count - 1) == hoverSlot;
                            Color fill = (slotIndex % 2 == 0) ? Color.FromArgb(230, 240, 255) : Color.FromArgb(240, 255, 230);
                            if (isSelected) fill = Color.FromArgb(180, 200, 255);
                            if (isHover && !isSelected) fill = Color.FromArgb(210, 230, 255);
                            using (var brushFill = new SolidBrush(fill))
                            {
                                g.FillRectangle(brushFill, rect);
                            }

                            if (isSelected)
                            {
                                using (var selPen = new Pen(Color.DodgerBlue, 2.2f))
                                {
                                    g.DrawRectangle(selPen, rect.X, rect.Y, rect.Width, rect.Height);
                                }
                            }
                            else
                            {
                                g.DrawRectangle(penSlot, rect.X, rect.Y, rect.Width, rect.Height);
                            }

                            string text = slotStart.ToString("HH:mm") + " - " + slotEnd.ToString("HH:mm");
                            g.DrawString(text, font, brushText, rect.X + 4, rect.Y + 4);

                            cursor = slotEnd + SlotSpacing;
                            slotIndex++;
                        }
                    }
                }
                else
                {
                    // affichage journalier unique (colonne)
                    DateTime colStart = DateTime.Today.AddHours(StartHour);
                    DateTime colEnd = colStart.AddHours(HoursToShow);
                    DateTime cursor = colStart;

                    int slotIndex = 0;
                    while (cursor < colEnd)
                    {
                        var slotStart = cursor;
                        var slotEnd = slotStart + SlotDuration;
                        if (slotEnd > colEnd)
                            slotEnd = colEnd;

                        double minutesFromStart = (slotStart - DateTime.Today).TotalMinutes - StartHour * 60.0;
                        double minutesToEnd = (slotEnd - DateTime.Today).TotalMinutes - StartHour * 60.0;
                        float y1 = (float)(topOffset + minutesFromStart * pxPerMinute);
                        float y2 = (float)(topOffset + minutesToEnd * pxPerMinute);

                        RectangleF rect = new RectangleF(leftMargin, y1 + 2, width - leftMargin - 10, Math.Max(4, y2 - y1 - 4));

                        // enregistrer le slot
                        visibleSlots.Add(new SlotInfo { Rect = rect, Start = slotStart, End = slotEnd, DayIndex = 0 });

                        int currentIndex = visibleSlots.Count - 1;
                        bool isSelected = currentIndex == selectedSlot;
                        bool isHover = currentIndex == hoverSlot;

                        Color fill = (slotIndex % 2 == 0) ? Color.FromArgb(230, 240, 255) : Color.FromArgb(240, 255, 230);
                        if (isSelected) fill = Color.FromArgb(180, 200, 255);
                        if (isHover && !isSelected) fill = Color.FromArgb(210, 230, 255);
                        using (var brushFill = new SolidBrush(fill))
                        {
                            g.FillRectangle(brushFill, rect);
                        }

                        if (isSelected)
                        {
                            using (var selPen = new Pen(Color.DodgerBlue, 2.2f))
                            {
                                g.DrawRectangle(selPen, rect.X, rect.Y, rect.Width, rect.Height);
                            }
                        }
                        else
                        {
                            g.DrawRectangle(penSlot, rect.X, rect.Y, rect.Width, rect.Height);
                        }

                        // texte de la case
                        string text = slotStart.ToString("HH:mm") + " - " + slotEnd.ToString("HH:mm");
                        g.DrawString(text, font, brushText, rect.X + 4, rect.Y + 4);

                        // avancer le curseur: slot + espacement
                        cursor = slotEnd + SlotSpacing;
                        slotIndex++;
                    }
                }
            }
        }

        private void panelCalendar_MouseClick(object sender, MouseEventArgs e)
        {
            PointF pf = new PointF(e.X, e.Y);
            int found = -1;
            for (int i = 0; i < visibleSlots.Count; i++)
            {
                if (visibleSlots[i].Rect.Contains(pf))
                {
                    found = i;
                    break;
                }
            }

            if (found != selectedSlot)
            {
                selectedSlot = found;
                panelCalendar.Invalidate();
            }
        }

        private void panelCalendar_MouseMove(object sender, MouseEventArgs e)
        {
            PointF pf = new PointF(e.X, e.Y);
            int found = -1;
            for (int i = 0; i < visibleSlots.Count; i++)
            {
                if (visibleSlots[i].Rect.Contains(pf))
                {
                    found = i;
                    break;
                }
            }

            if (found != hoverSlot)
            {
                hoverSlot = found;
                panelCalendar.Cursor = (hoverSlot >= 0) ? Cursors.Hand : Cursors.Default;
                panelCalendar.Invalidate();
            }
        }

        private void chkWeekView_CheckedChanged(object sender, EventArgs e)
        {
            panelCalendar.Invalidate();
        }
    }
}
