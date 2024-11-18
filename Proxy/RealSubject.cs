using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class RealSubject : ISubject
    {
        public void Request(string request)
        {
            Console.WriteLine($"RealSubject: Handling request: {request}");
        }
    }
}
