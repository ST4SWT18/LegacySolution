using NUnit.Framework;
using LegacySolution;
using LegacySolution.UnitTests.Fakes;

namespace LegacySolution.UnitTests
{
    public class Tests
    {
        private ECS uut;
        private int thr = 23;
        private FakeTempSensor fakeTempSensor;
        private FakeHeater fakeHeater;

        [SetUp]
        public void Setup()
        {
            fakeTempSensor = new FakeTempSensor();
            fakeHeater = new FakeHeater();
            uut = new ECS(thr, fakeHeater,fakeTempSensor);
        }

        [Test]
        public void ECS_Regulate_Low_Temp()
        {
            fakeTempSensor.Temp = 21;
            uut.Regulate();
            Assert.That(fakeHeater.TurnOnCounter, Is.EqualTo(1));
        }

        [Test]
        public void ECS_Regulate_High_Temp()
        {
            fakeTempSensor.Temp = 28;
            uut.Regulate();
            Assert.That(fakeHeater.TurnOffCounter, Is.EqualTo(1));
        }

        [TestCase(true,true,true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, false)]
        public void ECS_RunSelfTest(bool hresult,bool tresult,bool testresult)
        {
            fakeTempSensor.RunSelfTestBool = tresult;
            fakeHeater.RunSelfTestBool = hresult;
            Assert.That(uut.RunSelfTest(), Is.EqualTo(testresult));
        }
    }
}