using System.Runtime.Serialization;

namespace HelloWorldService
{
    public class HelloObject
    {
        [DataMember]
        public bool happyHello { get; set; } = false;

        [DataMember]
        public string helloMessage { get; set; } = "Bonjour!"; 
    }
}