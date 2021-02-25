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

        public void Regulate(double temp)
        {
            temp = TempSensor.GetTemp();
            if (temp < _threshold)
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
            return TempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return TempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}