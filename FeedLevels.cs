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
        private static System.Timers.Timer _aTimer; //

        private static readonly string ConnData = "server=localhost;uid=root;" +
                                                  "pwd=****"; // server conn

        private static readonly MySqlConnection Conn = new MySqlConnection(ConnData);
        private SocketMessage _message;
        private string _query;

        public FeedLevels(SocketMessage messages) // class constructor
        {
            _message = messages;
        }
        public static int CountFeed() // count feed
        {
            int numb; 
            Conn.Open(); // conn 2 db open
            string query = $"USE clash;SELECT COUNT(kom) FROM com";
            MySqlCommand cmd = new MySqlCommand(query, Conn);
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                numb = Convert.ToInt32(result);
                Conn.Close();
                return numb;
            }

            Conn.Close();
            return 0;
        }

        public static void TrunData() // delete data from db
        {
            Conn.Open();
            string trun = $"USE clash;TRUNCATE com";
            MySqlCommand cmdtrun = new MySqlCommand(trun, Conn);
            object result = cmdtrun.ExecuteScalar();
            if (result != null) // check if query was done right
            {
                Console.WriteLine("Good");
            }

            Conn.Close(); // conn with db close
        }

        public async Task SetTimer() // time 4 feed
        {
            // Create a timer with a two second interval.
            _aTimer = new System.Timers.Timer(360000);
            // Hook up the Elapsed event for the timer. 
            _aTimer.Elapsed += SendFeed;
            _aTimer.AutoReset = true;
            _aTimer.Enabled = true;
        }

        private void SendFeed(object sender, ElapsedEventArgs e) // sending feed when time == right
        {
            if (DateTime.Now.Hour.Equals(19) || DateTime.Now.Hour.Equals(8)) // if hour == good
            {
                for (int i = 0; i <= CountFeed(); i++) // foreach loop, kind of
                {
                    Conn.Open();
                    _query = $"USE clash;SELECT kom FROM com WHERE id={i}"; // get feed from db
                    MySqlCommand cmd = new MySqlCommand(_query, Conn);
                    MySqlDataReader reader = cmd.ExecuteReader(); // exe query

                    if (reader.Read()) // if it reads
                    {
                        _message.Channel.SendMessageAsync(reader[0].ToString()); // send msg
                        reader.Close(); // close query
                        Conn.Close(); // close conn
                    }

                    reader.Close();
                    Conn.Close();
                }
                TrunData(); // delete data
            }
        }
    }
}