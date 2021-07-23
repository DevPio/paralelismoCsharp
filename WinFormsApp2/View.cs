using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.Models;
using WinFormsApp2.Repository;
using WinFormsApp2.Service;

namespace WinFormsApp2
{
    public partial class View : Form
    {
        public class Progress<T> : IProgress<T>
        {
            public Progress()
            {

            }
            public void Report(T value)
            {

                
            }
        }
        int progressCount = 0;
        public View()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.CleanView();
             progressCount = 10;
            progressBar1.Value = 0;
            List<Cliente> repos = new RepoContas().contasTransactions();

            button1.Enabled = false;
            progressBar1.Value = progressCount;

            var resultadoSync = await ConsolidaTarefas(repos);

            progressBar1.Value = progressCount + 20;



            button1.Enabled = false;

            foreach (var item in resultadoSync)
                {
                    ListItem.Items.Add(item);

                

                }

            
           
            button1.Enabled = true;
            progressBar1.Value = 100;



        }

        public void CleanView()
        {
            ListItem.Items.Clear();
        }

        private async Task<string[]> ConsolidaTarefas(List<Cliente> clientes,IProgress<string> progress )
        {
            List<string> resultado = new List<string>();
            var context = TaskScheduler.FromCurrentSynchronizationContext();
            
            var contasTarefas = clientes.Select(repo =>
           
            Task.Factory.StartNew(() =>
           {



             var c =   new ClienteService().ConsolidarMovimentacao(repo);
               progressCount += 10;
               progress.Report(progressCount.ToString());
               Task.Factory.StartNew(
                   () => progressBar1.Value = progressCount,
                   CancellationToken.None,
                   TaskCreationOptions.None,
                   context
               );


               return c;

           })
            ).ToArray();


            var r = await Task.WhenAll(contasTarefas);

            return r;

        }

     
    }
}
