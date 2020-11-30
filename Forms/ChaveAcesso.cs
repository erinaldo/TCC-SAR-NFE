using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static Tingle.NFe;
using static Tingle.Inicial;


namespace Tingle
{
    public partial class ChaveAcesso : Form
    {
        string URI = "";
        private int codigo;
        BindingSource bsDados = new BindingSource();

        public int CHNFE { get; private set; }

        public ChaveAcesso(int codigo)
        {
            InitializeComponent();
            pbOk.BackgroundImage = Properties.Resources.imgOk;

            this.codigo = codigo;
        }

        //Classe Prods para tipar o Json
        public class Prods
        {
        public int CHNFE { get; set; }
        public string cProd { get; set; }
        public int nNF { get; set; }
        public string xProd { get; set; }
        public int NCM { get; set; }
        public int CFOP { get; set; }
        public string uCom { get; set; }
        public int qCom { get; set; }
        public int vUnCom { get; set; }
        public int vProd { get; set; }
        }

        //Classe NFeWS para tipar o JSON
        public class NFeWS
        {
            public int CHNFE { get; set; }
            public int nNF { get; set; }
            public int Dest_CNPJ { get; set; }
            public string Dest_xNome { get; set; }
            public string Dest_xLgr { get; set; }
            public string Dest_xBairro { get; set; }
            public string Dest_xMun { get; set; }
            public string Dest_UF { get; set; }
            public int Dest_CEP { get; set; }
            public int Dest_fone { get; set; }
            public int Dest_IE { get; set; }
            public string dEmit { get; set; }
            public string dRecbto { get; set; }
            public string hRecbto { get; set; }
            public int CNPJ { get; set; }
            public  string Emit_xNome { get; set; }
           public  string Emit_xLgr { get; set; }
            public  string Emit_xBairro { get; set; }
            public  string Emit_xMun { get; set; }
            public  string Emit_UF { get; set; }
            public  int Emit_CEP { get; set; }
            public  int Emit_fone { get; set; }
            public  int Emit_IE { get; set; }
            public  int Emit_nro { get; set; }
            public int vBc { get; set; }
            public int vICMS { get; set; }
            public int vBCTS { get; set; }
            public int vProd { get; set; }
            public int vFrete { get; set; }
            public int vSeg { get; set; }
            public int vDesc { get; set; }
            public int vIPI { get; set; }
            public int vOutro { get; set; }
            public int vNF { get; set; }
            public int Transp_CNPJ { get; set; }
            public string Transp_xNome { get; set; }
            public string Transp_xLgr { get; set; }
            public string Transp_xMun { get; set; }
            public string Transp_UF { get; set; }
            public int Transp_IE { get; set; }
            public int qVol { get; set; }
            public string esp { get; set; }
            public string error { get; set; }
            public int modfrete { get; set; }
            public int nProt { get; set; }
            public string natOp { get; set; }
        }

        //Obter a NFE pela chave de acesso, onde deserializa um JSON em strnig.
        private async Task<NFeWS> GetNFEById(int CHNFE)
        {
            using (var client = new HttpClient())
            {

                URI = "https://localhost:44335/receitaWS/nfe/" + CHNFE.ToString();
                HttpResponseMessage response = await client.GetAsync(URI);
                if (response.IsSuccessStatusCode || response.Content != null)
                {
                    
                    var NFeJsonString = await response.Content.ReadAsStringAsync();
                    NFeWS nota = JsonConvert.DeserializeObject<NFeWS>(NFeJsonString);
                    return nota;
                }
                else
                {
                    MessageBox.Show("Falha ao obter a NFe : " + response.StatusCode);
                    return null;
                }
            }
        }

        //Obter os produtos pela chave de acesso
        private async Task<BindingSource> GetProdutosById(int CHNFE, BindingSource bsDados)
        {
            using (var client = new HttpClient())
            {

                URI = "https://localhost:44335/receitaWS/prod/" + CHNFE.ToString();
                HttpResponseMessage response = await client.GetAsync(URI);
                if (response.IsSuccessStatusCode || response.Content != null)
                {

                    var NFeJsonString = await response.Content.ReadAsStringAsync();
                    bsDados.DataSource = JsonConvert.DeserializeObject<Prods>(NFeJsonString);
                    // dgvDados.DataSource = bsDados;
                    return bsDados;
                }
                else
                {
                    MessageBox.Show("Falha ao obter os produtos : " + response.StatusCode);
                    return null;
                }
            }
        }

        //Trasnformando os JSON convertidos para NFeWS e BindingSource
        private async void btnWS_Click(object sender, EventArgs e)
        {

            CHNFE = Convert.ToInt32(txtURI.Text);

            NFeWS notas = await GetNFEById(CHNFE);
            BindingSource produtos = await GetProdutosById(CHNFE, bsDados);

            if (notas == null)
            {
                MessageBox.Show("Chave de acesso incorreta");
            }
            else
            {
                openChildForm(new NFe(this.codigo, notas, produtos));

            }

        }

        //Não permite caracteres
        private void txtURI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void Ok_MouseMove(object sender, MouseEventArgs e)
        {
            pbOk.BackgroundImage = Properties.Resources.imgOkE;
        }

        private void Ok_MouseLeave_1(object sender, EventArgs e)
        {
           pbOk.BackgroundImage = Properties.Resources.imgOk;
        }
    }
}
