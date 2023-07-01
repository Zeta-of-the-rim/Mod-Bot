using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;

namespace ModBot;

public class DiscordMain
{
    public DiscordMain(string discordToken, string openAiAipKey)
    {
        DiscordToken = discordToken;
        OpenAiAipKey = openAiAipKey;
        
        DiscordAsync();
    }

    
    public async void  DiscordAsync()
    {
        LogLevel logLevel = File.Exists("DEBUG") ? LogLevel.Debug : LogLevel.Information;
        
        var client = new DiscordClient(new DiscordConfiguration()
        {
            Token = DiscordToken,
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents,
            MinimumLogLevel = logLevel,
        });
        
        var commands = client.UseCommandsNext(new CommandsNextConfiguration()
        {
            StringPrefixes = new[] { "!" }
        });
        commands.RegisterCommands<Commands.PingServer>();
        client.MessageCreated += MessageCreatedHandler;
        
        await client.ConnectAsync(new DiscordActivity("Poorly written Japanese cartoons", ActivityType.Watching), UserStatus.Online);
        await Task.Delay(-1);
    }

    private async Task MessageCreatedHandler(DiscordClient sender, MessageCreateEventArgs args)
    {
        // Check if the message is from a bot (if it is, ignore it)
        if (args.Author.IsBot)
        {
            return;
        }
        String message = args.Message.Content;
    }

    public string DiscordToken { get; set; }
    public string OpenAiAipKey { get; set; }
}