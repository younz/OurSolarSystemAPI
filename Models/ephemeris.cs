namespace OurSolarSystemAPI.Models
{
    public class ephemeris
    {
        public double position_x { get; set; }
        public double position_y { get; set; }
        public double position_z { get; set; }
        public double velocity_x { get; set; }
        public double velocity_y { get; set; }
        public double velocity_z { get; set; }
        public double epoch { get; set; }
        public int object_id { get; set; }
        public int object_type_id { get; set; }
        public string timestamp_day { get; set; }
        public string timestamp_month { get; set; }
        public string timestamp_year { get; set; }
        public string timestamp_hour { get; set; }
        public string timestamp_minute { get; set; }
        public double julian_day_format { get; set; }
        public DateTime Timestamp
        {
            get
            {
                int year = int.Parse(timestamp_year);
                int month = int.Parse(timestamp_month);
                int day = int.Parse(timestamp_day);
                int hour = int.Parse(timestamp_hour);
                int minute = int.Parse(timestamp_minute);

                return new DateTime(year, month, day, hour, minute, 0);
            }
        }
    }
}
