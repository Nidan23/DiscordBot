using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DiscordBot
{
    public class Program
        {
            public readonly DiscordSocketClient Client = new DiscordSocketClient();

            public static void Main(string[] args)
                => new Program().MainAsync().GetAwaiter().GetResult(); // starting bot

            public async Task MainAsync() // main bot func
            {
                Client.Log += new Commands().Log; // setting log
                Client.MessageReceived += new Commands().MessageHandeler; // setting cmd handler
                Client.UserJoined += new Commands().JoinMess; // setting joinmsg, not working
                Client.UserLeft += new Commands().LeaveMess; // setting leavemsg, not working
                await Client.LoginAsync(TokenType.Bot,
                    "****"); // bot token
                await Client.StartAsync(); // bot starts right here
                await Client.SetStatusAsync(UserStatus.AFK); // setting bot status on dsc
                await Client.SetGameAsync("Self Programming..."); // setting bot status on dsc
                var a = new Game("Ciach") as RichGame; // setting a game on dsc
                await Task.Delay(-1);
            }
        }

        // Moim kolejnym krokiem jest poprawienie tego bota, doszlifowanie wszystkiego na cacy i potem przerobienie go tak, żeby nie był dla jednego klanu, ale dla każdego, stąd w plikach token.txt
	}
