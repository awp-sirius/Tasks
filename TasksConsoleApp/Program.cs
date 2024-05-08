namespace TasksConsoleApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        Method1();
        Method2();
        await Method3();
        Method4();
        Method5();
        Method6();
        Console.ReadLine();
    }

    /*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-*/

    static void Method1()
    {
        int i = 1;
        Console.WriteLine($"i={i++}");
        Console.WriteLine($"i={i-1}");
        Console.WriteLine($"i={i}");
    }

    /*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-*/

    static List<int> list;
    static DateTime time;

    static void Method2()
    {
        Console.WriteLine(list == null);
        Console.WriteLine(time == null);
    }

    /*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-*/

    static string result = "empty";

    static async Task Method3()
    {
        SaySomething();
        Console.WriteLine(result);
    }

    static async Task<string> SaySomething()
    {
        await Task.Delay(10);
        result = "Hello World";
        return "Something";
    }

    /*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-*/

    static void Method4()
    {
        string s1 = "text";
        object s2 = "text";
        Console.WriteLine(s1 == s2);
        Console.WriteLine(string.Equals(s1, s2));
        s2 = string.Copy(s1);
        Console.WriteLine(s1 == s2);
        Console.WriteLine(string.Equals(s1, s2));
        s2 = s1;
        Console.WriteLine(s1 == s2);
        Console.WriteLine(string.Equals(s1, s2));
    }

    /*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-*/

    static void Method5()
    {
        Dog dog = new Dog();
        dog.Say();

        Animal animal = dog;
        animal.Say();
    }

    internal class Animal
    {
        internal virtual void Say() { Console.WriteLine("animal"); }
    }

    internal class Dog : Animal
    {
        internal override void Say() { Console.WriteLine("dog"); }
    }

    /*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-*/

    static void Method6()
    {
        try
        {
            throw new ArgumentNullException();
        }
        catch (Exception)
        {
            Console.WriteLine("Exception 1");
            try
            {
                throw new ArgumentNullException();
            }
            catch
            {
                throw new Exception();
                Console.WriteLine("Exception 2");
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Exception 3");
        }
        finally
        {
            Console.WriteLine("finally");
        }
    }

    /*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-*/
}