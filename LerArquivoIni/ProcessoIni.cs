using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LerArquivoIni
{
	public class ProcessoIni
	{
        private const string nomeArquivoIni = "ARQ";

        private string caminhoArquivo;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public ProcessoIni(string IniPath = null)
        {
            string Diretorio = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            caminhoArquivo = Path.Combine(Diretorio, nomeArquivoIni + ".ini");
            if (!File.Exists(caminhoArquivo))
            {
                Diretorio = Directory.GetParent(Diretorio).FullName;
                caminhoArquivo = Path.Combine(Diretorio, nomeArquivoIni + ".ini");
            }
        }

        public string LerValor(string Chave, string Sessao = null)
        {
            StringBuilder Retorno = new StringBuilder(255);
            GetPrivateProfileString(Sessao ?? nomeArquivoIni, Chave, "", Retorno, 255, caminhoArquivo);
            return Retorno.ToString();
        }

        public void EscreverValor(string Chave, string Valor, string Sessao = null)
        {
            WritePrivateProfileString(Sessao ?? nomeArquivoIni, Chave, Valor, caminhoArquivo);
        }

        public void ApagarChave(string Chave, string Sessao = null)
        {
            EscreverValor(Chave, null, Sessao ?? nomeArquivoIni);
        }

        public void ApagarSessao(string Sessao = null)
        {
            EscreverValor(null, null, Sessao ?? nomeArquivoIni);
        }

        public bool ExisteChave(string Chave, string Sessao = null)
        {
            return LerValor(Chave, Sessao).Length > 0;
        }
    }
}
