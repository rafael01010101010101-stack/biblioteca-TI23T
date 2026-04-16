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
	public partial class Consultar : Form
	{
		DaoAutor dao;
		public Consultar()
		{
			ChamarMetodo(dataGridView1);
			this.dao = new DaoAutor();
		}

		//chamar método
		public void ChamarMetodo(DataGridView dataGrid) 
		{
			InitializeComponent();// inicializar os componentes da tela
			ConfigurarDataGrid(dataGrid);//configurar a estrutura da tabela
			NomeColunas(dataGrid);// definir o nome das colunas
			AdicionarDados(dataGrid);// adicionar os dados do banco de dados na tabela
		}

		//nome colunas
		public void NomeColunas(DataGridView dataGrid) 
		{
			dataGrid.Columns[0].Name = "Código";
			dataGrid.Columns[1].Name = "Nome";
			dataGrid.Columns[2].Name = "Gênero";
			dataGrid.Columns[3].Name = "Endereço";
		}//fim do método nome colunas

		//definir a estrutura da tabela
		public void ConfigurarDataGrid(DataGridView dataGrid) 
		{
			dataGrid.AllowUserToAddRows = false;//nao permite o usuario adicionar linhas
			dataGrid.AllowUserToDeleteRows = false;
			dataGrid.AllowUserToResizeColumns = false;
			dataGrid.AllowUserToResizeRows = false;
			dataGrid.ColumnCount = 4;
		}

		public void AdicionarDados(DataGridView dataGrid) 
		{
			//Preencher o vetor
			this.dao.PreencherVetor();
			for(int i = 0; i < this.dao.contar; i++) 
			{
				dataGrid.Rows.Add(this.dao.codigo[i], this.dao.nome[i], this.dao.genero[i], this.dao.endereco[i]);
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}//FIM DO dataGrid

		private void label1_Click(object sender, EventArgs e)
		{

		}// CONSULTAR AUTOR NO TOPO
	}
}
