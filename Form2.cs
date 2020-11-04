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
    public partial class NFe : Form
    {
        public NFe()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NFe_Load(object sender, EventArgs e)
        {

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
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            cmd5.ExecuteNonQuery();

            //Limpa os parâmetros
            cmd.Parameters.Clear();
            cmd2.Parameters.Clear();
            cmd3.Parameters.Clear();
            cmd4.Parameters.Clear();
            cmd5.Parameters.Clear();

            //Fecha a conexão
            connection.Close();

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
            dgvProd.DataSource = Nfe.XMLSchema.Tables["prod"];
        }
    }
}
