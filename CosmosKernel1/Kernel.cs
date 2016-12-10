using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Display;
using System.IO;
namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        bool running = true;
        string username;
        DisplayDriver d;
        protected override void BeforeRun()
        {
            Console.WriteLine("JohnOs booted successfully. Type in Username");
            username = Console.ReadLine();
            Console.WriteLine("Password");
            var password = Console.ReadLine();
            d = new DisplayDriver();
        }

        protected override void Run()
        {
            while (running ){
                Console.Write(username + "@JohnOS>");
                var input = Console.ReadLine();
                Console.WriteLine(input);
                if (input == "commandlist")
                {
                    Console.WriteLine("commandlist\nsystem info\nGUI\n");
                }
                else if (input == "GUI")
                {
                    d.init();
                    d.clear();
                }
                else if (input == "system info")
                {
                    Console.WriteLine("Current Time: " + d.getTime());
                    Console.WriteLine("OS Version: JohnOS v0.0.1");
                }
                else if (input == "shutdown")
                {
                    Console.Clear();
                    Console.WriteLine("It is safe to shutdown");
                    running = false;
                }
                else if (input == "reboot")
                {
                    Sys.Power.Reboot();
                }
                else if (input.StartsWith("mkdir"))
                {
                    d.makeDir(input);
                }
                else {
                    Console.WriteLine(input + " is not a recognized command\n");
                }
            }
        }
    }
}
