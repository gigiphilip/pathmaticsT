using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;

namespace pathmatics
{
    public class Program
    {
        private static string file_loc = ConfigurationSettings.AppSettings["file_location"];
        

        public static void Main(string[] args)
        {
  
            try
            {
                print_line("Duplicates");

                getDuplicates_By_Stripping();

                // Suspend the screen.
                Console.ReadLine();
                }
           
            catch (Exception e)
            {
                print_line("Error:");
                print_line(e.Message);
            }

        }

        private static void print_line(string title = "") 
        {
            Console.WriteLine(string.Format("============================{0}==================================",title));
        }

        private static void getDuplicates_By_Stripping()
        {
            string line; string local_name;
            int dupe_count = 0;

            //Instantiate a hashset for tracking unique names.
            HashSet<string> names_hashlist = new HashSet<string>();

            // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader(file_loc))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    //Strip everything except AlphaNumeric
                    Regex rgx = new Regex("[^a-zA-Z0-9]");
                    local_name = rgx.Replace(line, "");

                    //optional - remove generic parts in Names. Could be driven from Config file.
                    local_name.ToLower().Replace(" llc", "").Replace(" inc", "");

                    //Add item to hashlist, if it cannot be added, it's a probable duplicate.
                    if (!names_hashlist.Add(local_name))
                    {
                        Console.WriteLine(line);
                        dupe_count++;
                    }
                }
            }

            print_line("Stats.");
            Console.WriteLine(String.Format("Total: {0}, Unique: {1}, Duplicate: {2}", names_hashlist.Count + dupe_count, names_hashlist.Count, dupe_count));
        }
    }
}
