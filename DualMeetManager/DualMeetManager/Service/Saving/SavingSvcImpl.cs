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
    public class SavingSvcImpl : ISavingSvc
    {
        /// <summary>
        /// Implementation for saving a Meet object as a JSON object
        /// </summary>
        /// <param name="filePath">filename for the Meet</param>
        /// <param name="meetToSave">Meet object to save</param>
        /// <returns>boolean that tells the user whether or not the Meet was succcessfully saved or not</returns>
        public bool saveMeet(string filePath, Meet meetToSave)
        {
            bool didSave = true;
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
            catch(Exception e)
            {
                Console.WriteLine(e);
                //If there is an exception above, the file did not save properly.
                didSave = false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            
            return didSave;
        }

        /// <summary>
        /// Implementation for opening a saved Meet object JSON file
        /// </summary>
        /// <param name="fileName">filename for the Meet to be open</param>
        /// <returns>Opened Meet</returns>
        public Meet openMeet(string fileName)
        {
            Meet myMeet;
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(fileName))
                {
                    // Read the stream to a string, and write the string to the console.
                    string line = sr.ReadToEnd();
                    //Console.WriteLine(line);

                    myMeet = JsonConvert.DeserializeObject<Meet>(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
            Console.WriteLine("Leaving openMeet");
            //Console.WriteLine(myMeet.ToString());
            return myMeet;
        }
    }
}
