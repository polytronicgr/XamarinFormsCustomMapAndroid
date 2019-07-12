using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Maps;
using Maps.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRender))]
namespace Maps.Droid
{
    class CustomMapRender : MapRenderer, IOnMapReadyCallback
    {
        const string Host = "https://cartodb-basemaps-a.global.ssl.fastly.net/light_all/{z}/{x}/{y}.png";
        CustomMap customMap;
        GoogleMap nativeMap;
        private TileOverlay tileOverlay;
        public CustomMapRender(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                customMap = e.NewElement as CustomMap;
                ((MapView)Control).GetMapAsync(this);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            UpdateTiles();
        }

        private void UpdateTiles()
        {
            if (nativeMap != null)
            {
                if (tileOverlay != null)
                {
                    this.tileOverlay.Remove();
                    this.nativeMap.MapType = GoogleMap.MapTypeNormal;
                }
                nativeMap.MapType = GoogleMap.MapTypeNone;
                tileOverlay = nativeMap.AddTileOverlay(new TileOverlayOptions().InvokeTileProvider(new WebTileProvider(Host)));

            }
        }

        protected override void OnMapReady(GoogleMap googleMap)
        {
            nativeMap = googleMap;
            UpdateTiles();
        }

    }
}