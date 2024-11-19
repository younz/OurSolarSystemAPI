namespace OurSolarSystemAPI.Models
{
    public class EphemerisPlanet(
        int id,
        int planetId,
        double positionX,
        double positionY,
        double positionZ,
        double velocityX,
        double velocityY,
        double velocityZ,
        double epoch,
        string timestampDay,
        string timestampMonth,
        string timestampYear,
        string timestampHour,
        string timestampMinute,
        double julianDay)
    {
        public int ID = id;
        public int PlanetID = planetId; 
        public double PositionX = positionX;
        public double PositionZ = positionZ;
        public double PositionY = positionY;
        public double VelocityX = velocityX;
        public double VelocityY = velocityY;
        public double VelocityZ = velocityZ;
        public double Epoch = epoch;
        public string TimestampDay = timestampDay;
        public string TimestampMonth = timestampMonth;
        public string TimestampYear = timestampYear;
        public string TimestampHour = timestampHour;
        public string TimestampMinute = timestampMinute;
        public double JulianDay = julianDay;

        public DateTime Timestamp
        {
            get
            {
                int year = int.Parse(TimestampYear);
                int month = int.Parse(TimestampMonth);
                int day = int.Parse(TimestampDay);
                int hour = int.Parse(TimestampHour);
                int minute = int.Parse(TimestampMinute);

                return new DateTime(year, month, day, hour, minute, 0);
            }
            set
            {
                TimestampDay = value.Day.ToString();
                TimestampMonth = value.Month.ToString();
                TimestampYear = value.Year.ToString();
                TimestampHour = value.Hour.ToString();
                TimestampMinute = value.Minute.ToString();
            }
        }
    }
}
