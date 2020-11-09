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
        private int codigo;

        public Histórico(int codigo)
        {
            InitializeComponent();
            this.codigo = codigo;

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

            listView1.Columns.Add("Funcionário", 150);
            listView1.Columns.Add("Código NFe", 150);
            listView1.Columns.Add("Inscrição Estadual", 150);
            listView1.Columns.Add("CNPJ Destinatário", 50);
            listView1.Columns.Add("Nome", 100);
            listView1.Columns.Add("Logradouro", 50);
            listView1.Columns.Add("Bairro", 50);
            listView1.Columns.Add("Município", 50);
            listView1.Columns.Add("UF", 50);
            listView1.Columns.Add("CEP", 50);
            listView1.Columns.Add("Telefone", 50);
            listView1.Columns.Add("Inscrição Estadual", 50);
            listView1.Columns.Add("Data Emitida", 150);
            listView1.Columns.Add("Horas Recebida", 100);
            listView1.Columns.Add("Código NFe", 150);
            listView1.Columns.Add("Inscrição Estadual", 150);
            listView1.Columns.Add("Data Hora Emitida", 150);
            listView1.Columns.Add("CNPJ", 100);
            listView1.Columns.Add("Nome", 100);
            listView1.Columns.Add("Logradouro", 100);
            listView1.Columns.Add("Número", 45);
            listView1.Columns.Add("Bairro", 100);
            listView1.Columns.Add("Município", 100);
            listView1.Columns.Add("UF", 50);
            listView1.Columns.Add("CEP", 50);
            listView1.Columns.Add("Telefone", 50);
            listView1.Columns.Add("BC", 100);
            listView1.Columns.Add("ICMS", 100);
            listView1.Columns.Add("BCST", 100);
            listView1.Columns.Add("Produto", 100);
            listView1.Columns.Add("Frete", 100);
            listView1.Columns.Add("Seguro", 100);
            listView1.Columns.Add("Desconto", 100);
            listView1.Columns.Add("IPI", 100);
            listView1.Columns.Add("Outro", 100);
            listView1.Columns.Add("NF", 100);
            listView1.Columns.Add("CNPJ", 100);
            listView1.Columns.Add("Nome", 100);
            listView1.Columns.Add("IE", 100);
            listView1.Columns.Add("Rua", 100);
            listView1.Columns.Add("Município", 100);
            listView1.Columns.Add("UF", 100);
            listView1.Columns.Add("Quantidade Vol", 100);
            listView1.Columns.Add("Específicação", 100);

        }
        private void consultar()
        {

            connection.Open();
            cmd = new MySqlCommand("SELECT funcionario.nome, completa.* " +
                "FROM completa " +
                "INNER JOIN funcionario ON completa.funId = funcionario.cod_fun", connection);
            adapter = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            adapter.Fill(ds, "testTable");

            dt = ds.Tables["testTable"];


            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {

                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString(), 0);
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[10].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[11].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[12].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[13].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[14].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[15].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[16].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[17].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[18].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[19].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[20].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[21].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[22].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[23].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[24].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[25].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[26].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[27].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[28].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[29].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[30].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[31].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[32].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[33].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[34].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[35].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[36].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[37].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[38].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[39].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[40].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[41].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[42].ToString());
                //listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[43].ToString());

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

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {

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
