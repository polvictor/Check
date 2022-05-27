using System;

namespace Check
{    class Product
    {
        private string name;
        private int count;
        private int price;
        private double discount;
        private double cost;
        public Product(string name, int count, int price, double discount)
        {
            this.name = name;
            this.count = count;
            this.price = price;
            this.discount = discount;
            this.cost = (price - price * (discount / 100)) * count;
        }
        public double Cost
        {
            get { return cost; }
        }
        public void PrintProduct()
        {
            Console.WriteLine("Наименование товара: " + this.name);
            Console.Write(" Количество: " + this.count);
            Console.WriteLine(" Цена: " + this.price + " грн" + " Скидка: " + this.discount + " %");
            Console.WriteLine(" Итого: " + this.cost);
        }
    }
    class Check
    {
        private Product[] products;
        private double total;
        public Check(Product[] array)
        {
            total = 0;
            products = new Product[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                this.products[i] = array[i];
            }
        }
        public void Print()
        {
            Console.WriteLine("     Fozzy Group   ");
            Console.WriteLine("Чек # 0001");
            Console.WriteLine("Дата и время: " + DateTime.Now);
            Console.WriteLine("Список продуктов: ");
            for (int i = 0; i < this.products.Length; i++)
            {
                this.products[i].PrintProduct();
                this.total += this.products[i].Cost;
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("Итого к оплате: " + this.total + " грн.");
            Console.WriteLine();            
        }
        public void AddProduct(Product other)
        {
            Array.Resize(ref products, products.Length + 1);
            products[products.Length - 1] = other;
        }
        public void AddProduct(string name, int count, int price, double discount)
        {
            this.AddProduct(new Product(name, count, price, discount));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Product[] p = new Product[5];
            p[0] = new Product("Хлеб", 1, 17, 5);
            p[1] = new Product("Молоко", 2, 33, 15);
            p[2] = new Product("Сыр плавленный", 3, 15, 0);
            p[3] = new Product("Чай черный", 1, 55, 10);
            p[4] = new Product("Макароны", 2, 35, 10);
            
            Check c = new Check(p);
            c.Print();
        }
    }
}
