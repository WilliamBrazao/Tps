using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseado_na_Aplicação_Realizada_em_Sala
{
    internal class Produto
    {
        public String Nome { get; private set; }
        public double Preco { get; private set; }
        public int Quantidade { get; private set; }
        public String Descricao { get; private set; }
        public Produto(String nome, double preco, int quantidade, String descricao)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
            Descricao = descricao;
        }
        public double calcularEstoque()
        {
            return this.Preco * this.Quantidade;
        }
        public void adicionarProduto(int quantidade)
        {
            this.Quantidade += quantidade;
        }
    }
}
