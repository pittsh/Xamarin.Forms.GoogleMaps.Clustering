using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Xamarin.Forms.GoogleMaps.Clustering
{
    public class ClusteredMap : Map
    {
        public static readonly BindableProperty ClusterOptionsProperty = BindableProperty.Create(nameof(ClusterOptionsProperty),
            typeof(ClusterOptions),
            typeof(ClusteredMap),
            default(ClusterOptions));

        public event EventHandler<ClusterClickedEventArgs> ClusterClicked;
        public event EventHandler<MyLocationChangedEventArgs> MyLocationChanged;

        internal Action OnCluster { get; set; }

        internal bool PendingClusterRequest { get; set; }

        public ClusteredMap()
        {
            ClusterOptions = new ClusterOptions();
        }
        
        public ClusterOptions ClusterOptions
        {
            get => (ClusterOptions)GetValue(ClusterOptionsProperty);
            set => SetValue(ClusterOptionsProperty, value);
        }

        public void Cluster()
        {
            SendCluster();
        }
        
        private void SendCluster()
        {
            if (OnCluster != null)
            {
                OnCluster.Invoke();
            }
            else
            {
                PendingClusterRequest = true;
            }
        }

      
        internal bool SendClusterClicked(IEnumerable<Pin> items)
        {
            var args = new ClusterClickedEventArgs(items);
            ClusterClicked?.Invoke(this, args);
            return args.Handled;
        }
        internal bool SendUserLocation(Position position)
        {
            var args = new MyLocationChangedEventArgs(position);
            MyLocationChanged?.Invoke(this, args);
            return args.Handled;
        }
    }
}