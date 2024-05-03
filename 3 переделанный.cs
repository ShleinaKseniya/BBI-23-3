class Survey
{
    private string _name;
    private string _surname;
    private double _quantity;
    private double _procent;
    public static double s { get; private set; }
    public double Procent => _procent;
    public double Quantity => _quantity;
    public Survey(string name, string surname, double quantity)
    {
        _name = name;
        _surname = surname;
        _quantity = quantity;
        s = s + _quantity;


    }

    public void Print()
    {
        Console.WriteLine(_name + "     " + _surname + "          " + _quantity + "          " + (_quantity / s) * 100);
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Survey[] surveys = new Survey[7]
        {
            new Survey("Ivan", "Ivanov", 250),
            new Survey("Vladimir", "Putin", 328),
            new Survey("Alexander", "Pupkin", 105),
            new Survey("Valentin", "Budeyko", 160),
            new Survey("Mikhail", "Kuznetsov", 57),
            new Survey("Kirill", "Smirnov", 37),
            new Survey("Konstantin", "Lebedev", 63),
        };

        Sort(surveys);
        Console.WriteLine("Результирующая таблица:");
        Console.WriteLine("Имя\t Фамилия\t Голоса\t Проценты");
        for (int i = 0; i < 7; i++)
        {
            surveys[i].Print();
        }
        //Console.ReadKey();

    }
    static void Sort(Survey[] Surveys)
    {
        int gap = Surveys.Length / 2;

        while (gap > 0)
        {
            for (int i = gap; i < Surveys.Length; i++)
            {
                Survey current = Surveys[i];
                int j = i;
                while (j >= gap && Surveys[j - gap].Quantity < current.Quantity)
                {
                    Surveys[j] = Surveys[j - gap];
                    j = j - gap;
                }
                Surveys[j] = current;
            }

            gap = gap / 2;
        }


    }
}
