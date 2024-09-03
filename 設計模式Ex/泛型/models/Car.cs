using 泛型.Interface;

namespace 泛型.models
{
    public class Car : Transportation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string Type { get; set; }

        public string CarDoor { get; set; }

        public string Engine { get; set; }


        public void Run()
        { 
        
        }
    }
}