using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ParseIt
{
    class Program
    {
        public static void Main(string[] args)
        {
            string testString1 = "1,2,3,5,8,131,21,34";

            List<string> test1 = ParseIt(testString1, 3, new List<string>());
            if (test1.Count != 7) 
                Console.WriteLine("Count was incorrect for test1, Sorry Try again");
            if (test1[4] != "131") 
                Console.WriteLine("Sorry Try again");

            List<string> test2 = ParseIt(testString1, 4, new List<string>());
            if (test2.Count != 6) 
                Console.WriteLine("Count for test2 was incorrect, something's wrong!");
            if (test2[3] != "131,") 
                Console.WriteLine("Returned array is wrong for test2");

            List<string> test3 = ParseIt(testString1, 5, new List<string>());
            if (test3.Count != 4) 
                Console.WriteLine("Count for test3 was incorrect, something's wrong!");
            if (test3[2] != "131,") 
                Console.WriteLine("Returned array is wrong for test2");

            Console.WriteLine("You Win!");
            Console.ReadLine();
        }

        /// <summary>
        /// write you test code here. 
        /// 
        /// You are to parse the string into pieces that are no more than "pieceLength" characters long
        /// INCLUDING the commas. 
        /// 
        /// If pieceLength = 3 the result for the above test string would be
        ///             3       4       5
        /// result[0] = "1,2"   1,2,   1,2,3
        /// result[1] = ",3,"   3,5,   ,5,8,
        /// result[2] = "5,8"   8,     131,
        /// result[3] = ","     131,   21,34
        /// result[4] = "131"   21,    
        /// result[5] = ",21"   34
        /// result[6] = ",34"   
        /// 
        /// You can look at the test above. This is a sample string and result, however
        /// your code will be run with multiple input strings and piece length parameters.
        /// Note how result[3] is just ",". Including any more characters would break apart 
        /// the next number, 131, and that's not allowed.
        ///  
        /// </summary>
        /// <param name="theString"></param>
        internal static List<string> ParseIt(string theString, int pieceLength, List<string> rtVal)
        {
            var firstChars = theString.Take(pieceLength + 1).ToArray();
            string newString;

            if (firstChars.Last() == ',' || firstChars[pieceLength - 1] == ',')
            {
                rtVal.Add(string.Join("", theString.Take(pieceLength)));
                newString = theString.Substring(string.Join("", theString.Take(pieceLength)).Length);
            }
            else
            {
                rtVal.Add(string.Join("", theString.Take(theString.IndexOf(",") + 1)));
                newString = theString.Substring(theString.IndexOf(",") + 1);
            }

            if (newString.Length <= pieceLength)
                rtVal.Add(newString);
            else
                ParseIt(newString, pieceLength, rtVal);

            return rtVal;
        }
    }
}
