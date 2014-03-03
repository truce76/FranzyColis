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
using System.Device.Location;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Services;
using Windows.Devices.Geolocation;
using System.Collections.Generic;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;

namespace Franzy_Colis.Classe
{
    public class GPS
    {

        /// <summary>
        /// Objet MAP sur l'interface utilisé
        /// </summary>
        public Map mapGPS { get; set; }
        public LongListSelector RouteLLS { get; set; }
        /// <summary>
        /// Position actuelle du telephone
        /// </summary>
        List<GeoCoordinate> MyCoordinates = new List<GeoCoordinate>(); 
        RouteQuery MyQuery = null;
        GeocodeQuery Mygeocodequery = null;
        Geoposition MyGeoPosition = null;
       public bool loaded = true;
        //BingKey, utiliser pour pouvoir obtenir les points sur la map de Bing (Clé Bing obtenue par RomainG)
        //Bing AtXkkJAwKS965UTVIRZsvu3e9vUTLzhSq7mZps4zl6LX7HwGQDKI24uTrVa2ux7H
        string BingKey = "AtXkkJAwKS965UTVIRZsvu3e9vUTLzhSq7mZps4zl6LX7HwGQDKI24uTrVa2ux7H";

        /// <summary>
        /// Constructeur de l'objet GPS
        /// </summary>
        /// <param name="mapGPS">Nom de l'objet sur lequelle sera affiché</param>
        public GPS(Map mapGPS, LongListSelector LLS)
        {
            this.mapGPS = mapGPS;
            this.RouteLLS = LLS;
        }

              

            //GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default)
            //{
            //    MovementThreshold = 20
            //};

            //watcher.PositionChanged += this.watcher_PositionChanged;
            //watcher.StatusChanged += this.watcher_StatusChanged;
            //watcher.Start();
            //}

        /// <summary>
        /// Lorsque le statut de la Géolocalisation change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    // location is pas support sur ce device
                    break;
                case GeoPositionStatus.NoData:
                    // Données pas disponnible
                    break;
            }
        }

        /// <summary>
        /// Evenement sur le changement de la position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var epl = e.Position.Location;

            //Accèder au information 
            epl.Latitude.ToString("0.000");
            epl.Longitude.ToString("0.000");
            epl.Altitude.ToString();
            epl.HorizontalAccuracy.ToString();
            epl.VerticalAccuracy.ToString();
            epl.Course.ToString();
            epl.Speed.ToString();
            e.Position.Timestamp.LocalDateTime.ToString();
        }


        /// <summary>
        /// Cette méthode permet d'obtenir le chemin entre un point A et un point B
        /// </summary>
        /// <param name="LatitudeA">Latitude du point de départ</param>
        /// <param name="LongitudeA">Longitude du point de départ</param>
        /// <param name="LatitudeB">Latitude du point d'arrivé</param>
        /// <param name="LongitudeB">Longitude du point d'arrivé</param>
        public void newRoad(double LatitudeA, double LongitudeA, double LatitudeB, double LongitudeB)
        {

            GeoCoordinate LocationA = new GeoCoordinate(LatitudeA, LongitudeA);
            GeoCoordinate LocationB = new GeoCoordinate(LatitudeB, LongitudeB);
 
       
            //mapGPS.Children
             
        }

     

        public async void GetCoordinates()
        {
            // Get the phone's current location.
            Geolocator MyGeolocator = new Geolocator();
            MyGeolocator.DesiredAccuracy = PositionAccuracy.High;
            
            try
            {


                MyGeoPosition = await MyGeolocator.GetGeopositionAsync(TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));
                MyCoordinates.Add(new GeoCoordinate(MyGeoPosition.Coordinate.Latitude, MyGeoPosition.Coordinate.Longitude));


                Mygeocodequery = new GeocodeQuery();
                Mygeocodequery.SearchTerm = (49.53525).ToString().Replace(",", ".") + "," + (0.186292).ToString().Replace(",", ".");
                Mygeocodequery.GeoCoordinate = new GeoCoordinate(49.53525, 0.186292);


                Mygeocodequery.QueryCompleted += Mygeocodequery_QueryCompleted;
                Mygeocodequery.QueryAsync();

            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Location is disabled in phone settings or capabilities are not checked.");
            }
            catch (Exception ex)
            {
                // Something else happened while acquiring the location.
                MessageBox.Show(ex.Message);
            }
        }
         
        void Mygeocodequery_QueryCompleted(object sender, QueryCompletedEventArgs<System.Collections.Generic.IList<MapLocation>> e)
        {
            if (e.Error == null)
            {
                MyQuery = new RouteQuery();
                MyCoordinates.Add(e.Result[0].GeoCoordinate);
                MyQuery.Waypoints = MyCoordinates;
                MyQuery.QueryCompleted += MyQuery_QueryCompleted;
                MyQuery.QueryAsync();
                Mygeocodequery.Dispose();
            }
        }

        private void MyQuery_QueryCompleted(object sender, QueryCompletedEventArgs<Route> e)
        {
            if (e.Error == null)
            {
                Route MyRoute = e.Result;
                MapRoute MyMapRoute = new MapRoute(MyRoute);
                mapGPS.AddRoute(MyMapRoute);

                List<string> RouteList = new List<string>();
                foreach (RouteLeg leg in MyRoute.Legs)
                {
                    foreach (RouteManeuver maneuver in leg.Maneuvers)
                    {
                        RouteList.Add(maneuver.InstructionText);
                    }
                } 
                RouteLLS.ItemsSource = RouteList;
                
                loaded = false;
                MyQuery.Dispose();
                


            }
        }
    }
}
