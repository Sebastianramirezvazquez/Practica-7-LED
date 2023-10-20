using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_7_LED
{
    public partial class Form1 : Form
    {
        public SerialPort Arduinoport {get;}
        
        public Form1()
        {
            InitializeComponent();
            Arduinoport = new System.IO.Ports.SerialPort();
            Arduinoport.PortName = "COM7";
            Arduinoport.BaudRate = 9600;
            Arduinoport.Open();

            //Vincular eventos
            this.FormClosing += CerrandoForm1;
            this.Btn_Apagar.Click += Btn_Apagar_Click;
            this.Btn_encender.Click += Btn_encender_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CerrandoForm1(object sender, FormClosingEventArgs e)
        {
            if (Arduinoport.IsOpen) Arduinoport.Close();
        }

        private void Btn_encender_Click(object sender, EventArgs e)
        {
            Arduinoport.Write("b");
        }

        private void Btn_Apagar_Click(object sender, EventArgs e)
        {
            Arduinoport.Write("a");
        }
    }
}
