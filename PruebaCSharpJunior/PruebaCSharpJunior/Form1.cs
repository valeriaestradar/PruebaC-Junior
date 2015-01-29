using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace PruebaCSharpJunior
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLeer_Click(object sender, EventArgs e)
        {
            int[][] Matriz = new int[0][];
            OpenFileDialog lector = new OpenFileDialog();
            if (lector.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(lector.FileName);
                richTextBox1.LoadFile(lector.FileName, RichTextBoxStreamType.PlainText);
                Matriz mz = new Matriz();
                var matriz = mz.leerMatriz(lector.FileName);
                var transpuesta = mz.transponer(matriz);
                mz.escribirMatriz(transpuesta,"salida.txt");
                MessageBox.Show("Matriz transpuesta guardada en el archivo de texto 'salida.txt' en la carpeta Debug del proyecto");
                sr.Close();
            }
            
            System.IO.StreamReader archivo = new System.IO.StreamReader("salida.txt");
            richTextBox2.LoadFile("salida.txt", RichTextBoxStreamType.PlainText);

            archivo.Close();
        }

    }
}
