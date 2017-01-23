using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrewScheduling
{
    public class Tarefas
    {
        private int tempoInicial;
        private int tempoFinal;
        private int numTarefa;

        public int NumTarefa
        {
            get { return numTarefa; }
            set { numTarefa = value; }
        }

        public int TempoInicial
        {
            get { return tempoInicial; }
            set { tempoInicial = value; }
        }        

        public int TempoFinal
        {
            get { return tempoFinal; }
            set { tempoFinal = value; }
        }

        public Tarefas()
        {
        }

        public Tarefas(int tInicial, int tFinal)
        {
            this.tempoInicial = tInicial;
            this.tempoFinal = tFinal;
        }
        
    }

    public class Sched
    {
        private int numeroTarefas;
        private int tempoLimite;
        private List<Tarefas> tempoTarefas;

        public List<Tarefas> TempoTarefas
        {
            get { return tempoTarefas; }
            set { tempoTarefas = value; }
        }

        public int TempoLimite
        {
            get { return tempoLimite; }
            set { tempoLimite = value; }
        }

        public int NumeroTarefas
        {
            get { return numeroTarefas; }
            set { numeroTarefas = value; }
        }

        public Sched()
        {
            this.tempoTarefas = new List<Tarefas>();
        }
    }
}
