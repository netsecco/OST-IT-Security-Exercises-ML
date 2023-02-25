using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace utils
{
    public class DataStore
    {
        private string m_filename;

        public DataStore(string filename)
        {
            Data = new Dictionary<string, string>();
            m_filename = filename;
        }

        public Dictionary<string, string> Data { get; set; }

        public void save()
        {
            string json = JsonSerializer.Serialize(Data);
            File.WriteAllText(m_filename, json);
        }

        public void load()
        {
            if (File.Exists(m_filename))
            {
                string jsonFromFile = File.ReadAllText(m_filename);
                Data = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonFromFile);
            }

        }
    }
}
