using System;
using System.Diagnostics;
using System.Threading.Tasks;
using DSharpPlus;
using Figgle;
using Newtonsoft.Json;
using static Newtonsoft.Json.Formatting;

namespace ModBot
{
    class StartUp
    {
        public static Boolean Debug;
        static async Task Main(string[] args)
        {
            Console.WriteLine(FiggleFonts.Standard.Render("ModBot"));
            Console.WriteLine("Remember to customize before rolling out to a live server");
            Console.WriteLine("This would be where the config would be shown \nIF I HAD ONE\nTo enable debug mode, create a file called DEBUG in the same directory as the executable\nPress enter to continue");
            Console.ReadLine();
            Console.Clear();
            // Check if a token file exists
            if (!File.Exists("token.txt"))
            {
                // If not, create one
                File.Create("token.txt");
                // Throw an error
                Console.WriteLine("No token file found. Please enter your token in token.txt");
                Environment.Exit(400);
            }
            // Read the token file
            string token = File.ReadAllText("token.txt");
            // Check if the token is empty (or has whitespace)
            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("Token file is empty. Please enter your token in token.txt");
                Environment.Exit(400);
            }
            // Trying to make my code look professional (see how long that lasts)
            DiscordMain client = new DiscordMain(token, "OpenAiAipKey");
            await Task.Delay(-1);
        }
    }
}