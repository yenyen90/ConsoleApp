using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;

namespace ConsoleApplication_iPhone11
{
    class Program
    {
        public class phone
        {
            public string WebsiteName;
            public string ProductName;
            public string ProductPrice;
            public string ProductLink;
        }

        static void Main(string[] args)
        {
            //variables
            var htmlDoc = new HtmlDocument();

            var prodname = "";
            var prodprice = "";
            var prodlink = "";

            var list = new List<phone>();

            //------------------------------------------------------eBay-----------------------------------------------------------------------------------
            //load html doc
            var htmleBay = @"eBay_iphone11.html";
            htmlDoc.Load(htmleBay);

            //select nodes from html
            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//li[contains(@class, 's-item')]");

            //loop the single nodes from the xpath of selectnodes
             foreach (var node in htmlNodes)
            {
                var title = node.SelectSingleNode(".//h3[@class='s-item__title']");
                var price = node.SelectSingleNode(".//span[@class='s-item__price']");
                var link = node.SelectSingleNode(".//a[@class='s-item__link']");

                //get the product name value
                if (title != null)
                { prodname = title.InnerText.Trim(); }

                //get the product price value
                if (price != null)
                { prodprice = price.InnerText; }

                //get the product link value
                if (link != null)
                { prodlink = link.Attributes["href"].Value; }

                //add info to the list
                if (title != null && price != null && link != null)
                {
                
                    list.Add(new phone
                    {
                        WebsiteName = "eBay",
                        ProductName = prodname,
                        ProductPrice = prodprice,
                        ProductLink = prodlink
                    });
                }

            }
            //-------------------------------------------------------------------------------------------------------------------------------------------------

             //------------------------------------------------------Amazon-----------------------------------------------------------------------------------
             
            //load html doc
             var htmlAmazon = @"Amazon.com_iphone11.html";
             htmlDoc.Load(htmlAmazon);

             //select nodes from html
             var htmlNodes2 = htmlDoc.DocumentNode.SelectNodes("//span[contains(@class, 'celwidget slot=MAIN template=SEARCH_RESULTS widgetId=search-results')]");

             //loop the single nodes from the xpath of selectnodes
             foreach (var node2 in htmlNodes2)
             {
                 var title2 = node2.SelectSingleNode(".//span[@class='a-size-medium a-color-base a-text-normal']");
                 var price2 = node2.SelectSingleNode(".//span[@class='a-price']/span[@class='a-offscreen']");
                 var link2 = node2.SelectSingleNode(".//h2[@class='a-size-mini a-spacing-none a-color-base s-line-clamp-2']/a[@class='a-link-normal a-text-normal']");

                 //get the product name value
                 if (title2 != null)
                 { prodname = title2.InnerText.Trim(); }

                 //get the product price value
                 if (price2 != null)
                 { prodprice = price2.InnerText; }

                 //get the product link value
                 if (link2 != null)
                 { prodlink = link2.Attributes["href"].Value; }

                 //add info to the list
                 if (title2 != null && price2 != null && link2 != null)
                 {
                     
                     list.Add(new phone
                     {
                         WebsiteName = "Amazon",
                         ProductName = prodname,
                         ProductPrice = prodprice,
                         ProductLink = prodlink
                     });
                 }

             }

             //order product by price
             list = list.OrderBy(item => item.ProductPrice.Length).ThenBy(item => item.ProductPrice).ToList();

            //loop the info and display result in console
             foreach (var item in list)
             {

                 Console.Write("WebsiteName: " + item.WebsiteName);
                 Console.WriteLine();
                 Console.Write("ProductName: " + item.ProductName);
                 Console.WriteLine();
                 Console.Write("ProductPrice: " + item.ProductPrice);
                 Console.WriteLine();
                 Console.Write("ProductLink: " + item.ProductLink);
                 Console.WriteLine();
                 Console.WriteLine();
             }
        }
  }
}

