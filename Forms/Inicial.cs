using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tingle.Forms;
using static Tingle.ChaveAcesso;

namespace Tingle
{
    public partial class Inicial : Form
    {
        public static Panel painel;

        NFeWS notas;
        BindingSource produtos;

        private int s;


        public Inicial(int codigo)
        {
            InitializeComponent();
            costumizeDesign(); 
            this.codigo = codigo;
            s = codigo;
            painel = panelChildForm;
        }

        private void costumizeDesign()
        {
            panelMediaSubmenu.Visible = false;
            panelPlaylistSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelMediaSubmenu.Visible == true)
                panelMediaSubmenu.Visible = false;

            if (panelPlaylistSubMenu.Visible == true)
                panelPlaylistSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else subMenu.Visible = false;
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMediaSubmenu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            //Inicial.painel.Controls.Clear();
            //Inicial.painel.Controls.Add(new NFe(codigo, notas, produtos));
             openChildForm(new NFe(this.codigo, notas, produtos));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            hideSubMenu();

            Inicial.painel.Controls.Clear();
            Inicial.painel.Controls.Add(new Histórico(this.codigo));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new ChaveAcesso(this.codigo));

            //   Inicial.painel.Controls.Clear();
            //  Inicial.painel.Controls.Add(new ChaveAcesso(this.codigo));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hideSubMenu();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            var newForm = new Login();
            newForm.Show();
        }

        private void login()
        {
            Connection con = new Connection();

            con.Open();
            string query = "SELECT cargo, cod_fun FROM funcionario WHERE cod_fun ='" + s + "'";
            MySqlDataReader row;
            row = con.ExecuteReader(query);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    cargo = row["cargo"].ToString();
                    codigo = Convert.ToInt32(row["cod_fun"]);

                }
            }

            if(cargo == "Gerente")
            {
                Inicial.painel.Controls.Clear();
                Inicial.painel.Controls.Add(new PerfilG(this.codigo));
            }

            else
            {
                Inicial.painel.Controls.Clear();
                Inicial.painel.Controls.Add(new Perfil(this.codigo));

            }

            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            login();
            //openChildForm(new Perfil(this.codigo));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a sessão?", "Voltar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Hide();

                login.FormClosed += (s, args) => this.Close();
                login.Show();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPlaylistSubMenu);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private static Form activeForm = null;
        private int codigo;
        private string cargo;

        public static void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            painel.Controls.Add(childForm);
            painel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panelMediaSubmenu_Paint(object sender, PaintEventArgs e)
        {

        }


    }
      


    
}
