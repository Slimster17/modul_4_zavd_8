using System.Text;
using System.Text.Json;

namespace modul_4_zavd_8
{
    class Dish : IComparable<Dish> // Клас страва
    {
        public string Name { get; set; } // Назва страви
        public int Weight { get; set; } // Вага страви
        public double Price { get; set; } // Ціна страви
        public List<string> Ingredients { get; set; } // Інгредієнти для приготування

        public Dish(string name, int weight, double price, List<string> ingredients) // Конструктор
        {
            Name = name;
            Weight = weight;
            Price = price;
            Ingredients = ingredients;
        }

        public int CompareTo(Dish? other) // Метод порівняння ціни об'єктів класу
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other.Price);
        }
    }

    class Program
    {
        static void Main(string[] args)

        {
            Console.OutputEncoding = Encoding.UTF8; // Кодування для виводу символів на консоль

            SortedList<string, Dish> menu = new SortedList<string, Dish>(); // Колекція

            // Додавання страв до меню
            menu.Add("Борщ", new Dish("Борщ", 300, 50.0, new List<string> { "Свинина", "Буряк", "Картопля", "Капуста", "Морква" }));
            menu.Add("Піца", new Dish("Піца", 500, 120.0, new List<string> { "Томатний соус", "Сир", "Шинка", "Оливки", "Перець" }));
            menu.Add("Піца2", new Dish("Піца", 500, 120.0, new List<string> { "Томатний соус", "Сир", "Шинка", "Оливки", "Перець" }));
            menu.Add("Салат", new Dish("Салат", 200, 35.0, new List<string> { "Помідори", "Огірки", "Зелень", "Олія" }));

            // Виведення всіх страв у меню
            Console.WriteLine("Весь список страв:");


            foreach (KeyValuePair<string, Dish> kvp in menu)
            {

                Console.WriteLine($"{kvp.Key} - {kvp.Value.Price} грн");
            }

            // Знаходить найдорожчу страву
            Dish mostExpensiveDish = menu.Values.Max();
            Console.WriteLine(new string('*', 50));
            Console.WriteLine("Найдорожча страва: " + mostExpensiveDish.Price);

            // Видалення страви з меню
            menu.Remove("Салат");




            // Виведення оновленого списку страв
            Console.WriteLine(new string('*', 50));
            Console.WriteLine("Оновлений список страв після видалення:");
            foreach (KeyValuePair<string, Dish> kvp in menu)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value.Price} грн");
            }
            Console.WriteLine(new string('*', 50));

            // Серіалізація та десеріалізація
            string json = JsonSerializer.Serialize(menu);
            Console.WriteLine(json);

            Console.WriteLine(new string('*', 50));
            SortedList<string, Dish> deserializedMenu = JsonSerializer.Deserialize<SortedList<string, Dish>>(json);
            Console.WriteLine($"Кількість страв у десеріалізованому меню: {deserializedMenu.Count}");
        }
    }
}
