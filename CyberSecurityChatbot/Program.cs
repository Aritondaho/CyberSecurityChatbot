using System;

namespace CyberSecurityChatbot
{
    internal static class Program
    {
        static void Main()
        {
            Console.Title = "Cybersecurity Awareness Bot";

            

            
            var bot = new ChatBot();
            bot.Run();

            Console.WriteLine("\nThanks for using the Cybersecurity Awareness Bot. Press any key to close.");
            Console.ReadKey();
        }
    }
}