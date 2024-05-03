
using System.Diagnostics;
using System.Xml.Linq;

class Team
{
    private string Name;
    private int Grade;
    public void SetGrade(int grade)
    {
        Grade = grade;
    }
    public int GetGrade()
    {
        return Grade;
    }


    public Team(string name)
    {
        Name = name;
    }
    public string GetName()
    {
        return Name;
    }
    public void GetInfo()
    {
        Console.WriteLine($"{Name} Количество очков: {Grade}");

    }


}
class Play
{
    private Team Team1;
    private Team Team2;
    private int Score1;
    private int Score2;
    public Team TEAM1 => Team1;
    public Team TEAM2 => Team2;
    public Play(Team team1, Team team2, int score1, int score2)
    {
        Team1 = team1;
        Team2 = team2;
        Score1 = score1;
        Score2 = score2;
    }
    public void CalculateScore()
    {
        if (Score1 > Score2)
        {
            Team1.SetGrade(Team1.GetGrade() + 3);

        }
        else if (Score1 < Score2)
        {
            Team2.SetGrade(Team2.GetGrade() + 3);

        }
        else
        {
            Team1.SetGrade(Team1.GetGrade() + 1); 
            Team2.SetGrade(Team2.GetGrade() + 1);
        }

    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Team teams1 = new Team("Динамо");
        Team teams2 = new Team("Cпартак");
        Team teams3 = new Team("Локомотив");

        Play play1 = new Play(teams1, teams2, 3, 2);
        Play play2 = new Play(teams1, teams3, 3, 3);
        Play play3 = new Play(teams2, teams3, 1, 2);

        Play[] mass = { play1, play2, play3 };
        for (int i = 0; i < mass.Length; i++)
        {
            mass[i].CalculateScore();
        }
        for (int i = 0; i < mass.Length; i++)
        {
            for (int j = 0; j < mass.Length - 1; j++)
            {
                if (mass[j].TEAM1.GetGrade() < mass[j + 1].TEAM2.GetGrade())
                {
                    Play a = mass[j];
                    mass[j] = mass[j + 1];
                    mass[j + 1] = a;
                }

            }
        }
        Team[] mess = { teams1, teams2, teams3 };
        int b = 1;
        for (int i = 0; i < mess.Length; i++)
        {
            Console.Write($"{b} Место ");
            mess[i].GetInfo();
            b++;
        }

    }
}

