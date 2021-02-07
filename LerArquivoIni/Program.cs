using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerArquivoIni
{
	public class Program
	{
		static void Main(string[] args)
		{
			ProcessoIni processoIni = new ProcessoIni();

			string usuario = processoIni.LerValor("Usuario", "LOGIN");
			string senha = processoIni.LerValor("Senha", "LOGIN");

			//bool teste1 = processoIni.ExisteChave("Caminho", "LOGIN");
			//bool teste2 = processoIni.ExisteChave("Senha", "LOGIN");

			//processoIni.EscreverValor("Numero", "15", "LOGOUT");

			//processoIni.ApagarChave("Numero", "LOGOUT");
			//processoIni.ApagarSessao("LOGOUT");

		}
	}
}
