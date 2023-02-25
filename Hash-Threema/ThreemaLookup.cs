using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utils;

namespace Hash_Threema
{
    public static class ThreemaLookup
    {
        private static utils.DataStore s_DataStore = new DataStore(@"../../../threemaDB");

        public static void init()
        {
            s_DataStore.load();
        }

        public static void registerId(string id, string hash)
        {
            s_DataStore.Data[hash] = id; 
            s_DataStore.save();
        }

        public static string lookup(string hash) 
        {
            string l_id;

            if (s_DataStore.Data.TryGetValue(hash, out l_id))
            {
                return l_id;
            }
            {
                return "not found";  // username not found
            }
        }


    }
}
