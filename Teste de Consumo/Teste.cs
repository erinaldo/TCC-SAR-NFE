using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LeitorNfe
{
    
    public partial class Teste : Form
    {
        private string txtURIE;
        public string URI = "";
        
        public class DestinatarioController
        {
            public string CNPJ { get; set; }
            public string xNome { get; set; }
            public string xLgr { get; set; }
            public string xBairro { get; set; }
            public string xMun { get; set; }
            public string UF { get; set; }
            public string CEP { get; set; }
            public string fone { get; set; }
            public string IE { get; set; }
            public string dEmit { get; set; }
            public string dRecbto { get; set; }
            public string hRecbto { get; set; }

            public string erro { get; set; }
        }

        public class EmitsController
        {
            public string cnpj { get; set; }
            public string xnome { get; set; }
            public string xlgr { get; set; }
            public string nro { get; set; }
            public string xBairro { get; set; }
            public string xMun { get; set; }
            public string UF { get; set; }
            public string CEP { get; set; }
            public string Fone { get; set; }
            public string IE { get; set; }

            public string error { get; set; }
        }

        public class ImpostoController
        {
            public string nNF { get; set; }
            public string vBC { get; set; }
            public string vICMS { get; set; }
            public string vBCST { get; set; }
            public string vProd { get; set; }
            public string vFrete { get; set; }
            public string vSeg { get; set; }
            public string vDesc { get; set; }
            public string vIPI { get; set; }
            public string vOutro { get; set; }
            public string vNF { get; set; }

            public string error { get; set; }
        }

        public class NFeController
        {
            public string nNF { get; set; }
            public string Dest_CNPJ { get; set; }
            public string Dest_xNome { get; set; }
            public string Dest_xLgr { get; set; }
            public string Dest_xBairro { get; set; }
            public string Dest_xMun { get; set; }
            public string Dest_UF { get; set; }
            public string Dest_CEP { get; set; }
            public string Dest_fone { get; set; }
            public string Dest_IE { get; set; }
            public string dEmit { get; set; }
            public string dRecbto { get; set; }
            public string hRecbto { get; set; }
            public string CNPJ { get; set; }
            public string Emit_xNome { get; set; }
            public string Emit_xLgr { get; set; }
            public string Emit_xBairro { get; set; }
            public string Emit_xMun { get; set; }
            public string Emit_UF { get; set; }
            public string Emit_CEP { get; set; }
            public string Emit_fone { get; set; }
            public string Emit_IE { get; set; }
            public string Emit_nro { get; set; }
            public string vBc { get; set; }
            public string vICMS { get; set; }
            public string vBCTS { get; set; }
            public string vProd { get; set; }
            public string vFrete { get; set; }
            public string vSeg { get; set; }
            public string vDesc { get; set; }
            public string vIPI { get; set; }
            public string vOutro { get; set; }
            public string vNF { get; set; }
            public string Transp_CNPJ { get; set; }
            public string Transp_xNome { get; set; }
            public string Transp_xLgr { get; set; }
            public string Transp_xMun { get; set; }
            public string Transp_UF { get; set; }
            public string Transp_IE { get; set; }
            public string qVol { get; set; }
            public string esp { get; set; }
            
            public string error { get; set; }
        }

        public class ProdutosController
        {
            public string cProd { get; set; }
            public string nNF { get; set; }
            public string xProd { get; set; }
            public string NCM { get; set; }
            public string CFOP { get; set; }
            public string uCom { get; set; }
            public string qCom { get; set; }
            public string vUnCom { get; set; }
            public string vProd { get; set; }

            public string error { get; set; }
        }

        public class TransportadorController
        {
            public string CNPJ { get; set; }
            public string xNome { get; set; }
            public string IE { get; set; }
            public string xEnder { get; set; }
            public string xMun { get; set; }
            public string UF { get; set; }
            public string qVol { get; set; }
            public string esp { get; set; }

            public string error { get; set; }
        }

        private async void GetAllEmit()
        {
            txtURIE = "https://localhost:44368/api/Emits";
            URI = txtURIE;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var EmitsJsonString = await response.Content.ReadAsStringAsync();
                        dgvDados.DataSource = JsonConvert.DeserializeObject<EmitsController[]>(EmitsJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
                    }
                }
            }
        }

        private async void GetAllDest()
        {
            txtURIE = "https://localhost:44368/api/Destinatario";
            URI = txtURIE;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var DestinatarioJsonString = await response.Content.ReadAsStringAsync();
                        dgvDados.DataSource = JsonConvert.DeserializeObject<DestinatarioController[]>(DestinatarioJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
                    }
                }
            }
        }

        private async void GetAllImp()
        {
            txtURIE = "https://localhost:44368/api/Imposto";
            URI = txtURIE;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ImpostoJsonString = await response.Content.ReadAsStringAsync();
                        dgvDados.DataSource = JsonConvert.DeserializeObject<ImpostoController[]>(ImpostoJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
                    }
                }
            }

        }

        private async void GetAllNFe()
        {
            txtURIE = "https://localhost:44368/api/NFe";
            URI = txtURIE;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var NFeJsonString = await response.Content.ReadAsStringAsync();
                        dgvDados.DataSource = JsonConvert.DeserializeObject<NFeController[]>(NFeJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
                    }
                }
            }
        }

        private async void GetAllProd()
        {
            txtURIE = "https://localhost:44368/api/Produtos";
            URI = txtURIE;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ProdutosJsonString = await response.Content.ReadAsStringAsync();
                        dgvDados.DataSource = JsonConvert.DeserializeObject<ProdutosController[]>(ProdutosJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
                    }
                }
            }
        }

        private async void GetAllTransp()
        {
            txtURIE = "https://localhost:44368/api/Transportador";
            URI = txtURIE;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var TransportadorJsonString = await response.Content.ReadAsStringAsync();
                        dgvDados.DataSource = JsonConvert.DeserializeObject<TransportadorController[]>(TransportadorJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
                    }
                }
            }
        }
        public Teste()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAllEmit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetAllDest();
        }

        private void Teste_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetAllImp();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetAllNFe();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetAllProd();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GetAllTransp();
        }

    }
}
