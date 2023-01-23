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
        public Urna()
        {

        }
        public Urna(string nomeEnquete, string[] opcoesEnquete)
        {
            this.NomeEnquete = nomeEnquete;
            this.OpcoesEnquete = new List<PossibilidadeVoto>();
            for (int i = 0; i < opcoesEnquete.Length; i++)
            {
                var opcao = new PossibilidadeVoto(opcoesEnquete[i], i);
                this.OpcoesEnquete.Add(opcao);
            }
        }
        public string NomeEnquete { get; set; }
        public List<PossibilidadeVoto> OpcoesEnquete { get; set; }

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
            string caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Enquetes", NomeEnquete);
            XmlSerializer serializer = new XmlSerializer(typeof(Urna));
            using (XmlWriter writer = XmlWriter.Create(caminhoArquivo))
            {
                serializer.Serialize(writer, urna);
            }
        }

        public static T DesserializarXml<T>(string NomeEnquete)
        {
            T retorno;

            string caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Enquetes", NomeEnquete);

            if (!File.Exists(caminhoArquivo))
                retorno = (T)(object)"Enquete não encontrada";

            XmlSerializer desserializar = new XmlSerializer(typeof(T));
            using (XmlReader leitor = XmlReader.Create(caminhoArquivo))
            {
                retorno = (T)desserializar.Deserialize(leitor);
            }
            return retorno;
        }

        public void AdicionarVoto(int id)
        {
            foreach (var item in this.OpcoesEnquete)
            {
                if (item.ID == id)
                {
                    item.IncrementarVoto();
                }
            }
        }
    }
}