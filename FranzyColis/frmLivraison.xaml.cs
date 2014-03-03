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
using Windows.Devices.Geolocation;
using System.Device.Location;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;

namespace FranzyColis
{
    public partial class frmLivraison : PhoneApplicationPage
    {
       Geolocator gl = new Geolocator();
       GPS map; 
        public frmLivraison()
        {
            InitializeComponent();
        }

        private void BtnMap_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            
            map = new GPS(MyMap, RouteLLS);
            gl.MovementThreshold = 20;
            gl.DesiredAccuracyInMeters = 5;
            map.GetCoordinates(new GeoCoordinate(49.53525, 0.186292));
            gl.PositionChanged+=gl_PositionChanged;
        }

        void gl_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            Dispatcher.BeginInvoke(() =>
{

    double lati, longi;
    lati = args.Position.Coordinate.Latitude;
    longi = args.Position.Coordinate.Longitude;
    var truc = args.Position.Coordinate;
    map.GetCoordinates(new GeoCoordinate(49.53525, 0.186292));
    //MyMap.Center = truc;
});
        } 
    }
}