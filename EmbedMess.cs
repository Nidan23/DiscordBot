using ClashOfClans.Models;
using Discord;

namespace DiscordBot
{
    public class EmbedMess
    {
        public string RangCheck(string ranga)
        {
            switch (ranga)
            {
                case "coLeader":
                    return "Co-leader";
                case "leader":
                    return "Leader";
                case "admin":
                    return "Elder";
                default:
                    return "Member";
            }
        } // just checking ur rang pattern

        public Embed ShittiDev(string nick, string tag, string ranga, string op, string pp, string czob)
        {
            var nie = new EmbedBuilder()
                {
                    Color = new Color(0x4F882A),
                    Title = $@"Informacje o graczu: {nick}",
                    Description = " ",
                };
                nie.AddField(x =>
                {
                    x.Name = "Nick:";
                    x.Value = nick;
                    x.IsInline = false;
                });
                nie.AddField(x =>
                {
                    x.Name = "TAG:";
                    x.Value = tag;
                    x.IsInline = false;
                });
                nie.AddField(x =>
                {
                    x.Name = "Ranga:";
                    x.Value = RangCheck(ranga);
                    x.IsInline = false;
                });
                nie.AddField(x =>
                {
                    x.Name = "Ostatnie pojawienie:";
                    x.Value = op;
                    x.IsInline = false;
                });
                nie.AddField(x =>
                {
                    x.Name = "Pierwsze pojawienie:";
                    x.Value = pp;
                    x.IsInline = false;
                });
                nie.AddField(x =>
                {
                    x.Name = "Nadal w klanie:";
                    x.Value = char.ToUpper(czob[0]) + czob.Substring(1);
                    x.IsInline = false;
                });

                return nie.Build();
        } // Basic pattern
        public Embed AllDataShittiDev(string nick, string tag, string ranga, string poziom, string rdonated,
            string received, string awin, string dwin, string uelixir, string ugold, string udark, string warstars,
            string rcwl, string rcg, string th, string op, string pp, string czob)
        {
            var nie = new EmbedBuilder()
            {
                Color = new Color(0x4F882A),
                Title = $@"Informacje o graczu: {nick}",
                Description = " ",
            };
            nie.AddField(x =>
            {
                x.Name = "Nick:";
                x.Value = nick;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "TAG:";
                x.Value = tag;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Ranga:";
                x.Value = RangCheck(ranga);
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Poziom:";
                x.Value = poziom + " lvl";
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Donaty:";
                x.Value = rdonated;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Received:";
                x.Value = received;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Wygrane ataki:";
                x.Value = awin;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Wygrane obrony:";
                x.Value = dwin;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Ufarmiony elixir:";
                x.Value = uelixir;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Ufarmione złoto:";
                x.Value = ugold;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Ufarmiony dark:";
                x.Value = udark;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Gwiazdki z wojny:";
                x.Value = warstars;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Gwiazdki z tego CWL:";
                x.Value = rcwl;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Punkty z tego CG:";
                x.Value = rcg;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Poziom TH:";
                x.Value = th;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Ostatnie pojawienie:";
                x.Value = op;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Pierwsze pojawienie:";
                x.Value = pp;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Nadal w klanie:";
                x.Value = char.ToUpper(czob[0]) + czob.Substring(1);
                x.IsInline = false;
            });

            return nie.Build();
        }  // Msg pattern 4 data from DB (db includes data from API)

        public Embed AllPlayerShittiDev(string nick, string tag, string poziom, string donated,
            string received, string awin, string dwin, string warstars, string cwl, string cg, string th,
            string clanLevel = "", string clanLogo = "", string clanTag = "", string clan = "",
            string ranga = null)
        {
            var nie = new EmbedBuilder()
            {
                Color = new Color(0x4F882A),
                Title = $@"Informacje o graczu: {nick}",
                Description = " ",
                ThumbnailUrl = clanLogo,
            };
            nie.AddField(x =>
            {
                x.Name = "Nick:";
                x.Value = nick;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "TAG:";
                x.Value = tag;
                x.IsInline = false;
            });
            if (!clan.Equals(""))
            {
                nie.AddField(z =>
                {
                    z.Name = "Nazwa klanu:";
                    z.Value = clan;
                    z.IsInline = false;
                });
                nie.AddField(z =>
                {
                    z.Name = "TAG klanu:";
                    z.Value = clanTag;
                    z.IsInline = false;
                });
                nie.AddField(z =>
                {
                    z.Name = "Poziom Klanu:";
                    z.Value = clanLevel + " lvl";
                    z.IsInline = false;
                });
                nie.AddField(z =>
                {
                    z.Name = "Ranga w klanie:";
                    z.Value = RangCheck(ranga);
                    z.IsInline = false;
                });
            }

            nie.AddField(x =>
            {
                x.Name = "Poziom:";
                x.Value = poziom + " lvl";
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Donaty:";
                x.Value = donated;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Received:";
                x.Value = received;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Wygrane ataki:";
                x.Value = awin;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Wygrane obrony:";
                x.Value = dwin;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Gwiazdki z wojny:";
                x.Value = warstars;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Gwiazdki na CWL:";
                x.Value = cwl;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Punkty na CG:";
                x.Value = cg;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Poziom TH:";
                x.Value = th;
                x.IsInline = false;
            });

            return nie.Build();
        } // Msg pattern 4 data directly from API
        public Embed HomeTroops(string nick, string tag, string poziom, string th, PlayerItemLevelList data, string el)
        {
            var nie = new EmbedBuilder()
            {
                Color = new Color(0x4F882A),
                Title = $@"Informacje o wojsku gracza: {nick}",
                Description = " ",
            };
            nie.AddField(x =>
            {
                x.Name = "Nick:";
                x.Value = nick;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "TAG:";
                x.Value = tag;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Poziom:";
                x.Value = poziom;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Poziom TH:";
                x.Value = th;
                x.IsInline = false;
            });
            string[] super;
            for (int i = 0; i < data.Count; i++)
            {
                super = data[i].Name.Split(' ');
                if (data[i].Village == Village.Home && super[0] != "Super" && super[0] != "Sneaky" && super[0] != "Inferno")
                {
                    if (el.Equals("elixir"))
                    {
                        switch (data[i].Name)
                        {
                            case "Minion":
                                break;
                            case "Hog Rider":
                                break;
                            case "Valkyrie":
                                break;
                            case "Golem":
                                break;
                            case "Witch":
                                break;
                            case "Lava Hound":
                                break;
                            case "Bowler":
                                break;
                            case "Ice Golem":
                                break;
                            case "Headhunter":
                                break;
                            case "Wall Wrecker":
                                break;
                            case "Battle Blimp":
                                break;
                            case "Stone Slammer":
                                break;
                            case "Siege Barracks":
                                break;
                            default:
                                nie.AddField(x =>
                                {
                                    x.Name = data[i].Name + ":";
                                    x.Value = data[i].Level + "/" + data[i].MaxLevel;
                                    x.IsInline = false;
                                });
                                break;
                        }
                    } else if (el.Equals("de"))
                    {
                        switch (data[i].Name)
                        {
                            case "Minion":
                                nie.AddField(x =>
                                {
                                    x.Name = data[i].Name + ":";
                                    x.Value = data[i].Level;
                                    x.IsInline = false;
                                });
                                break;
                            case "Hog Rider":
                                nie.AddField(x =>
                                {
                                    x.Name = data[i].Name + ":";
                                    x.Value = data[i].Level;
                                    x.IsInline = false;
                                });
                                break;
                            case "Valkyrie":
                                nie.AddField(x =>
                                {
                                    x.Name = data[i].Name + ":";
                                    x.Value = data[i].Level;
                                    x.IsInline = false;
                                });
                                break;
                            case "Golem":
                                nie.AddField(x =>
                                {
                                    x.Name = data[i].Name + ":";
                                    x.Value = data[i].Level;
                                    x.IsInline = false;
                                });
                                break;
                            case "Witch":
                                nie.AddField(x =>
                                {
                                    x.Name = data[i].Name + ":";
                                    x.Value = data[i].Level;
                                    x.IsInline = false;
                                });
                                break;
                            case "Lava Hound":
                                nie.AddField(x =>
                                {
                                    x.Name = data[i].Name + ":";
                                    x.Value = data[i].Level;
                                    x.IsInline = false;
                                });
                                break;
                            case "Bowler":
                                nie.AddField(x =>
                                {
                                    x.Name = data[i].Name + ":";
                                    x.Value = data[i].Level;
                                    x.IsInline = false;
                                });
                                break;
                            case "Ice Golem":
                                nie.AddField(x =>
                                {
                                    x.Name = data[i].Name + ":";
                                    x.Value = data[i].Level;
                                    x.IsInline = false;
                                });
                                break;
                            case "Headhunter":
                                nie.AddField(x =>
                                {
                                    x.Name = data[i].Name + ":";
                                    x.Value = data[i].Level;
                                    x.IsInline = false;
                                });
                                break;
                        }
                    }
                }
            }

            return nie.Build();
        } // Player troops msg pattern

        public Embed Spells(string nick, string tag, string poziom, string th, PlayerItemLevelList spells, string el)
        {
            var nie = new EmbedBuilder()
            {
                Color = new Color(0x4F882A),
                Title = $@"Informacje o czarach gracza: {nick}",
                Description = " ",
            };
            nie.AddField(x =>
            {
                x.Name = "Nick:";
                x.Value = nick;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "TAG:";
                x.Value = tag;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Poziom:";
                x.Value = poziom;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Poziom TH:";
                x.Value = th;
                x.IsInline = false;
            });
            string[] super;
            for (int i = 0; i < spells.Count; i++)
            {
                super = spells[i].Name.Split(' ');
                if (el.Equals("elixir"))
                {
                    switch (super[0])
                    {
                        case "Poison":
                            break;
                        case "Earthquake":
                            break;
                        case "Haste":
                            break;
                        case "Skeleton":
                            break;
                        case "Bat":
                            break;
                        default:
                            nie.AddField(x =>
                            {
                                x.Name = spells[i].Name + ":";
                                x.Value = spells[i].Level + "/" + spells[i].MaxLevel;
                                x.IsInline = false;
                            });
                            break;
                    }
                }
                else if (el.Equals("de"))
                {
                    switch (super[0])
                    {
                        case "Poison":
                            nie.AddField(x =>
                            {
                                x.Name = spells[i].Name + ":";
                                x.Value = spells[i].Level + "/" + spells[i].MaxLevel;
                                x.IsInline = false;
                            });
                            break;
                        case "Earthquake":
                            nie.AddField(x =>
                            {
                                x.Name = spells[i].Name + ":";
                                x.Value = spells[i].Level + "/" + spells[i].MaxLevel;
                                x.IsInline = false;
                            });
                            break;
                        case "Haste":
                            nie.AddField(x =>
                            {
                                x.Name = spells[i].Name + ":";
                                x.Value = spells[i].Level + "/" + spells[i].MaxLevel;
                                x.IsInline = false;
                            });
                            break;
                        case "Skeleton":
                            nie.AddField(x =>
                            {
                                x.Name = spells[i].Name + ":";
                                x.Value = spells[i].Level + "/" + spells[i].MaxLevel;
                                x.IsInline = false;
                            });
                            break;
                        case "Bat":
                            nie.AddField(x =>
                            {
                                x.Name = spells[i].Name + ":";
                                x.Value = spells[i].Level + "/" + spells[i].MaxLevel;
                                x.IsInline = false;
                            });
                            break;
                        default:
                            break;
                    }
                }
            }

            return nie.Build();
        } // Player spells msg pattern

        public Embed HomeHeroes(string nick, string tag, string poziom, string th, PlayerItemLevelList hero)
        {
            var nie = new EmbedBuilder()
            {
                Color = new Color(0x4F882A),
                Title = $@"Informacje o herosach gracza: {nick}",
                Description = " ",
            };
            nie.AddField(x =>
            {
                x.Name = "Nick:";
                x.Value = nick;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "TAG:";
                x.Value = tag;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Poziom:";
                x.Value = poziom;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Poziom TH:";
                x.Value = th;
                x.IsInline = false;
            });
            for (int i = 0; i < hero.Count; i++)
            {
                if (hero[i].Village == Village.Home)
                {
                    nie.AddField(x =>
                    {
                        x.Name = hero[i].Name + ":";
                        x.Value = hero[i].Level + "/" + hero[i].MaxLevel;
                        x.IsInline = false;
                    });
                }
            }

            return nie.Build();
        } // Player heroes msg pattern
        public Embed Machines(string nick, string tag, string poziom, string th, PlayerItemLevelList machine)
        {
            var nie = new EmbedBuilder()
            {
                Color = new Color(0x4F882A),
                Title = $@"Informacje o maszynach gracza: {nick}",
                Description = " ",
            };
            nie.AddField(x =>
            {
                x.Name = "Nick:";
                x.Value = nick;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "TAG:";
                x.Value = tag;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Poziom:";
                x.Value = poziom;
                x.IsInline = false;
            });
            nie.AddField(x =>
            {
                x.Name = "Poziom TH:";
                x.Value = th;
                x.IsInline = false;
            });
            string[] super;
            for (int i = 0; i < machine.Count; i++)
            {
                super = machine[i].Name.Split(' ');
                if (machine[i].Village != Village.Home || super[0] == "Super" || super[0] == "Sneaky" ||
                    super[0] == "Inferno") continue;
                switch (machine[i].Name)
                {
                    case "Wall Wrecker":
                        nie.AddField(x =>
                        {
                            x.Name = machine[i].Name + ":";
                            x.Value = machine[i].Level + "/" + machine[i].MaxLevel;
                            x.IsInline = false;
                        });
                        break;
                    case "Battle Blimp":
                        nie.AddField(x =>
                        {
                            x.Name = machine[i].Name + ":";
                            x.Value = machine[i].Level + "/" + machine[i].MaxLevel;
                            x.IsInline = false;
                        });
                        break;
                    case "Stone Slammer":
                        nie.AddField(x =>
                        {
                            x.Name = machine[i].Name + ":";
                            x.Value = machine[i].Level + "/" + machine[i].MaxLevel;
                            x.IsInline = false;
                        });
                        break;
                    case "Siege Barracks":
                        nie.AddField(x =>
                        {
                            x.Name = machine[i].Name + ":";
                            x.Value = machine[i].Level + "/" + machine[i].MaxLevel;
                            x.IsInline = false;
                        });
                        break;
                    default:
                        break;
                }
            }

            return nie.Build();
        } // Player machines msg pattern

    }
}
