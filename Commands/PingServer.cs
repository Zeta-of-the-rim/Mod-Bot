using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace ModBot.Commands;

public class PingServer : BaseCommandModule
{
    [Command("TestServer")]
    public async Task ServerPing(CommandContext ctx)
    {
        // Send some data to the channel and a small footer about the fact that the bot is still in development
        await ctx.RespondAsync($"Server response time: {ctx.Client.Ping}ms \nBot response time: {ctx.Client.Ping}ms\n*I am a bot, and this action was performed automatically.*");
    }
}