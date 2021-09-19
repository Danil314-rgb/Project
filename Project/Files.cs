using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Project
{
    public class Files
    {
        public string site { get; private set; }

        public Files(string sites)
        {
            site = sites;
        }

        public void SavePages()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string directory = Directory.GetCurrentDirectory();
                    string html = client.DownloadString(site.ToString());
                    File.WriteAllText(directory + @"\" + ".html", html);                    
                    Console.WriteLine("Файл сохранён в папку!");
                }
            }
            catch
            {
                Console.WriteLine("Ошибка! Указаная ссылка является ошибочной!  \t\nЗавершение работы программы!");
                Environment.Exit(404);
            }
        }
    }
}
