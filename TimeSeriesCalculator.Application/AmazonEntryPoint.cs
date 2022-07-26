using Amazon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesCalculator.Application
{
    public static class AmazonEntryPoint
    {
        public static string ClientId() => "1uenqsl177lkord52kndq35tla";
        public static RegionEndpoint Region() => RegionEndpoint.USEast1;
        public static string UserPoolId() => "us-east-1_9YbGlSTA4";
    }
}
