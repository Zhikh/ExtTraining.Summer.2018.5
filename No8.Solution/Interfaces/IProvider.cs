namespace No8.Solution.Interfaces
{
    public interface IProvider<out TResult>
    {
        TResult Load();
    }
}
