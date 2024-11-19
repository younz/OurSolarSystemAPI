namespace OurSolarSystemAPI.Models
{
    public class Barycenter
    {
        public int id { get; set; } // primary key
        public string name { get; set; }

        public Barycenter(int id, string name) 
        {
            this.id = id;
            this.name = name;
        }
       
    }
}
