using System;
using System.IO;
using System.Threading;

namespace CyberSecurityChatbot
{
    public class ChatBot
    {
        private readonly ResponseEngine engine = new ResponseEngine();
        private string userName = "User";

        public void Run()
        {
            DisplayAsciiLogo();
            AskName();
            ChatLoop();
        }

        private void DisplayAsciiLogo()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "ascii_logo.txt");
                if (File.Exists(path))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    foreach (var line in File.ReadAllLines(path))
                        Console.WriteLine(line);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("===============================================");
                    Console.WriteLine("        CYBERSECURITY AWARENESS BOT");
                    Console.WriteLine("                 by Hope");
                    Console.WriteLine("===============================================");
                    Console.ResetColor();
                }
            }
            catch
            {
                // ignore display errors
            }
        }

        private void AskName()
        {
            Console.Write("\nWhat is your name? ");
            userName = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(userName)) userName = "User";

            Console.ForegroundColor = ConsoleColor.Green;
            TypeWrite($"Hello {userName}! I'm here to help you stay safe online.", 8);
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Ask me about cybersecurity topics (type 'help' or 'exit'):");
        }

        private void ChatLoop()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();

                string input = (Console.ReadLine() ?? string.Empty).Trim();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter something or type 'help'.");
                    continue;
                }

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    TypeWrite($"Goodbye {userName}! Stay safe online.", 8);
                    break;
                }

                if (input.Equals("help", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Try: password, phishing, safe browsing, two factor.");
                    continue;
                }

                var reply = engine.GetResponse(input);
                TypeWrite("Bot: " + reply, 6);
            }
        }

        private void TypeWrite(string text, int msDelay)
        {
            foreach (var c in text)
            {
                Console.Write(c);
                Thread.Sleep(msDelay);
            }
            Console.WriteLine();
        }
    }
}
