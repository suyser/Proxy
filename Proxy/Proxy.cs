using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Proxy : ISubject, IProxy
    {
        private readonly RealSubject _realSubject;
        private readonly Dictionary<string, (string response, DateTime timestamp)> _cache;
        private readonly TimeSpan _cacheExpiration;
        private readonly bool _hasAccess;

        public Proxy(bool hasAccess)
        {
            _realSubject = new RealSubject();
            _cache = new Dictionary<string, (string, DateTime)>();
            _cacheExpiration = TimeSpan.FromSeconds(10);
            _hasAccess = hasAccess;
        }

        public void Request(string request)
        {
            if (!_hasAccess)
            {
                Console.WriteLine("Proxy: Access denied.");
                return;
            }

            if (_cache.ContainsKey(request))
            {
                var cachedResponse = _cache[request];
                if (DateTime.Now - cachedResponse.timestamp < _cacheExpiration)
                {
                    Console.WriteLine($"Proxy: Returning cached response for '{request}': {cachedResponse.response}");
                    return;
                }
                else
                {
                    _cache.Remove(request);
                    Console.WriteLine("Proxy: Cache expired. Requesting fresh data.");
                }
            }

            _realSubject.Request(request);

            string response = $"Response to: {request}";
            _cache[request] = (response, DateTime.Now);
            Console.WriteLine($"Proxy: Caching response for '{request}': {response}");
        }
    }
}
