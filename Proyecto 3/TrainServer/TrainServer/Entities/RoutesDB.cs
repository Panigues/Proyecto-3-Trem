namespace TrainServer.Entities
{
    public class RoutesDB
    {
        public static List<TrainRoute> routes = new() {
            new TrainRoute("Cartago", "San Jose"),
            new TrainRoute("San Jose", "Heredia")
        };
    }
}
