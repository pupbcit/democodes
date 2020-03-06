using PointsLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PointsService service = new PointsService();
            var items = service.GetAllPoints();

            foreach (var y in items)
            {
                Console.WriteLine(y.StudentNumber + " " 
                    + y.NumberOfPoints);
            }

            service.AddPointsToStudent("2018-00044-BN-0", 10);
            service.AddPointsToStudent("2015-00066-BN-0", 5);

            foreach (var y in items)
            {
                Console.WriteLine(y.StudentNumber + " "
                    + y.NumberOfPoints);
            }
        }
    }
}
