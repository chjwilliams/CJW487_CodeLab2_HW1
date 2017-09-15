public class OrderedNumberGenerator : NumberGenerator
{
    public int[] order;

    public int current = 0;

    public override int Next()
    {
        int result = order[current % order.Length];

        current++;

        return result;
    }
}
