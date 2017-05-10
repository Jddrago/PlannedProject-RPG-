using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace PlannedProject_RPG_
{
    class Arlo
    {

        Dictionary<int, Scene> scenes = new Dictionary<int, Scene>();

        const String greeting = "Welcome to Arlo. You are the hero of this story sire and we hope you enjoy the adventure.";
        public Arlo(string path)
        {
            var lines = File.ReadAllText(path);
            //Console.WriteLine(lines);

            String[] container = lines.Split(new[] { Environment.NewLine + "==" + Environment.NewLine }, StringSplitOptions.None);

            foreach (var item in container)
            {
                //Console.WriteLine(item);

                var SceneID = Regex.Match(item, "#([0-9]{3})");
                //Console.WriteLine(SceneID.Index + "\t=> " + SceneID.Value);
                
                var sid = Int32.Parse(SceneID.Groups[1].Value);


                var ChoiceNum = Regex.Match(item, "\\*([0-9]+)");
                //Console.WriteLine(ChoiceNum.Index + "\t=> " + ChoiceNum.Value);

                var desc = item.Substring(SceneID.Index + SceneID.Value.Length, ChoiceNum.Index);
                //Console.WriteLine("DESC == " + desc);

                int numChoices;

                Scene scene = null;

                if (Int32.TryParse(ChoiceNum.Groups[1].Value, out numChoices))
                {
                    if (numChoices == 0)
                    {
                        //Console.WriteLine("SHIT HAPPENED");
                        var REF = Regex.Match(item, ":(-?[0-9]*)");
                        var rf = REF.Groups[1].Value;
                        scene = new Scene(desc, Int32.Parse(rf));
                    }
                    else
                    {
                        Choice[] choices = new Choice[numChoices];
                        var ChoicesMatch = Regex.Match(item, "\\+([^:]*):([0-9]{3})");
                        for (int i = 0; i < numChoices; i++)
                        {
                            //choices[i] = ChoicesMatch.Value;
                            //Console.WriteLine(choices[i]);
                            //Console.WriteLine("Choice: " + ChoicesMatch.Groups[1].Value);
                            //Console.WriteLine("Ref: " + ChoicesMatch.Groups[2].Value);

                            var rf = ChoicesMatch.Groups[2].Value;
                            int r;
                            if (Int32.TryParse(rf, out r))
                            {
                                Choice c = new Choice(ChoicesMatch.Groups[1].Value, r);
                                choices[i] = c;
                                ChoicesMatch = ChoicesMatch.NextMatch();
                            } else
                            {
                                throw new NotImplementedException();
                            }
                        }
                        scene = new Scene(desc, choices);
                    }
                }
                else
                {
                    //Console.WriteLine("SHIT HAPPENED");
                    throw new NotImplementedException();
                }
                if (scene != null)
                {
                    scenes.Add(sid, scene);
                }
                else
                {
                    throw new NotImplementedException();
                }
                //Console.WriteLine("=======================");
            }
            Console.WriteLine("Done Parsing Story");
        }

        public void Start()
        {
            Hero p = null;

            bool rolling = true;

            while (rolling)
            {
                p = new Hero();
                Console.WriteLine(p.details());

                Console.WriteLine("=======================\n\nRoll again? (y/n)");
                var resp = Console.ReadLine();

                rolling = resp.Equals("y");
            }

            bool naming = true;
            string name = "";
            while (naming)
            {
                Console.WriteLine("What do you want to name your hero?");
                name = Console.ReadLine();
                Console.WriteLine(String.Format("Are you sure you want to name your hero {0}? (y/n)", name));
                var res = Console.ReadLine();
                naming = !res.Equals("y");
            }

            p.setName(name);



            bool running = true;
            Scene CurrentScene = scenes.First().Value;
            while (running)
            {
                var reg = Regex.Match(CurrentScene.Description, "&Combat\\(([^)]*)\\)");

                if(reg.Length != 0)
                {
                    //Console.WriteLine("::" + reg.Groups[1].Value);
                    bool doFight = true;
                    var des = 0;
                    var d = CurrentScene.Description.Split(new[] { reg.Value }, StringSplitOptions.None);
                    while (doFight)
                    {
                        var ene = reg.Groups[1].Value.Split(',');


                        Console.WriteLine(d[des].Replace("@", p.getName()+":"));
                        des++;

                        int EnemyCount = Int32.Parse(ene[1]);
                        var EnemyType = ene[0];
                        for (int i = 0; i < EnemyCount && p.IsAlive(); i++)
                        {
                            new Combat(p, Enemy.GenerateEnemy(EnemyType)).Start();
                        }

                        if (!p.IsAlive())
                        {
                            CurrentScene = scenes.Last().Value;
                            Console.WriteLine(CurrentScene.Description);
                            doFight = false;
                        } else
                        {
                            reg = reg.NextMatch();
                            if(reg.Length == 0)
                            {
                                doFight = false;
                            }
                        }


                    }
                    if (p.IsAlive())
                    {
                        Console.WriteLine(d[des].Replace("@", p.getName() + ":"));
                    }

                } else
                {
                    Console.WriteLine(CurrentScene.Description.Replace("@", p.getName() + ":"));
                }

                if (CurrentScene.choices != null && p.IsAlive())
                {

                    for (int i = 0; i < CurrentScene.choices.Length; i++)
                    {
                        Console.WriteLine(String.Format("{0}: {1}", i + 1, CurrentScene.choices[i].Description));
                    }
                    bool choosing = true;

                    while (choosing)
                    {
                        var userChoice = Console.ReadLine();
                        int c;
                        if (Int32.TryParse(userChoice, out c))
                        {
                            if (c > 0 && c <= CurrentScene.choices.Length)
                            {
                                choosing = false;
                                CurrentScene = scenes[CurrentScene.choices[c-1].Reference];
                            }
                            else
                            {
                                Console.WriteLine(String.Format("You must choose a valid choice (1-{0})", CurrentScene.choices.Length));
                            }
                        }

                    }
                } else
                {
                    if(CurrentScene.Reference != -1)
                    {
                        CurrentScene = scenes[CurrentScene.Reference];
                    } else
                    {
                        Console.WriteLine("Do you want to play again? (y/n)");
                        var resp = Console.ReadLine();
                        if (resp.Equals("y"))
                        {
                            CurrentScene = scenes.First().Value;
                        } else
                        {
                            running = false;
                        }
                    }
                }
            }
        }

        //public static void Main(String[] args)
        //{
        //    Console.WriteLine(greeting);
        //}
    }
}
