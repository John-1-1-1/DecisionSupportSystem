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
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.показатьКадрсекундуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.координатыМышиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редакторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_del = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.Panel();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.CreatorPanel = new System.Windows.Forms.Panel();
            this.buttonSaveInfo = new System.Windows.Forms.Button();
            this.oidBox = new System.Windows.Forms.TextBox();
            this.oidLabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.menu.SuspendLayout();
            this.CreatorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FPSlabel
            // 
            this.FPSlabel.AutoSize = true;
            this.FPSlabel.Location = new System.Drawing.Point(2, -1);
            this.FPSlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FPSlabel.Name = "FPSlabel";
            this.FPSlabel.Size = new System.Drawing.Size(35, 13);
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
            this.panel1.Location = new System.Drawing.Point(9, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 327);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // label_y_mouse_move
            // 
            this.label_y_mouse_move.AutoSize = true;
            this.label_y_mouse_move.Location = new System.Drawing.Point(101, 13);
            this.label_y_mouse_move.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_y_mouse_move.Name = "label_y_mouse_move";
            this.label_y_mouse_move.Size = new System.Drawing.Size(33, 13);
            this.label_y_mouse_move.TabIndex = 4;
            this.label_y_mouse_move.Text = "None";
            // 
            // label_x_mouse_move
            // 
            this.label_x_mouse_move.AutoSize = true;
            this.label_x_mouse_move.Location = new System.Drawing.Point(101, 0);
            this.label_x_mouse_move.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_x_mouse_move.Name = "label_x_mouse_move";
            this.label_x_mouse_move.Size = new System.Drawing.Size(33, 13);
            this.label_x_mouse_move.TabIndex = 3;
            this.label_x_mouse_move.Text = "None";
            // 
            // label_x_mouse_down
            // 
            this.label_x_mouse_down.AutoSize = true;
            this.label_x_mouse_down.Location = new System.Drawing.Point(51, 0);
            this.label_x_mouse_down.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_x_mouse_down.Name = "label_x_mouse_down";
            this.label_x_mouse_down.Size = new System.Drawing.Size(33, 13);
            this.label_x_mouse_down.TabIndex = 2;
            this.label_x_mouse_down.Text = "None";
            // 
            // label_y_mouse_down
            // 
            this.label_y_mouse_down.AutoSize = true;
            this.label_y_mouse_down.Location = new System.Drawing.Point(51, 13);
            this.label_y_mouse_down.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_y_mouse_down.Name = "label_y_mouse_down";
            this.label_y_mouse_down.Size = new System.Drawing.Size(33, 13);
            this.label_y_mouse_down.TabIndex = 1;
            this.label_y_mouse_down.Text = "None";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.режимыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(744, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.sToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.показатьКадрсекундуToolStripMenuItem,
            this.координатыМышиToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // показатьКадрсекундуToolStripMenuItem
            // 
            this.показатьКадрсекундуToolStripMenuItem.Name = "показатьКадрсекундуToolStripMenuItem";
            this.показатьКадрсекундуToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.показатьКадрсекундуToolStripMenuItem.Text = "Показать кадр/секунду";
            this.показатьКадрсекундуToolStripMenuItem.Click += new System.EventHandler(this.FPSToolStripMenuItem_Click);
            // 
            // координатыМышиToolStripMenuItem
            // 
            this.координатыМышиToolStripMenuItem.Name = "координатыМышиToolStripMenuItem";
            this.координатыМышиToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.координатыМышиToolStripMenuItem.Text = " Координаты мыши";
            this.координатыМышиToolStripMenuItem.Click += new System.EventHandler(this.координатыМышиToolStripMenuItem_Click);
            // 
            // режимыToolStripMenuItem
            // 
            this.режимыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редакторToolStripMenuItem,
            this.просмотрToolStripMenuItem});
            this.режимыToolStripMenuItem.Name = "режимыToolStripMenuItem";
            this.режимыToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.режимыToolStripMenuItem.Text = "Режимы";
            // 
            // редакторToolStripMenuItem
            // 
            this.редакторToolStripMenuItem.Name = "редакторToolStripMenuItem";
            this.редакторToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.редакторToolStripMenuItem.Text = "Редактор";
            this.редакторToolStripMenuItem.Click += new System.EventHandler(this.редакторToolStripMenuItem_Click);
            // 
            // просмотрToolStripMenuItem
            // 
            this.просмотрToolStripMenuItem.Name = "просмотрToolStripMenuItem";
            this.просмотрToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.просмотрToolStripMenuItem.Text = "Просмотр";
            this.просмотрToolStripMenuItem.Click += new System.EventHandler(this.просмотрToolStripMenuItem_Click);
            // 
            // button_del
            // 
            this.button_del.Location = new System.Drawing.Point(4, 4);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(75, 23);
            this.button_del.TabIndex = 0;
            this.button_del.Text = "Удалить";
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click_1);
            // 
            // menu
            // 
            this.menu.Controls.Add(this.button_del);
            this.menu.Location = new System.Drawing.Point(0, 251);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(200, 100);
            this.menu.TabIndex = 6;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Парамерт";
            this.columnHeader1.Width = 68;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Значение";
            this.columnHeader2.Width = 100;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(598, 24);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(135, 327);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // CreatorPanel
            // 
            this.CreatorPanel.Controls.Add(this.buttonSaveInfo);
            this.CreatorPanel.Controls.Add(this.oidBox);
            this.CreatorPanel.Controls.Add(this.oidLabel);
            this.CreatorPanel.Controls.Add(this.NameBox);
            this.CreatorPanel.Controls.Add(this.NameLabel);
            this.CreatorPanel.Location = new System.Drawing.Point(0, 106);
            this.CreatorPanel.Name = "CreatorPanel";
            this.CreatorPanel.Size = new System.Drawing.Size(156, 84);
            this.CreatorPanel.TabIndex = 7;
            // 
            // buttonSaveInfo
            // 
            this.buttonSaveInfo.Location = new System.Drawing.Point(71, 56);
            this.buttonSaveInfo.Name = "buttonSaveInfo";
            this.buttonSaveInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveInfo.TabIndex = 4;
            this.buttonSaveInfo.Text = "Сохранить";
            this.buttonSaveInfo.UseVisualStyleBackColor = true;
            this.buttonSaveInfo.Click += new System.EventHandler(this.buttonSaveInfo_Click);
            // 
            // oidBox
            // 
            this.oidBox.Location = new System.Drawing.Point(46, 30);
            this.oidBox.Name = "oidBox";
            this.oidBox.Size = new System.Drawing.Size(100, 20);
            this.oidBox.TabIndex = 3;
            // 
            // oidLabel
            // 
            this.oidLabel.AutoSize = true;
            this.oidLabel.Location = new System.Drawing.Point(3, 33);
            this.oidLabel.Name = "oidLabel";
            this.oidLabel.Size = new System.Drawing.Size(26, 13);
            this.oidLabel.TabIndex = 2;
            this.oidLabel.Text = "OID";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(46, 4);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(100, 20);
            this.NameBox.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(3, 7);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(29, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Имя";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 358);
            this.Controls.Add(this.CreatorPanel);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.CreatorPanel.ResumeLayout(false);
            this.CreatorPanel.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem режимыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редакторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel CreatorPanel;
        private System.Windows.Forms.TextBox oidBox;
        private System.Windows.Forms.Label oidLabel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button buttonSaveInfo;
    }
}

