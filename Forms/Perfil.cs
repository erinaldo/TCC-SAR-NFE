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
    public partial class Perfil : UserControl
    {
        private int codigo;
        private int s;
        private DataTable dt = new DataTable();
        MySqlDataAdapter adapter;
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user id=root; password =;database=historico; Convert Zero Datetime=True");

        public Perfil(int codigo)
        {
            InitializeComponent();
            this.codigo = codigo;
            s = codigo;
        }

        private void Consulta()
        {
            //Connection con = new Connection();
           // con.Open();

            adapter = new MySqlDataAdapter("SELECT * FROM funcionario WHERE cod_fun = '" + s + "'", connection);
            adapter.Fill(dt);

            lblNome.Text = dt.Rows[0][1].ToString();
            lblCargo.Text = dt.Rows[0][2].ToString();
            lblCPF.Text = dt.Rows[0][4].ToString();
            lblEmail.Text = dt.Rows[0][5].ToString();

            /*var query = "SELECT * FROM funcionario WHERE cod_fun = '" + codigo + "'";
            MySqlDataReader row;
            row = con.ExecuteReader(query);
            dt.Clear();
            dt.Load(row);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    codigo = (int)row["cod_fun"];

                }
                Preencher();
            }*/
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         //   this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           // this.Close();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            this.Consulta();
        }
    }
}
