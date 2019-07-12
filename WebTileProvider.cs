using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Net;

namespace Maps.Droid
{
    public class WebTileProvider : UrlTileProvider
    {
        private string _url;
        public WebTileProvider(string tileUrl) : base(256, 256)
        {
            _url = tileUrl;
            Console.WriteLine("url " + _url);
        }

        public override URL GetTileUrl(int x, int y, int z)
        {
            var url = _url.Replace("{z}", z.ToString()).Replace("{x}", x.ToString()).Replace("{y}", y.ToString());
            Console.WriteLine("testttttttttttt");
            return new URL(url);
        }
    }
}