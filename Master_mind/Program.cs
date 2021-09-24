using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_mind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n..........CLICK 'H' TO ENTER INTO THE GAME...........");
            string click=Console.ReadLine();
            while (click == "H" || click == "h")
            {
                colors1();
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t\tMASTER MIND\t\t\t");
                Console.WriteLine("\n\n\t\t\t\t|--------|\n\t\t\t\t|NEW GAME|\t-> click-'G'\n\t\t\t\t|--------|");
                Console.WriteLine("\n\n\t\t\t\tHOW TO PLAY ?\t-> click-'P'");
                Console.WriteLine();
                string option = Console.ReadLine();
                Console.WriteLine();
                if (option == "P" || option == "p")
                {
                    Console.Clear();
                    colors2();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\t\t\t\t HOW TO PLAY ?");
                    Console.WriteLine("\n*****************************************************************************************");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    rules();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n************************CLICK 'H' to go home page******************************");
                    click = Console.ReadLine();                                        
                }
                while (option == "g" || option == "G")
                {
                    Console.Clear();
                    colors2();
                    Console.WriteLine("\n\n\n\n\t\t\t|------|\t\t|------|\n\t\t\t| EASY |\t\t|MEDIUM|\n\t\t\t|------|\t\t|------|");
                    Console.WriteLine("\t\t\t   |   \t\t\t    |   \n\t\t\t   v   \t\t\t    v   ");
                    Console.WriteLine("\t\t\t click 'E' \t\t click 'M'");
                    string mode = Console.ReadLine();
    
                    if (mode == "e" || mode == "E")
                    {
                        Console.Clear();
                        colors2();
                        int[] secretcode=new int[4];
                        int count = 6;
                        codegenerator(secretcode, count);
                        Console.WriteLine("choose only four colores :Red-1\t\tGreen-2\t\tyellow-3\tBlue-4\t\tCyan-5");
                        Console.WriteLine("Example input: 2 3 4 5 \t=> (GREEN ,YELLOW ,BLUE, CYAN)");
                        int count1 = 0;
                        int totalrounds = 5;
                        bool flag = false;
                        int attempt = 0;
                        for (int i = 0; i < totalrounds; i++)
                        {
                            Console.WriteLine("\nAttempt : " + (i + 1));
                            int[] userchoose = Getinput();
                            displaycolor(userchoose);
                            CheckUserChoice(secretcode, userchoose);
                            count1 = output(secretcode, userchoose);
                            attempt = i + 1;
                            if (count1 == secretcode.Length)
                            {
                                flag = true;
                                break;
                            }
                        }
                        displayoutput(flag, attempt);
                        Console.WriteLine("\n\tSCORE =" + displayscore(attempt, totalrounds)+" out of "+(totalrounds*10));
                    }
                    else if (mode == "m" || mode == "M")
                    {
                        Console.Clear();
                        colors2();
                        int[] secretcode = new int[4];
                        int count = 9;
                        codegenerator(secretcode, count);
                        Console.WriteLine("choose only four colores :\nRed-1\t\tGreen-2\t\tyellow-3\tBlue-4\t\tCyan-5\tWhite-6\tBlack-7\tPink-8");
                        Console.WriteLine("Example input: 2 3 4 5 \t=> (GREEN ,YELLOW ,BLUE, CYAN)");
                        int count1 = 0;
                        int totalrounds = 10;
                        bool flag = false;
                        int attempt = 0;
                        for (int i = 0; i < totalrounds; i++)
                        {
                            Console.WriteLine("\nAttempt : " + (i + 1));
                            int[] userchoose = Getinput();
                            displaycolor(userchoose);
                            CheckUserChoice(secretcode, userchoose);
                            count1 = output(secretcode, userchoose);
                            attempt = i + 1;
                            if (count1 == secretcode.Length)
                            {
                                flag = true;
                                break;
                            }
                        }
                        displayoutput(flag, attempt);
                        Console.WriteLine("\n\tSCORE =" + displayscore(attempt, totalrounds) + " out of " + (totalrounds * 10));
                    }
                    Console.WriteLine("\n------If you want to play again..click 'g'------");
                    option = Console.ReadLine();
                }
                Console.Clear();
                Console.WriteLine("\n\n-----------For home screen ..click 'H'");
            }
        }

        public static void rules()
        {
           
            Console.WriteLine("You are a code breaker,and your goal is to guess the secret code.\n\nThe code is a sequence of colored pins,and on each round after you make guess you will get hints\nwhich will help to improve your guess\n you have only 5 rounds");
            Console.WriteLine("\nThe hints are either WITHE OR BLACK :\n * WHITE -one of your guess pins has the correct color But is on the worng position.\n * BLACK -one of your guess pins has the correct color and is on the correct position.");
        }
        public static int[] codegenerator(int[] array,int size)
        {
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(1, size);
            }
            return array;
        }
        public static int[] Getinput()
        {

         
            Console.WriteLine("Enter you guess :");
            string[] s = Console.ReadLine().Split();
            int[] userinput = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                userinput[i] =Convert.ToInt32(s[i]);                
            }
            return userinput;
        }
        public static void colors1()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
        }
        public static void colors2()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        public static void Defaultcolors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
        public static void CheckUserChoice(int[] secretcode, int[] userchoose)
        {
            for (int i = 0; i < secretcode.Length; i++)
            {
                int count = 0;
                int count1 = 0;
                for (int j = 0; j < userchoose.Length; j++)
                {
                    if (secretcode[i] == userchoose[j] && i == j)
                    {
                        
                        Console.Write((i + 1) + ":");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("  BLACK");
                        Console.WriteLine();
                       
                        count++;
                        break;
                    }
                    else if (secretcode[i] == userchoose[j])
                    {
                        count1++;
                    }
                }
                if (count1 > 0 && secretcode[i] != userchoose[i])
                {
                    Console.Write((i + 1) + ":");
                    Console.ForegroundColor = ConsoleColor.White;                    
                    Console.Write("  WHITE");
                    Console.WriteLine();
                }
                else if (count == 0 && count1 == 0)
                {
                    Console.WriteLine((i + 1) + ": .....");
                }
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
        public static int output(int[] secretcode, int[] userchoose)
        {
            int count = 0;
            for (int i = 0; i < secretcode.Length; i++)
            {
                if (secretcode[i] == userchoose[i])
                {
                    count++;
                }
            }
            return count;
        }
        public static void displaycolor(int[] userchoose)
        {
            for (int j = 0; j < userchoose.Length; j++)
            {
                if (userchoose[j] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("RED ");
                }
                else if (userchoose[j] == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("GREEN ");
                }
                else if (userchoose[j] == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("YELLOW ");
                }
                else if (userchoose[j] == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("BLUE ");
                }
                else if (userchoose[j] == 5)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("CYAN ");
                }
                else if (userchoose[j] == 6)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("WHITE ");
                }
                else if (userchoose[j] == 7)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("BLACK ");
                }
                else if (userchoose[j] == 8)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("PINK ");
                }
                if (j != userchoose.Length - 1)
                {
                    Console.Write(", ");
                }
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine();
        }
        public static void displayoutput(bool flag,int attempt)
        {
            if (flag == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("\n\t\t\t\t|***************|\n\t\t\t\t|YOU ARE WINNER |\n\t\t\t\t|***************|");
                Console.WriteLine("\n\t\tNo.Of.Attempt you taken to crack the secret code =" + attempt);
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t\t|***************|\n\t\t\t\t| YOU ARE LOSER |\n\t\t\t\t|***************|");
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
        public static int displayscore(int attempt , int rounds)
        {

            int score = rounds * 10;
            for (int i = 0; i < (attempt-1); i++)
            {
                score -= 10;
            }
            return score;
            
        }
      
       
    }
}
