namespace OurSolarSystemAPI.Models
{
    public class Ephemeris
    {
        private double positionX { get; set; }
        private double positionZ { get; set; }
        private double positionY { get; set; }
        private double velocityX { get; set; }
        private double velocityY { get; set; }
        private double velocityZ { get; set; }
        private double epoch { get; set; }
        private int objectId { get; set; }
        private int objectTypeId { get; set; }
        private string timestampDay { get; set; }
        private string timestampMonth { get; set; }
        private string timestampYear { get; set; }
        private string timestampHour { get; set; }
        private string timestampMinute { get; set; }
        private double julianDay { get; set; }
        public DateTime Timestamp
        {
            get
            {
                int year = int.Parse(timestampYear);
                int month = int.Parse(timestampMonth);
                int day = int.Parse(timestampDay);
                int hour = int.Parse(timestampHour);
                int minute = int.Parse(timestampMinute);

                return new DateTime(year, month, day, hour, minute, 0);
            }
            set
            {
                timestampDay = value.Day.ToString();
                timestampMonth = value.Month.ToString();
                timestampYear = value.Year.ToString();
                timestampHour = value.Hour.ToString();
                timestampMinute = value.Minute.ToString();
            }
        }

        public Ephemeris(
            double positionX,
            double positionY,
            double positionZ,
            double velocityX,
            double velocityY,
            double velocityZ,
            double epoch,
            int objectId,
            int objectTypeId,
            string timestampDay,
            string timestampMonth,
            string timestampYear,
            string timestampHour,
            string timestampMinute,
            double julianDay)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.positionZ = positionZ;
            this.velocityX = velocityX;
            this.velocityY = velocityY;
            this.velocityZ = velocityZ;
            this.epoch = epoch;
            this.objectId = objectId;
            this.objectTypeId = objectTypeId;
            this.timestampDay = timestampDay;
            this.timestampMonth = timestampMonth;
            this.timestampYear = timestampYear;
            this.timestampHour = timestampHour;
            this.timestampMinute = timestampMinute;
            this.julianDay = julianDay;
        }


    }
}
