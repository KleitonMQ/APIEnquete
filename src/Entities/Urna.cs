using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace APIEnquete.src.Entities
{
    public class Urna
    {
        public Urna(string nomeEnquete, string[] opcoesEnquete)
        {
            this.NomeEnquete = nomeEnquete;
            this.OpcoesEnquete = new List<PossibilidadeVoto>();
            for (int i = 0; i < opcoesEnquete.Length; i++)
            {
                var opcao = new PossibilidadeVoto(opcoesEnquete[i]);
                this.OpcoesEnquete.Add(opcao);
            }
        }
        private string NomeEnquete;
        private List<PossibilidadeVoto> OpcoesEnquete;

        public List<string> opcoesValidas()
        {
            var validos = new List<string>();
            foreach (var item in OpcoesEnquete)
            {
                validos.Add(item.NomeOpcao());
            }
            return validos;
        }

        public void SerializarXml(Urna urna)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Urna));
            using (XmlWriter writer = XmlWriter.Create(@"C:\urna.xml"))
            {
                serializer.Serialize(writer, urna);
            }
        }

    }
}