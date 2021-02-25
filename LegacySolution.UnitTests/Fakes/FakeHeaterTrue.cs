using System.Diagnostics;

namespace LegacySolution.UnitTests.Fakes
{
    public class FakeHeaterTrue : IHeater
    {
        public bool RunSelfTest()
        {
            return true;
        }

        public void TurnOn()
        {
            Debug.WriteLine("On");
        }

        public void TurnOff()
        {
            Debug.WriteLine("Off");
        }
    }
}