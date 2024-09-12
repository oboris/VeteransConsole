using System;


using System.Text.Json;

using System.Text.Json.Serialization;

namespace _2dArray
{
    [JsonDerivedType(typeof(MilkFood), 1)]
    [JsonDerivedType(typeof(MeatFood), 2)]
    [JsonDerivedType(typeof(BakeryFood), 3)]
    abstract class GeneralFood
    {
        public double Fat { set; get; }
        public double Proteins { set; get; }
        public double Carbs { set; get; }

        public GeneralFood(double fat, double proteins, double carbs)
        {
            Fat = fat;
            Proteins = proteins;
            Carbs = carbs;
        }

        public abstract string GetDescription();
    }

    class MeatFood : GeneralFood
    {
        public string Type { set; get; }

        public MeatFood(double fat, double proteins, double carbs, string type) : base(fat, proteins, carbs)
        {
            Type = type;
        }

        public override string GetDescription()
        {
            return $"this is meat - {Type}";
        }
    }

    class MilkFood : GeneralFood
    {
        public string Type { set; get; }
        public string Origin { set; get; }

        public MilkFood(double fat, double proteins, double carbs, string type, string origin) : base(fat, proteins, carbs)
        {
            Type = type;
            Origin = origin;
        }

        public override string GetDescription()
        {
            return $"This is milk food {Type} {Origin}";
        }
    }

    class BakeryFood : GeneralFood
    {
        public string Name { set; get; }
        public double Weight { set; get; }

        public BakeryFood(double fat, double proteins, double carbs, string name, double weight) : base(fat, proteins, carbs)
        {
            Name = name;
            Weight = weight;
        }

        public override string GetDescription()
        {
            return $"This is Bakery {Name} {Weight}";
        }
    }

    internal class Program
    {
        static GeneralFood[] foods = new GeneralFood[100];
        static int foodsNumber = 0;
        static void MainMenuShow()
        {
            while (true)
            {
                Console.WriteLine("1. Create milk food");
                Console.WriteLine("2. Print all foods");
                Console.WriteLine("3. Save all foods to file");
                Console.WriteLine("4. Load all foods from file");

                Console.Write("Select menu: ");
                int menuItem = Convert.ToInt32(Console.ReadLine());
                switch (menuItem)
                {
                    case 1:
                        {
                            CreateMilk();
                            break;
                        }
                    case 2:
                        {
                            PrintAllFoods();
                            break;
                        }
                    case 3:
                        {
                            SaveAllFoods();
                            break;
                        }
                    case 4:
                        {
                            LoadAllFoods();
                            break;
                        }

                }
            }
        }

        private static void LoadAllFoods()
        {
            string foodsJson = File.ReadAllText("d:\\temp\\foods.json");
            GeneralFood[] listFood = JsonSerializer.Deserialize<GeneralFood[]>(foodsJson);
            foodsNumber = 0;
            for (int i = 0; i < listFood.Length; i++)
            {
                foods[i] = listFood[i];
                foodsNumber++;
            }
        }

        private static void SaveAllFoods()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            GeneralFood[] food1 = new GeneralFood[foodsNumber];
            for (int i = 0; i < foodsNumber; i++)
            {
                food1[i] = foods[i];
            }
            string foodsJson = JsonSerializer.Serialize(food1, options);
            
            File.WriteAllText("d:\\temp\\foods.json", foodsJson);
        }

        private static void PrintAllFoods()
        {
            for (int i = 0; i < foodsNumber; i++)
            {
                Console.WriteLine(foods[i].GetDescription());
            }
        }

        private static void CreateMilk()
        {
            MilkFood milk = new MilkFood(50, 100, 100, "kefir", "Cow");
            foods[foodsNumber] = milk;
            foodsNumber++;
        }

        static void Main(string[] args)
        {

            MainMenuShow();            
    
        }
    }
}