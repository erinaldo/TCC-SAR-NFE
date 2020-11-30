using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace Tingle
{
    public partial class Histórico : UserControl
    {

        string pastaimg = "";
        Image img_Voltar;
        Image img_EVoltar;

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user id=root; password =;database=historico; Convert Zero Datetime=True");
        MySqlCommand cmd;
        private MySqlCommand lsd;
        private MySqlDataAdapter adapter2;
        private DataSet ds2;
        MySqlDataAdapter adapter;
        System.Data.DataTable dt;
        DataSet ds;
        private int codigo;
        private System.Data.DataTable dt2;

        public Histórico(int codigo)
        {
            InitializeComponent();
            this.codigo = codigo;

            pastaimg = System.Windows.Forms.Application.StartupPath + @"\";

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

            
        }
    
        private void consultarProd()
        {
            listView1.Clear();
            listView1.Columns.Add("cProd", 150);
            listView1.Columns.Add("nNF", 150);
            listView1.Columns.Add("xProd", 150);
            listView1.Columns.Add("NCM", 50);
            listView1.Columns.Add("CFOP", 100);
            listView1.Columns.Add("uCom", 50);
            listView1.Columns.Add("qCom", 50);
            listView1.Columns.Add("vUnCom", 50);
            listView1.Columns.Add("vProd", 50);

            connection.Open();
            lsd = new MySqlCommand("SELECT * FROM produtos ", connection);               
            adapter2 = new MySqlDataAdapter(lsd);
            ds2 = new DataSet();
            adapter2.Fill(ds2, "testTable");
            dt2 = ds2.Tables["testTable"];


            for (int i = 0; i <= dt2.Rows.Count - 1; i++)
            {

                listView1.Items.Add(dt2.Rows[i].ItemArray[0].ToString(), 0);
                listView1.Items[i].SubItems.Add(dt2.Rows[i].ItemArray[1].ToString());
                listView1.Items[i].SubItems.Add(dt2.Rows[i].ItemArray[2].ToString());
                listView1.Items[i].SubItems.Add(dt2.Rows[i].ItemArray[3].ToString());
                listView1.Items[i].SubItems.Add(dt2.Rows[i].ItemArray[4].ToString());
                listView1.Items[i].SubItems.Add(dt2.Rows[i].ItemArray[5].ToString());
                listView1.Items[i].SubItems.Add(dt2.Rows[i].ItemArray[6].ToString());
                listView1.Items[i].SubItems.Add(dt2.Rows[i].ItemArray[7].ToString());
                listView1.Items[i].SubItems.Add(dt2.Rows[i].ItemArray[8].ToString());
                //listView1.Items[i].SubItems.Add(dt2.Rows[i].ItemArray[9].ToString());
            
                
            }

            lsd.Parameters.Clear();
            connection.Close();
        }
        
        private void consultar()
        {
            listView1.Clear();
            listView1.Columns.Add("Funcionário", 150);
            listView1.Columns.Add("Código NFe", 150);
            listView1.Columns.Add("Dest_CNPJ", 150);
            listView1.Columns.Add("Dest_Nome", 50);
            listView1.Columns.Add("Dest_Logradouro", 100);
            listView1.Columns.Add("Dest_Bairro", 50);
            listView1.Columns.Add("Dest_Município", 50);
            listView1.Columns.Add("Dest_UF", 50);
            listView1.Columns.Add("Dest_CEP", 50);
            listView1.Columns.Add("Dest_Fone", 50);
            listView1.Columns.Add("Dest_IE", 50);
            listView1.Columns.Add("Data Emitida", 50);
            listView1.Columns.Add("Data Recebido", 150);
            listView1.Columns.Add("Horas Recebida", 100);
            listView1.Columns.Add("CNPJ", 150);
            listView1.Columns.Add("Emit_Nome", 150);
            listView1.Columns.Add("Emit_Logradouro", 150);
            listView1.Columns.Add("Emit_Bairro", 100);
            listView1.Columns.Add("Emit_Município", 100);
            listView1.Columns.Add("Emit_UF", 100);
            listView1.Columns.Add("Emit_CEP", 45);
            listView1.Columns.Add("Emit_Fone", 100);
            listView1.Columns.Add("Emit_IE", 100);
            listView1.Columns.Add("Emit_Número", 50);
            listView1.Columns.Add("vBc", 50);
            listView1.Columns.Add("vICMS", 50);
            listView1.Columns.Add("vBCTS", 100);
            listView1.Columns.Add("vProd", 100);
            listView1.Columns.Add("vFrete", 100);
            listView1.Columns.Add("vSeg", 100);
            listView1.Columns.Add("vDesc", 100);
            listView1.Columns.Add("vIPI", 100);
            listView1.Columns.Add("vOutro", 100);
            listView1.Columns.Add("vNF", 100);
            listView1.Columns.Add("Transp_CNPJ", 100);
            listView1.Columns.Add("Transp_Nome", 100);
            listView1.Columns.Add("Transp_Logradouro", 100);
            listView1.Columns.Add("Transp_Município", 100);
            listView1.Columns.Add("Transp_UF", 100);
            listView1.Columns.Add("Transp_IE", 100);
            listView1.Columns.Add("qVol", 100);
            listView1.Columns.Add("esp", 100);
            listView1.Columns.Add("fundId", 100);


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

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //this.Close();
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void destinatarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
                /*if (destinatarioToolStripMenuItem.Checked == true)
                {
                    //var dest = new MySqlCommand("", connection);
                    listView1.Columns.Add("Código NFe", 150);
                    listView1.Columns.Add("Inscrição Estadual", 150);
                    listView1.Columns.Add("CNPJ", 50);
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
                }
                else
                {
                }*/
            }

        /*private void emitenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (emitenteToolStripMenuItem.Checked == true)
            {
                listView1.Columns.Add("Código NFe", 150);
                listView1.Columns.Add("Inscrição Estadual", 150);
                listView1.Columns.Add("Data Hora Emitida", 150);
                listView1.Columns.Add("CNPJ", 100);
                listView1.Columns.Add("Nome");
                listView1.Columns.Add("Logradouro", 100);
                listView1.Columns.Add("Número", 13);
                listView1.Columns.Add("Bairro", 100);
                listView1.Columns.Add("Município", 100);
                listView1.Columns.Add("UF", 2);
                listView1.Columns.Add("CEP", 8);
                listView1.Columns.Add("Telefone", 13);
            }*/

            
            
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {

                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Excel |* .xls",
                    InitialDirectory = @"c:\dados\xls",
                    FileName = "NFeCompleta" + DateTime.Now.Millisecond.ToString() + ".xls",
                    ValidateNames = true
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                        Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                        Worksheet ws = (Worksheet)app.ActiveSheet;
                        app.Visible = false;
                        ws.Cells[1, 1] = "Funcionário";
                        ws.Cells[1, 2] = "Código NFe";
                        ws.Cells[1, 3] = "Dest_CNPJ";
                        ws.Cells[1, 4] = "Dest_Nome";
                        ws.Cells[1, 5] = "Dest_Logradouro";
                        ws.Cells[1, 6] = "Dest_Bairro";
                        ws.Cells[1, 7] = "Dest_Município";
                        ws.Cells[1, 8] = "Dest_UF";
                        ws.Cells[1, 9] = "Dest_CEP";
                        ws.Cells[1, 10] = "Dest_Fone";
                        ws.Cells[1, 11] = "Dest_IE";
                        ws.Cells[1, 12] = "Data Emitida";
                        ws.Cells[1, 13] = "Data Recebido";
                        ws.Cells[1, 14] = "Horas Recebida";
                        ws.Cells[1, 15] = "CNPJ";
                        ws.Cells[1, 16] = "Emit_Nome";
                        ws.Cells[1, 17] = "Emit_Logradouro";
                        ws.Cells[1, 18] = "Emit_Bairro";
                        ws.Cells[1, 19] = "Emit_Município";
                        ws.Cells[1, 20] = "Emit_UF";
                        ws.Cells[1, 21] = "Emit_CEP";
                        ws.Cells[1, 22] = "Emit_Fone";
                        ws.Cells[1, 23] = "Emit_IE";
                        ws.Cells[1, 24] = "Emit_Número";
                        ws.Cells[1, 25] = "vBc";
                        ws.Cells[1, 26] = "vICMS";
                        ws.Cells[1, 27] = "vBCTS";
                        ws.Cells[1, 28] = "vProd";
                        ws.Cells[1, 29] = "vFrete";
                        ws.Cells[1, 30] = "vSeg";
                        ws.Cells[1, 31] = "vDesc";
                        ws.Cells[1, 32] = "vIPI";
                        ws.Cells[1, 33] = "vOutro";
                        ws.Cells[1, 34] = "vNF";
                        ws.Cells[1, 35] = "Transp_CNPJ";
                        ws.Cells[1, 36] = "Transp_Nome";
                        ws.Cells[1, 37] = "Transp_Logradouro";
                        ws.Cells[1, 38] = "Transp_Município";
                        ws.Cells[1, 39] = "Transp_UF";
                        ws.Cells[1, 40] = "Transp_IE";
                        ws.Cells[1, 41] = "qVol";
                        ws.Cells[1, 42] = "esp";
                        ws.Cells[1, 43] = "fundId";
                        int i = 2;

                        foreach (ListViewItem item in listView1.Items)
                        {
                            ws.Cells[i, 1] = item.SubItems[0].Text;
                            ws.Cells[i, 2] = item.SubItems[1].Text;
                            ws.Cells[i, 3] = item.SubItems[2].Text;
                            ws.Cells[i, 4] = item.SubItems[3].Text;
                            ws.Cells[i, 5] = item.SubItems[4].Text;
                            ws.Cells[i, 6] = item.SubItems[5].Text;
                            ws.Cells[i, 7] = item.SubItems[6].Text;
                            ws.Cells[i, 8] = item.SubItems[7].Text;
                            ws.Cells[i, 9] = item.SubItems[8].Text;
                            ws.Cells[i, 10] = item.SubItems[9].Text;
                            ws.Cells[i, 11] = item.SubItems[10].Text;
                            ws.Cells[i, 12] = item.SubItems[11].Text;
                            ws.Cells[i, 13] = item.SubItems[12].Text;
                            ws.Cells[i, 14] = item.SubItems[13].Text;
                            ws.Cells[i, 15] = item.SubItems[14].Text;
                            ws.Cells[i, 16] = item.SubItems[15].Text;
                            ws.Cells[i, 17] = item.SubItems[16].Text;
                            ws.Cells[i, 18] = item.SubItems[17].Text;
                            ws.Cells[i, 19] = item.SubItems[18].Text;
                            ws.Cells[i, 20] = item.SubItems[19].Text;
                            ws.Cells[i, 21] = item.SubItems[20].Text;
                            ws.Cells[i, 22] = item.SubItems[21].Text;
                            ws.Cells[i, 23] = item.SubItems[22].Text;
                            ws.Cells[i, 24] = item.SubItems[23].Text;
                            ws.Cells[i, 25] = item.SubItems[24].Text;
                            ws.Cells[i, 26] = item.SubItems[25].Text;
                            ws.Cells[i, 27] = item.SubItems[26].Text;
                            ws.Cells[i, 28] = item.SubItems[27].Text;
                            ws.Cells[i, 29] = item.SubItems[28].Text;
                            ws.Cells[i, 30] = item.SubItems[29].Text;
                            ws.Cells[i, 31] = item.SubItems[30].Text;
                            ws.Cells[i, 32] = item.SubItems[31].Text;
                            ws.Cells[i, 33] = item.SubItems[32].Text;
                            ws.Cells[i, 34] = item.SubItems[33].Text;
                            ws.Cells[i, 35] = item.SubItems[34].Text;
                            ws.Cells[i, 36] = item.SubItems[35].Text;
                            ws.Cells[i, 37] = item.SubItems[36].Text;
                            ws.Cells[i, 38] = item.SubItems[37].Text;
                            ws.Cells[i, 39] = item.SubItems[38].Text;
                            ws.Cells[i, 40] = item.SubItems[39].Text;
                            ws.Cells[i, 41] = item.SubItems[40].Text;
                            ws.Cells[i, 42] = item.SubItems[41].Text;
                            ws.Cells[i, 43] = item.SubItems[42].Text;
                            i++;
                        }
                        wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange,
     XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                        app.Quit();
                    }
                    MessageBox.Show("Seus dados foram exportados para o Excel com sucesso");
                }
                
            }

            if (radioButton1.Checked == true)
            {

                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Excel |* .xls",
                    InitialDirectory = @"c:\dados\xls",
                    FileName = "NFeProd" + DateTime.Now.Millisecond.ToString() + ".xls",
                    ValidateNames = true
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                        Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                        Worksheet ws = (Worksheet)app.ActiveSheet;
                        app.Visible = false;
                        ws.Cells[1, 1] = "cProd";
                        ws.Cells[1, 2] = "nNF";
                        ws.Cells[1, 3] = "xProd";
                        ws.Cells[1, 4] = "NCM";
                        ws.Cells[1, 5] = "CFOP";
                        ws.Cells[1, 6] = "uCom";
                        ws.Cells[1, 7] = "qCom";
                        ws.Cells[1, 8] = "vUnCom";
                        ws.Cells[1, 9] = "vProd";
                        int i = 2;

                        foreach (ListViewItem item in listView1.Items)
                        {
                            ws.Cells[i, 1] = item.SubItems[0].Text;
                            ws.Cells[i, 2] = item.SubItems[1].Text;
                            ws.Cells[i, 3] = item.SubItems[2].Text;
                            ws.Cells[i, 4] = item.SubItems[3].Text;
                            ws.Cells[i, 5] = item.SubItems[4].Text;
                            ws.Cells[i, 6] = item.SubItems[5].Text;
                            ws.Cells[i, 7] = item.SubItems[6].Text;
                            ws.Cells[i, 8] = item.SubItems[7].Text;
                            ws.Cells[i, 9] = item.SubItems[8].Text;
                            i++;
                        }
                        wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange,
     XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                        app.Quit();
                    }
                    MessageBox.Show("Seus dados foram exportados para o Excel com sucesso");
                }
            }

            else 
            {
                MessageBox.Show("Opção de exibição não selecionada"); 
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            consultar();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            consultarProd();        }

        private void btExportar_MouseEnter(object sender, EventArgs e)
        {
            btExportar.BackgroundImage = Properties.Resources.btExportarE;
        }

        private void btExportar_MouseLeave(object sender, EventArgs e)
        {
            btExportar.BackgroundImage = Properties.Resources.btExportar;
        }

        private void btExportar_MouseMove(object sender, MouseEventArgs e)
        {
            btExportar.BackgroundImage = Properties.Resources.btExportarE;

        }

        private void btExportar_MouseLeave_1(object sender, EventArgs e)
        {
            btExportar.BackgroundImage = Properties.Resources.btExportar;

        }
    }
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
    
    


