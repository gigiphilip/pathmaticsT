using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace pathamticsTest
{
    public class testPathmatics
    {
        private static string file_loc = ConfigurationSettings.AppSettings["test_file_location"];

        // method under test
        public void getDuplicates_By_Stripping_UnitTest()
        {
            string line; string local_name;            
            HashSet<string> names_hashlist = new HashSet<string>();

            // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader(file_loc))
            {
                while ((line = sr.ReadLine()) != null)
                {                    
                    Regex rgx = new Regex("[^a-zA-Z0-9]");
                    local_name = rgx.Replace(line, "");

                    local_name.ToLower().Replace(" llc", "").Replace(" inc", "");

                    if (!names_hashlist.Add(local_name))
                        Console.WriteLine(line);
                }
            }
             
        }

    }
}
