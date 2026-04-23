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
	
	public partial class excluir : Form
	{
		DaoAutor dao;
		public excluir()
		{
			InitializeComponent();
			this.dao = new DaoAutor();
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
				int codigo = Convert.ToInt32(maskedTextBox1.Text);//pegar o código digitado
				string excluido = this.dao.deletar(codigo);// deletar o dado do banco de dados
				MessageBox.Show(excluido);// mostrar a mensagem de exclusão
				maskedTextBox1.Text = "";// limpar o campo do código
			}
			
		}//fim do botão excluir
	}
}
