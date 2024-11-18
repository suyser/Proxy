using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public static void Main(string[] args)
    {
        ISubject proxyWithAccess = new Proxy.Proxy(true);

        proxyWithAccess.Request("Request1");

        proxyWithAccess.Request("Request1");

        // Вторичный запрос с другим значением — будет обработан RealSubject
        proxyWithAccess.Request("Request2");

        // Прокси с отказом в доступе
        ISubject proxyWithoutAccess = new Proxy.Proxy(false);
        proxyWithoutAccess.Request("Request1");
    }
}
