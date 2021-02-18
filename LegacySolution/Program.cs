namespace LegacySolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            IHeater heater = new Heater();
            ITempSensor tempSensor = new TempSensor();

            var ecs = new ECS(28, heater);

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate(); //test
            ecs.RunSelfTest(tempSensor, heater);
        }
    }
}
