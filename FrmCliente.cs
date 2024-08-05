using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            if (cliente.RegistroRepetido(txtNome.Text, txtEmail.Text) == true )
            {
                MessageBox.Show("Cliente já existe em nossa base de dados");
                txtNome.Text = string.Empty;
                txtCelular.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtCidade.Text = string.Empty;
                return;
            }
            else
            {
                cliente.Inserir(txtNome.Text, txtCelular.Text, txtEmail.Text, txtCidade.Text);
                MessageBox.Show("Cliente cadastrado com sucesso");
                List<Cliente> cli = cliente.Listacliente();
                dgvCliente.DataSource = cli;
                txtNome.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtCidade.Text = string.Empty;
                txtCelular.Text = string.Empty;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            List<Cliente> cli = cliente.Listacliente();
            dgvCliente.DataSource = cli;
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
