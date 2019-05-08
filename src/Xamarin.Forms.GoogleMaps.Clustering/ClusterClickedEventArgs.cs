using System;
using System.Collections;
using System.Collections.Generic;

namespace Xamarin.Forms.GoogleMaps.Clustering
{
    public sealed class ClusterClickedEventArgs : EventArgs
    {
        public bool Handled { get; set; } = false;
        public IEnumerable<Pin> Items { get; }

        internal ClusterClickedEventArgs(IEnumerable<Pin> items)
        {
            Items = items;
        }
    }
}