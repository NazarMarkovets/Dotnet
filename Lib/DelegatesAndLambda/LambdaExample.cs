using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DelegatesAndLambda
{
    /// <summary>
    /// public void DoSomething()                          // Action
    /// public void DoSomething(int number)                // Action<int>
    /// public void DoSomething(int number, string text)   // Action<int,string>
    /// 
    /// public int DoSomething()                           // Func<int>
    /// public int DoSomething(float number)               // Func<float,int>
    /// public int DoSomething(float number, string text)  // Func<float,string,int>
    /// </summary>
    public class LambdaExample
    {
        private int valueFromFuncPlus6 = 0;
        public LambdaExample()
        {

        }

        public LambdaExample(Func<string> func)
        {
            StringFuncToExecute = func;
        }

        private readonly Func<string> StringFuncToExecute;

        public Func<int, int> FuncPropertyWithDefaultValue { get; set; } = x => x * 5;

        public Func<int, int> FuncFromCtorPlus6 = inParameter =>
        {
            int outParameter = inParameter + 6;
            return outParameter;
        };

        private Func<int, int> funcProperty = x => x + 5;
        public Func<int, int> FuncPropertyPlus5 { get => funcProperty; set => funcProperty = value; }

        public void UseFunc()
        {
            var result = (int)FuncPropertyWithDefaultValue.Method.Invoke(10, null);
        }

        public string UseStringFuncModified()
        {
            return StringFuncToExecute() + ",you";
        }

        public string UseStringFunc()
        {
            return StringFuncToExecute();
        }

        public void UseAciton()
        {

        }
    }
}
