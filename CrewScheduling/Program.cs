using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using QuickGraph;

namespace CrewScheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Sched alocacao = new Sched();
            Heuristica heuristica = new Heuristica();
                        
            if (!String.IsNullOrEmpty(args[0]))
            {
                Arquivo arquivo = new Arquivo();
                arquivo.Caminho = System.Environment.CurrentDirectory;
                arquivo.Nome = args[0];
                arquivo.LeArquivo();
                
                try
                {
                    int contLinha = 1;
                    while (!arquivo.ArquivoLido.EndOfStream)
                    {
                        string linha = arquivo.ArquivoLido.ReadLine();
                        if (contLinha == 1)
                        {
                            string[] linha1 = linha.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            alocacao.NumeroTarefas = Convert.ToInt32(linha1[0]);
                            alocacao.TempoLimite = Convert.ToInt32(linha1[1]);
                        }
                        else if (contLinha <= alocacao.NumeroTarefas + 1)
                        {
                            string[] tempoTarefas = linha.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            int tInicial = Convert.ToInt32(tempoTarefas[0]);
                            int tFinal = Convert.ToInt32(tempoTarefas[1]);
                        
                            alocacao.TempoTarefas.Add(new Tarefas(tInicial, tFinal));

                        }
                        else
                        {
                            string[] verticesGrafo = linha.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            int nodoA = Convert.ToInt32(verticesGrafo[0]);
                            int nodoB = Convert.ToInt32(verticesGrafo[1]);
                            int custoTransicao = Convert.ToInt32(verticesGrafo[2]);

                            heuristica.Grafo.AddVerticesAndEdge(new TaggedEdge<int, int>(nodoA, nodoB, custoTransicao));
                            
                        }

                        contLinha++;
                    }
                }
                finally
                {
                    arquivo.ArquivoLido.Close();                   

                    Console.WriteLine("\nNúmero tarefas: {0}", alocacao.NumeroTarefas);
                    Console.WriteLine("Tempo Limite: {0}", alocacao.TempoLimite);
                    int t = 1;
                    foreach (Tarefas tempo in alocacao.TempoTarefas)
                    {
                        Console.WriteLine("Tempo inicial da tarefa {0}: {1} - Tempo Final {2} ", t, tempo.TempoInicial, tempo.TempoFinal);
                        t++;
                    }                    
                }
            }

            if (!String.IsNullOrEmpty(args[1]))
            {
                heuristica.MaxIteracoes = Convert.ToInt32(args[1]);
                heuristica.Alocacao = alocacao;
                heuristica.VNS();


                Console.WriteLine("\nSolução ótima encontrada {0}", heuristica.SolucaoOtima);
                
            }
        }
    }
}
