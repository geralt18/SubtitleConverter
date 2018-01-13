namespace SubtitleConverter
{
    partial class Form1
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
            this.xFramerate = new System.Windows.Forms.TextBox();
            this.xResolution = new System.Windows.Forms.TextBox();
            this.xName = new System.Windows.Forms.TextBox();
            this.xPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.xOpen = new System.Windows.Forms.Button();
            this.xOpenSub = new System.Windows.Forms.Button();
            this.xOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.xUwagi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // xFramerate
            // 
            this.xFramerate.Location = new System.Drawing.Point(122, 153);
            this.xFramerate.Name = "xFramerate";
            this.xFramerate.Size = new System.Drawing.Size(221, 20);
            this.xFramerate.TabIndex = 17;
            // 
            // xResolution
            // 
            this.xResolution.Location = new System.Drawing.Point(122, 117);
            this.xResolution.Name = "xResolution";
            this.xResolution.Size = new System.Drawing.Size(221, 20);
            this.xResolution.TabIndex = 16;
            // 
            // xName
            // 
            this.xName.Location = new System.Drawing.Point(122, 82);
            this.xName.Name = "xName";
            this.xName.Size = new System.Drawing.Size(221, 20);
            this.xName.TabIndex = 15;
            // 
            // xPath
            // 
            this.xPath.Location = new System.Drawing.Point(122, 53);
            this.xPath.Name = "xPath";
            this.xPath.Size = new System.Drawing.Size(221, 20);
            this.xPath.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Œcie¿ka";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Framerate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Rozdzielczoœæ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nazwa";
            // 
            // xOpen
            // 
            this.xOpen.Location = new System.Drawing.Point(12, 12);
            this.xOpen.Name = "xOpen";
            this.xOpen.Size = new System.Drawing.Size(119, 23);
            this.xOpen.TabIndex = 9;
            this.xOpen.Text = "Informacje o filmie";
            this.xOpen.UseVisualStyleBackColor = true;
            this.xOpen.Click += new System.EventHandler(this.xOpen_Click);
            // 
            // xOpenSub
            // 
            this.xOpenSub.Location = new System.Drawing.Point(242, 12);
            this.xOpenSub.Name = "xOpenSub";
            this.xOpenSub.Size = new System.Drawing.Size(119, 23);
            this.xOpenSub.TabIndex = 18;
            this.xOpenSub.Text = "Konwertuj napisy";
            this.xOpenSub.UseVisualStyleBackColor = true;
            this.xOpenSub.Click += new System.EventHandler(this.xOpenSub_Click);
            // 
            // xOpenFile
            // 
            this.xOpenFile.Filter = "Pliki napisów|*.txt|Wszystkie pliki|*.*";
            this.xOpenFile.Multiselect = true;
            this.xOpenFile.Title = "Wybierz plik wideo";
            // 
            // xUwagi
            // 
            this.xUwagi.Location = new System.Drawing.Point(33, 188);
            this.xUwagi.Multiline = true;
            this.xUwagi.Name = "xUwagi";
            this.xUwagi.Size = new System.Drawing.Size(310, 49);
            this.xUwagi.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 255);
            this.Controls.Add(this.xUwagi);
            this.Controls.Add(this.xOpenSub);
            this.Controls.Add(this.xFramerate);
            this.Controls.Add(this.xResolution);
            this.Controls.Add(this.xName);
            this.Controls.Add(this.xPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xOpen);
            this.Name = "Form1";
            this.Text = "SubtitleConverter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox xFramerate;
        private System.Windows.Forms.TextBox xResolution;
        private System.Windows.Forms.TextBox xName;
        private System.Windows.Forms.TextBox xPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button xOpen;
        private System.Windows.Forms.Button xOpenSub;
        private System.Windows.Forms.OpenFileDialog xOpenFile;
        private System.Windows.Forms.TextBox xUwagi;
    }
}

