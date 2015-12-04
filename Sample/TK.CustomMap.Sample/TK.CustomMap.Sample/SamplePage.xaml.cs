﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TK.CustomMap.Sample
{
    public partial class SamplePage : ContentPage
    {
        public SamplePage()
        {
            InitializeComponent();

            this.CreateView();
            this.BindingContext = new SampleViewModel();
        }

        private void CreateView()
        {
            var autoComplete = new GooglePlacesAutoComplete();
            autoComplete.SetBinding(GooglePlacesAutoComplete.PlaceSelectedCommandProperty, "PlaceSelectedCommand");

            var mapView = new TKCustomMap();
            mapView.SetBinding(TKCustomMap.CustomPinsProperty, "Pins");
            mapView.SetBinding(TKCustomMap.MapClickedCommandProperty, "MapClickedCommand");
            mapView.SetBinding(TKCustomMap.MapLongPressCommandProperty, "MapLongPressCommand");
            mapView.SetBinding(TKCustomMap.MapCenterProperty, "MapCenter");
            mapView.AnimateMapCenterChange = true;


            this._baseLayout.Children.Add(
                mapView,
                Constraint.RelativeToView(autoComplete, (r, v) => v.X),
                Constraint.RelativeToView(autoComplete, (r, v) => autoComplete.HeightOfSearchBar),
                heightConstraint: Constraint.RelativeToParent((r) => r.Height - autoComplete.HeightOfSearchBar),
                widthConstraint: Constraint.RelativeToView(autoComplete, (r, v) => v.Width));

            this._baseLayout.Children.Add(
                autoComplete,
                Constraint.Constant(0),
                Constraint.Constant(0));
        }
    }
}
