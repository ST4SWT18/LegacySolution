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
            throw new System.NotImplementedException();
        }

        public void TurnOff()
        {
            throw new System.NotImplementedException();
        }
    }
}