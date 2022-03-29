using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TreeViewPicturesAppCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    private TreeNode CrearArbol(DirectoryInfo directoryInfo)
        {
            //recursiva al crear arboles 
            TreeNode treeNode = new TreeNode(directoryInfo.Name);
            //leer en base a los directorios pasados
            foreach (var item in directoryInfo.GetDirectories())
            {
                treeNode.Nodes.Add(CrearArbol(item));
            }
            //lo mismo que en el pasado solo que para los archivos
            foreach (var item in directoryInfo.GetFiles())
            {
                treeNode.Nodes.Add(new TreeNode(item.Name));
            }
            return treeNode;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //para que al abrir el formulario corra directamente con
            //una ruta base
            string rutaBase = "C:\\Users\\Usuario\\Pictures\\tarjetas";

            tvFile.Nodes.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(rutaBase);
            tvFile.Nodes.Add(CrearArbol(directoryInfo));
           
        }
    }
}
