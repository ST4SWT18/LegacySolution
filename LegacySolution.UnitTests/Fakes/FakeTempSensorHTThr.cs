namespace LegacySolution.UnitTests.Fakes
{
    public class FakeTempSensorHTThr : ITempSensor
    {
        public int GetTemp()
        {
            return 45;
        }

        public bool RunSelfTest()
        {
            throw new System.NotImplementedException();
        }
    }
}