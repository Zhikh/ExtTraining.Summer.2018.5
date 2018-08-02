using No8.Solution.Interfaces;
using System;
using System.Collections.Generic;

namespace No8.Solution.Concrete
{
    public class Printer : BasePrinter
    {
        public Printer(string name, string model) : base(name, model)
        {
        }

        /*
         * если это бы не был симулятор, принтер бы принимал данные для печати, а не извлекал бы их
         * интерфейс IPrinter позволяет принимать и данные и возвращать любой результат
         */
        internal override TResult PrintData<TResult>(IProvider<TResult> resource)
        {
            return resource.Load();
        }
    }
}
