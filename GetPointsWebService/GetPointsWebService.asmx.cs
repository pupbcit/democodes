using PointsLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace GetPointsWebService
{
    /// <summary>
    /// Summary description for GetPointsWebService
    /// </summary>
    [WebService(Namespace = "http://getpointswebservice.org/", Name ="Get Points Web Service", Description ="This is a simple web service to get the points by student.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GetPointsWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public int GetPoints(string studentNumber)
        {
            PointsService service = new PointsService();
            return service.GetPointsByStudentNumber(studentNumber);
        }
    }
}
