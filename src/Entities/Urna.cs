using Microsoft.AspNetCore.Components.Web;
using System.Xml;
using System.Xml.Serialization;


namespace APIEnquete.src.Entities
{
    public class Urna
    {
        private Urna()
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
        public int TotalDeVotos { get; set; }
        public List<string> opcoesValidas()
        {

            var validos = new List<string>();
            foreach (var item in OpcoesEnquete)
            {
                validos.Add(item.NomeOpcao());
            }
            return validos;
        }

        public bool SerializarXml(Urna urna)
        {
            string caminhoArquivo = GarantirEndereco();

            if (urna.NomeEnquete == null || urna.NomeEnquete == "" || urna.OpcoesEnquete.Any(x=> x.Opcao ==""))
            {
                return false;
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Urna));
                using (XmlWriter writer = XmlWriter.Create(caminhoArquivo))
                {
                    serializer.Serialize(writer, urna);
                }
                return true;
            }
        }

        public static T DesserializarXml<T>(string NomeEnquete)
        {
            T retorno;

            string caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Enquetes", NomeEnquete);

            if (!File.Exists(caminhoArquivo))
                return (T)(object)null;

            XmlSerializer desserializar = new XmlSerializer(typeof(T));
            using (XmlReader leitor = XmlReader.Create(caminhoArquivo))
            {
                retorno = (T)desserializar.Deserialize(leitor);
            }
            return retorno;
        }

        public void AdicionarVoto(int id)
        {
            if (this.OpcoesEnquete.Any(x => x.ID == id))
            {
                this.OpcoesEnquete.FirstOrDefault(x => x.ID == id).IncrementarVoto();
                this.TotalDeVotos++;
            }
        }

        private string GarantirEndereco()
        {
            string caminhoArquivo;
            if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Enquetes")))
                return caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Enquetes", NomeEnquete);

            else
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Enquetes"));
                return caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Enquetes", NomeEnquete);
            }
        }

    }
}