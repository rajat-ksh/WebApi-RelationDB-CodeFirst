// See https://aka.ms/new-console-template for more information
using DynamicInvocation;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");
string str = "{ '''001''': '''DummyMethod1''',
                 '''002''': '''DummyMethod2''', 
                 '''003''': '''DummyMethod3'''}";
var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(str);
foreach (var kv in dict)
{
    Console.WriteLine(kv.Key + ":" + kv.Value);
}
JsonParser jsonParser = new JsonParser();
jsonParser.InvokeMethod();
Console.ReadKey();