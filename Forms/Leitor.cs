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
using static Tingle.ChaveAcesso;

namespace Tingle
{
    public partial class NFe : Form
    {
        private int codigo;
        private NFeWS notas;
        private BindingSource produtos;

        public NFe(int codigo, NFeWS notas, BindingSource produtos)
        {
            InitializeComponent();
            this.codigo = codigo;
            this.notas = notas;
            this.produtos = produtos;
            pbEnviar.BackgroundImage = Properties.Resources.BtEnv;
            pbInserir.BackgroundImage = Properties.Resources.btBuscar;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void NFe_Load(object sender, EventArgs e)
        {
            this.Refresh();

        }

        public void OpenFile()
        {
            Nfe.Open();

            if (Nfe.Path != null)
            {
                Nfe.Read();
                MessageBox.Show("Documento lido com sucesso!");

            }
        }
        //Inserção de dados para o BD
        private void Insert()
        {
            //Conexão bd
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user id=root;database=historico;password =");

            //Abre conexão MySQL
            connection.Open();

            //Insert ALL
            var all = "INSERT INTO completa(nNF, Dest_CNPJ, Dest_xNome, Dest_xLgr, Dest_xBairro, Dest_xMun, Dest_UF, Dest_CEP, Dest_fone, Dest_IE," 
                + " dEmit, dRecbto, hRecbto, " 
                + "CNPJ, Emit_xNome, Emit_xLgr, Emit_xBairro, Emit_xMun, Emit_UF, Emit_CEP, Emit_fone, Emit_IE, Emit_nro, " 
                + "vBc, vICMS, vBCTS, vProd, vFrete, vSeg, vDesc, vIPI, vOutro, vNF, " 
                + "Transp_CNPJ, Transp_xNome, Transp_xLgr, Transp_xMun, Transp_UF, Transp_IE, qVol, esp, funId) " 
                //Values
                + "VALUES(@nNF, @Dest_CNPJ, @Dest_xNome, @Dest_xLgr, @Dest_xBairro, @Dest_xMun, @Dest_UF, @Dest_CEP, @Dest_fone, @Dest_IE, @dEmit, @dRecbto, @hRecbto, " +
                "@CNPJ, @Emit_xNome, @Emit_xLgr, @Emit_xBairro, @Emit_xMun, @Emit_UF, @Emit_CEP, @Emit_fone, @Emit_IE, @Emit_nro, " +
                "@vBc, @vICMS, @vBCTS, @vProd, @vFrete, @vSeg, @vDesc, @vIPI, @vOutro, @vNF, " +
                "@Transp_CNPJ, @Transp_xNome, @Transp_xLgr, @Transp_xMun, @Transp_UF, @Transp_IE, @qVol, @esp, @funId)";

            var comando = new MySqlCommand(all, connection);

            //Dest
            comando.Parameters.AddWithValue("@nNF", this.nNF.Text);
            comando.Parameters.AddWithValue("@Dest_CNPJ", this.CNPJeCPFRtext.Text);
            comando.Parameters.AddWithValue("@Dest_xNome", this.NomeRtxt.Text);
            comando.Parameters.AddWithValue("@Dest_xLgr", this.Enderecotxt.Text);
            comando.Parameters.AddWithValue("@Dest_xBairro", this.Bairrotxt.Text);
            comando.Parameters.AddWithValue("@Dest_xMun", this.Municipiotxt.Text);
            comando.Parameters.AddWithValue("@Dest_UF", this.UFtxt.Text);
            comando.Parameters.AddWithValue("@Dest_CEP", this.CEPtxt.Text);
            comando.Parameters.AddWithValue("@Dest_fone", this.Telefonetxt.Text);
            comando.Parameters.AddWithValue("@Dest_IE", this.IEtxt.Text);
            comando.Parameters.AddWithValue("@dEmit", this.DataEtxt.Text);
            comando.Parameters.AddWithValue("@dRecbto", this.DataSaidatxt.Text);
            comando.Parameters.AddWithValue("@hRecbto", this.HoraSaidatxt.Text);
            
            //Emit
            comando.Parameters.AddWithValue("@CNPJ", this.CNPJeCPFtxt.Text);
            comando.Parameters.AddWithValue("@Emit_xNome", this.IdentificaçãoEmitentetxt.Text);
            comando.Parameters.AddWithValue("@Emit_xLgr", this.xLgrEmitente.Text);
            comando.Parameters.AddWithValue("@Emit_xBairro", this.xBairroEmitente.Text);
            comando.Parameters.AddWithValue("@Emit_xMun", this.xMunEmit.Text);
            comando.Parameters.AddWithValue("@Emit_UF", this.UFemit.Text);
            comando.Parameters.AddWithValue("@Emit_CEP", this.CEPemit.Text);
            comando.Parameters.AddWithValue("@Emit_fone", this.foneEmitente.Text);
            comando.Parameters.AddWithValue("@Emit_IE", this.IEtxt.Text);
            comando.Parameters.AddWithValue("@Emit_nro", this.nroEmitente.Text);

            //Imposto
            comando.Parameters.AddWithValue("@vBC", this.Basetxt.Text);
            comando.Parameters.AddWithValue("@vICMS", this.ICMStxt.Text);
            comando.Parameters.AddWithValue("@vBCTS", this.BaseSTtxt.Text);
            comando.Parameters.AddWithValue("@vProd", this.ValorTotalProdtxt.Text);
            comando.Parameters.AddWithValue("@vFrete", this.Fretetxt.Text);
            comando.Parameters.AddWithValue("@vSeg", this.Segurotxt.Text);
            comando.Parameters.AddWithValue("@vDesc", this.Descontotxt.Text);
            comando.Parameters.AddWithValue("@vIPI", this.PIStxt.Text);
            comando.Parameters.AddWithValue("@vOutro", this.Despesastxt.Text);
            comando.Parameters.AddWithValue("@vNF", this.ValorTotalNotatxt.Text);

            //Transp
            comando.Parameters.AddWithValue("@Transp_CNPJ", this.CNPJTtxt.Text);
            comando.Parameters.AddWithValue("@Transp_xNome", this.NomeTtxt.Text);
            comando.Parameters.AddWithValue("@Transp_xLgr", this.EnderecoTtxt.Text);
            comando.Parameters.AddWithValue("@Transp_xMun", this.MunicipioTtxt.Text);
            comando.Parameters.AddWithValue("@Transp_UF", this.UFTtxt.Text);
            comando.Parameters.AddWithValue("@Transp_IE", this.IETtxt.Text);
            comando.Parameters.AddWithValue("@qVol", this.Quantidadetxt.Text);
            comando.Parameters.AddWithValue("@esp", this.Especietxt.Text);
            
            //Funcionario
            comando.Parameters.AddWithValue("@funId", codigo);


            //Insert Tabela Destinatário
            var dest = "Insert INTO destinatario(nNF, CNPJ, xNome, xLgr, xBairro, xMun, UF, CEP, fone, IE, dEmit, dRecbto, hRecbto)"
                          + "VALUES(@nNF, @CNPJ, @xNome, @xLgr, @xBairro, @xMun, @UF, @CEP, @fone, @IE, @dEmit, @dRecbto, @hRecbto)";

            //Cria o comando
            var cmd = new MySqlCommand(dest, connection);

            //Adicionando os valores no parâmetro do comando
            cmd.Parameters.AddWithValue("@nNF", this.nNF.Text);
            cmd.Parameters.AddWithValue("@CNPJ", this.CNPJeCPFRtext.Text);
            cmd.Parameters.AddWithValue("@xNome", this.NomeRtxt.Text);
            cmd.Parameters.AddWithValue("@xLgr", this.Enderecotxt.Text);
            cmd.Parameters.AddWithValue("@xBairro", this.Bairrotxt.Text);
            cmd.Parameters.AddWithValue("@xMun", this.Municipiotxt.Text);
            cmd.Parameters.AddWithValue("@UF", this.UFtxt.Text);
            cmd.Parameters.AddWithValue("@CEP", this.CEPtxt.Text);
            cmd.Parameters.AddWithValue("@fone", this.Telefonetxt.Text);
            cmd.Parameters.AddWithValue("@IE", this.IEtxt.Text);
            cmd.Parameters.AddWithValue("@dEmit", this.DataEtxt.Text);
            cmd.Parameters.AddWithValue("@dRecbto", this.DataSaidatxt.Text);
            cmd.Parameters.AddWithValue("@hRecbto", this.HoraSaidatxt.Text);

            //Insert Tabela Emitente
            var emit = "Insert INTO emitente(nNF, dhEmi, CNPJ, xNome, xLgr, nro, xBairro, xMun, UF, CEP, fone, IE)"
                        + "VALUES(@nNF, @dhEmi, @CNPJ, @xNome, @xLgr, @nro, @xBairro, @xMun, @UF, @CEP, @fone, @IE)";

            //Cria o comando MySQL
            var cmd2 = new MySqlCommand(emit, connection);

            //Adiciona os valores no parâmetros do cmd
            cmd2.Parameters.AddWithValue("@nNF", this.nNF.Text);
            cmd2.Parameters.AddWithValue("@dhEmi", this.DataEtxt.Text);
            cmd2.Parameters.AddWithValue("@CNPJ", this.CNPJeCPFtxt.Text);
            cmd2.Parameters.AddWithValue("@xNome", this.IdentificaçãoEmitentetxt.Text);
            cmd2.Parameters.AddWithValue("@xLgr", this.xLgrEmitente.Text);
            cmd2.Parameters.AddWithValue("@nro", this.nroEmitente.Text);
            cmd2.Parameters.AddWithValue("@xBairro", this.xBairroEmitente.Text);
            cmd2.Parameters.AddWithValue("@xMun", this.xMunEmit.Text);
            cmd2.Parameters.AddWithValue("@UF", this.UFemit.Text);
            cmd2.Parameters.AddWithValue("@CEP", this.CEPemit.Text);
            cmd2.Parameters.AddWithValue("@fone", this.foneEmitente.Text);
            cmd2.Parameters.AddWithValue("@IE", this.IEtxt.Text);


            //Insert Tabela Transporte
            var transp = "Insert INTO transportador(nNF, CNPJ, xNome, IE, xEnder, xMun, UF, qVol, esp)"
                          + "VALUES(@nNF, @CNPJ, @xNome, @IE, @xEnder, @xMun, @UF, @qVol, @esp)";

            //Cria o comando MySQL
            var cmd3 = new MySqlCommand(transp, connection);

            //Adiciona os valores no parâmetro do comando
            cmd3.Parameters.AddWithValue("@nNF", this.nNF.Text);
            cmd3.Parameters.AddWithValue("@CNPJ", this.CNPJTtxt.Text);
            cmd3.Parameters.AddWithValue("@xNome", this.NomeTtxt.Text);
            cmd3.Parameters.AddWithValue("@IE", this.IETtxt.Text);
            cmd3.Parameters.AddWithValue("@xEnder", this.EnderecoTtxt.Text);
            cmd3.Parameters.AddWithValue("@xMun", this.MunicipioTtxt.Text);
            cmd3.Parameters.AddWithValue("@UF", this.UFTtxt.Text);
            cmd3.Parameters.AddWithValue("@qVol", this.Quantidadetxt.Text);
            cmd3.Parameters.AddWithValue("@esp", this.Especietxt.Text);


            //Insert Tabela Produtos
            var prodt = "INSERT INTO produtos(nNF, cProd, xProd, NCM, CFOP, uCom, qCom, vUnCom, vProd)"
                        + "VALUES(@nNF, @cProd, @xProd, @NCM, @CFOP, @uCom, @qCom, @vUnCom, @vProd)";

            var cmd4 = new MySqlCommand(prodt, connection);

            //Percorre o DataGridView e insere os produtos
            for (int i = 0; i < dgvProd.Rows.Count - 1; i++)
            {
                cmd4.Parameters.Clear();

                cmd4.Parameters.AddWithValue("@nNF", this.nNF.Text);
                cmd4.Parameters.AddWithValue("@cProd",
                    dgvProd.Rows[i].Cells[0].Value);
                cmd4.Parameters.AddWithValue("@xProd",
                    dgvProd.Rows[i].Cells[2].Value);
                cmd4.Parameters.AddWithValue("@NCM",
                    dgvProd.Rows[i].Cells[3].Value);
                cmd4.Parameters.AddWithValue("@CFOP",
                    dgvProd.Rows[i].Cells[4].Value);
                cmd4.Parameters.AddWithValue("@uCom",
                    dgvProd.Rows[i].Cells[5].Value);
                cmd4.Parameters.AddWithValue("@qCom",
                    dgvProd.Rows[i].Cells[6].Value);
                cmd4.Parameters.AddWithValue("@vUnCom",
                    dgvProd.Rows[i].Cells[7].Value);
                cmd4.Parameters.AddWithValue("@vProd",
                    dgvProd.Rows[i].Cells[8].Value);

                cmd4.ExecuteNonQuery();

            }

            //Insert Tabela Imposto
            var imposto = "INSERT INTO imposto(nNF, vBC, vICMS, vBCST, vProd, vFrete, vSeg, vDesc, vIPI, vOutro, vNF)"
                        + "VALUES(@nNF, @vBC, @vICMS, @vBCST, @vProd, @vFrete, @vSeg, @vDesc, @vIPI, @vOutro, @vNF)";

            var cmd5 = new MySqlCommand(imposto, connection);

            //Adiciona os valores no parâmetro do comando.
            cmd5.Parameters.AddWithValue("@nNF", this.nNF.Text);
            cmd5.Parameters.AddWithValue("@vBC", this.Basetxt.Text);
            cmd5.Parameters.AddWithValue("@vICMS", this.ICMStxt.Text);
            cmd5.Parameters.AddWithValue("@vBCST", this.BaseSTtxt.Text);
            cmd5.Parameters.AddWithValue("@vProd", this.ValorTotalProdtxt.Text);
            cmd5.Parameters.AddWithValue("@vFrete", this.Fretetxt.Text);
            cmd5.Parameters.AddWithValue("@vSeg", this.Segurotxt.Text);
            cmd5.Parameters.AddWithValue("@vDesc", this.Descontotxt.Text);
            cmd5.Parameters.AddWithValue("@vIPI", this.PIStxt.Text);
            cmd5.Parameters.AddWithValue("@vOutro", this.Despesastxt.Text);
            cmd5.Parameters.AddWithValue("@vNF", this.ValorTotalNotatxt.Text);

            //Executa os parâmetros
            comando.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            cmd5.ExecuteNonQuery();

            //Limpa os parâmetros
            comando.Parameters.Clear();
            cmd.Parameters.Clear();
            cmd2.Parameters.Clear();
            cmd3.Parameters.Clear();
            cmd4.Parameters.Clear();
            cmd5.Parameters.Clear();

            MessageBox.Show("Você registrou essa NFe!");
            //Fecha a conexão
            connection.Close();

        }

        public void PopulationXMLCH()
        {

                //Emitente
                xLgrEmitente.Text = notas.Emit_xLgr.ToString();
                IdentificaçãoEmitentetxt.Text = notas.Emit_xNome.ToString();
                xBairroEmitente.Text = notas.Emit_xBairro.ToString();
                xMunEmit.Text = notas.Emit_xMun.ToString();
                UFemit.Text = notas.Emit_UF.ToString();
                CEPemit.Text = notas.Emit_CEP.ToString();
                foneEmitente.Text = notas.Emit_fone.ToString();
                IETtxt.Text = notas.Emit_IE.ToString();
                nroEmitente.Text = notas.Emit_nro.ToString();
                NOtxt.Text = notas.Emit_xLgr.ToString();
                DataEtxt.Text = notas.dEmit.ToString();
                CNPJeCPFtxt.Text = notas.CNPJ.ToString();

                //Destinatário
                NomeRtxt.Text = notas.Dest_xNome.ToString();
                CNPJeCPFRtext.Text = notas.Dest_CNPJ.ToString();
                Enderecotxt.Text = notas.Dest_xLgr.ToString();
                Bairrotxt.Text = notas.Dest_xBairro.ToString();
                Municipiotxt.Text = notas.Dest_xMun.ToString();
                CEPtxt.Text = notas.Dest_CEP.ToString();
                Telefonetxt.Text = notas.Dest_fone.ToString();
                UFtxt.Text = notas.Dest_UF.ToString();
                IERtxt.Text = notas.Dest_IE.ToString();
                DataSaidatxt.Text = notas.dRecbto.ToString();
                HoraSaidatxt.Text = notas.hRecbto.ToString();

                //Transporte

                NomeTtxt.Text = notas.Transp_xNome.ToString();
                EnderecoTtxt.Text = notas.Transp_xLgr.ToString();
                MunicipioTtxt.Text = notas.Transp_xMun.ToString();
                IETtxt.Text = notas.Transp_IE.ToString();
                CNPJTtxt.Text = notas.Transp_CNPJ.ToString();
                UFTtxt.Text = notas.Transp_UF.ToString();
                Quantidadetxt.Text = notas.qVol.ToString();
                Especietxt.Text = notas.esp.ToString();
                FreteTtxt.Text = notas.modfrete.ToString();

                //Total
                Basetxt.Text = notas.vBc.ToString();
                ICMStxt.Text = notas.vICMS.ToString();
                BaseSTtxt.Text = notas.vBCTS.ToString();
                ValorTotalProdtxt.Text = notas.vProd.ToString();
                Fretetxt.Text = notas.vFrete.ToString();
                Segurotxt.Text = notas.vSeg.ToString();
                Descontotxt.Text = notas.vDesc.ToString();
                PIStxt.Text = notas.vIPI.ToString();
                //COFINStxt.Text = notas.modfrete.ToString();
                Despesastxt.Text = notas.vOutro.ToString();
                ValorTotalNotatxt.Text = notas.vNF.ToString();

                //Informações adicionais
                UAPtxt.Text = notas.nProt.ToString();
                nNF.Text = notas.nNF.ToString();
                ChaveAcessotxt.Text = notas.CHNFE.ToString();

                dgvProd.DataSource = produtos;

            }

        //População dos Dados do Esquema XML
        private void PopulationXML()
        {
            //Emitente
            IdentificaçãoEmitentetxt.Text = Nfe.XMLSchema.Tables["emit"].Rows[0]["xNome"].ToString();
            xLgrEmitente.Text = Nfe.XMLSchema.Tables["enderEmit"].Rows[0]["xLgr"].ToString();
            nroEmitente.Text = Nfe.XMLSchema.Tables["enderEmit"].Rows[0]["nro"].ToString();
            xBairroEmitente.Text = Nfe.XMLSchema.Tables["enderEmit"].Rows[0]["xBairro"].ToString();
            UFemit.Text = Nfe.XMLSchema.Tables["enderEmit"].Rows[0]["UF"].ToString();
            CEPemit.Text = Nfe.XMLSchema.Tables["enderEmit"].Rows[0]["CEP"].ToString();
            xMunEmit.Text = Nfe.XMLSchema.Tables["enderEmit"].Rows[0]["xMun"].ToString();
            foneEmitente.Text = Nfe.XMLSchema.Tables["enderEmit"].Rows[0]["fone"].ToString();
            CNPJeCPFtxt.Text = Nfe.XMLSchema.Tables["emit"].Rows[0]["CNPJ"].ToString();
            IEtxt.Text = Nfe.XMLSchema.Tables["emit"].Rows[0]["IE"].ToString();
            NOtxt.Text = Nfe.XMLSchema.Tables["ide"].Rows[0]["natOp"].ToString();
            DataEtxt.Text = Convert.ToDateTime(Nfe.XMLSchema.Tables["ide"].Rows[0]["dhEmi"].ToString().Substring(0, 10), System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");

            //Destinatário
            NomeRtxt.Text = Nfe.XMLSchema.Tables["dest"].Rows[0]["xNome"].ToString();
            CNPJeCPFRtext.Text = Nfe.XMLSchema.Tables["dest"].Rows[0]["CNPJ"].ToString();
            Enderecotxt.Text = Nfe.XMLSchema.Tables["enderDest"].Rows[0]["xLgr"].ToString();
            Bairrotxt.Text = Nfe.XMLSchema.Tables["enderDest"].Rows[0]["xBairro"].ToString();
            Municipiotxt.Text = Nfe.XMLSchema.Tables["enderDest"].Rows[0]["xMun"].ToString();
            CEPtxt.Text = Nfe.XMLSchema.Tables["enderDest"].Rows[0]["CEP"].ToString();
            Telefonetxt.Text = Nfe.XMLSchema.Tables["enderDest"].Rows[0]["fone"].ToString();
            UFtxt.Text = Nfe.XMLSchema.Tables["enderDest"].Rows[0]["UF"].ToString();
            IERtxt.Text = Nfe.XMLSchema.Tables["dest"].Rows[0]["IE"].ToString();
            DataSaidatxt.Text = Convert.ToDateTime(Nfe.XMLSchema.Tables["infProt"].Rows[0]["dhRecbto"].ToString().Substring(0, 9), System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
            HoraSaidatxt.Text = Convert.ToDateTime(Nfe.XMLSchema.Tables["infProt"].Rows[0]["dhRecbto"].ToString().Substring(11), System.Globalization.CultureInfo.InvariantCulture).ToString("HH:mm");

            //Transporte
            NomeTtxt.Text = Nfe.XMLSchema.Tables["transporta"].Rows[0]["xNome"].ToString();
            EnderecoTtxt.Text = Nfe.XMLSchema.Tables["transporta"].Rows[0]["xEnder"].ToString();
            MunicipioTtxt.Text = Nfe.XMLSchema.Tables["transporta"].Rows[0]["xMun"].ToString();
            IETtxt.Text = Nfe.XMLSchema.Tables["transporta"].Rows[0]["IE"].ToString();
            CNPJTtxt.Text = Nfe.XMLSchema.Tables["transporta"].Rows[0]["CNPJ"].ToString();
            UFTtxt.Text = Nfe.XMLSchema.Tables["transporta"].Rows[0]["UF"].ToString();
            Quantidadetxt.Text = Nfe.XMLSchema.Tables["vol"].Rows[0]["qVol"].ToString();
            Especietxt.Text = Nfe.XMLSchema.Tables["vol"].Rows[0]["esp"].ToString();
            FreteTtxt.Text = Nfe.XMLSchema.Tables["transp"].Rows[0]["modFrete"].ToString();

            //Total
            Basetxt.Text = Nfe.XMLSchema.Tables["ICMSTot"].Rows[0]["vBC"].ToString();
            ICMStxt.Text = Nfe.XMLSchema.Tables["ICMSTot"].Rows[0]["vICMS"].ToString();
            BaseSTtxt.Text = Nfe.XMLSchema.Tables["ICMSTot"].Rows[0]["vBCST"].ToString();
            ValorTotalProdtxt.Text = Nfe.XMLSchema.Tables["ICMSTot"].Rows[0]["vProd"].ToString();
            Fretetxt.Text = Nfe.XMLSchema.Tables["ICMSTot"].Rows[0]["vFrete"].ToString();
            Segurotxt.Text = Nfe.XMLSchema.Tables["ICMSTot"].Rows[0]["vSeg"].ToString();
            Descontotxt.Text = Nfe.XMLSchema.Tables["ICMSTot"].Rows[0]["vDesc"].ToString();
            PIStxt.Text = Nfe.XMLSchema.Tables["ICMSTot"].Rows[0]["vPIS"].ToString();
            COFINStxt.Text = Nfe.XMLSchema.Tables["ICMSTot"].Rows[0]["vCOFINS"].ToString();
            Despesastxt.Text = Nfe.XMLSchema.Tables["ICMSTot"].Rows[0]["vOutro"].ToString();
            ValorTotalNotatxt.Text = Nfe.XMLSchema.Tables["ICMSTot"].Rows[0]["vNF"].ToString();

            //Informações adicionais
            UAPtxt.Text = Nfe.XMLSchema.Tables["infProt"].Rows[0]["nProt"].ToString();
            nNF.Text = Nfe.XMLSchema.Tables["ide"].Rows[0]["nNF"].ToString();
            ChaveAcessotxt.Text = Nfe.XMLSchema.Tables["infProt"].Rows[0]["chNFe"].ToString();

            //Produtos
            //Pega todos os dados do produto do Esquema XML para exibir no DataGridView
            this.dgvProd.DataSource = null;
            dgvProd.Rows.Clear();

            dgvProd.DataSource = Nfe.XMLSchema.Tables["prod"];

        }

        private void pbEnviar_Click(object sender, EventArgs e)
        {
            Insert();   
        }

        private void pbInserir_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            OpenFile();
            PopulationXML();
        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void pbInserir_MouseEnter(object sender, EventArgs e)
        {
            pbInserir.BackgroundImage = Properties.Resources.btBuscarEs;
        }

        private void pbInserir_MouseLeave(object sender, EventArgs e)
        {
            pbInserir.BackgroundImage = Properties.Resources.btBuscar;
        }

        private void pbEnviar_MouseEnter(object sender, EventArgs e)
        {
            pbEnviar.BackgroundImage = Properties.Resources.BtEnvEs;
        }

        private void pbEnviar_MouseLeave(object sender, EventArgs e)
        {
            pbEnviar.BackgroundImage = Properties.Resources.BtEnv;
        }

        private void pbVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbEnviar_Click_1(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Você deseja inserir essa NFE?", "Enviar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Insert();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PopulationXMLCH();
            this.Refresh();
        }
    }
}
