using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace CyberSecurityChatbot
{
    public static class AudioPlayer
    {
        public static void TryPlayGreeting()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string wavPath = Path.Combine(baseDir, "Assets", "greeting.wav");

                if (File.Exists(wavPath))
                {
                    
                    var psi = new ProcessStartInfo
                    {
                        FileName = wavPath,
                        UseShellExecute = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };
                    Process.Start(psi);

                    
                    Thread.Sleep(800);
                }
                else
                {
                    
                    Console.Beep(800, 300);
                }
            }
            catch
            {
               
                try { Console.Beep(800, 200); } catch {  }
            }

            Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!\n");
        }
    }
}
