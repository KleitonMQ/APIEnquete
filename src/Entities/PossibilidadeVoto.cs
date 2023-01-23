using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEnquete.src.Entities
{
    public class PossibilidadeVoto
    {
        public PossibilidadeVoto()
        {

        }
        public PossibilidadeVoto(string opcao, int id)
        {
            this.ID = id;
            this.Opcao = opcao;
            this.votos = 0;
        }
        public int ID {get; set;}
        public string Opcao {get; set;}
        public int votos {get; set;}

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