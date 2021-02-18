namespace LegacySolution.UnitTests.Fakes
{
    public class FakeTempSensorLTThr : ITempSensor
    {
        public int GetTemp()
        {
            return -5;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}