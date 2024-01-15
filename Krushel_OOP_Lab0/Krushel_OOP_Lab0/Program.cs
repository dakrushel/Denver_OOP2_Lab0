using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    public static void Main(string[] args)
    {
        /***** Creating Variables *****/

        Console.WriteLine("Enter a low number.");
        string lowString = Console.ReadLine();
        Console.WriteLine("Enter a high number.");
        string highString = Console.ReadLine();

        int lowNum = int.Parse(lowString);
        int highNum = int.Parse(highString);

        int difference = highNum - lowNum;
        Console.WriteLine($"The difference between {lowNum} and {highNum} is {difference}");

        /***** Looping and Input Validation *****/
        static int taskTwoA(int lowNum)
        {
            Console.WriteLine($"Enter another number that is lower than {lowNum}");
            int lowLoopNum;
            while (true)
            {
                string lowLoop = Console.ReadLine();
                if (int.TryParse(lowLoop, out lowLoopNum) && 0 < lowLoopNum && lowLoopNum < lowNum)
                {
                    Console.WriteLine($"{lowLoopNum} is a valid low number.");
                    return lowLoopNum;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Enter a number that is lower than {lowNum}.");
                }
            }
        }
        taskTwoA(lowNum);

        static int taskTwoB(int lowNum)
        {
            Console.WriteLine($"Enter another number that is higher than {lowNum}");
            int highLoopNum;
            while (true)
            {
                string highLoop = Console.ReadLine();
                if (int.TryParse(highLoop, out highLoopNum) && highLoopNum > lowNum)
                {
                    Console.WriteLine($"{highLoopNum} is a valid high number");
                    return highLoopNum;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Enter a number that is higher than {lowNum}.");
                }
            }
        }
        taskTwoB(lowNum);

        static int[] taskThree(int lowNum, int highNum)
        {
            int arrayLength = highNum - (lowNum + 1);
            int[] numList = new int[arrayLength];
            Console.WriteLine("Array elements:");
            for (int i = 0; i < (arrayLength); i++)
            {
                numList[i] = lowNum + (i + 1);
                Console.WriteLine(numList[i]);
            }

            if (!File.Exists("numbers.txt"))
            {
                using (StreamWriter sw = new StreamWriter("numbers.txt"))
                {
                    for(int i = arrayLength; i > 0; i--)
                    {
                        sw.WriteLine(numList[i-1]);
                    }
                }
                Console.WriteLine("numbers.txt successfully created");
            }
            else
            {
                Console.WriteLine("Unfortunately, 'numbers.txt' already exists");
            }

            return numList;
        }
        taskThree(lowNum, highNum);

        static double additionalTasks(int lowNum, int highNum)
        {
            //Read #s from file, store in list, output sum
            List<double> outputList = new List<double>();
            double listSum = 0;
            using (StreamReader sr = new StreamReader("numbers.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    double lineDouble = double.Parse(line);
                    outputList.Add(lineDouble);
                }
                foreach (double num in outputList)
                {
                    listSum += num;
                }
            }
            Console.WriteLine($"The sum of all the numbers in the list is {listSum}.");

            //Went with a nested method prime numbers; not ideal. I'm still missing something in the way C# is written
            //and didn't think I'd have this much trouble figuring it out
            static void isPrimeNum(List<double> list, int lowNum, int highNum)
            {
                Console.WriteLine($"If there are any prime numbers between {lowNum} and {highNum} they are:");
                foreach (double num in list)
                {
                    if (isPrime(num))
                    {
                        Console.WriteLine(num);
                    }
                }
                static bool isPrime(double num)     //Had to borrow from ChatGPT for this one
                {
                    if (num <= 1)
                    {
                        return false;
                    }
                    for (int i = 2; i < num / 2; i++)
                    {
                        if (num % i == 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            isPrimeNum(outputList, lowNum, highNum);
            return listSum;
        }
        additionalTasks(lowNum, highNum);

        //prime # method
    }
}