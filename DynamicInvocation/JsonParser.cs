using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicInvocation
{
    internal class JsonParser
    {
        public void InvokeMethod()
        {

            Type type = Type.GetType("DynamicInvocation.DummyCLass");

            Console.WriteLine(type);
            var initiatedObject = Activator.CreateInstance(type) as DummyCLass;
            var myMethod = type.GetMethod("DummyMethod1");
            Console.WriteLine(myMethod.Name);
            // _ = Activator.CreateInstance(type) as DummyCLass;
        }
    }
}
