using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DiscordBot
{
    public class Program
        {
            public readonly DiscordSocketClient _client = new DiscordSocketClient();

            public static void Main(string[] args)
                => new Program().MainAsync().GetAwaiter().GetResult();

            public async Task MainAsync()
            {
                _client.Log += new Commands().Log;
                _client.MessageReceived += new Commands().MessageHandeler;
                _client.UserJoined += new Commands().JoinMess;
                _client.UserLeft += new Commands().LeaveMess;
                await _client.LoginAsync(TokenType.Bot,
                    "NzgyNzEzMDk1MjY5MTIyMTQw.X8QMYA.TE_qSvvWF_CsItU5cNTH3I3bHgA");
                await _client.StartAsync();
                await _client.SetStatusAsync(UserStatus.AFK);
                await _client.SetGameAsync("Self Programming...");
                var a = new Game("Ciach") as RichGame;
                await Task.Delay(-1);
            }
        }
	}
