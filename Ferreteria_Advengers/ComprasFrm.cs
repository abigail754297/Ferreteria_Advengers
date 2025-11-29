using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ferreteria_Advengers.Models;

namespace Ferreteria_Advengers
{
    public partial class ComprasFrm : Form
    {
        int Id_compra= 0;
        public ComprasFrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Compras.Obtener();
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["id_compra"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numero_factura = txtNum_Fact.Text;
            string fecha_compra = timefech.Value.ToString("yyyy-MM-dd");
            string total = txtTotal.Text;
            string estado = txtEstado.Text;
            bool resultado = false;
            if (Id_compra == 0)
            {
                resultado = Compras.Guardar(numero_factura, fecha_compra, total, estado);
                MessageBox.Show("Compra guardada correctamente.");
            }
            else
            {
                resultado = Compras.Editar(Id_compra, numero_factura, fecha_compra, total, estado);
                MessageBox.Show("Compra Editada correctamente.");
            }
            dataGridView1.DataSource = Compras.Obtener();
            limpiar();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNum_Fact.Text = dataGridView1.CurrentRow.Cells["numero_factura"].Value.ToString();
            timefech.Text = dataGridView1.CurrentRow.Cells["fecha_compra"].Value.ToString();
            txtTotal.Text = dataGridView1.CurrentRow.Cells["total"].Value.ToString();
            txtEstado.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
            Id_compra = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_compra"].Value.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_compra"].Value.ToString());
            if (Id != 0)
            {
                Compras.Eliminar(Id);
            }
            dataGridView1.DataSource = Compras.Obtener();
            limpiar();
        }
        private void limpiar()
        {
            txtNum_Fact.Clear();
            txtTotal.Clear();
            txtEstado.Clear();
            txtNum_Fact.Focus();
        }
    }

}
