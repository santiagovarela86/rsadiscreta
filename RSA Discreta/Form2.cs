using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RSA_Discreta
{
    partial class Form2 : Form
    {
        public String text_key = "";
        public String text_exp_pub = "";
        public String text_exp_priv = "";
        Button btn1, btn2, btn3, btn4;
        ComboBox cmb1;
        int k;
        
        public Form2(Button b1, Button b2, Button b3, Button b4, ComboBox c1, int k0)
        {
            InitializeComponent();
            btn1 = b1;
            btn2 = b2;
            btn3 = b3;
            btn4 = b4;
            k = k0;
            cmb1 = c1;
        }

        void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = text_key;
            textBox2.Text = text_exp_pub;
            textBox3.Text = text_exp_priv;
            textBox1.MaxLength = k / 8;
            textBox3.MaxLength = k / 8;
            cmb1.Enabled = false;

        }

        void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Text.Contains("ncriptar"))
                {
                    Application.OpenForms[index].Close();
                }
            }

            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = false;
            btn4.Enabled = false;
            cmb1.Enabled = true;

            this.Dispose();
        }
    }
}
