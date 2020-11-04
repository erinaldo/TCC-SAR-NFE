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
    public partial class Histórico : Form
    {

        string pastaimg = "";
        Image img_Voltar;
        Image img_EVoltar;

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user id=root; password =;database=historico; Convert Zero Datetime=True");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        DataSet ds;

        public Histórico()
        {
            InitializeComponent();


            pastaimg = Application.StartupPath + @"\";

            //Imagens
            img_Voltar = Image.FromFile(pastaimg + "branco.png");
            img_EVoltar = Image.FromFile(pastaimg + "azul.png");

            //ListView
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            /*  listView1.Groups.Add(new ListViewGroup("Ontem",
                  HorizontalAlignment.Left));
              listView1.Groups.Add(new ListViewGroup("Últimos 7 dias",
                              HorizontalAlignment.Left));
              listView1.Groups.Add(new ListViewGroup("Mês Anterior",
               HorizontalAlignment.Left));
            */
            listView1.SmallImageList = imageList1;

            listView1.Columns.Add("Código NFe", 150);
            listView1.Columns.Add("IE", 150);
            listView1.Columns.Add("Data Emitida", 150);
            listView1.Columns.Add("Horas Recebida", 100);

        }

        private void consultar()
        {

            connection.Open();
            cmd = new MySqlCommand("SELECT nnf, ie, dEmit, hRecbto FROM destinatario ORDER BY dEmit DESC ", connection);
            adapter = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            adapter.Fill(ds, "testTable");

            dt = ds.Tables["testTable"];

            var date1 = new DateTime(2020, 9, 10);
            date1.Subtract(Convert.ToDateTime(dt.Rows[0].ItemArray[2]));

            textBox1.Text = date1.ToString();

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {

                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString(), 0);
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());

            }
            cmd.Parameters.Clear();
            connection.Close();
        }

        /**private void populate(String nNF, String CNPJ, String IE)
        {
            //ROW
            String[] row = { nNF, CNPJ, IE};

            ListViewItem item = new ListViewItem(row);
            
            listView1.Items.Add(item);
        }

        private void consultar()
        {
            listView1.Items.Clear();

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user id=root;database=historico;password =");
            var sel = "SELECT nNF, CNPJ, IE FROM destinatario";
            var cmdSEL = new MySqlCommand(sel, connection);

            try
            {
                connection.Open();
                adapter = new MySqlDataAdapter(cmdSEL);

                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem lvItem = new ListViewItem(row);
                    lvItem.SubItems.Add(row);
                    listView1.Items.Add(lvItem); 
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }

                connection.Close();

                dt.Rows.Clear();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

          private void pLview()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user id=root;database=historico;password =");

            var sel = "SELECT nNF, dEmit, dRecbto, hRecbto FROM destinatario";
            
            var sel = "SELECT emitente.xNome, emitente.dhEmi, transportador.qVol FROM emitente " +
                "INNER JOIN transportador ON emitente.nNF = transportador.nNF;";
            
            var cmdSEL = new MySqlCommand(sel, connection);
            connection.Open();

            var dataReader = cmdSEL.ExecuteReader();

            while (dataReader.Read())
            {
                ListViewItem objListItem = new ListViewItem(dataReader.GetValue(0).ToString());
                for (int c = 1; c < dataReader.FieldCount; c++)
                {
                    objListItem.SubItems.Add(dataReader.GetValue(c).ToString());
                }
                //lvHistorico.Items.Add(objListItem);
            }
            dataReader.Close();
            connection.Close();
        }
*/

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = img_EVoltar;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = img_Voltar;
        }

        private void Histórico_Load(object sender, EventArgs e)
        {
           
                consultar();
                /*pbVoltar.BackgroundImage = img_Voltar;
                lvHistorico.Clear();
                lvHistorico.View = View.Details;
                lvHistorico.LabelEdit = false;
                lvHistorico.FullRowSelect = true;
                lvHistorico.GridLines = true;
                pLview();*/
        }
       
        /*private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Groups.Add(new ListViewGroup("List item text",
         HorizontalAlignment.Left));
        }

        private void destinatarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (emitenteToolStripMenuItem.Checked == false) { }

        }*/
    }
    

}
