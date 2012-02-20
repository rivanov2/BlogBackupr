using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoadTools.WebZapper;
using System.Net;
using System.IO;
using System.Diagnostics;
using HtmlAgilityPack;
using System.Xml;
using System.Configuration;

namespace BlogScraper
{
	class Program
	{
		static void Main(string[] args)
		{
            List<string> postUrls = GetAllPostUrls();

            WebClient wc = new WebClient();
            int p, fn = 0;
            wc.Proxy = null;
            HtmlDocument content = new HtmlDocument();


            
            foreach (string url in postUrls)
            {
                p = 0;
               string html = wc.DownloadString(url);
               HtmlDocument doc = new HtmlDocument();
               doc.LoadHtml(html);
               // Main content
                doc.DocumentNode.SelectNodes("//div[@class='full-post']");
               doc.Save(Environment.CurrentDirectory + "\\backup\\" + fn++.ToString() + ".html");
                // Comments
               doc.DocumentNode.SelectNodes("//id[@id='commentList]");
            }


            // XSLT for all the links, including archive links
            // Comments from each link
//            string xpathToComment = @"/html/body/form[@id='aspnetForm']/div[@id='ctl00_content_ctl00_page' and @class='content-fragment-page postlist']/div[@class='layout']/div[@id='ctl00_content_ctl00_layout' and @class='layout-content content-left-sidebar-right']/div[@id='ctl00_content_ctl00_content' and @class='layout-region content']/div[@class='layout-region-inner content']/div[@id='fragment-42826' and @class='content-fragment blog-post-list no-wrapper with-header']/div[@class='content-fragment-inner msdn-content-fragment-inner']/div[3][@class='content-fragment-content']/div[@id='ctl00_content_ctl00_w_42826__aa9e85_ctl00_ctl00_ctl00_PostListWrapper']/ul[@class='content-list standard']/li[1][@class='content-item']/div[2][@class='abbreviated-post']/div[5][@class='post-summary']
////div[@id='ctl00_content_ctl00_w_42826__aa9e85_ctl00_ctl00_ctl00_PostListWrapper']/ul[@class='content-list standard']/li[1][@class='content-item']/div[2][@class='abbreviated-post']/div[5][@class='post-summary']";

//            string url = "http://blogs.msdn.com/b/noahc/";
//            HtmlDocument doc = new HtmlDocument();

//            doc.LoadHtml(new WebClient().DownloadString(url));
//            doc.OptionOutputAsXml = true;
//            doc.Save("noahc.xml");


//            HtmlNode root = doc.DocumentNode;
//            string nodes = ConfigurationManager.AppSettings["selectNodes"];
//            foreach (HtmlNode n in doc.DocumentNode.SelectNodes(nodes))
//            {
//                System.Console.WriteLine(n.Attributes.AttributesWithName("href"));
//            }

//            HtmlNode root2 = doc.DocumentNode;

				
		}

        private static List<string> GetAllPostUrls()
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            string url = "http://blogs.msdn.com/b/noahc/";
            string html = wc.DownloadString(url);
            string htmlfile = "page.html.txt";
            File.WriteAllText(htmlfile, html);
            //Process.Start(htmlfile);

            List<string> archives = new List<string>();
            List<string> posturls = new List<string>();
            Stack<string> siteStack = new Stack<string>();

            int p = 0;
            string postUrl, archiveUrl;
            string logfile = "log.txt";

            siteStack.Push(url);
            // Archive posts
            while ((archiveUrl
                = WebZap.getHTML(html, ref p, "\"internal-link view-post-archive-list\"", "href=\"", "\">")) != String.Empty)
            {
                archiveUrl = "http://blogs.msdn.com" + archiveUrl;
                archives.Add(archiveUrl);
            }

            foreach (string s in archives)
            {
                p = 0;
                html = wc.DownloadString(s);
                while ((postUrl
                = WebZap.getHTML(html, ref p, "\"internal-link view-post\"", "href=\"", "\">")) != String.Empty)
                {
                    posturls.Add("http://blogs.msdn.com" + postUrl);
                }
            }
            //// Go to that month
            //html = wc.DownloadString(archiveUrl);
            //// Find all posts for that month
            //while ((postUrl
            //= WebZap.getHTML(html, ref p, "\"internal-link view-post\"", "href=\"", "\">")) != String.Empty)
            //{
            //    posturls.Add(postUrl);
            //}
            //// Go back
            //html = wc.DownloadString(siteStack.Pop());

            File.WriteAllText(logfile, String.Join("\r\n", posturls.ToArray()));
            //posturls.Clear();
            Process.Start(logfile);
            return posturls;
        }
	}
}
