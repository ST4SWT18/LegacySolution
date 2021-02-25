namespace LegacySolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            IHeater heater = new Heater();
            ITempSensor tempSensor = new TempSensor();
            double temp = tempSensor.GetTemp();

            var ecs = new ECS(28, heater);

            ecs.Regulate(temp);

            ecs.SetThreshold(20);

            ecs.Regulate(temp); //test
            ecs.RunSelfTest(tempSensor, heater);
        }
    }
}
