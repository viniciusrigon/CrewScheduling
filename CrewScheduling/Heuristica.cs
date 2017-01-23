using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGraph;

namespace CrewScheduling
{    
    public class Heuristica
    {
        private Int32 maxIteracoes;
        private AdjacencyGraph<int, TaggedEdge<int, int>> grafo;
        private List<AdjacencyGraph<int, TaggedEdge<int, int>>> vizinhanca;
        private Sched alocacao;


        public Sched Alocacao
        {
            get { return alocacao; }
            set { alocacao = value; }
        }


        public List<AdjacencyGraph<int, TaggedEdge<int, int>>> Vizinhanca
        {
            get { return vizinhanca; }
            set { vizinhanca = value; }
        }
        private Int32 solucaoOtima;

        public Int32 SolucaoOtima
        {
            get { return solucaoOtima; }
            set { solucaoOtima = value; }
        }

        //private Int32[] solucaoInicial;
        //private Int32[] solucao;

        //public Int32[] SolucaoInicial
        //{
        //    get { return solucaoInicial; }
        //    set { solucaoInicial = value; }
        //}

        public AdjacencyGraph<int, TaggedEdge<int, int>> Grafo
        {
            get { return grafo; }
            set { grafo = value; }
        }

        public Int32 MaxIteracoes
        {
            get { return maxIteracoes; }
            set { maxIteracoes = value; }
        }

        public Heuristica()
        {
            this.grafo = new AdjacencyGraph<int, TaggedEdge<int, int>>();
            this.alocacao = new Sched();
        }

        //private List<Tarefas> GeraSolucaoInicial()
        //{
        //    List<Tarefas> retorno = new List<Tarefas>();


        //    return retorno;
        //}

        private int GeraSolucaoInicial()
        {
            Random rand = new Random(Grafo.Edges.Count<QuickGraph.TaggedEdge<int,int>>());
            int solucaoGerada = 0;

            while (solucaoGerada <= Alocacao.TempoLimite)
            {
                solucaoGerada += rand.Next();
            }            

            return solucaoGerada;
        }

        private int AvaliaSolucao(IEnumerable<TaggedEdge<int, int>> lstArcos)
        {
            int resultado = 0;

            foreach (TaggedEdge<int, int> arco in lstArcos)
            {   
                resultado += arco.Tag;
            }

            return resultado;
        }
        
        private int BuscaLocal(int vizinhanca)
        {
            // busca local - first improvement
            // solução recebe solução inicial(parametro)
            int solucao = vizinhanca;
            foreach (AdjacencyGraph<int, TaggedEdge<int, int>> vizinho in Vizinhanca)
            {
                int solucaoParcial = AvaliaSolucao(vizinho.Edges);
                if (solucaoParcial < solucao)
                {
                    solucao = solucaoParcial;
                }
            }

            return solucao;
        }

        private int SolucaoVizinhanca()
        {
            int solucaoEncontrada = 0;

            return solucaoEncontrada;
        }

        private void GerarVizinhanca()
        {
            AdjacencyGraph<int, TaggedEdge<int, int>> vizinho = new AdjacencyGraph<int, TaggedEdge<int, int>>();

            foreach (Tarefas tarefa in Alocacao.TempoTarefas)
            {
                

            }
        }

        public void VNS()
        {
            TimeSpan tempo;
            
            int Interacoes = 1;
            int solucaoAtual;

            // x = So
            //solucaoAtual = this.GeraSolucaoInicial();
            solucaoAtual = 20000;

            // enquanto (criterio de parada não satisfeito) faça
            while (this.MaxIteracoes >= Interacoes)
            {
                // k = 1 // tipo da estrutura vizinhança
                // enquanto (k < r) // vizinhança k é menor que a vizinhança max
                while (true)
                {
                    // escolher y pertencente a vizinhança randomicamente
                    int solucaoVizinhanca = this.SolucaoVizinhanca();
                    int resulBuscaLocal = this.BuscaLocal(solucaoVizinhanca);
                    
                    // se f(y) < f(x) entao
                    if (resulBuscaLocal < solucaoAtual)
                    {
                        // x = y
                        solucaoAtual = resulBuscaLocal;

                        // k = 1
                        
                    }
                    else
                    {
                        // k = k + 1 vai para a proxima vizinhança
                    }
                }

                Interacoes++;
            }

            this.solucaoOtima = solucaoAtual; 
        }
    }
}
