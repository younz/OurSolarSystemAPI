namespace OurSolarSystemAPI.Models
{
    public class Barycenter(int id, string name)
    {
        public int ID { get; set; } = id;
        public string Name { get; set; } = name;
    }
}
