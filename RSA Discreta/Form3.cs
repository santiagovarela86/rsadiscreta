using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Agregados
using System.Numerics;

namespace RSA_Discreta
{
    partial class Form3 : Form
    {
        public String etiqueta = "";
        public String exponente = "";
        public String modulo = "";
        public String titulo = "";
        public String boton = "";
        Button btn1;
        Clave keySet;

        public Form3(Button btn, Clave k)
        {
            InitializeComponent();
            btn1 = btn;
            keySet = k;
        }

        void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            btn1.Enabled = true;
            this.Dispose();
        }

        void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = etiqueta;
            label2.Text = exponente;
            label3.Text = modulo;
            button1.Text = boton;
            this.Text = titulo;

            if (this.Text.Contains("Encriptar"))
            {
                textBox1.MaxLength = keySet.k / 20;
                textBox2.MaxLength = keySet.k / 8;
                textBox3.MaxLength = keySet.k / 8;
                textBox4.MaxLength = keySet.k / 8;
            }
            else
            {
                if (this.Text.Contains("Desencriptar"))
                {
                    textBox1.MaxLength = keySet.k / 8;
                    textBox2.MaxLength = keySet.k / 8;
                    textBox3.MaxLength = keySet.k / 8;
                    textBox4.MaxLength = keySet.k / 20;
                }
            }
        }

        void button1_Click(object sender, EventArgs e)
        {
            BigInteger valido = new BigInteger();

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" 
                && BigInteger.TryParse(textBox2.Text, out valido) && BigInteger.TryParse(textBox3.Text, out valido))
            {
                if (this.Text.Contains("Encriptar"))
                {
                    String temp1 = textBox1.Text;
                    String temp2 = textBox2.Text;
                    String temp3 = textBox3.Text;
                    String temp4 = textBox4.Text;

                    Funciones func = new Funciones();
                    func.encriptar(ref temp1, ref temp2, ref temp3, ref temp4);

                    textBox1.Text = temp1;
                    textBox2.Text = temp2;
                    textBox3.Text = temp3;
                    textBox4.Text = temp4;
                }
                else
                {                  
                    if (this.Text.Contains("Desencriptar") && BigInteger.TryParse(textBox1.Text, out valido))
                    {
                        String temp1 = textBox1.Text;
                        String temp2 = textBox2.Text;
                        String temp3 = textBox3.Text;
                        String temp4 = textBox4.Text;
                        
                        Funciones func = new Funciones();
                        func.desencriptar(ref temp1, ref temp2, ref temp3, ref temp4);

                        textBox1.Text = temp1;
                        textBox2.Text = temp2;
                        textBox3.Text = temp3;
                        textBox4.Text = temp4;
                    }
                }
            }
        }
    }
}
