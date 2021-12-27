namespace RLE
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pgb_archive = new System.Windows.Forms.ProgressBar();
            this.lbl_result = new System.Windows.Forms.Label();
            this.btn_start_rle = new System.Windows.Forms.Button();
            this.lbl_file_path = new System.Windows.Forms.Label();
            this.btn_set_file = new System.Windows.Forms.Button();
            this.tbx_pass = new System.Windows.Forms.TextBox();
            this.lbl_set_pass = new System.Windows.Forms.Label();
            this.cbx_set_pass = new System.Windows.Forms.CheckBox();
            this.cbx_del_files = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_get_archive = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.rb_rle = new System.Windows.Forms.RadioButton();
            this.rb_btw = new System.Windows.Forms.RadioButton();
            this.rb_hf = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_hf_un = new System.Windows.Forms.RadioButton();
            this.rb_btw_un = new System.Windows.Forms.RadioButton();
            this.rb_rle_un = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_cnt_frag = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(471, 236);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbx_cnt_frag);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.rb_hf);
            this.tabPage1.Controls.Add(this.rb_btw);
            this.tabPage1.Controls.Add(this.rb_rle);
            this.tabPage1.Controls.Add(this.pgb_archive);
            this.tabPage1.Controls.Add(this.lbl_result);
            this.tabPage1.Controls.Add(this.btn_start_rle);
            this.tabPage1.Controls.Add(this.lbl_file_path);
            this.tabPage1.Controls.Add(this.btn_set_file);
            this.tabPage1.Controls.Add(this.tbx_pass);
            this.tabPage1.Controls.Add(this.lbl_set_pass);
            this.tabPage1.Controls.Add(this.cbx_set_pass);
            this.tabPage1.Controls.Add(this.cbx_del_files);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(463, 210);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Архивация";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pgb_archive
            // 
            this.pgb_archive.Location = new System.Drawing.Point(76, 181);
            this.pgb_archive.Name = "pgb_archive";
            this.pgb_archive.Size = new System.Drawing.Size(373, 23);
            this.pgb_archive.TabIndex = 8;
            this.pgb_archive.Value = 1;
            this.pgb_archive.Visible = false;
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Location = new System.Drawing.Point(13, 185);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(56, 13);
            this.lbl_result.TabIndex = 7;
            this.lbl_result.Text = "Прогресс";
            this.lbl_result.Visible = false;
            // 
            // btn_start_rle
            // 
            this.btn_start_rle.Enabled = false;
            this.btn_start_rle.Location = new System.Drawing.Point(128, 144);
            this.btn_start_rle.Name = "btn_start_rle";
            this.btn_start_rle.Size = new System.Drawing.Size(223, 23);
            this.btn_start_rle.TabIndex = 6;
            this.btn_start_rle.Text = "Архивировать";
            this.btn_start_rle.UseVisualStyleBackColor = true;
            this.btn_start_rle.Click += new System.EventHandler(this.btn_start_rle_Click);
            // 
            // lbl_file_path
            // 
            this.lbl_file_path.AutoSize = true;
            this.lbl_file_path.Location = new System.Drawing.Point(214, 31);
            this.lbl_file_path.Name = "lbl_file_path";
            this.lbl_file_path.Size = new System.Drawing.Size(95, 13);
            this.lbl_file_path.TabIndex = 5;
            this.lbl_file_path.Text = "Файл НЕ выбран";
            // 
            // btn_set_file
            // 
            this.btn_set_file.Location = new System.Drawing.Point(19, 26);
            this.btn_set_file.Name = "btn_set_file";
            this.btn_set_file.Size = new System.Drawing.Size(150, 23);
            this.btn_set_file.TabIndex = 4;
            this.btn_set_file.Text = "Загрузить файл";
            this.btn_set_file.UseVisualStyleBackColor = true;
            this.btn_set_file.Click += new System.EventHandler(this.btn_set_file_Click);
            // 
            // tbx_pass
            // 
            this.tbx_pass.Location = new System.Drawing.Point(342, 72);
            this.tbx_pass.Name = "tbx_pass";
            this.tbx_pass.Size = new System.Drawing.Size(100, 20);
            this.tbx_pass.TabIndex = 3;
            this.tbx_pass.Visible = false;
            // 
            // lbl_set_pass
            // 
            this.lbl_set_pass.AutoSize = true;
            this.lbl_set_pass.Location = new System.Drawing.Point(288, 75);
            this.lbl_set_pass.Name = "lbl_set_pass";
            this.lbl_set_pass.Size = new System.Drawing.Size(45, 13);
            this.lbl_set_pass.TabIndex = 2;
            this.lbl_set_pass.Text = "Пароль";
            this.lbl_set_pass.Visible = false;
            // 
            // cbx_set_pass
            // 
            this.cbx_set_pass.AutoSize = true;
            this.cbx_set_pass.Location = new System.Drawing.Point(175, 74);
            this.cbx_set_pass.Name = "cbx_set_pass";
            this.cbx_set_pass.Size = new System.Drawing.Size(101, 17);
            this.cbx_set_pass.TabIndex = 1;
            this.cbx_set_pass.Text = "Задать пароль";
            this.cbx_set_pass.UseVisualStyleBackColor = true;
            this.cbx_set_pass.CheckedChanged += new System.EventHandler(this.cbx_set_pass_CheckedChanged);
            // 
            // cbx_del_files
            // 
            this.cbx_del_files.AutoSize = true;
            this.cbx_del_files.Location = new System.Drawing.Point(19, 75);
            this.cbx_del_files.Name = "cbx_del_files";
            this.cbx_del_files.Size = new System.Drawing.Size(150, 17);
            this.cbx_del_files.TabIndex = 0;
            this.cbx_del_files.Text = "Удалить исходный файл";
            this.cbx_del_files.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.rb_hf_un);
            this.tabPage2.Controls.Add(this.rb_btw_un);
            this.tabPage2.Controls.Add(this.rb_rle_un);
            this.tabPage2.Controls.Add(this.btn_get_archive);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(472, 210);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Восстановление";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_get_archive
            // 
            this.btn_get_archive.Enabled = false;
            this.btn_get_archive.Location = new System.Drawing.Point(54, 42);
            this.btn_get_archive.Name = "btn_get_archive";
            this.btn_get_archive.Size = new System.Drawing.Size(150, 23);
            this.btn_get_archive.TabIndex = 5;
            this.btn_get_archive.Text = "Выбрать файл";
            this.btn_get_archive.UseVisualStyleBackColor = true;
            this.btn_get_archive.Click += new System.EventHandler(this.btn_get_archive_Click);
            // 
            // rb_rle
            // 
            this.rb_rle.AutoSize = true;
            this.rb_rle.Location = new System.Drawing.Point(76, 112);
            this.rb_rle.Name = "rb_rle";
            this.rb_rle.Size = new System.Drawing.Size(46, 17);
            this.rb_rle.TabIndex = 9;
            this.rb_rle.TabStop = true;
            this.rb_rle.Text = "RLE";
            this.rb_rle.UseVisualStyleBackColor = true;
            // 
            // rb_btw
            // 
            this.rb_btw.AutoSize = true;
            this.rb_btw.Location = new System.Drawing.Point(128, 112);
            this.rb_btw.Name = "rb_btw";
            this.rb_btw.Size = new System.Drawing.Size(50, 17);
            this.rb_btw.TabIndex = 10;
            this.rb_btw.TabStop = true;
            this.rb_btw.Text = "BTW";
            this.rb_btw.UseVisualStyleBackColor = true;
            // 
            // rb_hf
            // 
            this.rb_hf.AutoSize = true;
            this.rb_hf.Location = new System.Drawing.Point(184, 112);
            this.rb_hf.Name = "rb_hf";
            this.rb_hf.Size = new System.Drawing.Size(39, 17);
            this.rb_hf.TabIndex = 11;
            this.rb_hf.TabStop = true;
            this.rb_hf.Text = "HF";
            this.rb_hf.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Метод";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Метод";
            // 
            // rb_hf_un
            // 
            this.rb_hf_un.AutoSize = true;
            this.rb_hf_un.Location = new System.Drawing.Point(185, 19);
            this.rb_hf_un.Name = "rb_hf_un";
            this.rb_hf_un.Size = new System.Drawing.Size(39, 17);
            this.rb_hf_un.TabIndex = 15;
            this.rb_hf_un.TabStop = true;
            this.rb_hf_un.Text = "HF";
            this.rb_hf_un.UseVisualStyleBackColor = true;
            this.rb_hf_un.CheckedChanged += new System.EventHandler(this.rb_hf_un_CheckedChanged);
            // 
            // rb_btw_un
            // 
            this.rb_btw_un.AutoSize = true;
            this.rb_btw_un.Location = new System.Drawing.Point(129, 19);
            this.rb_btw_un.Name = "rb_btw_un";
            this.rb_btw_un.Size = new System.Drawing.Size(50, 17);
            this.rb_btw_un.TabIndex = 14;
            this.rb_btw_un.TabStop = true;
            this.rb_btw_un.Text = "BTW";
            this.rb_btw_un.UseVisualStyleBackColor = true;
            this.rb_btw_un.CheckedChanged += new System.EventHandler(this.rb_btw_un_CheckedChanged);
            // 
            // rb_rle_un
            // 
            this.rb_rle_un.AutoSize = true;
            this.rb_rle_un.Location = new System.Drawing.Point(77, 19);
            this.rb_rle_un.Name = "rb_rle_un";
            this.rb_rle_un.Size = new System.Drawing.Size(46, 17);
            this.rb_rle_un.TabIndex = 13;
            this.rb_rle_un.TabStop = true;
            this.rb_rle_un.Text = "RLE";
            this.rb_rle_un.UseVisualStyleBackColor = true;
            this.rb_rle_un.CheckedChanged += new System.EventHandler(this.rb_rle_un_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Количество частей";
            // 
            // tbx_cnt_frag
            // 
            this.tbx_cnt_frag.Location = new System.Drawing.Point(342, 112);
            this.tbx_cnt_frag.Name = "tbx_cnt_frag";
            this.tbx_cnt_frag.Size = new System.Drawing.Size(100, 20);
            this.tbx_cnt_frag.TabIndex = 14;
            this.tbx_cnt_frag.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 272);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbx_pass;
        private System.Windows.Forms.Label lbl_set_pass;
        private System.Windows.Forms.CheckBox cbx_set_pass;
        private System.Windows.Forms.CheckBox cbx_del_files;
        private System.Windows.Forms.Button btn_set_file;
        private System.Windows.Forms.Label lbl_file_path;
        private System.Windows.Forms.Button btn_start_rle;
        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.ProgressBar pgb_archive;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_get_archive;
        private System.Windows.Forms.RadioButton rb_btw;
        private System.Windows.Forms.RadioButton rb_rle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_hf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb_hf_un;
        private System.Windows.Forms.RadioButton rb_btw_un;
        private System.Windows.Forms.RadioButton rb_rle_un;
        private System.Windows.Forms.TextBox tbx_cnt_frag;
        private System.Windows.Forms.Label label3;
    }
}

