using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

using System.Web.Script.Serialization;
using System.Web.Services;


namespace BooleanExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyService.GetFileListOnWebServer();
            //Console.ReadKey();
        }

    }


    // Use "Namespace" attribute with an unique name,to make service uniquely         discoverable  
    [WebService(Namespace = "http://localhost:80/")]
    // To indicate service confirms to "WsiProfiles.BasicProfile1_1" standard,   
    // if not, it will throw compile time error.  
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To restrict this service from getting added as a custom tool to toolbox  
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX  
    [System.Web.Script.Services.ScriptService]
    public class MyService : WebService
    {

        [WebMethod]
        public int SumOfNums(int First, int Second)
        {
            return First + Second;
        }

        [WebMethod]
        public static string GetFileListOnWebServer()
        {
            return "Hello World";
        }

    }



}
