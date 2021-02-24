namespace LegacySolution.UnitTests.Fakes
{
    public class FakeHeater : IHeater
    {
        public int TurnOnCounter{ get; set; }
        public int TurnOffCounter { get; set; }
        public bool RunSelfTestBool{ get; set; }

        public FakeHeater()
        {
            RunSelfTestBool = true;
            TurnOffCounter = 0;
            TurnOnCounter = 0;
        }

        public bool RunSelfTest()
        {
            return RunSelfTestBool;
        }

        public void TurnOn()
        {
            ++TurnOnCounter;
        }

        public void TurnOff()
        {
            ++TurnOffCounter;
        }
    }
}