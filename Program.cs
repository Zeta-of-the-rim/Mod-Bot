using System;
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
        public Boolean Debug = false;
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Thank you for choosing ModBot!");
            if (File.Exists("DEBUG"))
            {
                // This is not a good way to do this, but it should allow users to debug the bot without tools
                Console.WriteLine("Running in debug. This is not recommended for regular use. \n Remove the file DEBUG to disable debug mode.");
            }
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
            // Deserialize the config file (I have no idea what im doing)
            






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
}
