using Org.BouncyCastle.Pqc.Crypto.Lms;
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
	public partial class atualizar : Form
	{
		DaoAutor dao;
		public atualizar()
		{
			InitializeComponent();
			dao = new DaoAutor();
		}

		private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{

		}//fim do textbox do código

		private void button1_Click(object sender, EventArgs e)
		{
			if (maskedTextBox1.Text == "")
			{
				MessageBox.Show("Preencha o campo do código!");
			}
			else 
			{
				int codigo = Convert.ToInt32(maskedTextBox1.Text);
				maskedTextBox2.Text = this.dao.ConsultarNome(codigo);
				maskedTextBox3.Text = this.dao.ConsultarGenero(codigo);
				maskedTextBox4.Text = this.dao.ConsultarEndereco(codigo);
			}	
		}//fim do botão buscar

		private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{

		}//fim do textbox do nome

		private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{

		}//fim do textbox do gênero

		private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{

		}//fim do textbox do endereço

		private void button2_Click(object sender, EventArgs e)
		{
			int codigo = Convert.ToInt32(maskedTextBox1.Text);

			//Atualizando os dados
			this.dao.atualizar(codigo, "nome", maskedTextBox2.Text);
			this.dao.atualizar(codigo, "genero", maskedTextBox3.Text);
			string atualizado = this.dao.atualizar(codigo, "endereco", maskedTextBox4.Text);
			MessageBox.Show(atualizado);

			//Limpar os campos
			maskedTextBox1.Text = "";
			maskedTextBox2.Text = "";
			maskedTextBox3.Text = "";
			maskedTextBox4.Text = "";
		}//fim do botão atualizar
	}//fim da classe atualizar
}// fim do projeto
