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
        Connection con = new Connection(); 
        string username, password;

        public Login()
        {
            InitializeComponent();
            pbIconeUsername.BackgroundImage = Properties.Resources.User1;
            pbIconePassword.BackgroundImage = Properties.Resources.Lock2;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }


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

        private void button2_Click(object sender, EventArgs e)
        {
            var newForm = new Registro();
            newForm.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Inicial inicial = new Inicial();
            inicial.Show();
            this.Hide();

            inicial.FormClosed += (s, args) => this.Close();
            inicial.Show();

           /* try
            {

                if (txtUsername.Text != "" && txtPassword.Text != "")
                {

                    con.Open();
                    string query = "select username, password from user WHERE username ='" + txtUsername.Text + "' AND password ='" + txtPassword.Text + "'";
                    MySqlDataReader row;
                    row = con.ExecuteReader(query);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            username = row["username"].ToString();
                            password = row["password"].ToString();

                        }
                    }

                    else
                    {
                        MessageBox.Show("Data not found", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password is empty", "Information");
                }
            }
            catch
            {
                MessageBox.Show("Connection Error", "Information");
            }*/
        } 

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
