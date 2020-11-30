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
    public partial class Registro : Form
    {
        //Conexão MySQL
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user id=root; password =;database=historico; Convert Zero Datetime=True");

        public Registro()
        {
            InitializeComponent();
            pbIconePassword.BackgroundImage = Properties.Resources.Lock2;
            pbIconeUsername.BackgroundImage = Properties.Resources.User1;
            pbIconeEmail.BackgroundImage = Properties.Resources.Email2;
            pbCargo.BackgroundImage = Properties.Resources.Cargo;
            pbCPF.BackgroundImage = Properties.Resources.CPF;

        }
        private void Registro_Load(object sender, EventArgs e)
        {

        }

        //Código

        //Cadastro de Funcionário
        private void cadastrar()
        {
            validarCampos();
            try
            {
                connection.Open();
                var f = "INSERT INTO funcionario (nome, cargo, senha, CPF, email)"
                    + "VALUES(@nome, @cargo, @senha, @CPF, @email)";

                var cmd = new MySqlCommand(f, connection);

                cmd.Parameters.AddWithValue("@nome", this.txtUsername.Text);
                cmd.Parameters.AddWithValue("@cargo", this.txtCargo.Text);
                cmd.Parameters.AddWithValue("@senha", this.txtPassword.Text);
                cmd.Parameters.AddWithValue("@CPF", this.txtCPF.Text);
                cmd.Parameters.AddWithValue("@email", this.txtEmail.Text);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                limparCampos();
                MessageBox.Show("Funcionário registrado!", "Ok");

            }

            catch
            {
                MessageBox.Show("Erro de conexão!", "Information");
            }
            
            finally
            {
                connection.Close();
            }
    }

        //Vai para o Login
        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

            login.FormClosed += (s, args) => this.Close();
            login.Show();
        }


        //Valida os campos de cadastro
        private bool validarCampos()
        {
            if (this.txtEmail.Text.ToString().Equals(String.Empty))
            {
                MessageBox.Show("Digite o e-mail! ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtEmail.Focus();
                return false;
            }

            if (this.txtUsername.Text.ToString().Equals(String.Empty))
            {
                MessageBox.Show("Digite o nome de usuário! ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtUsername.Focus();
                return false;
            }

            if (this.txtPassword.Text.ToString().Equals(String.Empty))
            {
                MessageBox.Show("Digite a senha! ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPassword.Focus();
                return false;
            }

            if (this.txtCPF.Text.ToString().Equals(String.Empty))
            {
                MessageBox.Show("Digite o RG! ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCPF.Focus();
                return false;
            }

            if (this.txtCargo.Text.ToString().Equals(String.Empty))
            {
                MessageBox.Show("Digite o Cargo! ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCargo.Focus();
                return false;
            }

            return true;
        }

        //Limpa os campos
        private void limparCampos()
        {
            this.txtUsername.Clear();
            this.txtPassword.Clear();
            this.txtEmail.Clear();
            this.txtCargo.Clear();
            this.txtCPF.Clear();
        }


        //Propriedades das textboxs
        private void textBox1_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            pbIconeUsername.BackgroundImage = Properties.Resources.User2;
            LinhaUsername.BackColor = Color.FromArgb(0, 134, 251);
            txtUsername.ForeColor = Color.FromArgb(0, 134, 251);

            pbIconePassword.BackgroundImage = Properties.Resources.Lock1;
            panel2.BackColor = Color.WhiteSmoke;
            txtPassword.ForeColor = Color.WhiteSmoke;

            pbIconeEmail.BackgroundImage = Properties.Resources.Email1;
            panel3.BackColor = Color.WhiteSmoke;
            txtEmail.ForeColor = Color.WhiteSmoke;

            pbCPF.BackgroundImage = Properties.Resources.CPFS;
            panel4.BackColor = Color.WhiteSmoke;
            txtCPF.ForeColor = Color.WhiteSmoke;

            pbCargo.BackgroundImage = Properties.Resources.CargoS;
            panel1.BackColor = Color.WhiteSmoke;
            txtCargo.ForeColor = Color.WhiteSmoke;
        }

        //Propriedades das textboxs
        private void textBox2_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtPassword.PasswordChar = '*';
            pbIconePassword.BackgroundImage = Properties.Resources.Lock2;
            panel2.BackColor = Color.FromArgb(0, 134, 251);
            txtPassword.ForeColor = Color.FromArgb(0, 134, 251);

            pbIconeUsername.BackgroundImage = Properties.Resources.User1;
            LinhaUsername.BackColor = Color.WhiteSmoke;
            txtUsername.ForeColor = Color.WhiteSmoke;

            pbIconeEmail.BackgroundImage = Properties.Resources.Email1;
            panel3.BackColor = Color.WhiteSmoke;
            txtEmail.ForeColor = Color.WhiteSmoke;

            pbCPF.BackgroundImage = Properties.Resources.CPFS;
            panel4.BackColor = Color.WhiteSmoke;
            txtCPF.ForeColor = Color.WhiteSmoke;

            pbCargo.BackgroundImage = Properties.Resources.CargoS;
            panel1.BackColor = Color.WhiteSmoke;
            txtCargo.ForeColor = Color.WhiteSmoke;
        }

        //Propriedades das textboxs
        private void textBox3_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            pbIconeEmail.BackgroundImage = Properties.Resources.Email2;
            panel3.BackColor = Color.FromArgb(0, 134, 251);
            txtEmail.ForeColor = Color.FromArgb(0, 134, 251);

            pbIconeUsername.BackgroundImage = Properties.Resources.User1;
            LinhaUsername.BackColor = Color.WhiteSmoke;
            txtUsername.ForeColor = Color.WhiteSmoke;

            pbIconePassword.BackgroundImage = Properties.Resources.Lock1;
            panel2.BackColor = Color.WhiteSmoke;
            txtPassword.ForeColor = Color.WhiteSmoke;

            pbCPF.BackgroundImage = Properties.Resources.CPFS;
            panel4.BackColor = Color.WhiteSmoke;
            txtCPF.ForeColor = Color.WhiteSmoke;

            pbCargo.BackgroundImage = Properties.Resources.CargoS;
            panel1.BackColor = Color.WhiteSmoke;
            txtCargo.ForeColor = Color.WhiteSmoke;
        }

        private void txtCPF_Click(object sender, EventArgs e)
        {
            txtCPF.Clear();
            pbCPF.BackgroundImage = Properties.Resources.CPF;
            panel4.BackColor = Color.FromArgb(0, 134, 251);
            txtCPF.ForeColor = Color.FromArgb(0, 134, 251);

            pbIconeUsername.BackgroundImage = Properties.Resources.User1;
            LinhaUsername.BackColor = Color.WhiteSmoke;
            txtUsername.ForeColor = Color.WhiteSmoke;

            pbIconePassword.BackgroundImage = Properties.Resources.Lock1;
            panel2.BackColor = Color.WhiteSmoke;
            txtPassword.ForeColor = Color.WhiteSmoke;

            pbIconeEmail.BackgroundImage = Properties.Resources.Email1;
            panel3.BackColor = Color.WhiteSmoke;
            txtEmail.ForeColor = Color.WhiteSmoke;

            pbCargo.BackgroundImage = Properties.Resources.CargoS;
            panel1.BackColor = Color.WhiteSmoke;
            txtCargo.ForeColor = Color.WhiteSmoke;
        }

        private void txtCargo_Click(object sender, EventArgs e)
        {
            txtCargo.Clear();
            pbCargo.BackgroundImage = Properties.Resources.Cargo;
            panel1.BackColor = Color.FromArgb(0, 134, 251);
            txtCargo.ForeColor = Color.FromArgb(0, 134, 251);

            pbIconeUsername.BackgroundImage = Properties.Resources.User1;
            LinhaUsername.BackColor = Color.WhiteSmoke;
            txtUsername.ForeColor = Color.WhiteSmoke;

            pbIconePassword.BackgroundImage = Properties.Resources.Lock1;
            panel2.BackColor = Color.WhiteSmoke;
            txtPassword.ForeColor = Color.WhiteSmoke;

            pbIconeEmail.BackgroundImage = Properties.Resources.Email1;
            panel3.BackColor = Color.WhiteSmoke;
            txtEmail.ForeColor = Color.WhiteSmoke;

            pbCPF.BackgroundImage = Properties.Resources.CPFS;
            panel4.BackColor = Color.WhiteSmoke;
            txtCPF.ForeColor = Color.WhiteSmoke;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cadastrar();
        }
    }
}
