using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Resources;
using System.Xml.Linq;
using System.Text;
using Franzy_Colis.Objet.Colis;
using System.IO;
using System.Threading;


namespace Franzy_Colis.Objet.ParseXML
{
    class ParseXML
    {
        XDocument xdoc;
        List<ColisRecu> lcr = new List<ColisRecu>();
        WebClient webClient = new WebClient();

        public ParseXML(int i, string chemin)
        {
            webClient.DownloadStringAsync(new Uri(chemin));

            webClient.DownloadStringCompleted += (s, a) =>
            {
                string xml = a.Result;
                xdoc = XDocument.Parse(xml);

                var select =
                from fr in xdoc.Descendants("liste")
                select fr;

                foreach (var x in select)
                {
                    ColisRecu nColisRecu = new ColisRecu();
                    nColisRecu.id = int.Parse(x.Element("colis").Element("id").Value);
                    nColisRecu.Destinataire = x.Element("colis").Element("destinataire").Value;
                    nColisRecu.Adresse = x.Element("colis").Element("adresse").Value;
                    nColisRecu.X = double.Parse(x.Element("colis").Element("x").Value.Replace(".",","));
                    nColisRecu.Y = double.Parse(x.Element("colis").Element("y").Value.Replace(".", ","));

                    lcr.Add(nColisRecu);
                }               
            };
        }

        public List<ColisRecu> Extract()
        {
            while (true)
            {
                return lcr;
            }
        }

    

    }
}

