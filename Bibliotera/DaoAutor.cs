using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//importando a estrutura de tela

namespace Bibliotera
{
    class DaoAutor
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] nome;
        public string[] genero;
        public string[] endereco;
        public int i;
        public int contar;
        public string msg;
        public DaoAutor() 
        { //conexão com banco de dados
            conexao = new MySqlConnection("server=localhost;DataBase=registro;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                conexao.Open();//abrir a conexão
                MessageBox.Show("Conectado com sucesso!");
            }
            catch (Exception erro) 
            {
				MessageBox.Show($"Algo deu errado!\n\n {erro}");
                conexao.Close();//fecha conexão com o banco de dados
            }//fim do try_catch
        }//fim do construtor

        //Inserir dado no banco
        public void Inserir(string nome, string genero, string endereco) 
        {
            try
            {
                this.dados = $"('', '{nome}', '{genero}', '{endereco}')";
                this.comando = $"Insert into autor(codigo, nome, genero, endereco) values{this.dados}";
                //Inserir comando
                MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);
                string resultado = "" + sql.ExecuteNonQuery();
				MessageBox.Show($"Inserido com Sucesso! \n\n{resultado}");
            }
            catch (Exception erro) 
            {
                MessageBox.Show($"Algo deu errado\n\n {erro}");
            }
        }//fim do inserir
        public void PreencherVetor() 
        {
            string query = "select * from autor"; //mostrando os dados da tabela autor

            //instalando os vetor
            this.codigo = new int[100];
            this.nome = new string[100];
            this.genero = new string[100];
            this.endereco = new string[100];

            //Preencher os vetores com valores padrões
            for(i = 0; i < 100; i++) 
            {
                this.codigo[i] = 0;
                this.nome[i] = "";
                this.genero[i] = "";
                this.endereco[i] = "";
            }//fim do for

            //executar comando do SQL
            MySqlCommand coletar = new MySqlCommand(query, this.conexao);

            //leitura do dado no banco
            MySqlDataReader leitura = coletar.ExecuteReader();//percorre o banco e traz os dados

            //Zerar o contador

            i = 0;
            this.contar = 0;
            while (leitura.Read()) 
            {
                this.codigo[i] = Convert.ToInt32(leitura["codigo"]);
                this.nome[i] = leitura["nome"] + "";
                this.genero[i] = leitura["genero"] + "";
                this.endereco[i] = leitura["endereco"] + "";
                i++;
                this.contar++;//informa quantos dados tem no banco
            }//fim do while

            leitura.Close();
        }//fim do método PreencherVetor

        public string ConsultarTudo() 
        {
            PreencherVetor();//preencher todos oos dados do vetor
            this.msg = "";

            for (int i = 0; i < this.contar; i++) 
            {
                this.msg += $"\n Código: {this.codigo[i]} \nNome: {this.nome[i]} \nGênero: {this.genero[i]} \nEndereço: {this.endereco[i]}\n\n";
            }//fim do for
            return this.msg;
        }//fim do método consultarTudo

        public string ConsultarPorCodigo(int codigo)
        {
            PreencherVetor();//preencher todos oos dados do vetor
            this.msg = "";

            for (int i = 0; i < this.contar; i++)
            {
                if (this.codigo[i] == codigo) 
                {
                    this.msg = $"\n Código: {this.codigo[i]} \nNome: {this.nome[i]} \nGênero: {this.genero[i]} \nEndereço: {this.endereco[i]}\n\n";
                    return this.msg;
                }//fim do if
            }//fim do for
            return "Código informado não existe";
        }//fim do método consultarPorCodigo

        public string atualizar(int codigo, string campo, string novoDado) 
        {
            try
            {
                string query = $"update autor set {campo} = '{novoDado}' where codigo = '{codigo}'";
                //executar o comando

                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                string resultado = "" + sql.ExecuteNonQuery();//comando da inserção no banco
                return $"Atualizado com sucesso!\n\n{resultado}";
            }
            catch (Exception erro) 
            {
                return $"Algo deu errado\n\n{erro}";
            }
        }

        public string deletar(int codigo)
        {
            try
            {
                string query = $"delete from autor where codigo = '{codigo}'";
                //executar o comando

                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                string resultado = "" + sql.ExecuteNonQuery();//comando da inserção no banco
                return $"Deletado com sucesso!\n\n{resultado}";
            }
            catch (Exception erro)
            {
                return $"Algo deu errado\n\n{erro}";
            }
        }
    }//fim da classe
}//fim do projeto
