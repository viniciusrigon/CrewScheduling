using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CrewScheduling
{
    public class Arquivo
    {
        private String nome;
        private String caminho;
        private StreamReader arquivo;

        public String Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }

        public String Caminho
        {
            get
            {
                return caminho;
            }
            set
            {
                this.caminho = value;
            }
        }

        public StreamReader ArquivoLido
        {
            get
            {
                return arquivo;
            }
            set
            {
                this.arquivo = value;
            }
        }

        public void LeArquivo()
        {
            this.ArquivoLido = new StreamReader(string.Concat(Caminho, "\\", Nome));
        }
    }
}
