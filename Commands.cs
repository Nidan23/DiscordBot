using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DiscordBot
{
    class Commands
    {
        private readonly Clash _clash = new Clash(); // class object
        private readonly DiscordSocketClient _client = new DiscordSocketClient(); // same  
        private readonly Database _db = new Database(); // same

        public Task Log(LogMessage msg) // logging
        {
            Console.WriteLine(msg.ToString()); // write log on console
            return Task.CompletedTask;
        }

        public async Task JoinMess(SocketGuildUser user) // not working
        {
            var channel = _client.GetChannel(597408924815327267) as SocketTextChannel; // get channel id
            await channel.SendMessageAsync($"Witamy na discordzie Klanu Nowa Era!"); // send welcome msg
        }
        public async Task LeaveMess(SocketGuildUser user) // not working
        {
            var channel = _client.GetChannel(597408924815327267) as SocketTextChannel; // get channel id
            await channel.SendMessageAsync($"Użytkownik {user.Username} opuścił naszą drużynę!"); // send gb msg
        }
        public async Task<Task> MessageHandeler(SocketMessage message) // command handeler actually
        {
            string command; // usefull var
            string[] args; // args in command
            int lengthOfCommand; // cmd length
            message.Content.ToLower(); // making string easier to work with
            _client.Log += Log; // logging
            if (!message.Content.StartsWith('.') || message.Author.IsBot) // filtring msg
                return Task.CompletedTask;

            if (message.Content.Contains(' ')) // checking if command has args
            {
                lengthOfCommand = message.Content.IndexOf(' '); // getting cmd length
                command = message.Content.Substring(1, lengthOfCommand - 1).ToLower(); // getting cmd
                args = message.Content.Split(' '); // getting agrs

                if (command.Equals("my")) // first msg type
                {
                    switch (args[1]) // checking first arg
                    {
                        case "tag":
                            _db.SingleMyData(message, args[1], "klandata", ":trophy:");
                            break;
                        case "donated":
                            _db.SingleMyData(message, args[1], "klandata", ":thumbsup:");
                            break;
                        case "lvl":
                            _db.SingleMyData(message, "poziom", "klandata",
                                " lvl");
                            break;
                        case "ranga":
                            _db.SingleMyData(message, args[1], "klandata", ":muscle:");
                            break;
                        case "data":
                            _db.AllMyData(message);
                            break;
                        default:
                            await message.Channel.SendMessageAsync("Nie zrozumiałem komendy. Spróbuj ponownie");
                            break;
                    }
                }
                else if (command.Equals("check")) // second cmd type
                {
                    switch (args[1]) // checking arg
                    {
                        case "clan":
                            await _clash.CocApiClan(args[2]);
                            await message.Channel.SendMessageAsync(_clash.ClashClan.Name);
                            break;
                        case "player":
                            await _clash.CocApiPlayer(args[2]);
                            await _clash.PlayerInfo(message, args[2]);
                            break;
                        default:
                            await message.Channel.SendMessageAsync("Nie zrozumiałem komendy. Spróbuj ponownie");
                            break;
                    }
                }
                else if (command.Equals("admin")) // 3 cmd type
                {
                    //if (_clash.CheckAdminPerm(message).Equals(true)) // checking if person has admin perm
                    //{
                        if (args[1].Equals("get")) // checking 1 arg
                        {
                            if (args[2].Equals("single")) // checking 2 arg
                            {
                                switch (args[3]) // checking arg, more in future
                                {
                                    case "player":
                                        _db.SingleGetData(message, args[5], "klandata", "", args[4]);
                                        break;
                                }
                            }
                            else if (args[2].Equals("all")) // checking 2 arg
                            {
                                switch (args[3]) // checking 3 arg
                                {
                                    case "player":
                                        _db.AllGetData(message, args[4]);
                                        break;
                                    case "data":
                                        await _clash.Playerdata(message, args[4]);
                                        break;
                                    case "spells":
                                        await _clash.PlayerSpells(message, args[4]);
                                        break;
                                    case "heroes":
                                        await _clash.PlayerHeroes(message, args[4]);
                                        break;
                                    case "profile":
                                        await _clash.PlayerInfo(message, args[4]);
                                        await _clash.Playerdata(message, args[4]);
                                        await _clash.PlayerMachines(message, args[4]);
                                        await _clash.PlayerSpells(message, args[4]);
                                        await _clash.PlayerHeroes(message, args[4]);
                                    break;
                                    case "feed":
                                        var a = new FeedLevels(message).SetTimer();
                                        break;
                                        
                                }
                            }
                        }
                        else if (args[1].Equals("check")) // checking 1 arg
                        {
                            switch (args[2])
                            {
                                case "player":
                                    _db.AllGetData(message, args[4]);
                                    break;
                                case "explayer":
                                    _db.CheckIfPlayerWasInClan(message, args[3]);
                                    break;
                            }
                        }
                        else
                        {
                            await message.Channel.SendMessageAsync("Nie zrozumiałem komendy. Spróbuj ponownie");
                        }
                        // msg 4 user with/ admin perm
                    /*}
                    else
                    {
                        var usr = message.Author as SocketGuildUser;
                        await message.Channel.SendMessageAsync("", false, new EmbedBuilder() 
                        {
                            Title = usr.Nickname,
                            ThumbnailUrl = usr.GetAvatarUrl(),
                            Color = new Color(0x4F882A),
                            Description =
                                "Obawiam się, że nie masz do tego uprawnień \n Sprawdź czy jesteś Co-leaderem lub Leaderem klanie"
                        }.Build());
                    } */
                }
            }
            else // more cmd
            {
                lengthOfCommand = message.Content.Length;

                command = message.Content.Substring(1, lengthOfCommand - 1);
                switch (command)
                {
                    case "Lolas":
                        await message.Channel.SendMessageAsync($@"To ty {message.Author.Mention}");
                        break;
                    case "clantag":
                        await message.Channel.SendMessageAsync("", false, new EmbedBuilder()
                        {
                            Title = "Tag naszego Klanu",
                            Description = "#28LJOYOLQ",
                            Color = Color.DarkGreen
                        }.Build());
                        break;
                    case "myTag":
                        _db.SingleMyData(message, "tag", "klandata", ":trophy:");
                        break;
                    default:
                        await message.Channel.SendMessageAsync(command);
                        break;
                }
            }

            return Task.CompletedTask;
        }
    }
}
