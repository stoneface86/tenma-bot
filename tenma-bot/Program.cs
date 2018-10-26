using System;
using System.Threading.Tasks;
using DSharpPlus;


namespace tenma_bot {
    class Program {

        static DiscordClient discord;
        

        static async Task MainAsync(string token) {
            discord = new DiscordClient(new DiscordConfiguration{
                Token = token,
                TokenType = TokenType.Bot
            });

            discord.MessageCreated += async e => {
                if (e.Message.Content.ToLower().StartsWith("hello"))
                    await e.Message.RespondAsync("bitch");
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }


        static void Main(string[] args) {
            if (args.Length != 1) {
                Console.Error.WriteLine("Invalid command line arguments given");
                return;
            }

            MainAsync(args[0]).ConfigureAwait(false).GetAwaiter().GetResult();
        }


    }
}
