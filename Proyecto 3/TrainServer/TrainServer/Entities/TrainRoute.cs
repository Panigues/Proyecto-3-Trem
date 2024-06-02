namespace TrainServer.Entities
{
    public class TrainRoute
    {
        public decimal Cost { get; set; }

        public decimal DistanceInKm { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public TrainRoute(string start, string end) { 
            Start = start;
            End = end;
        }
    }
}
