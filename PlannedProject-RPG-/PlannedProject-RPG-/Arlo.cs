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
        const String greeting = "Welcome to Arlo. You are the hero of this story sire and we hope you enjoy the adventure.";
        public Arlo(string path)
        {
            var lines = File.ReadAllText(path);
            //Console.WriteLine(lines);

            String[] container = lines.Split(new[] { Environment.NewLine + "==" + Environment.NewLine }, StringSplitOptions.None);

            foreach (var item in container)
            {
                Console.WriteLine(item);

                var SceneID = Regex.Match(item, "#[0-9]{3}");
                Console.WriteLine(SceneID.Index + "\t=> " + SceneID.Value);

                var ChoiceNum = Regex.Match(item, "\\*([0-9]+)");
                Console.WriteLine(ChoiceNum.Index + "\t=> " + ChoiceNum.Value);


                Console.WriteLine("DESC == " + item.Substring(SceneID.Index + SceneID.Value.Length, ChoiceNum.Index));

                int numChoices;
                if(Int32.TryParse(ChoiceNum.Groups[1].Value, out numChoices))
                {
                    if(numChoices == 0)
                    {
                        Console.WriteLine("SHIT HAPPENED");
                    } else
                    {
                        string[] choices = new string[numChoices];
                        var ChoicesMatch = Regex.Match(item, "\\+([^:]*):([0-9]{3})");
                        for (int i = 0; i < numChoices; i++)
                        {
                            choices[i] = ChoicesMatch.Value;
                            ChoicesMatch = ChoicesMatch.NextMatch();
                            Console.WriteLine(choices[i]);
                        }
                    }
                } else
                {
                    Console.WriteLine("SHIT HAPPENED");
                }


                Console.WriteLine("=======================");
            }

        }

        public void Start()
        {

        }

        //public static void Main(String[] args)
        //{
        //    Console.WriteLine(greeting);
        //}
    }
}
