﻿#pragma checksum "C:\Users\gmaur_000\Documents\GitHub\FranzyColis\FranzyColis\Scanner.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F3FB79AFF2704AA825DE4A3F07B851B6"
//------------------------------------------------------------------------------
// <auto-generated>
<<<<<<< HEAD
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
=======
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18449
>>>>>>> 6c93c29ae5cb6739c1e92c5265545bd8f59cb787
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace FranzyColis {
    
    
    public partial class Scanner : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Shapes.Rectangle _previewRect;
        
        internal System.Windows.Media.VideoBrush _previewVideo;
        
        internal System.Windows.Media.CompositeTransform _previewTransform;
        
        internal System.Windows.Controls.ListBox _matchesList;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/FranzyColis;component/Scanner.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this._previewRect = ((System.Windows.Shapes.Rectangle)(this.FindName("_previewRect")));
            this._previewVideo = ((System.Windows.Media.VideoBrush)(this.FindName("_previewVideo")));
            this._previewTransform = ((System.Windows.Media.CompositeTransform)(this.FindName("_previewTransform")));
            this._matchesList = ((System.Windows.Controls.ListBox)(this.FindName("_matchesList")));
        }
    }
}

