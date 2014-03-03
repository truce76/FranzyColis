using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Franzy_Colis.Objet.Colis
{
    public struct ColisRecu
    {
        public int id;
        public string Destinataire;
        public string Adresse;
        public double X;
        public double Y;
    }

    public struct ColisEnvoyer
    {
        int id;
        int Etat;
    }
}
