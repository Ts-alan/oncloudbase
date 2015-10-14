using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Spatial;

namespace oncloud.Domain.Entities
{
    public class Street
    {
        public int StreetId { get; set; }
        public string Caption { get; set; }

        public double? StartPointLongitude { get; set; }
        public double? StartPointLatitude { get; set; }
        public double? EndPointLongitude { get; set; }
        public double? EndPointLatitude { get; set; }

        public DbGeography StartPoint { 
            get 
            {
                return DbGeography.PointFromText(string.Format("POINT({0},{1})", StartPointLongitude, StartPointLatitude), DbGeography.DefaultCoordinateSystemId);
            }
            set 
            {
                StartPointLongitude = value.Longitude;
                StartPointLatitude = value.Latitude;
            }
        }
    }
}
