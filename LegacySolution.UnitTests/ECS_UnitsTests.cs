using NUnit.Framework;
using LegacySolution;
using LegacySolution.UnitTests.Fakes;
using NSubstitute;

namespace LegacySolution.UnitTests
{
    public class Tests
    {
        private ECS uut;
        private int thr = 23;

        private IHeater _heater;
        private ITempSensor _tempSensor;

        ////Before NSubstitue
        //private FakeTempSensor fakeTempSensor;
        //private FakeHeater fakeHeater;

        [SetUp]
        public void Setup()
        {
            _heater = Substitute.For<IHeater>();
            _tempSensor = Substitute.For<ITempSensor>();
            uut = new ECS(thr, _heater, _tempSensor);

            ////Before NSubstitute
            //fakeHeater = new FakeHeater();
            //uut = new ECS(thr, fakeHeater,fakeTempSensor);
        }

        [Test]
        public void ECS_Regulate_Low_Temp()
        {
            _tempSensor.GetTemp().Returns(21);
            uut.Regulate();
            _heater.Received(1).TurnOn();

            //fakeTempSensor.Temp = 21;
            //uut.Regulate();
            //Assert.That(fakeHeater.TurnOnCounter, Is.EqualTo(1));
        }

        [Test]
        public void ECS_Regulate_High_Temp()
        {
            _tempSensor.GetTemp().Returns(28);
            uut.Regulate();
            _heater.Received(1).TurnOff();


            ////Before NSubstitute
            //fakeTempSensor.Temp = 28;

            ////Act
            //uut.Regulate();

            ////Assert
            //Assert.That(fakeHeater.TurnOffCounter, Is.EqualTo(1));
        }

        [TestCase(true,true,true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, false)]
        public void ECS_RunSelfTest(bool hresult,bool tresult,bool testresult)
        {
            _tempSensor.RunSelfTest().Returns(tresult);
            _heater.RunSelfTest().Returns(hresult);
            Assert.That(uut.RunSelfTest(), Is.EqualTo(testresult));

            //fakeTempSensor.RunSelfTestBool = tresult;
            //fakeHeater.RunSelfTestBool = hresult;
            //Assert.That(uut.RunSelfTest(), Is.EqualTo(testresult));
        }
    }
}