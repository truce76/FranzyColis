﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FranzyColis.Resources;
using System.Xml.Linq;

using Franzy_Colis.Objet.ParseXML;
namespace FranzyColis
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructeur
        public MainPage()
        {
            InitializeComponent();

            // Exemple de code pour la localisation d'ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

             NavigationService.Navigate(new Uri("/Scanner.xaml", UriKind.Relative));
             //WebClient webClient = new WebClient();
             //webClient.DownloadStringAsync(new Uri("http://192.168.1.14/symfony/web/app_dev.php/mobile/identification/coursier/" + TxtBoxLogin.Text + "/" + PassBox.Password));
             //http://vds43.monespace.net/franzycolis/web/app_dev.php/mobile/identification/coursier/bcatelain/azerty
             //webClient.DownloadStringCompleted += (s, a) =>
             //{
             //    try
             //    {
             //        string xml = a.Result;
             //        //MessageBox.Show(xml);
             //        XDocument xdoc = XDocument.Parse(xml);
             //        string x = (string)xdoc.Element("retour").Value;

             //        string iduser = x.Trim();
             //        if (iduser != "1" && iduser != "")
             //        {
             //            MessageBox.Show("Vous êtes connecté", "Information", MessageBoxButton.OK);
             //            NavigationService.Navigate(new Uri("/TestPage.xaml", UriKind.Relative));

             //        }
             //        else
             //        {
             //            MessageBox.Show("Erreur d'authentification, veuillez vérifier le couple utilisateur/mot de passe", "Information", MessageBoxButton.OK);
             //        }

             //    }
             //    catch (WebException ex)
             //    {
             //        MessageBox.Show("Une erreur est survenue : " + (ex.Message.ToString()), "test", MessageBoxButton.OK);
             //        NavigationService.Navigate(new Uri("/Network.xaml", UriKind.Relative));
             //        //throw;
             //    }

             //};

            //http://vds43.monespace.net/franzycolis/web/app_dev.php/mobile/liste/8e883b0e01ff2b81d964

             ParseXML px = new ParseXML("http://vds43.monespace.net/franzycolis/web/app_dev.php/mobile/liste/8e883b0e01ff2b81d964");


         }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
             
        }
        
            // Exemple de code pour la conception d'une ApplicationBar localisée
            //private void BuildLocalizedApplicationBar()
            //{
            //    // Définit l'ApplicationBar de la page sur une nouvelle instance d'ApplicationBar.
            //    ApplicationBar = new ApplicationBar();

            //    // Crée un bouton et définit la valeur du texte sur la chaîne localisée issue d'AppResources.
            //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            //    appBarButton.Text = AppResources.AppBarButtonText;
            //    ApplicationBar.Buttons.Add(appBarButton);

            //    // Crée un nouvel élément de menu avec la chaîne localisée d'AppResources.
            //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            //    ApplicationBar.MenuItems.Add(appBarMenuItem);
            //}
    }
}