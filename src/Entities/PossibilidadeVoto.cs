using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEnquete.src.Entities
{
    public class PossibilidadeVoto
    {
        public PossibilidadeVoto(string opcao)
        {
            this.Opcao = opcao;
            this.votos = 0;
        }

        private string Opcao;
        private int votos;

        public string NomeOpcao()
        {
            return this.Opcao;
        }
        public int QuantidadeVotos()
        {
            return this.votos;
        }
        public int IncrementarVoto()
        {
            votos++;
            return votos;
        }
    }
}