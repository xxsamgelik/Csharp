using System.Linq;

public class MyArray
{
    public int[] Values { get; set; }

    public MyArray(int[] values)
    {
        Values = values;
    }

    public int[] FindOddNumbers()
    {
        return Values.Where(x => x % 2 != 0).ToArray();
    }
}
