using System;

class FootballTeam
{
    private string name;
    private int Scored;
    private int Failed;
    private int points;

    public FootballTeam(string name)
    {
        this.name = name;
        Scored = 0;
        Failed = 0;
        points = 0;
    }

    public string Name { get { return name; } set { name = value; } }

    public void Result(int scored, int conceded)
    {
        Scored += scored;
        Failed += conceded;
        if (scored > conceded) points += 3;
        else if (scored == conceded) points += 1;
    }

    public int Points { get { return points; } }
    public int Difference { get { return Scored - Failed; } }

    public static void Print(FootballTeam[] teams)
    {
        Console.WriteLine(" Place   Team   Gender   Points");
        for (int i = 0; i < teams.Length; i++)
        {
            Console.WriteLine("{0,2} {1,10} {2,12} {3,3}", i + 1, teams[i].Name, teams[i] is MaleFootballTeam ? "Male Team" : "Female Team", teams[i].Points);
        }
    }
}

class MaleFootballTeam : FootballTeam
{
    public MaleFootballTeam(string name) : base(name)
    {
    }
}

class FemaleFootballTeam : FootballTeam
{
    public FemaleFootballTeam(string name) : base(name)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        FootballTeam[] maleTeams = new FootballTeam[]
 {
    new MaleFootballTeam("A"),
    new MaleFootballTeam("B"),
    new MaleFootballTeam("C")
 };

        FootballTeam[] femaleTeams = new FootballTeam[]
        {
    new FemaleFootballTeam("D"),
    new FemaleFootballTeam("E"),
    new FemaleFootballTeam("F")
        };
        PlayMatches(maleTeams);
        PlayMatches(femaleTeams);
        FootballTeam bestMaleTeam = GetBestTeam(maleTeams);
        FootballTeam bestFemaleTeam = GetBestTeam(femaleTeams);

        FootballTeam overallBestTeam = (bestMaleTeam.Points > bestFemaleTeam.Points || (bestMaleTeam.Points == bestFemaleTeam.Points && bestMaleTeam.Difference > bestFemaleTeam.Difference)) ? bestMaleTeam : bestFemaleTeam;

        Console.WriteLine("Лучшая команда: {0}", overallBestTeam.Name);
    }

    static void PlayMatches(FootballTeam[] teams)
    {
        for (int i = 0; i < teams.Length; i++)
        {
            for (int j = i + 1; j < teams.Length; j++)
            {
                if ((teams[i] is MaleFootballTeam && teams[j] is MaleFootballTeam) ||
                    (teams[i] is FemaleFootballTeam && teams[j] is FemaleFootballTeam))
                {
                    Match(ref teams[i], ref teams[j]);
                }
            }
        }
    }

    static void Match(ref FootballTeam team1, ref FootballTeam team2)
    {
        Random random = new Random();
        int scored = random.Next(0, 5);
        int conceded = random.Next(0, 5);
        team1.Result(scored, conceded);
        team2.Result(conceded, scored);
    }

    static FootballTeam GetBestTeam(FootballTeam[] teams)
    {
        FootballTeam bestTeam = teams[0];
        for (int i = 1; i < teams.Length; i++)
        {
            if (teams[i].Points > bestTeam.Points ||
                (teams[i].Points == bestTeam.Points && teams[i].Difference > bestTeam.Difference))
            {
                bestTeam = teams[i];
            }
        }
        return bestTeam;
    }
}