using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.GoogleMaps.Clustering
{
    public sealed class MyLocationChangedEventArgs : EventArgs
    {
        public bool Handled { get; set; } = false;
        public Position Position { get; }

        internal MyLocationChangedEventArgs(Position position)
        {
            Position = position;
        }
    }
}
