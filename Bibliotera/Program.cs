using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//importando a biblioteca para usar o menu

namespace Bibliotera
{
    internal class Program
    {
        [STAThread]//definir ponto de entrada do aplicativo
		static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());//chamando o menu
		}//fim do metodo main
    }//fim da classe
}//fim do projeto
