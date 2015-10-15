using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace oncloud.Web.oddBase.Models.Home
{
    public class Table
    {
        public void Setinitialization(OddAdbaseDataBase db)
        {
            GetDataModel = db.City.Join(db.Street, city => city.id, street => street.City_id,
      (city, street) => new { Location = city.Name, Denomination = street.Name, StreetId = street.id, UniqueNumber=street.UniqueNumber })
      .GroupJoin(db.Segment, citystreet => citystreet.StreetId, segment => segment.Street_id,
          (citystreet, segment) =>
              new Table()
              {
                  Denomination = citystreet.Denomination,
                  Location = citystreet.Location,
                  NumberSegment = segment.Count(),
                  UniqueNumber= citystreet.UniqueNumber
              });
         }
        public IEnumerable<Table> GetDataModel { get; set; }
        public int NumberSegment { get; set; }
        public string Location { get; set; }
        public string Denomination { get; set; }
        public string UniqueNumber { get; set; }
    }
}