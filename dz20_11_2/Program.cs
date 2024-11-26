namespace dz20_11_2
{
    class Money
    {

        private int wholePart; // кароче ну бакси,еуро і гривні
        private int centsPart; //копійки
        private string currency; 


        public Money(int whole, int cents, string currencyName)
        {
            wholePart = whole;
            centsPart = cents;
            currency = currencyName;
        }


        public int WholePart
        {
            get { return wholePart; }
            set { wholePart = value; }
        }

        public int CentsPart
        {
            get { return centsPart; }
            set { centsPart = value; }
        }

        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }


        public void ShowAmount()
        {
            Console.WriteLine($"{wholePart}.{centsPart:D2} {currency}");//D2 кароче центики в двох числах
        }
    }

    class Product
    {
        private string name; 
        private Money price; 


        public Product(string productName, Money productPrice)
        {
            name = productName;
            price = productPrice;
        }
        public void ReducePrice(int whole, int cents)
        {
   
            int totalCents = price.WholePart * 100 + price.CentsPart;
            int reduceCents = whole * 100 + cents;

            if (totalCents < reduceCents)
            {
                totalCents = 0;
            }
            else
            {
                totalCents -= reduceCents;
            }


            price.WholePart = totalCents / 100;
            price.CentsPart = totalCents % 100;
        }


        public void ShowInfo()
        {
            Console.Write($"{name} коштує ");
            price.ShowAmount();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Money uahMoney = new Money(50, 75, "грн"); // 50 грн 75 коп.
            Money usdMoney = new Money(10, 50, "USD"); // 10 долярів 50 центів
            Money eurMoney = new Money(20, 99, "EUR"); // 20 євуро 99 центів
            Console.WriteLine("Доступні різні валюти:");
            uahMoney.ShowAmount();
            usdMoney.ShowAmount();
            eurMoney.ShowAmount();

            Console.WriteLine("\nІнформація про молоко:");
            Product product = new Product("Молоко", uahMoney);
            product.ShowInfo();


            Console.WriteLine("\n\nЗменшую ціну на 10.50 грн");
            product.ReducePrice(10, 50);
            product.ShowInfo();

            
            Console.WriteLine("\n\nЗмінюю ціну на долари:");
            product = new Product("Молоко", usdMoney);
            product.ShowInfo();


            Console.WriteLine("\n\nпродукт у євро:");
            product = new Product("Молоко", eurMoney);
            product.ShowInfo();

            Console.WriteLine("\nНІ ОБАМА, Я НЕ ХОЧУ В ЖИТОМР");
        }
    }
}
