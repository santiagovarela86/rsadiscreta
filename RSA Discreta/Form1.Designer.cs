namespace RSA_Discreta
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
            this.btn_Generar = new System.Windows.Forms.Button();
            this.btn_MostrarClaves = new System.Windows.Forms.Button();
            this.btn_Encriptar = new System.Windows.Forms.Button();
            this.btn_Desencriptar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Generar
            // 
            this.btn_Generar.Location = new System.Drawing.Point(13, 13);
            this.btn_Generar.Name = "btn_Generar";
            this.btn_Generar.Size = new System.Drawing.Size(101, 23);
            this.btn_Generar.TabIndex = 0;
            this.btn_Generar.Text = "Generar Claves";
            this.btn_Generar.UseVisualStyleBackColor = true;
            this.btn_Generar.Click += new System.EventHandler(this.btn_Generar_Click);
            // 
            // btn_MostrarClaves
            // 
            this.btn_MostrarClaves.Enabled = false;
            this.btn_MostrarClaves.Location = new System.Drawing.Point(120, 13);
            this.btn_MostrarClaves.Name = "btn_MostrarClaves";
            this.btn_MostrarClaves.Size = new System.Drawing.Size(101, 23);
            this.btn_MostrarClaves.TabIndex = 2;
            this.btn_MostrarClaves.Text = "Mostrar Claves";
            this.btn_MostrarClaves.UseVisualStyleBackColor = true;
            this.btn_MostrarClaves.Click += new System.EventHandler(this.btn_MostrarClaves_Click);
            // 
            // btn_Encriptar
            // 
            this.btn_Encriptar.Enabled = false;
            this.btn_Encriptar.Location = new System.Drawing.Point(227, 12);
            this.btn_Encriptar.Name = "btn_Encriptar";
            this.btn_Encriptar.Size = new System.Drawing.Size(101, 23);
            this.btn_Encriptar.TabIndex = 4;
            this.btn_Encriptar.Text = "Encriptar";
            this.btn_Encriptar.UseVisualStyleBackColor = true;
            this.btn_Encriptar.Click += new System.EventHandler(this.btn_Encriptar_Click);
            // 
            // btn_Desencriptar
            // 
            this.btn_Desencriptar.Enabled = false;
            this.btn_Desencriptar.Location = new System.Drawing.Point(334, 12);
            this.btn_Desencriptar.Name = "btn_Desencriptar";
            this.btn_Desencriptar.Size = new System.Drawing.Size(101, 23);
            this.btn_Desencriptar.TabIndex = 5;
            this.btn_Desencriptar.Text = "Desencriptar";
            this.btn_Desencriptar.UseVisualStyleBackColor = true;
            this.btn_Desencriptar.Click += new System.EventHandler(this.btn_Desencriptar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "512 bits",
            "1024 bits",
            "2048 bits",
            "4096 bits"});
            this.comboBox1.Location = new System.Drawing.Point(13, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(101, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 73);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_Desencriptar);
            this.Controls.Add(this.btn_Encriptar);
            this.Controls.Add(this.btn_MostrarClaves);
            this.Controls.Add(this.btn_Generar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RSA Discreta K106110";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Generar;
        private System.Windows.Forms.Button btn_MostrarClaves;
        private System.Windows.Forms.Button btn_Encriptar;
        private System.Windows.Forms.Button btn_Desencriptar;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

