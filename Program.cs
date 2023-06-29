using System;
using System.Diagnostics;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using static Newtonsoft.Json.Formatting;

namespace ModBot
{
    class StartUp
    {
        public static Boolean Debug;
        static async Task Main(string[] args)
        {
            Console.WriteLine("ModBot\n  Remember to customize before rolling out to a live server");

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
            string Token = File.ReadAllText("token.txt");
            
            // Now we read the config file (this ships with the bot)
            string Config = File.ReadAllText("config.json");







            var Discord_client = new DiscordClient(new DiscordConfiguration()
            {
                Token = Token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });
            // Register commands
            Discord_client.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { "!" }
            });
            
            Thread.Sleep(-1);
            // Holding the program open
        }
    }  
    class DebugLogger
    {
        public void PrintDebugInfo(string info)
        {
            Console.WriteLine(info);
        }
    }
}
