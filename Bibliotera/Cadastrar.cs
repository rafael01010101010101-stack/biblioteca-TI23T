using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotera
{
	public partial class Cadastrar : Form
	{

		DaoAutor autor;
		public Cadastrar()
		{
			InitializeComponent();
			//inserir
			this.autor = new DaoAutor();
		}

		
		private void button1_Click(object sender, EventArgs e)
		{
			if ((textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")) 
			{
				MessageBox.Show("Preencha todos os campos!");
			}
			else 
			{
				string nome = textBox1.Text;
				string genero = textBox2.Text;
				string endereco = textBox3.Text;
				//inserir esses dados no banco
				this.autor.Inserir(nome, genero, endereco);
				//limpar os campos
				LimparCampos();
			}//fim do método cadastrar
		}
				
		//limpar os campos
		private void LimparCampos()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
		}//fim do método limpar

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			
		}// fim do método do campo do nome

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			
		}// fim do método do campo do gênero

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			
		}// fim do método do campo do endereço

		

		private void label1_Click(object sender, EventArgs e)
		{

		}//CADASTRAR AUTOR NO TOPO
	}//fim da classe
}//fim do projeto
