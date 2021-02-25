using NUnit.Framework;
using LegacySolution;
using LegacySolution.UnitTests.Fakes;

namespace LegacySolution.UnitTests
{
    public class Tests
    {
        private ECS uut;
        private int thr = 30;
        private ITempSensor fakeTempSensorLT;
        private ITempSensor fakeTempSensorHT;
        private IHeater fakeHeaterTrue;

        [SetUp]
        public void Setup()
        {
            fakeTempSensorLT = new FakeTempSensorLTThr();
            fakeTempSensorHT = new FakeTempSensorHTThr();
            fakeHeaterTrue = new FakeHeaterTrue();
            uut = new ECS(thr, fakeHeaterTrue);
        }

        [Test]
        public void ECS_Regulate_WithThresholdOf46_WillCall_TurnOn()
        {
            uut.SetThreshold(46);
            var temp = fakeTempSensorLT.GetTemp();
            uut.Regulate(temp); //den går bare ind og overskriver temp, da i Regulate selver kalder GetTemp()

            Assert.That(temp, Is.LessThan(46));

            //Assert.Multiple(() =>
            //{
            //    uut.SetThreshold(20);
            //    uut.Regulate();

            //    //Assert.That(uut.Regulate();
            //});
        }


        [Test]
        public void ECS_GetCurTemp_Is45()
        {
            Assert.That(uut.GetCurTemp(fakeTempSensorHT), Is.EqualTo(45));
        }

        [Test]
        public void ECS_GetCurTemp_IsMinus5()
        {
            Assert.That(uut.GetCurTemp(fakeTempSensorLT), Is.EqualTo(-5));
        }

        [Test]
        public void ECS_RunSelfTest_IsTrue()
        {
            Assert.That(uut.RunSelfTest(fakeTempSensorLT, new FakeHeaterTrue()), Is.True);
        }

        [Test]
        public void ECS_RunSelfTest_IsFalse()
        {
            Assert.That(uut.RunSelfTest(fakeTempSensorLT, new FakeHeaterFalse()), Is.False);
        }
    }
}