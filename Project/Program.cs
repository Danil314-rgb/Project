using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tПрограмма для считывания слов с сайта! ");
            Start();
        }

        public static void Start()
        {
            Link link = new Link();
            Files htmlFiles;
            Worker worker;
            var urldata = link.ReadLink();
            htmlFiles = new Files(urldata);
            htmlFiles.SavePages();
            worker = new Worker(urldata);
            worker.Work();
        }
    }
}
