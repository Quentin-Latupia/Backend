namespace WinFormsUtilisateur
{
    partial class formCalendrier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelCalendar = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelCalendar
            // 
            this.panelCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCalendar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelCalendar.Location = new System.Drawing.Point(0, 0);
            this.panelCalendar.Name = "panelCalendar";
            this.panelCalendar.Size = new System.Drawing.Size(800, 450);
            this.panelCalendar.TabIndex = 0;
            this.panelCalendar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCalendar_Paint);
            this.panelCalendar.Resize += new System.EventHandler(this.panelCalendar_Resize);
            this.panelCalendar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelCalendar_MouseClick);
            this.panelCalendar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCalendar_MouseMove);
            // 
            // chkWeekView
            // 
            this.chkWeekView = new System.Windows.Forms.CheckBox();
            this.chkWeekView.AutoSize = true;
            this.chkWeekView.Location = new System.Drawing.Point(8, 8);
            this.chkWeekView.Name = "chkWeekView";
            this.chkWeekView.Size = new System.Drawing.Size(90, 19);
            this.chkWeekView.TabIndex = 1;
            this.chkWeekView.Text = "Vue semaine";
            this.chkWeekView.UseVisualStyleBackColor = true;
            this.chkWeekView.CheckedChanged += new System.EventHandler(this.chkWeekView_CheckedChanged);
            this.panelCalendar.Controls.Add(this.chkWeekView);
            // 
            // formCalendrier
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelCalendar);
            this.Name = "formCalendrier";
            this.Text = "Calendrier";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCalendar;
        private System.Windows.Forms.CheckBox chkWeekView;
    }
}