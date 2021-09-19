using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Project
{
    public class Link
    {
        public string ReadLink()
        {
            Console.Write("\nВведите или вставьте ссылку: ");
            string link = Console.ReadLine(); 
            string path = link;

            return path;
        }
    }
}
