using System.Threading.Tasks;
using ClashOfClans;
using ClashOfClans.Models;
using Discord.WebSocket;

namespace DiscordBot
{
    public class Clash
    {
        private readonly EmbedMess _embedmess = new EmbedMess(); // class object
        private ClashOfClansClient ClashClient { get; set; } // get set, wow :D
        public Clan ClashClan { get; set; } // get set, wow :D
        public Player ClashPlayer { get; set; } // get set, wow :D
        public Clash coc = new Clash(); // class obj
        private void CocApiConn() // Clash Of Clans API conn
        {
            string token =
                "****"; // API token

            ClashClient = new ClashOfClansClient(token); 
        }
        public async Task<Task> CocApiClan(string clanTag) // setting clan
        {
            coc.CocApiConn();
            ClashClan = await coc.ClashClient.Clans.GetClanAsync(clanTag);

            return Task.CompletedTask;
        }

        public async Task<Task> CocApiPlayer(string playerTag) // setting player
        {
            coc.CocApiConn();
            ClashPlayer = await coc.ClashClient.Players.GetPlayerAsync(playerTag);

            return Task.CompletedTask;
        }

        public async Task PlayerInfo(SocketMessage message, string tag)
        {
            await CocApiPlayer(tag);
            if (ClashPlayer.Clan != null) // if player is in clan or not
                if (ClashPlayer.Clan.BadgeUrls.Large is { }) // second checking if first was not successfull
                    await message.Channel.SendMessageAsync("", false, _embedmess.AllPlayerShittiDev(ClashPlayer.Name,
                        ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                        ClashPlayer.Donations.ToString(), ClashPlayer.DonationsReceived.ToString(),
                        ClashPlayer.AttackWins.ToString(), ClashPlayer.DefenseWins.ToString(),
                        ClashPlayer.WarStars.ToString(), ClashPlayer.Achievements[33].Value.ToString(),
                        ClashPlayer.Achievements[31].Value.ToString(),
                        ClashPlayer.TownHallLevel.ToString(), ClashPlayer.Clan.ClanLevel.ToString(),
                        ClashPlayer.Clan.BadgeUrls.Large.ToString(), ClashPlayer.Clan.Tag, ClashPlayer.Clan.Name,
                        ClashPlayer.Role.ToString())); // Send msg when player is in clan
                // AllPlayerShittiDev() - sending embed msg func, but it looks shitty, so ShittiDev 

                else
                    await message.Channel.SendMessageAsync("", false, _embedmess.AllPlayerShittiDev(ClashPlayer.Name,
                        ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                        ClashPlayer.Donations.ToString(), ClashPlayer.DonationsReceived.ToString(),
                        ClashPlayer.AttackWins.ToString(), ClashPlayer.DefenseWins.ToString(),
                        ClashPlayer.WarStars.ToString(), ClashPlayer.Achievements[33].Value.ToString(),
                        ClashPlayer.Achievements[31].Value.ToString(),
                        ClashPlayer.TownHallLevel.ToString()));// Send msg when player is not in clan


            else
                    await message.Channel.SendMessageAsync("", false, _embedmess.AllPlayerShittiDev(ClashPlayer.Name,
                        ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                        ClashPlayer.Donations.ToString(), ClashPlayer.DonationsReceived.ToString(),
                        ClashPlayer.AttackWins.ToString(), ClashPlayer.DefenseWins.ToString(),
                        ClashPlayer.WarStars.ToString(), ClashPlayer.Achievements[33].Value.ToString(),
                        ClashPlayer.Achievements[31].Value.ToString(),
                        ClashPlayer.TownHallLevel.ToString()));// Send msg when player is not in clan
        }
        public async Task Playerdata(SocketMessage message, string tag) // getting player basic data + troops
        {
            await CocApiPlayer(tag);
            await message.Channel.SendMessageAsync("", false,
                _embedmess.HomeTroops(ClashPlayer.Name, ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                     ClashPlayer.TownHallLevel.ToString(),ClashPlayer.Troops, "elixir"));
            await message.Channel.SendMessageAsync("", false,
                _embedmess.HomeTroops(ClashPlayer.Name, ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                    ClashPlayer.TownHallLevel.ToString(),ClashPlayer.Troops, "de"));
        }
        public async Task PlayerSpells(SocketMessage message, string tag) // getting player army - spells
        {
            await CocApiPlayer(tag);
            await message.Channel.SendMessageAsync("", false,
                _embedmess.Spells(ClashPlayer.Name, ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                    ClashPlayer.TownHallLevel.ToString(), ClashPlayer.Spells, "elixir"));
            await message.Channel.SendMessageAsync("", false,
                _embedmess.Spells(ClashPlayer.Name, ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                    ClashPlayer.TownHallLevel.ToString(), ClashPlayer.Spells, "de"));
        }
        public async Task PlayerHeroes(SocketMessage message, string tag) // getting player army - heroes
        {
            await CocApiPlayer(tag);
            await message.Channel.SendMessageAsync("", false,
                _embedmess.HomeHeroes(ClashPlayer.Name, ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                    ClashPlayer.TownHallLevel.ToString(), ClashPlayer.Heroes));
        }
        public async Task PlayerMachines(SocketMessage message, string tag) // getting player army - machines
        {
            await CocApiPlayer(tag);
            await message.Channel.SendMessageAsync("", false,
                _embedmess.Machines(ClashPlayer.Name, ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                    ClashPlayer.TownHallLevel.ToString(), ClashPlayer.Troops));
        }

        // troops are only from home village, builder base troops comming soon
    }
}
