using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using Lib.LINQ.DataManager;
using System;

namespace Lib.DelegatesAndLambda.Data__Test_
{
    [TestClass]
    public class LambdaTest
    {
        LambdaExample labmdaExample;
        private int fixedNumber = 10;

        public Func<int, int> ReturnFunction(int param1) => (x) => { return fixedNumber + param1; };

        public int ReturnFunctionValue(Func<int> func) => func.Invoke();

        [TestMethod]
        [DataRow(5), DataRow(10)]
        public void CheckFunction(int dataRow)
        {
            Assert.AreEqual(fixedNumber + dataRow, ReturnFunction(dataRow).Invoke(dataRow));
        }

        [TestMethod]
        [DataRow(5), DataRow(10)]
        public void CheckFunctionValue(int dataRow)
        {
            Assert.AreEqual(fixedNumber + dataRow, ReturnFunctionValue(() => { return dataRow + fixedNumber; }));
        }

        [TestMethod]
        [DataRow(5), DataRow(10)]
        public void CheckLambdaExample(int dataRow)
        {
            labmdaExample = new LambdaExample();

            var result1 = labmdaExample.FuncPropertyPlus5.Invoke(dataRow);
            Assert.AreEqual(dataRow + 5, result1);
        }

        [TestMethod]
        [DataRow(5), DataRow(10)]
        public void CheckLambdaExample2(int dataRow)
        {
            labmdaExample = new LambdaExample();
            var overridePlus6 = labmdaExample.FuncFromCtorPlus6 = (x) =>
            {
                return dataRow + 7;
            };
            Assert.AreEqual(dataRow + 7, overridePlus6(dataRow));
        }

        [TestMethod]
        [DataRow(5), DataRow(10)]
        public void CheckLambdaExample3(int dataRow)
        {
            labmdaExample = new LambdaExample();
            Assert.AreEqual(dataRow + 6, labmdaExample.FuncFromCtorPlus6.Invoke(dataRow));
            Assert.AreEqual(dataRow + 6, labmdaExample.FuncFromCtorPlus6(dataRow));
        }

        [TestMethod]
        [DataRow(5), DataRow(10)]
        public void CheckLambdaExample4(int dataRow)
        {
            string StrMethod() => "SayHi";
            labmdaExample = new LambdaExample(StrMethod);
            Assert.AreEqual("SayHi", labmdaExample.UseStringFunc());
            Assert.AreEqual("SayHi,you", labmdaExample.UseStringFuncModified());
        }



        [TestMethod]
        public void CheckLambdaExample5()
        {
            //use original delegate
            labmdaExample = new LambdaExample();
            Assert.AreEqual(11, labmdaExample.FuncFromCtorPlus6(5));

            Func<int, int> overridingForFunc = (x) => { return 20 * x; };
            labmdaExample = new LambdaExample
            {
                FuncFromCtorPlus6 = overridingForFunc
            };
            Assert.AreEqual(100, labmdaExample.FuncFromCtorPlus6(5));
        }

    }


}
