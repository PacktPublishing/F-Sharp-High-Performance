using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTypeProviderInteropCShap
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleFSharpData.displayCustomerNameStartsWith("Maria");
            var customerData = from cust in SampleFSharpData.nwdb.Customers
                               orderby cust.ContactName
                               select cust;
            foreach (var item in customerData)
            {
                Console.WriteLine("Customer name = " + item.ContactName + "; Company =" + item.CompanyName);
            }
        }
    }
}
