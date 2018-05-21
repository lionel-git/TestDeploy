using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestDeploy
{
    public class ConfigReplacement
    {
        public List<Replacement> Replacements;

        public ConfigReplacement()
        {
            Replacements = new List<Replacement>();
        }

        public void SaveToFile(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ConfigReplacement));
            using (StreamWriter wr = new StreamWriter(fileName))
                xs.Serialize(wr, this);
        }

        public static ConfigReplacement LoadFromFile(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ConfigReplacement));
            using (StreamReader rd = new StreamReader(fileName))
                return xs.Deserialize(rd) as ConfigReplacement;
        }
    }
}
