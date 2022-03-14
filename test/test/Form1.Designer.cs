using System;
using System.Drawing;

namespace test
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.FPSlabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_y_mouse_move = new System.Windows.Forms.Label();
            this.label_x_mouse_move = new System.Windows.Forms.Label();
            this.label_x_mouse_down = new System.Windows.Forms.Label();
            this.label_y_mouse_down = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.показатьКадрсекундуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.координатыМышиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FPSlabel
            // 
            this.FPSlabel.AutoSize = true;
            this.FPSlabel.Location = new System.Drawing.Point(3, -1);
            this.FPSlabel.Name = "FPSlabel";
            this.FPSlabel.Size = new System.Drawing.Size(44, 16);
            this.FPSlabel.TabIndex = 0;
            this.FPSlabel.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_y_mouse_move);
            this.panel1.Controls.Add(this.label_x_mouse_move);
            this.panel1.Controls.Add(this.label_x_mouse_down);
            this.panel1.Controls.Add(this.label_y_mouse_down);
            this.panel1.Controls.Add(this.FPSlabel);
            this.panel1.Location = new System.Drawing.Point(12, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 409);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // label_y_mouse_move
            // 
            this.label_y_mouse_move.AutoSize = true;
            this.label_y_mouse_move.Location = new System.Drawing.Point(135, 16);
            this.label_y_mouse_move.Name = "label_y_mouse_move";
            this.label_y_mouse_move.Size = new System.Drawing.Size(40, 16);
            this.label_y_mouse_move.TabIndex = 4;
            this.label_y_mouse_move.Text = "None";
            // 
            // label_x_mouse_move
            // 
            this.label_x_mouse_move.AutoSize = true;
            this.label_x_mouse_move.Location = new System.Drawing.Point(135, 0);
            this.label_x_mouse_move.Name = "label_x_mouse_move";
            this.label_x_mouse_move.Size = new System.Drawing.Size(40, 16);
            this.label_x_mouse_move.TabIndex = 3;
            this.label_x_mouse_move.Text = "None";
            // 
            // label_x_mouse_down
            // 
            this.label_x_mouse_down.AutoSize = true;
            this.label_x_mouse_down.Location = new System.Drawing.Point(68, 0);
            this.label_x_mouse_down.Name = "label_x_mouse_down";
            this.label_x_mouse_down.Size = new System.Drawing.Size(40, 16);
            this.label_x_mouse_down.TabIndex = 2;
            this.label_x_mouse_down.Text = "None";
            // 
            // label_y_mouse_down
            // 
            this.label_y_mouse_down.AutoSize = true;
            this.label_y_mouse_down.Location = new System.Drawing.Point(68, 16);
            this.label_y_mouse_down.Name = "label_y_mouse_down";
            this.label_y_mouse_down.Size = new System.Drawing.Size(40, 16);
            this.label_y_mouse_down.TabIndex = 1;
            this.label_y_mouse_down.Text = "None";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.показатьКадрсекундуToolStripMenuItem,
            this.координатыМышиToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(248, 6);
            // 
            // показатьКадрсекундуToolStripMenuItem
            // 
            this.показатьКадрсекундуToolStripMenuItem.Name = "показатьКадрсекундуToolStripMenuItem";
            this.показатьКадрсекундуToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.показатьКадрсекундуToolStripMenuItem.Text = "Показать кадр/секунду";
            this.показатьКадрсекундуToolStripMenuItem.Click += new System.EventHandler(this.FPSToolStripMenuItem_Click);
            // 
            // координатыМышиToolStripMenuItem
            // 
            this.координатыМышиToolStripMenuItem.Name = "координатыМышиToolStripMenuItem";
            this.координатыМышиToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.координатыМышиToolStripMenuItem.Text = " Координаты мыши";
            this.координатыМышиToolStripMenuItem.Click += new System.EventHandler(this.координатыМышиToolStripMenuItem_Click);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FPSlabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem показатьКадрсекундуToolStripMenuItem;
        private System.Windows.Forms.Label label_y_mouse_move;
        private System.Windows.Forms.Label label_x_mouse_move;
        private System.Windows.Forms.Label label_x_mouse_down;
        private System.Windows.Forms.Label label_y_mouse_down;
        private System.Windows.Forms.ToolStripMenuItem координатыМышиToolStripMenuItem;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
    }
}

