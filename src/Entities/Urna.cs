using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEnquete.src.Entities
{
    public class Urna
    {
        public Urna(string[] opcoesEnquete)
        {
            this.OpcoesEnquete = new List<string>();
            for (int i = 0; i < opcoesEnquete.Length; i++)
            {
                this.OpcoesEnquete.Add(opcoesEnquete[i]);
            }
        }
        private List<string> OpcoesEnquete;

        public List<string> opcoesValidas()
        {
            return this.OpcoesEnquete;
        }

    }
}