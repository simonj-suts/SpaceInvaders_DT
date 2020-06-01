using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Configuration;
using System.Globalization;


namespace SpaceInvaders
{
    public class Scoreboard
    {
        // Directory of data file

        public List<Player> players = new List<Player>();
        public string scoreDataPath = Path.Combine(Directory.GetCurrentDirectory(), "scoreData.txt");
        public Scoreboard() {
              

            if (File.Exists(scoreDataPath))
            {
                //reads all lines of the file into the string array
                //and then closes file
                string[] lines = File.ReadAllLines(scoreDataPath);  
                foreach (string line in lines)
                {
                    string[] newLine = line.Split(' ');
                    int score = Int32.Parse(newLine[newLine.Length - 1]);
                    newLine = newLine.Take(newLine.Count() - 1).ToArray();
                    string name = string.Join(" ", newLine);
                    players.Add(new Player(name, score));
                }
            }
            else
            {
                StreamWriter score = File.CreateText(scoreDataPath);
                 
                score.Close();
            }


        }

        public void updateScoreboard(Player currPlayer) { 
        
            if (players!= null)
            {
                foreach (Player p in players)
                {
                    if (p.Name == currPlayer.Name)
                    {
                        p.Score = currPlayer.Score;
                        return;
                    }
                }
            }
            players.Add(currPlayer);
        }

        public void updateFile()
        {
            InsertionSort();
            StreamWriter score;
            score = File.CreateText(scoreDataPath);
            foreach (Player p in players)
            {
                score.WriteLine(p.Name + ' ' + p.Score);
            }

            score.Close();
        }

      /* public void DisplayScoreboard()
        {
            foreach (Player p in players)
            {       
                //Console.SetCursorPosition(3, i);
                //Console.WriteLine(j + ". " + p.Name + " - " +  p.Score);
                
            }
        }*/
        
        private void InsertionSort()
        {
            int j;
            Player temp;
            for (int i = 1; i < players.Count; i++)
            {
                temp = players[i];
                j = i;
                while (j > 0 && players[j - 1].Score < temp.Score)
                {
                    players[j] = players[j - 1];
                    j--;
                }
                players[j] = temp;
            }
        }
    }
}
