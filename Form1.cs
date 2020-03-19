using OC1_1S2020_PROY1_201800523;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace OC1_1S2020_P1_201800523
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string entrada = textBox1.Text;
            analizador a = new analizador();
            a.escanear(entrada);
          
            a.generadorArboles();
        }
     
    }
}
