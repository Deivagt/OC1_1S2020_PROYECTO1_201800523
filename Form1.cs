using OC1_1S2020_PROY1_201800523;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace OC1_1S2020_P1_201800523
{
    public partial class Form1 : Form
    {
        LinkedList<listaExpresiones> datos = new LinkedList<listaExpresiones>();
        LinkedListNode<listaExpresiones> nodoActual;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string entrada = textBox1.Text;
            analizador a = new analizador();
            a.escanear(entrada);

            datos = a.generadorAFN();
            a.generadorArboles();

            nodoActual = datos.First;
            if(nodoActual != null)
            {
                dataGridView1.DataSource = nodoActual.Value.getTablaTransiciones();
                pictureBox1.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes("D:\\salida\\afd\\" + nodoActual.Value.getNombre() + ".png")));
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (nodoActual != null)
            {
                if (nodoActual.Previous != null)
                {
                    nodoActual = nodoActual.Previous;
                    dataGridView1.DataSource = nodoActual.Value.getTablaTransiciones();
                    pictureBox1.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes("D:\\salida\\afd\\" + nodoActual.Value.getNombre() + ".png")));
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nodoActual != null)
            {
                if (nodoActual.Next != null)
                {
                    nodoActual = nodoActual.Next;
                    dataGridView1.DataSource = nodoActual.Value.getTablaTransiciones();
                    pictureBox1.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes("D:\\salida\\afd\\" + nodoActual.Value.getNombre() + ".png")));
                }
            }

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog()
            {
                Filter = "Archivo er(*.er)|*.er",
                Title = "Abrir planificacion"
            };
            if (abrir.ShowDialog() == DialogResult.OK)
            {


                String plan = abrir.FileName;
                string nombre = Path.GetFullPath(plan);

                textBox1.Text = File.ReadAllText(nombre);

            }
            abrir.Dispose();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream Stream;
            SaveFileDialog guardar = new SaveFileDialog();
            string ruta = "";
            String contenido = "";


            guardar.Filter = "Archivo er(*.er)|*.er";
            guardar.FilterIndex = 2;
            guardar.RestoreDirectory = true;



            if (guardar.ShowDialog() == DialogResult.OK)
            {
                if ((Stream = guardar.OpenFile()) != null)
                {
                    ruta = guardar.FileName;

                    Stream.Close();
                }
            }
            try
            {
                contenido = textBox1.Text;


            }
            catch (ArgumentOutOfRangeException g)
            {

            }


            try
            {
                StreamWriter escribir = new StreamWriter(ruta);
                escribir.Write(contenido);
                escribir.Flush();
                escribir.Close();
            }
            catch (ArgumentException g)
            {

            }

        }
    }
}
