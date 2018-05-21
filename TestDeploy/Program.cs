using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace TestDeploy
{
    class Program
    {
        static void Replace(string sourceFile, string destFile, string dataFile)
        {
            string content = File.ReadAllText(sourceFile);
            var c = ConfigReplacement.LoadFromFile(dataFile);
            foreach (var replacement in c.Replacements)
                content = content.Replace(replacement.Key, replacement.Value);
            File.WriteAllText(destFile, content);
        }

        static void Test()
        {
         //   var c = new ConfigReplacement();
         //   c.SaveToFile("data.xml");

            var d = ConfigReplacement.LoadFromFile("data.xml");
            Console.WriteLine(d);
        }

        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Hello world");
                    string configvalue1 = ConfigurationManager.AppSettings["countoffiles"];
                    string configvalue2 = ConfigurationManager.AppSettings["logfilelocation"];
                    string configvalue3 = ConfigurationManager.AppSettings["connectionString"];
                    Console.WriteLine($"{configvalue1} {configvalue2} {configvalue3}");
                }
                else if (args.Length==3)
                {
                    var configFile = args[0];
                    var destFile = args[1];
                    var dataFile = args[2];
                    Replace(configFile, destFile, dataFile);
                }
                else
                    Console.WriteLine("Nothing to do");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
