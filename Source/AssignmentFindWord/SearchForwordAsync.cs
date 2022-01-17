using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sampleFindWord
{
    public class SearchForwordAsync

    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedPath">path to the choosen folder</param>
        /// <param name="word">word to search</param>
        /// 

        public async Task<int> SearchWord(string selectedPath, string word)

        {

            string[] filepaths = Directory.GetFiles(selectedPath, "*.txt",
                                        SearchOption.AllDirectories);
          int count = 0;
            try
            {  
                foreach (string filepath in filepaths)
                {
                    foreach (string Line in File.ReadLines(filepath))
                    {
                        count += Regex.Matches(Line, word, RegexOptions.IgnoreCase).Count;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }
    }
}







