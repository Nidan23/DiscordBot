using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using ClashOfClans.Models;
using Discord;
using Discord.WebSocket;
using MySql.Data.MySqlClient;
using System.Timers;

namespace DiscordBot
{
    class FeedLevels
    {
        private static System.Timers.Timer aTimer;

        private static readonly string ConnData = "server=localhost;uid=root;" +
                                                  "pwd=pSp100321";

        private static readonly MySqlConnection _conn = new MySqlConnection(ConnData);
        private SocketMessage message;
        private string query;

        public FeedLevels(SocketMessage messages)
        {
            message = messages;
        }
        public static int CountFeed()
        {
            _conn.Open();
            string query = $"USE clash;SELECT COUNT(kom) FROM com";
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                int numb = Convert.ToInt32(result);
                _conn.Close();
                return numb;
            }

            _conn.Close();
            return 0;
        }

        public static void TrunData()
        {
            _conn.Open();
            string trun = $"USE clash;TRUNCATE com";
            MySqlCommand cmdtrun = new MySqlCommand(trun, _conn);
            object result = cmdtrun.ExecuteScalar();
            if (result != null)
            {
                Console.WriteLine("Good");
            }

            _conn.Close();
        }

        public async Task SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(360000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += SendFeed;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void SendFeed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour.Equals(19) || DateTime.Now.Hour.Equals(8))
            {
                for (int i = 0; i <= CountFeed(); i++)
                {
                    _conn.Open();
                    query = $"USE clash;SELECT kom FROM com WHERE id={i}";
                    MySqlCommand cmd = new MySqlCommand(query, _conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        message.Channel.SendMessageAsync(reader[0].ToString());
                        reader.Close();
                        _conn.Close();
                    }

                    reader.Close();
                    _conn.Close();
                }
                TrunData();
            }
        }
    }
}