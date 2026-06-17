namespace testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product phone = new Phone();

            phone.MemorySizeGB = 2; //❌

            ((Phone)phone).MemorySizeGB = 2; //✅

        }
    }


    //public class FoldableLaptop : PC, Phone {
    public class FoldableLaptop : PC{

    }

    public class PC : Product {

        public PC() {}
    
    }


    public class Phone : Product {
        
        public int MemorySizeGB {  get; set; }

        public Phone() {
            MemorySizeGB = 1;
        }
    }

    public abstract class Product {

        private static int _idGen = 0;
        private int _pid;

        public int PId {get;}
        public decimal Price { get; set; }

        public Product() {
            this._pid = _idGen;
            _idGen++;
        }

    }

}
