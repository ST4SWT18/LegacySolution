using NUnit.Framework;
using LegacySolution;
using LegacySolution.UnitTests.Fakes;

namespace LegacySolution.UnitTests
{
    public class Tests
    {
        private ECS uut;
        private int thr = 30;
        private ITempSensor fakeTempSensor;
        private ITempSensor fakeTempSensorHT;
        private IHeater fakeHeaterTrue;

        [SetUp]
        public void Setup()
        {
            fakeTempSensor = new FakeTempSensorLTThr();
            fakeTempSensorHT = new FakeTempSensorHTThr();
            fakeHeaterTrue = new FakeHeaterTrue();
            uut = new ECS(thr, fakeHeaterTrue);
        }

        //[Test]
        //public void ECS_Regulate()
        //{
        //    fakeTempSensor.Temp = 20;
        //    uut.Regulate();



        //    //Assert.Multiple(() =>
        //    //{
        //    //    uut.SetThreshold(-5);
        //    //    uut.Regulate();

        //    //    Assert.That(uut.Regulate(),);
        //    //});
        //}


        [Test]
        public void ECS_GetCurTemp_Is45()
        {
            Assert.That(uut.GetCurTemp(fakeTempSensorHT), Is.EqualTo(45));
        }

        [Test]
        public void ECS_GetCurTemp_IsMinus5()
        {
            Assert.That(uut.GetCurTemp(fakeTempSensor), Is.EqualTo(-5));
        }

        [Test]
        public void ECS_RunSelfTest_IsTrue()
        {
            Assert.That(uut.RunSelfTest(fakeTempSensor, new FakeHeaterTrue()), Is.True);
        }

        [Test]
        public void ECS_RunSelfTest_IsFalse()
        {
            Assert.That(uut.RunSelfTest(fakeTempSensor, new FakeHeaterFalse()), Is.False);
        }
    }
}