using System.Diagnostics;
using System.Xml.Linq;

class Participant
{
    private string Name;
    private int[] Grades;
    private int Distance;
    private int TotalResult;
    public int totalresult { get { return TotalResult; } }
    
    public Participant(string name, int[] grades, int distance)
    {
        Name = name;
        Grades = grades;
        Distance = distance;
        TotalResult = CalculateGrades();
    }
    public string GetName()
    {
        return Name;
    }
    public int CalculateGrades()
    {
        int amax = Grades[0];
        int amin = Grades[0];
        int sum = 0;
        for (int i = 0; i < Grades.Length; i++)
        {
            if (amax < Grades[i])
            {
                amax = Grades[i];
            }

        }
        for (int i = 0; i < Grades.Length; i++)
        {
            if (amin > Grades[i])
            {
                amin = Grades[i];
            }
        }
        for (int i = 0; i < Grades.Length; i++)
        {


            sum += Grades[i];

        }
        sum = sum - amax - amin;
        int d = 60 + ((Distance - 120) * 2);
        sum += d;
        return sum;

    }
    public void GetInfo()
    {
        Console.WriteLine($"{Name} Оценка: {CalculateGrades()}");
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        int[] grades = { 15, 14, 17, 5, 10 };
        Participant participant = new Participant("Ivan", grades, 125);
        Participant participant2 = new Participant("Владимир", grades, 100);
        Participant participant3 = new Participant("Михаил", grades, 120);
        Participant[] mass = { participant, participant2, participant3 };
        for (int i = 0; i < mass.Length; i++)
        {
            for (int j = 0; j < mass.Length - 1; j++)
            {
                if (mass[j].totalresult < mass[j + 1].totalresult)
                {
                    Participant a = mass[j];
                    mass[j] = mass[j + 1];
                    mass[j + 1] = a;

                }

            }



        }
        int b = 1;
        for (int i = 0; i < mass.Length; i++)
        {
            Console.Write($"{b} Место ");
            mass[i].GetInfo();
            b++;
        }



    }
}
