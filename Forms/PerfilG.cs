﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tingle.Forms
{
    public partial class PerfilG : UserControl
    {
        private int codigo;
        private DataTable dt = new DataTable();
        MySqlDataAdapter adapter;
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user id=root; password =;database=historico; Convert Zero Datetime=True");
        MySqlDataReader dr;
        DataSet ds = new DataSet();
        private int _linhaIndice;

        public PerfilG(int codigo)
        {
            InitializeComponent();
            this.codigo = codigo;

        }

        private void Excluir()
        {
            connection.Open();

            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Não existem dados a excluir.");
                return;
            }
            //verifica se foi selecionado um registro
            if (string.IsNullOrEmpty(txtCPF.Text) || string.IsNullOrEmpty(txtNome.Text) ||
string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtCargo.Text))
            {
                MessageBox.Show("Selecione um registro para exclusão.");
                return;
            }

            //Se rowindex é menor que um retorna pq seleção foi inválida
            if (_linhaIndice < 0)
                return;

            if (!(MessageBox.Show("Você deseja excluir esse funcionário?", "Atualizar registro !",
MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                return;

            string sql = "DELETE FROM funcionario WHERE cod_fun=@Codigo";
            var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@Codigo", this.txtCodigo.Text);


            try
            {
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connection.Close();
                MessageBox.Show("Funcionário excluido!");
                LoadDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro :: " + ex.Message);
            }
        }

        private void Alterar()
        {
            connection.Open();

            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Não existem dados a alterar.");
                return;
            }
            //verifica se foi selecionado um registro
            if (string.IsNullOrEmpty(txtCPF.Text) || string.IsNullOrEmpty(txtNome.Text) ||
string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtCargo.Text))
            {
                MessageBox.Show("Selecione um registro para exclusão.");
                return;
            }

            //Se rowindex é menor que um retorna pois seleção foi inválida
            if (_linhaIndice < 0)
                return;

            if (!(MessageBox.Show("Confirma a atualização deste registro?", "Atualizar registro !",
MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                return;
           
            string sql = "Update funcionario set nome=@Nome, email=@Email, cargo=@Cargo, CPF=@CPF where cod_fun =@Codigo";
            var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@Nome", this.txtNome.Text);
            cmd.Parameters.AddWithValue("@Email", this.txtEmail.Text);
            cmd.Parameters.AddWithValue("@Cargo", this.txtCargo.Text);
            cmd.Parameters.AddWithValue("@CPF", this.txtCPF.Text);
            cmd.Parameters.AddWithValue("@Codigo", this.txtCodigo.Text);


            try
            {
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connection.Close();
                MessageBox.Show("Dados do funcionário alterado!");
                LoadDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro :: " + ex.Message);
            }
        }

        private void Consulta()
        {
            //Connection con = new Connection();
            // con.Open();

            adapter = new MySqlDataAdapter("SELECT * FROM funcionario WHERE cod_fun = '" + codigo + "'", connection);
            adapter.Fill(dt);

            lblNomeG.Text = dt.Rows[0][1].ToString();
            lblCargoG.Text = dt.Rows[0][2].ToString();
            lblCPFG.Text = dt.Rows[0][2].ToString();
            lblEmailG.Text = dt.Rows[0][3].ToString();

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

        private void LoadDGV()
        {
            try
            {
                connection.Open();
                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM funcionario ", connection);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (connection.State == ConnectionState.Open){
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM funcionario", connection);
                da.Fill(ds, "funcionario");
                //da.Fill(ds);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "funcionario";
                connection.Close();
            }
        }

        private void PerfilG_Load(object sender, EventArgs e)
        {
            Consulta();
            LoadDGV();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Alterar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _linhaIndice = e.RowIndex;

            //Se _linhaIndice é menor que -1 então retorna
            if (_linhaIndice == -1)
            {
                return;
            }

            //Cria um objeto DataGridViewRow de um indice particular
            DataGridViewRow rowData = dataGridView1.Rows[_linhaIndice];

            //exibe os valores no textbox
            txtCodigo.Text = rowData.Cells[0].Value.ToString();
            txtNome.Text = rowData.Cells[1].Value.ToString();
            txtCargo.Text = rowData.Cells[2].Value.ToString();
            txtCPF.Text = rowData.Cells[4].Value.ToString();
            txtEmail.Text = rowData.Cells[3].Value.ToString();
            
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
