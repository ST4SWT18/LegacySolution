namespace LegacySolution.UnitTests.Fakes
{
    public class FakeHeaterFalse : IHeater
    {
        public bool RunSelfTest()
        {
            return false;
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