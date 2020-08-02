using Sitecore.Analytics.Pipelines.CreateVisits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace RD.IPMask.Pipelines
{
    /// <summary>
    /// Simple Visit processor to set IP based on Query string value
    /// </summary>
    public class SetIpBasedOnQueryString : CreateVisitProcessor
    {
        public override void Process(CreateVisitArgs args)
        {
            string ip = new IPAddress(Sitecore.Analytics.Tracker.Current.Interaction.Ip).ToString();
            var ipQueryString = args.Request.QueryString["ip"].ToString(); ///Get Query String IP value
            if (ip != "0.0.0.0" && ip != "127.0.0.1" && string.IsNullOrEmpty(ipQueryString))
            {
                return;
            }
            IPAddress address;
            if (IPAddress.TryParse(ipQueryString, out address))
            {
                args.Interaction.Ip = address.GetAddressBytes();
                var whoIsInfo = Sitecore.CES.GeoIp.Core.Lookups.LookupManager.GetWhoIsInformationByIp(ip);
                var result = Sitecore.Analytics.Lookups.GeoIpManager.GetGeoIpData(new Sitecore.Analytics.Lookups.GeoIpOptions() { Ip = address });
                //args.Interaction.SetGeoData(new Sitecore.Analytics.Model.WhoIsInformation()
                //{
                //    AreaCode = whoIsInfo.AreaCode,
                //    BusinessName = whoIsInfo.BusinessName,
                //    Country = whoIsInfo.Country,
                //    City = whoIsInfo.City,
                //    Dns = whoIsInfo.Dns,
                //    Isp = whoIsInfo.Isp,
                //    Latitude = whoIsInfo.Latitude,
                //    Longitude = whoIsInfo.Longitude,
                //    Region = whoIsInfo.Region,
                //    MetroCode = whoIsInfo.MetroCode,
                //    PostalCode = whoIsInfo.PostalCode
                //});
                args.Interaction.SetGeoData(result.GeoIpData);


                args.Interaction.UpdateLocationReference();
            }
        }
    }
}