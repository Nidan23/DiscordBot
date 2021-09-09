using System.Threading.Tasks;
using ClashOfClans;
using ClashOfClans.Models;
using Discord.WebSocket;

namespace DiscordBot
{
    public class Clash
    {
        private readonly EmbedMess _embedmess = new EmbedMess();
        private ClashOfClansClient ClashClient { get; set; }
        public Clan ClashClan { get; set; }
        public Player ClashPlayer { get; set; }
        private void CocApiConn()
        {
            string token =
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03Z" +
                "mExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2" +
                "FtZWFwaSIsImp0aSI6IjI4NzNkZWRkLTdhODAtNDFkOC04ZGJmLTZmMzk0NTI4ODE4NCIsImlhd" +
                "CI6MTYwNjk4NjA5MSwic3ViIjoiZGV2ZWxvcGVyLzgyN2U0YTdiLTgzZDQtNjdlYi01ZTI3LWU4ND" +
                "Q3ZDMxZmE3NiIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc" +
                "2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjM1LjIzNC4xMzQuMTg3Il0sInR5cGU" +
                "iOiJjbGllbnQifV19.TtmgqqxQtMTwjWozSAy41qXmXm5N3P43z3YjPPm2nyZDWD-8V9JhA4p5H4s1p8Pghs9a8sonPPiVVufbOZJndA";

            ClashClient = new ClashOfClansClient(token);
        }
        public async Task<Task> CocApiClan(string clanTag)
        {
            var coc = new Clash();
            coc.CocApiConn();
            ClashClan = await coc.ClashClient.Clans.GetClanAsync(clanTag);

            return Task.CompletedTask;
        }

        public async Task<Task> CocApiPlayer(string playerTag)
        {
            var coc = new Clash();
            coc.CocApiConn();
            ClashPlayer = await coc.ClashClient.Players.GetPlayerAsync(playerTag);

            return Task.CompletedTask;
        }

        public async Task PlayerInfo(SocketMessage message, string tag)
        {
            await CocApiPlayer(tag);
            if (ClashPlayer.Clan != null)
                if (ClashPlayer.Clan.BadgeUrls.Large is { })
                    await message.Channel.SendMessageAsync("", false, _embedmess.AllPlayerShittiDev(ClashPlayer.Name,
                        ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                        ClashPlayer.Donations.ToString(), ClashPlayer.DonationsReceived.ToString(),
                        ClashPlayer.AttackWins.ToString(), ClashPlayer.DefenseWins.ToString(),
                        ClashPlayer.WarStars.ToString(), ClashPlayer.Achievements[33].Value.ToString(),
                        ClashPlayer.Achievements[31].Value.ToString(),
                        ClashPlayer.TownHallLevel.ToString(), ClashPlayer.Clan.ClanLevel.ToString(),
                        ClashPlayer.Clan.BadgeUrls.Large.ToString(), ClashPlayer.Clan.Tag, ClashPlayer.Clan.Name,
                        ClashPlayer.Role.ToString()));

                else
                    await message.Channel.SendMessageAsync("", false, _embedmess.AllPlayerShittiDev(ClashPlayer.Name,
                        ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                        ClashPlayer.Donations.ToString(), ClashPlayer.DonationsReceived.ToString(),
                        ClashPlayer.AttackWins.ToString(), ClashPlayer.DefenseWins.ToString(),
                        ClashPlayer.WarStars.ToString(), ClashPlayer.Achievements[33].Value.ToString(),
                        ClashPlayer.Achievements[31].Value.ToString(),
                        ClashPlayer.TownHallLevel.ToString()));


            else
                    await message.Channel.SendMessageAsync("", false, _embedmess.AllPlayerShittiDev(ClashPlayer.Name,
                        ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                        ClashPlayer.Donations.ToString(), ClashPlayer.DonationsReceived.ToString(),
                        ClashPlayer.AttackWins.ToString(), ClashPlayer.DefenseWins.ToString(),
                        ClashPlayer.WarStars.ToString(), ClashPlayer.Achievements[33].Value.ToString(),
                        ClashPlayer.Achievements[31].Value.ToString(),
                        ClashPlayer.TownHallLevel.ToString()));
        }
        public async Task Playerdata(SocketMessage message, string tag)
        {
            await CocApiPlayer(tag);
            await message.Channel.SendMessageAsync("", false,
                _embedmess.HomeTroops(ClashPlayer.Name, ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                     ClashPlayer.TownHallLevel.ToString(),ClashPlayer.Troops, "elixir"));
            await message.Channel.SendMessageAsync("", false,
                _embedmess.HomeTroops(ClashPlayer.Name, ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                    ClashPlayer.TownHallLevel.ToString(),ClashPlayer.Troops, "de"));
        }
        public async Task PlayerSpells(SocketMessage message, string tag)
        {
            await CocApiPlayer(tag);
            await message.Channel.SendMessageAsync("", false,
                _embedmess.Spells(ClashPlayer.Name, ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                    ClashPlayer.TownHallLevel.ToString(), ClashPlayer.Spells, "elixir"));
            await message.Channel.SendMessageAsync("", false,
                _embedmess.Spells(ClashPlayer.Name, ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                    ClashPlayer.TownHallLevel.ToString(), ClashPlayer.Spells, "de"));
        }
        public async Task PlayerHeroes(SocketMessage message, string tag)
        {
            await CocApiPlayer(tag);
            await message.Channel.SendMessageAsync("", false,
                _embedmess.HomeHeroes(ClashPlayer.Name, ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                    ClashPlayer.TownHallLevel.ToString(), ClashPlayer.Heroes));
        }
        public async Task PlayerMachines(SocketMessage message, string tag)
        {
            await CocApiPlayer(tag);
            await message.Channel.SendMessageAsync("", false,
                _embedmess.Machines(ClashPlayer.Name, ClashPlayer.Tag, ClashPlayer.ExpLevel.ToString(),
                    ClashPlayer.TownHallLevel.ToString(), ClashPlayer.Troops));
        }
    }
}
