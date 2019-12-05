using System;
using System.Windows.Forms;
using System.IO;

namespace HelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

 
        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            // Declaração de variáveis
            string prato, ingredientes, categoria, sugestao;
            double preco;


            // Entrada de dados
            prato = txt_prato.Text;
            ingredientes = txt_ingredientes.Text;
            categoria = cb_categoria.Text;
            sugestao = txt_sugestao.Text;
            preco = double.Parse(txt_preco.Text);

            /* MessageBox.Show(
                prato +
                "\n" + ingredientes +
                "\n" + categoria +
                "\n" + sugestao +
                "\n" + preco,
                "Cardápio"
            );
            */

            // Caminho para criação do arquivo de texto
            string path = System.Environment.GetEnvironmentVariable("USERPROFILE");

            //objeto responsavel por gravar no arquivo criado acima
            StreamWriter io = new StreamWriter(path + "\\desktop\\cardapio.txt", true);

            //escrever no arquivo 1ª opçao
            //io.WriteLine(prato + ";" + ingredientes + ";" + categoria + ";" + sugestao + ";" + preco);

            //escrever no arquivo 2ª opçao
            string valores = string.Join(";", prato, ingredientes, categoria, sugestao, preco);
            io.WriteLine(valores);

            //fecha o arquivo para escrita
            io.Close();
            MessageBox.Show("Registro Cadastrado com Sucesso!", 
                            "Gravando ...", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                       
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            //txt_ingredientes.Clear();
            //txt_prato.Clear();
            //txt_preco.Clear();
            //txt_sugestao.Clear();
            //cb_categoria.Text = "Escolha uma opção";

            //Outra maneira + smart ###################
            foreach(Control c in this.Controls){
                if(c is TextBox)
                    (c as TextBox).Clear();
                if (c is ComboBox)
                    (c as ComboBox).Text = "Escolha uma opção";
               
            }
            //#########################################

            //define cursor no 1º campo
            txt_prato.Focus();
        }
    }
}
