using System.Linq;
using Discord;
using Discord.WebSocket;
using MySql.Data.MySqlClient;

namespace DiscordBot
{
    class Database
    {
        private static readonly string ConnData = "server=localhost;uid=root;" +
                                                  "pwd=pSp100321;database=clash";
        private readonly MySqlConnection _conn = new MySqlConnection(ConnData);

        private readonly EmbedMess _embedmess = new EmbedMess();

        public void SingleMyData(SocketMessage message, string dane, string tab, string emoji)
        {
            var usr = message.Author as SocketGuildUser;
            if (!usr.Nickname.Equals(null))
            {
                _conn.Open();
                string query = $"SELECT {dane} FROM {tab} WHERE nick='{usr.Nickname}'";
                MySqlCommand cmd = new MySqlCommand(query, _conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    message.Channel.SendMessageAsync("", false, new EmbedBuilder()
                    {
                        Title = $"Twoje informacje {usr.Nickname}",
                        Description = $"{dane.ToUpper()}: {reader[$"{dane}"]}",
                        Color = new Color(0x4F882A),
                    }.Build());
                }

                reader.Close();
                _conn.Close();
            }
        }
        public void SingleGetData(SocketMessage message, string dane, string tab, string emoji, string tag)
        {
            var usr = message.Author as SocketGuildUser;
            _conn.Open();
            string query = $"SELECT {dane}, nick FROM {tab} WHERE tag='{tag}'";
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                message.Channel.SendMessageAsync("", false, new EmbedBuilder()
                {
                    Title = $"Informacja o {reader["nick"]}",
                    Description = $"{dane.ToUpper()}: {reader[0]}",
                    Color = new Color(0x4F882A)
                }.Build());
            }

            reader.Close();
            _conn.Close();
        }
        public void AllMyData(SocketMessage message)
        {
            var usr = message.Author as SocketGuildUser;
            _conn.Open();
            string query = $@"SELECT tag FROM klandata WHERE nick='{usr.Nickname}'";
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                query = "SELECT klandata.nick, klandata.tag, klanplayers.ranga, klandata.poziom, klandata.rdonated, " +
                                "klandata.received, klandata.awin, klandata.dwin, klandata.uelixir, klandata.ugold, klandata.udark, " +
                                "klandata.warstars, klandata.rcwl, klandata.rcg, klandata.th, klanplayers.ppc, klanplayers.ppd, " +
                                "klanplayers.gak, klanplayers.mak, klanplayers.dak, klanplayers.msak, klanplayers.rak, klanplayers.czob " +
                                $@"FROM klandata, klanplayers WHERE klandata.tag = '{reader["tag"]}' AND klanplayers.tag = '{reader["tag"]}'";
                reader.Close();
                _conn.Close();
                _conn.Open();
                cmd = new MySqlCommand(query, _conn);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string[] via = reader["ppd"].ToString().Split("-").ToArray();

                    string op =
                        $@"Godzina: {reader["gak"]}:{reader["mak"]} dnia {reader["dak"]}.{reader["msak"]}.{reader["rak"]}";

                    string pp = $@"Godzina: {reader["ppc"]} dnia {via[2]}.{via[1]}.{via[0]}";

                    message.Channel.SendMessageAsync("", false, _embedmess.AllDataShittiDev(reader["nick"].ToString(), reader["tag"].ToString(), reader["ranga"].ToString(), reader["poziom"].ToString(), reader["rdonated"].ToString(), reader["received"].ToString(), reader["awin"].ToString(), reader["dwin"].ToString(), reader["uelixir"].ToString(), reader["ugold"].ToString(), reader["udark"].ToString(), reader["warstars"].ToString(), reader["rcwl"].ToString(), reader["rcg"].ToString(), reader["th"].ToString(), op, pp, reader["czob"].ToString()));
                }
                reader.Close();
            }
            else
            {
                message.Channel.SendMessageAsync("", false, new EmbedBuilder()
                {
                    Title = "Przykro mi",
                    Color = new Color(0x4F882A),
                    Description = $@"{message.Author.Mention} Obawiam się, że nie ma Cię u nas w klanie"
                }.Build());
            }
            _conn.Close();
        }
        public void AllGetData(SocketMessage message, string tag)
        {
            var usr = message.Author as SocketGuildUser;
            string query = "SELECT klandata.nick, klandata.tag, klanplayers.ranga, klandata.poziom, klandata.rdonated, " +
                           "klandata.received, klandata.awin, klandata.dwin, klandata.uelixir, klandata.ugold, klandata.udark, " +
                           "klandata.warstars, klandata.rcwl, klandata.rcg, klandata.th, klanplayers.ppc, klanplayers.ppd, " +
                           "klanplayers.gak, klanplayers.mak, klanplayers.dak, klanplayers.msak, klanplayers.rak, klanplayers.czob " +
                           $@"FROM klandata, klanplayers WHERE klandata.tag = '{tag}' AND klanplayers.tag = '{tag}'";
            _conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string[] via = reader["ppd"].ToString().Split("-").ToArray();

                string op =
                    $@"Godzina: {reader["gak"]}:{reader["mak"]} dnia {reader["dak"]}.{reader["msak"]}.{reader["rak"]}";

                string pp = $@"Godzina: {reader["ppc"]} dnia {via[2]}.{via[1]}.{via[0]}";

                message.Channel.SendMessageAsync("", false, _embedmess.AllDataShittiDev(reader["nick"].ToString(), reader["tag"].ToString(), reader["ranga"].ToString(), reader["poziom"].ToString(), reader["rdonated"].ToString(), reader["received"].ToString(), reader["awin"].ToString(), reader["dwin"].ToString(), reader["uelixir"].ToString(), reader["ugold"].ToString(), reader["udark"].ToString(), reader["warstars"].ToString(), reader["rcwl"].ToString(), reader["rcg"].ToString(), reader["th"].ToString(), op, pp, reader["czob"].ToString()));
                reader.Close();
            }
            else
            {
                message.Channel.SendMessageAsync("", false, new EmbedBuilder()
                {
                    Title = "Przykro mi",
                    Color = new Color(0x4F882A),
                    Description = $@"{message.Author.Mention} Obawiam się, że nie ma Cię u nas w klanie"
                }.Build());
            }
            _conn.Close();
        }
        public void CheckIfPlayerWasInClan(SocketMessage message, string tag)
        {
            _conn.Open();
            string query = $"SELECT nick, tag, ranga, gak, mak, dak, msak, rak, ppc, ppd, czob FROM klanplayers WHERE tag='{tag}'";
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string[] via = reader["ppd"].ToString().Split("-").ToArray();

                string op =
                    $@"Godzina: {reader["gak"]}:{reader["mak"]} dnia {reader["dak"]}.{reader["msak"]}.{reader["rak"]}";

                string pp = $@"Godzina: {reader["ppc"]} dnia {via[2]}.{via[1]}.{via[0]}";

                message.Channel.SendMessageAsync("", false, _embedmess.ShittiDev(reader["nick"].ToString(),
                        reader["tag"].ToString(), reader["ranga"].ToString(), op, pp,
                        reader["czob"].ToString()));
            }
            else
                message.Channel.SendMessageAsync("Ni chuja");

            reader.Close();
            _conn.Close();
        }

        public bool CheckAdminPerm(SocketMessage message)
        {
            var usr = message.Author as SocketGuildUser;
            _conn.Open();
            string query = $@"SELECT ranga FROM klandata WHERE nick='{usr.Nickname}'";
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (_embedmess.RangCheck(reader["ranga"].ToString()).Equals("Co-leader") ||
                    _embedmess.RangCheck(reader["ranga"].ToString()).Equals("Leader"))
                {
                    reader.Close();
                    _conn.Close();
                    return true;
                }
                reader.Close();
                _conn.Close();
                return false;
            }
            reader.Close();
            _conn.Close();
            return false;
        }
    }
}
