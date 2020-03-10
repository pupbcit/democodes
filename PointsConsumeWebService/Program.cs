using PointsConsumeWebService.getpointswebservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsConsumeWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            GetPointsWebServiceSoapClient client = new GetPointsWebServiceSoapClient();
            var points = client.GetPoints("2018-00044-BN-0");

            Console.WriteLine("points is : " + points.ToString());
        }
    }
}
