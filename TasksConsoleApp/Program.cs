namespace TasksConsoleApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine(nameof(Method1));
        Method1();
        Console.WriteLine();

        Console.WriteLine(nameof(Method2));
        Method2();
        Console.WriteLine();

        Console.WriteLine(nameof(Method3));
        await Method3();
        Console.WriteLine();

        Console.WriteLine(nameof(Method4));
        Method4();
        Console.WriteLine();

        Console.WriteLine(nameof(Method5));
        Method5();
        Console.WriteLine();

        Console.WriteLine(nameof(Method6));
        Method6();
        Console.WriteLine();

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

    static string taskRes = "empty";

    static async Task Method3()
    {
        Task<string> task = GetResAsync().ContinueWith(tsk => { taskRes = "finish"; return "return"; });
        Thread.Sleep(10);
        Console.WriteLine(taskRes);

        task.Start();
        Thread.Sleep(10);
        Console.WriteLine(taskRes);

        taskRes = task.Result;
        Console.WriteLine(taskRes);

        await task;
        Console.WriteLine(taskRes);

        taskRes = "empty";
        GetResAsync();
        Console.WriteLine(taskRes);
    }

    static async Task<string> GetResAsync()
    {
        taskRes = "start";
        await Task.Delay(50);
        return "method";
    }

    /*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-*/

    static void Method4()
    {
        string s1 = "text";
        object s2 = new string("text");
        Console.WriteLine($"1. {s1 == s2}");
        Console.WriteLine($"2. {string.Equals(s1, s2)}");
        s2 = string.Copy(s1);
        Console.WriteLine($"3. {s1 == s2}");
        Console.WriteLine($"4. {string.Equals(s1, s2)}");
        s2 = "text";
        Console.WriteLine($"5. {s1 == s2}");
        Console.WriteLine($"6. {string.Equals(s1, s2)}");
        s2 = s1;
        Console.WriteLine($"7. {s1 == s2}");
        Console.WriteLine($"8. {string.Equals(s1, s2)}");
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