namespace WinFormsUtilisateur
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            utilisateurToolStripMenuItem = new ToolStripMenuItem();
            membreToolStripMenuItem = new ToolStripMenuItem();
            adminGlobalToolStripMenuItem = new ToolStripMenuItem();
            adminSiteToolStripMenuItem = new ToolStripMenuItem();
            menuoptionToolStripMenuItem = new ToolStripMenuItem();
            planingToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(11, 171);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(780, 269);
            dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { utilisateurToolStripMenuItem, menuoptionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // utilisateurToolStripMenuItem
            // 
            utilisateurToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { membreToolStripMenuItem, adminGlobalToolStripMenuItem, adminSiteToolStripMenuItem });
            utilisateurToolStripMenuItem.Name = "utilisateurToolStripMenuItem";
            utilisateurToolStripMenuItem.Size = new Size(71, 20);
            utilisateurToolStripMenuItem.Text = "utilisateur";
            // 
            // membreToolStripMenuItem
            // 
            membreToolStripMenuItem.Name = "membreToolStripMenuItem";
            membreToolStripMenuItem.Size = new Size(180, 22);
            membreToolStripMenuItem.Text = "membre";
            membreToolStripMenuItem.Click += membreToolStripMenuItem_Click;
            // 
            // adminGlobalToolStripMenuItem
            // 
            adminGlobalToolStripMenuItem.Name = "adminGlobalToolStripMenuItem";
            adminGlobalToolStripMenuItem.Size = new Size(180, 22);
            adminGlobalToolStripMenuItem.Text = "adminGlobal";
            adminGlobalToolStripMenuItem.Click += adminGlobalToolStripMenuItem_Click;
            // 
            // adminSiteToolStripMenuItem
            // 
            adminSiteToolStripMenuItem.Name = "adminSiteToolStripMenuItem";
            adminSiteToolStripMenuItem.Size = new Size(180, 22);
            adminSiteToolStripMenuItem.Text = "adminSite";
            adminSiteToolStripMenuItem.Click += adminSiteToolStripMenuItem_Click;
            // 
            // menuoptionToolStripMenuItem
            // 
            menuoptionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { planingToolStripMenuItem });
            menuoptionToolStripMenuItem.Name = "menuoptionToolStripMenuItem";
            menuoptionToolStripMenuItem.Size = new Size(90, 20);
            menuoptionToolStripMenuItem.Text = "menu_option";
            // 
            // planingToolStripMenuItem
            // 
            planingToolStripMenuItem.Name = "planingToolStripMenuItem";
            planingToolStripMenuItem.Size = new Size(180, 22);
            planingToolStripMenuItem.Text = "planing";
            planingToolStripMenuItem.Click += planingToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem utilisateurToolStripMenuItem;
        private ToolStripMenuItem membreToolStripMenuItem;
        private ToolStripMenuItem adminGlobalToolStripMenuItem;
        private ToolStripMenuItem adminSiteToolStripMenuItem;
        private ToolStripMenuItem menuoptionToolStripMenuItem;
        private ToolStripMenuItem planingToolStripMenuItem;
    }
}
