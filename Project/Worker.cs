using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    class Worker
    {
        public string site { get; private set; }

        public Worker(string sites)
        {
            site = sites;
        }

        public void Work()
        {
            try
            {
                Console.WriteLine("\nВсе слова с ссылки " + site);
                Console.WriteLine("=====================================");
                string text = ReadTextFromSite(site);
                var result = Calc(text);
                result.Remove("");
                foreach (var pair in result)
                    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                Console.WriteLine("=====================================");
            }
            catch { Console.WriteLine("Неверно введен путь страницы ("); }
        }
        static Dictionary<string, int> Calc(string site)
        {
            var res = new Dictionary<string, int>();
            try
            {

                foreach (var word in site.Split(' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t', '#', '&', '@').Skip(1))
                {
                    var count = 0;
                    res.TryGetValue(word, out count);
                    res[word] = count + 1;
                }
            }
            catch (Exception e) { Console.WriteLine("Неверно введен путь страницы (" + e.ToString()); }
            return res;
        }
        public string ReadTextFromSite(string site)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            try
            {
                HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(site);
                return document.DocumentNode.InnerText;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.ToString());
                return null;
            }
        }
    }
}
