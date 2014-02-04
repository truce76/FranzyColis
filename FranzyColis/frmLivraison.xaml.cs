using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Franzy_Colis.Classe;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace FranzyColis
{
    public partial class frmLivraison : PhoneApplicationPage
    {
        public frmLivraison()
        {
            InitializeComponent();
        }

        private void BtnMap_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
             
            GPS map = new GPS(MyMap, RouteLLS);
            map.GetCoordinates(); 
        } 
    }
}