using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DualMeetManager.Domain;
using System.IO;
//using System.Xml.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DualMeetManager.Service.Saving
{
    public class SavingImpl : ISaving
    {
        public bool saveMeet(string filePath, Meet meetToSave)
        {
            TextWriter writer = null;
            try
            {
                //Serialize object with json.net
                string jsonData = JsonConvert.SerializeObject(meetToSave, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                });

                writer = new StreamWriter(filePath, false);
                writer.Write(jsonData);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            
            return true;
        }
    }
}
