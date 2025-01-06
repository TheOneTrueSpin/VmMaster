using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VmMaster.Utils
{
    public class ServiceFactory<T> where T : class
    {
        private readonly IEnumerable<T> _services;
        public ServiceFactory(IEnumerable<T> services)
        {
            _services = services;
        }
        public T? GetService(Type type)
        {
            return _services.FirstOrDefault(s => s.GetType() == type);
        }

        public T? GetService(string type)
        {
            return _services.FirstOrDefault(s => s.GetType().ToString().Split(".").Last() == type);
        }
    }
}
