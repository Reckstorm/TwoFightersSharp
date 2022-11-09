using System;
using System.IO;
using TwoFighters.Fighters;

Random random = new Random();
Fighter a = new Fighter(); 
Fighter b = new Fighter(); 
double? temp = 0;
int roll;
bool f = false;
ConsoleKeyInfo ch;

do
{
    Console.Clear();
    Console.Write("Choose action:\n1 - Play the game\nEsc - exit\n");
    
    ch = Console.ReadKey();
    if (ch.KeyChar == '1')
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Choose weapon for the first fighter:\n1 - Pike\n2 - Two-hand Sword\n3 - Shield and sword\nEsc - exit\n");
            ch = Console.ReadKey();
            if (ch.KeyChar == '1')
            {
                a = new Pikeman();
            }
            else if (ch.KeyChar == '2')
            {
                a = new Swordsman();
            }
            else if (ch.KeyChar == '3')
            {
                a = new Shieldsman();
            }
            else if (ch.KeyChar == 27)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid command");
            }
        } while (a.Name == "Fighter");
        do
        {
            Console.Clear();
            Console.WriteLine("Choose weapon for the second fighter:\n1 - Pike\n2 - Two-hand Sword\n3 - Shield and sword\nEsc - exit\n");
            ch = Console.ReadKey();
            if (ch.KeyChar == '1')
            {
                b = new Pikeman();
            }
            else if (ch.KeyChar == '2')
            {
                b = new Swordsman();
            }
            else if (ch.KeyChar == '3')
            {
                b = new Shieldsman();
            }
            else if (ch.KeyChar == 27)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid command");
            }
        } while (b.Name == "Fighter");
        Console.WriteLine("Roll for the first strike");
        roll = random.Next(1, 11);
        if (roll > 5)
        {
            Console.Clear();
            Console.WriteLine($"{b.Name} strikes first\nChoose strike type:\n1 - fast strike\n2 - normal strike\n3 - hard strike\nEsc - exit\n");
            f = true;
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"{a.Name} strikes first\nChoose strike type:\n1 - fast strike\n2 - normal strike\n3 - hard strike\nEsc - exit\n");
        }
        do
        {
            ch = Console.ReadKey();
            Console.Clear();
            if (f)
            {
                if (ch.KeyChar == '1')
                {
                    temp = b.Fight?.Invoke(1);
                    if (temp == (-1))
                    {
                        Console.WriteLine($"{a.Name} blocked");
                        Console.WriteLine($"{b.Name} has {b.Hp} left\n{a.Name} has {a.Hp} left");
                        f = false;
                    }
                    else if (temp == (-2))
                    {
                        Console.WriteLine($"{a.Name} dodged");
                        Console.WriteLine($"{b.Name} has {b.Hp} left\n{a.Name} has {a.Hp} left");
                        f = false;
                    }
                    else
                    {
                        a.Hp -= temp;
                        if (b.FlagCrit)
                        {
                            Console.WriteLine($"Critical strike!\n{b.Name} strikes for {temp}\n{b.Name} has {b.Hp} left\n{a.Name} has {a.Hp} left");
                            temp = 0;
                            f = false;
                        }
                    }
                }
                else if (ch.KeyChar == '2')
                {
                    temp = b.Fight?.Invoke(2);
                    if (temp == (-1))
                    {
                        Console.WriteLine($"{a.Name} blocked");
                        Console.WriteLine($"{b.Name} has {b.Hp} left\n{a.Name} has {a.Hp} left");
                        f = false;
                    }
                    else if (temp == (-2))
                    {
                        Console.WriteLine($"{a.Name} dodged");
                        Console.WriteLine($"{b.Name} has {b.Hp} left\n{a.Name} has {a.Hp} left");
                        f = false;
                    }
                    else
                    {
                        a.Hp -= temp;
                        if (b.FlagCrit)
                        {
                            Console.WriteLine($"Critical strike!\n{b.Name} strikes for {temp}\n{b.Name} has {b.Hp} left\n{a.Name} has {a.Hp} left");
                            temp = 0;
                            f = false;
                        }
                    }
                }
                else if (ch.KeyChar == '3')
                {
                    temp = b.Fight?.Invoke(3);
                    if (temp == (-1))
                    {
                        Console.WriteLine($"{a.Name} blocked");
                        Console.WriteLine($"{b.Name} has {b.Hp} left\n{a.Name} has {a.Hp} left");
                        f = false;
                    }
                    else if (temp == (-2))
                    {
                        Console.WriteLine($"{a.Name} dodged");
                        Console.WriteLine($"{b.Name} has {b.Hp} left\n{a.Name} has {a.Hp} left");
                        f = false;
                    }
                    else
                    {
                        a.Hp -= temp;
                        if (b.FlagCrit)
                        {
                            Console.WriteLine($"Critical strike!\n{b.Name} strikes for {temp}\n{b.Name} has {b.Hp} left\n{a.Name} has {a.Hp} left");
                            temp = 0;
                            f = false;
                        }
                    }
                }
                else if (ch.KeyChar == 27)
                {
                    Console.WriteLine("Bye!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid command");
                    Console.ReadKey();
                }
                if (a.Hp <= 0)
                {
                    Console.WriteLine($"{b.Name} wins!");
                    Console.ReadKey();
                    break;
                }
                if (b.Hp <= 0)
                {
                    Console.WriteLine($"{a.Name} wins!");
                    Console.ReadKey();
                    break;
                }
            }
            else
            {
                if (ch.KeyChar == '1')
                {
                    temp = a.Fight?.Invoke(1);
                    if (temp == (-1))
                    {
                        Console.WriteLine($"{b.Name} blocked");
                        Console.WriteLine($"{a.Name} has {a.Hp} left\n{b.Name} has {b.Hp} left");
                        f = true;
                    }
                    else if (temp == (-2))
                    {
                        Console.WriteLine($"{b.Name} dodged");
                        Console.WriteLine($"{a.Name} has {a.Hp} left\n{b.Name} has {b.Hp} left");
                        f = true;
                    }
                    else
                    {
                        b.Hp -= temp;
                        if (a.FlagCrit)
                        {
                            Console.WriteLine($"Critical strike!\n{a.Name} strikes for {temp}\n{a.Name} has {a.Hp} left\n{b.Name} has {b.Hp} left");
                            temp = 0;
                            f = true;
                        }
                    }
                }
                else if (ch.KeyChar == '2')
                {
                    temp = a.Fight?.Invoke(2);
                    if (temp == (-1))
                    {
                        Console.WriteLine($"{b.Name} blocked");
                        Console.WriteLine($"{a.Name} has {a.Hp} left\n{b.Name} has {b.Hp} left");
                        f = true;
                    }
                    else if (temp == (-2))
                    {
                        Console.WriteLine($"{b.Name} dodged");
                        Console.WriteLine($"{a.Name} has {a.Hp} left\n{b.Name} has {b.Hp} left");
                        f = true;
                    }
                    else
                    {
                        b.Hp -= temp;
                        if (a.FlagCrit)
                        {
                            Console.WriteLine($"Critical strike!\n{a.Name} strikes for {temp}\n{a.Name} has {a.Hp} left\n{b.Name} has {b.Hp} left");
                            temp = 0;
                            f = true;
                        }
                    }
                }
                else if (ch.KeyChar == '3')
                {
                    temp = a.Fight?.Invoke(3);
                    if (temp == (-1))
                    {
                        Console.WriteLine($"{b.Name} blocked");
                        Console.WriteLine($"{a.Name} has {a.Hp} left\n{b.Name} has {b.Hp} left");
                        f = true;
                    }
                    else if (temp == (-2))
                    {
                        Console.WriteLine($"{b.Name} dodged");
                        Console.WriteLine($"{a.Name} has {a.Hp} left\n{b.Name} has {b.Hp} left");
                        f = true;
                    }
                    else
                    {
                        b.Hp -= temp;
                        if (a.FlagCrit)
                        {
                            Console.WriteLine($"Critical strike!\n{a.Name} strikes for {temp}\n{a.Name} has {a.Hp} left\n{b.Name} has {b.Hp} left");
                            temp = 0;
                            f = true;
                        }
                    }
                }
                else if (ch.KeyChar == 27)
                {
                    Console.WriteLine("Bye!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid command");
                    Console.ReadKey();
                }
                if (a.Hp <= 0)
                {
                    Console.WriteLine($"{b.Name} wins!");
                    Console.ReadKey();
                    break;
                }
                if (b.Hp <= 0)
                {
                    Console.WriteLine($"{a.Name} wins!");
                    Console.ReadKey();
                    break;
                }
            }
        } while (true);
    }
    else if (ch.KeyChar == 27)
    {
        Console.Clear();
        Environment.Exit(0);
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Invalid command");
        Console.ReadKey();
    }
} while (true);