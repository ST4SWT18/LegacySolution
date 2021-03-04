using System;

namespace LegacySolution
{
    public class ECS
    {
        private int _threshold;
        public ITempSensor TempSensor { get; set; }
        private readonly IHeater _heater;

        public ECS(int thr, IHeater heater,ITempSensor tempSensor)
        {
            SetThreshold(thr);
            TempSensor = tempSensor;
            _heater = heater;
        }

        public void Regulate()
        {
            var t = GetCurTemp();
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();

        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            int temp = TempSensor.GetTemp();
            if (-5 <= temp && temp <= 45)
            {
                return temp;
            }

            throw new InvalidOperationException();
        }

        public bool RunSelfTest()
        {
            return TempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}