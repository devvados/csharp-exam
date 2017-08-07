using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesTask
{
    class Program
    {
        static List<Figure> figures = new List<Figure>();

        static void Main(string[] args)
        {
            int count = 0;
            Random rand = new Random();
             
            Console.Write("Выберите количество генерируемых фигур: ");
            Int32.TryParse(Console.ReadLine(), out count);

            CreateRandomShape(count, rand);

            foreach (var f in figures)
            {
                Console.WriteLine(String.Format("Тип: {0}, Площадь: {1}", f.GetType().ToString().Split('.')[1], f.Square()));
            }
        }

        public static void CreateRandomShape(int count, Random r)
        {
            List<string> figureTypes = new List<string> { "Rectangle", "Triangle" };

            for (int i = 0; i < count; i++)
            {
                var rand = r.Next(0, figureTypes.Count);
                switch (rand)
                {
                    case 0:
                        figures.Add(new Rectangle());
                        break;
                    case 1:
                        figures.Add(new Triangle());
                        break;
                }
            }
        }
    }
}
