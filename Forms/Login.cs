using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tingle
{
    public partial class Login : Form
    {
        string nome, senha;
        int codigo;

        public Login()
        {
            InitializeComponent();
            pbIconeUsername.BackgroundImage = Properties.Resources.User1;
            pbIconePassword.BackgroundImage = Properties.Resources.Lock2;
        }

        //Propriedades das textboxs
        private void textBox1_Click(object sender, EventArgs e)
        {

            txtUsername.Clear();
            pbIconeUsername.BackgroundImage = Properties.Resources.User2;
            LinhaUsername.BackColor = Color.FromArgb(0, 134, 251);
            txtUsername.ForeColor = Color.FromArgb(0, 134, 251);

            pbIconePassword.BackgroundImage = Properties.Resources.Lock1;
            LinhaPassword.BackColor = Color.WhiteSmoke;
            txtPassword.ForeColor = Color.WhiteSmoke;
        }

        //Propriedades das textboxs
        private void textBox2_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtPassword.PasswordChar = '*';
            pbIconePassword.BackgroundImage = Properties.Resources.Lock2;
            LinhaPassword.BackColor = Color.FromArgb(0, 134, 251);
            txtPassword.ForeColor = Color.FromArgb(0, 134, 251);
            pbIconeUsername.BackgroundImage = Properties.Resources.User1;
            LinhaUsername.BackColor = Color.WhiteSmoke;
            txtUsername.ForeColor = Color.WhiteSmoke;
        }

        //Vai para o form de Cadastro
        private void button2_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
            this.Hide();

            registro.FormClosed += (s, args) => this.Close();
            registro.Show();

            var newForm = new Registro();
            newForm.Show();
            this.Hide();
        }

        //Verifica os campos e após iso, autentica com o banco de dados.
        private void login()
        {
            Connection con = new Connection();
            con.Open();

            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                try
                {
                    if (txtUsername.Text != "" && txtPassword.Text != "")
                    {
                        con.Open();
                        string query = "SELECT cod_fun, nome, senha FROM funcionario WHERE nome ='" + txtUsername.Text + "' AND senha ='" + txtPassword.Text + "'";
                        MySqlDataReader row;
                        row = con.ExecuteReader(query);
                        if (row.HasRows)
                        {
                            while (row.Read())
                            {
                                nome = row["nome"].ToString();
                                senha = row["senha"].ToString();
                                codigo = (int)row["cod_fun"];

                            }
                            MessageBox.Show("Bem-vindo " + nome);

                            Inicial inicial = new Inicial(this.codigo);
                            inicial.Show();
                            this.Hide();

                            inicial.FormClosed += (s, args) => this.Close();
                            inicial.Show();
                        }
                        else
                        {
                            MessageBox.Show("Funcionário não registrado!", "Information");
                        }
                    }

                    else
                    {
                        MessageBox.Show("Nome do Funcionário ou senha em branco!", "Information");
                    }
                }
                catch
                {
                    MessageBox.Show("Erro de conexão!", "Information");
                }
                finally
                {
                    con.Close();
                }
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();

        }

    }
}



