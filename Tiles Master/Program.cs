using System;
using System.Collections.Generic;
using System.Linq;

namespace Tiles_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTiles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] grayTiles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> whiteStack = new Stack<int>(whiteTiles);
            Queue<int> grayQuaeue = new Queue<int>(grayTiles);


            Dictionary<string, int> output = new Dictionary<string, int>();
            output.Add("Floor", 0);
            output.Add("Sink", 0);
            output.Add("Oven", 0);
            output.Add("Countertop", 0);
            output.Add("Wall", 0);
            int sum = 0;
            while (grayQuaeue.Count != 0 && whiteStack.Count != 0)
            {

                if (whiteStack.Peek() == grayQuaeue.Peek())
                {
                    sum = whiteStack.Peek() + grayQuaeue.Peek();
                    if (sum == 40)
                    {
                        whiteStack.Pop();
                        grayQuaeue.Dequeue();
                        output["Sink"] += 1;
                    }
                    else if (sum == 50)
                    {
                        whiteStack.Pop();
                        grayQuaeue.Dequeue();
                        output["Oven"] += 1;
                    }
                    else if (sum == 60)
                    {
                        whiteStack.Pop();
                        grayQuaeue.Dequeue();
                        output["Countertop"] += 1;
                    }
                    else if (sum == 70)
                    {
                        whiteStack.Pop();
                        grayQuaeue.Dequeue();
                        output["Wall"] += 1;
                    }
                    else
                    {
                        whiteStack.Pop();
                        grayQuaeue.Dequeue();
                        output["Floor"] += 1;
                    }
                }
                else if (whiteStack.Peek() != grayQuaeue.Peek())
                {
                    int decreased = whiteStack.Peek() / 2;
                    whiteStack.Pop();
                    whiteStack.Push(decreased);
                    int decrQue = grayQuaeue.Peek();
                    grayQuaeue.Dequeue();
                    grayQuaeue.Enqueue(decrQue);
                }

            }

            if (whiteStack.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            if (whiteStack.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteStack)}");
            }
            if (grayQuaeue.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            if (grayQuaeue.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grayQuaeue)}");

            }
            foreach (var item in output.OrderBy(x => x.Key).OrderByDescending(x => x.Value).Where(x => x.Value > 0))
            {

                Console.WriteLine($"{item.Key}: {item.Value}");

            }
        }
    }
}
