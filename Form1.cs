using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baseado_na_Aplicação_Realizada_em_Sala
{
    public partial class Form1 : Form
    {   public bool renderizado = false;
        List<Produto> produtos = new List<Produto>();
        private DataGridView dgvProdutos;
        public Form1()
        {
            InitializeComponent();
        }

        public void renderizar()
        {

            Label lblQuantidade = new Label { Name = "lblQuantidade", Text = "Quantidade:", Location = new Point(199, 30), Width = 65 };            
            Label lblDescricao = new Label  { Name = "lblDescricao", Text = "Descrição:", Location = new Point(199, 60), Width = 60 };            
            TextBox txtQuantidade = new TextBox { Name = "txtQuantidade", Location = new Point(270, 27), Width = 100 };            
            TextBox txtDescricao = new TextBox { Name = "txtDescricao", Location = new Point(270, 57), Width = 100 };              
            Button btnCadastar = new Button { Name = "btnCadastrar", Text = "Cadastrar", Location = new Point(200, 87), Size = new Size(170, 23) };
            
            this.Controls.Add(lblQuantidade);
            this.Controls.Add(lblDescricao);
            this.Controls.Add(txtQuantidade);
            this.Controls.Add(txtDescricao);
            this.Controls.Add(btnCadastar);
           
            btnCadastar.Click += (s, e) => 
            {
                try
                {                  
                   
                    String nome = txtNome.Text; 
                    if (!double.TryParse(txtPreco.Text, out double preco)&& !int.TryParse(txtQuantidade.Text, out int quantidade))
                    {
                        throw new Exception("Valor inválido");
                    }
                    else
                    {
                        preco = double.Parse(txtPreco.Text);
                        quantidade = int.Parse(txtQuantidade.Text);
                       
                    }
                                     
                    String descricao = txtDescricao.Text;
                  
                    Produto produto = new Produto(nome, preco, quantidade, descricao);
                    produtos.Add(produto);
                   
                    atualizaGrid();
                    limpaCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar produto: " + ex.Message);
                }
                
                
            };
            
            this.renderizado = true;
        }

        public void limpaCampos()
        {
            TextBox txtNome = (TextBox)this.Controls["txtNome"];
            TextBox txtPreco = (TextBox)this.Controls["txtPreco"];
            TextBox txtQuantidade = (TextBox)this.Controls["txtQuantidade"];
            TextBox txtDescricao = (TextBox)this.Controls["txtDescricao"];
            txtNome.Text = "";
            txtPreco.Text = "";
            txtQuantidade.Text = "";
            txtDescricao.Text = "";
            txtNome.Focus();
        }
        public void carregaDataGrid()
        {
            if (dgvProdutos == null)
            {
                this.dgvProdutos = new DataGridView//cria o datagrid
                {
                    Name = "dgvProdutos",
                    Location = new Point(29, 131),
                    Size = new Size(416, 150),
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                };
                this.Controls.Add(dgvProdutos);//adiciona o datagrid ao form
            }                                 
                dgvProdutos.DataSource = null; // Limpa a fonte de dados
                dgvProdutos.DataSource = new BindingList<Produto>(produtos); // Usa BindingList para atualização dinâmica
                dgvProdutos.Refresh(); // Força a atualização da interface
            
        }
        public void atualizaGrid()
        {
            if (dgvProdutos == null)
            {
                carregaDataGrid();
            }
            else
            {
                
                dgvProdutos.DataSource = null;
                dgvProdutos.DataSource = new BindingList<Produto>(produtos);
                dgvProdutos.Refresh();
            }
        }

        private void btnCriar_Click_1(object sender, EventArgs e)
        {
            if (!this.renderizado)
            {
                renderizar();
            }
           
        }
    }
}
