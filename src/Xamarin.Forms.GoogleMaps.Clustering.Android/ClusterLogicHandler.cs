using Com.Google.Maps.Android.Clustering;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xamarin.Forms.GoogleMaps.Clustering.Android
{
    internal class ClusterLogicHandler : Java.Lang.Object,
        ClusterManager.IOnClusterClickListener,
        ClusterManager.IOnClusterItemClickListener,
        ClusterManager.IOnClusterInfoWindowClickListener,
        ClusterManager.IOnClusterItemInfoWindowClickListener
    {
        private ClusteredMap map;
        private ClusterManager clusterManager;
        private ClusterLogic logic;

        public ClusterLogicHandler(ClusteredMap map, ClusterManager manager, ClusterLogic logic)
        {
            this.map = map;
            clusterManager = manager;
            this.logic = logic;
        }

        public bool OnClusterClick(ICluster cluster)
        {
            var pins = new List<Pin>();
            foreach (var item in cluster.Items)
            {
                var pin = logic.LookupPin(item as ClusteredMarker);
                pins.Add(pin);
            }

            return map.SendClusterClicked(pins);
        }

        public bool OnClusterItemClick(Java.Lang.Object nativeItemObj)
        {
            var targetPin = logic.LookupPin(nativeItemObj as ClusteredMarker);
           
            targetPin?.SendTap();

            if (targetPin != null)
            {
                if (!ReferenceEquals(targetPin, map.SelectedPin))
                    map.SelectedPin = targetPin;
                return map.SendPinClicked(targetPin);
            }

            return false;
        }

        public void OnClusterInfoWindowClick(ICluster cluster)
        {

        }

        public void OnClusterItemInfoWindowClick(Java.Lang.Object nativeItemObj)
        {
            var targetPin = logic.LookupPin(nativeItemObj as ClusteredMarker);
           
            targetPin?.SendTap();

            if (targetPin != null)
            {
                map.SendInfoWindowClicked(targetPin);
            }
        }
    }
}