namespace LegacySolution.UnitTests.Fakes
{
    public class FakeTempSensor : ITempSensor
    {
        public int Temp{ get; set; }
        public bool RunSelfTestBool { get; set; }

        public FakeTempSensor()
        {
            RunSelfTestBool = true;
            Temp = 0;
        }
        public int GetTemp()
        {
            return Temp;
        }

        public bool RunSelfTest()
        {
            return RunSelfTestBool;
        }
    }
}