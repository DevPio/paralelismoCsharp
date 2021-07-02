using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.Models;
using WinFormsApp2.Repository;
using WinFormsApp2.Service;

namespace WinFormsApp2
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Cliente> repos = new RepoContas().contasTransactions();

            List<string> resultado = new List<string>();

            foreach (var conta in repos)
            {
              var resultadoMomento = new ClienteService().ConsolidarMovimentacao(conta);

              

                listBox1.Items.Add(resultadoMomento);

            }

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
