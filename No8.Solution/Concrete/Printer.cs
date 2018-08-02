namespace No8.Solution.Concrete
{
    public class Printer : BasePrinter
    {
        public Printer(string name, string model) : base(name, model)
        {
        }

        // тут может быть еще и обработка данных
        internal override object PrintData<T>(T data)
        {
            return data;
        }
    }
}
