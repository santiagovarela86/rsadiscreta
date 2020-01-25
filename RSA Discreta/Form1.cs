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
    partial class Form1 : Form
    {      
        Clave keySet;

        public Form1(ref Clave k)
        {
            InitializeComponent();
            keySet = k;
        }

        void btn_Generar_Click(object sender, EventArgs e)
        {
            btn_Generar.Enabled = false;
            btn_MostrarClaves.Enabled = false;
            btn_Encriptar.Enabled = false;
            btn_Desencriptar.Enabled = false;

            Funciones func = new Funciones();
            func.generar_Claves(ref keySet);

            btn_Generar.Enabled = true;
            btn_MostrarClaves.Enabled = true;
        }

        void btn_Encriptar_Click(object sender, EventArgs e)
        {
            btn_Encriptar.Enabled = false;
           
            Form3 encriptar = new Form3(this.btn_Encriptar, keySet);
            encriptar.etiqueta = "Mensaje";
            encriptar.titulo = "Encriptar Mensaje";
            encriptar.exponente = "Exponente Publico";
            encriptar.modulo = "Modulo";
            encriptar.boton = "Encriptar";

            encriptar.Visible = true;
        }

        void btn_Desencriptar_Click(object sender, EventArgs e)
        {
            btn_Desencriptar.Enabled = false;

            Form3 desencriptar = new Form3(this.btn_Desencriptar,keySet);
            desencriptar.etiqueta = "Texto Cifrado";
            desencriptar.titulo = "Desencriptar Mensaje";
            desencriptar.exponente = "Exponente Privado";
            desencriptar.modulo = "Modulo";
            desencriptar.boton = "Desencriptar";

            desencriptar.Visible = true;
        }

        void btn_MostrarClaves_Click(object sender, EventArgs e)
        {
            btn_Generar.Enabled = false;
            btn_MostrarClaves.Enabled = false;
            btn_Encriptar.Enabled = true;
            btn_Desencriptar.Enabled = true;
            
            Form2 mostrarClaves = new Form2(this.btn_Generar, this.btn_MostrarClaves, this.btn_Encriptar, this.btn_Desencriptar, this.comboBox1, keySet.k);
            mostrarClaves.text_key = keySet.n.ToString();
            mostrarClaves.text_exp_pub = keySet.exp_pub.ToString();
            mostrarClaves.text_exp_priv = keySet.exp_pri.ToString();

            mostrarClaves.Visible = true;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            btn_Generar.Enabled = false;
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Generar.Enabled = true;

            if (comboBox1.SelectedIndex == 0)
            {
                keySet.k = 512;
            }
            else
            {
                if (comboBox1.SelectedIndex == 1)
                {
                    keySet.k = 1024;
                }
                else
                {
                    if (comboBox1.SelectedIndex == 2)
                    {
                        keySet.k = 2048;  
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex == 3)
                        {
                            keySet.k = 4096;
                        }
                    }
                }
            }
        }
    }
}
