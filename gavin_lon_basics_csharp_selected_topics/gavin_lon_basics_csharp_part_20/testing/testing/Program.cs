namespace testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Apartment apartment = new Apartment();
            apartment.GetSize() = 1;  //we have 2 GetSize()❌
            apartment.Floor = 1;  //✅
            apartment.HomeAddr = "";  //✅
            

            IDimensionMetric metric = apartment; 
            metric.GetSize();    //✅

            IDimensionImperial imperial = apartment;
            imperial.GetSize(); //✅
        }
    }

    public interface IApartment {
        int Id { get; set; }
        int Floor {get;}
        double SizeInSquareMeters {get;}
    }
    public interface IHome {
        string? HomeAddr { get; set; }
    }
    public interface IDimensionMetric {
        double GetSize();
    }
    public interface IDimensionImperial {
        double GetSize();
    }


    public class Apartment : IHome,  IApartment, IDimensionImperial, IDimensionMetric {
        public int Id { get; set; }
        public string? HomeAddr { get; set; }
        public int Floor { get; set; }
        public double SizeInSquareMeters { get; set; }

        double IDimensionImperial.GetSize() {//👈🏻
            return SizeInSquareMeters;
        }

        double IDimensionMetric.GetSize() {//👈🏻
            double factor = 10.746;
            return SizeInSquareMeters * factor;
        }
    }
}
