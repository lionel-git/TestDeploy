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
        static Dictionary<string, string> replacements = new Dictionary<string, string>();
        static char[] separators = new char[] { ' ', '\t' };
        static void Replace(string sourceFile, string destFile, string dataFile)
        {
            Console.WriteLine($"Copy {sourceFile} {destFile} {dataFile}");
            string content = File.ReadAllText(sourceFile);
            foreach (string line0 in File.ReadLines(dataFile))
            {
                var line = line0.TrimStart(separators);
                var index=line.IndexOfAny(separators);
                var key = line.Substring(0, index);
                var value = line.Substring(index+1);
                Console.WriteLine($"key='{key}' '{value}'");
                content = content.Replace(key, value);
            }
            File.WriteAllText(destFile, content);
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
