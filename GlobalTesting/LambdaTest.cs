using NUnit.Framework;
using System;
using Lib.DelegatesAndLambda;

namespace GlobalTesting
{
    [TestFixture]
    public class LambdaTest
    {
        private LambdaExample labmdaExample;
        private int fixedNumber = 10;
        
        [SetUp]
        public void Setup()
        {
        }


        public Func<int, int> ReturnFunction(int param1) => (x) => { return fixedNumber + param1; };
        public int ReturnFunctionValue(Func<int> func) => func.Invoke();

        [Test]
        [TestCase(5), TestCase(10)]
        public void CheckFunction(int TestCase)
        {
            Assert.AreEqual(fixedNumber + TestCase, ReturnFunction(TestCase).Invoke(TestCase));
        }

        [Test]
        [TestCase(5), TestCase(10)]
        public void CheckFunctionValue(int TestCase)
        {
            Assert.AreEqual(fixedNumber + TestCase, ReturnFunctionValue(() => { return TestCase + fixedNumber; }));
        }

        [Test]
        [TestCase(5), TestCase(10)]
        public void CheckLambdaExample(int TestCase)
        {
            labmdaExample = new LambdaExample();

            var result1 = labmdaExample.FuncPropertyPlus5.Invoke(TestCase);
            Assert.AreEqual(TestCase + 5, result1);
        }

        [Test]
        [TestCase(5), TestCase(10)]
        public void CheckLambdaExample2(int TestCase)
        {
            labmdaExample = new LambdaExample();
            var overridePlus6 = labmdaExample.FuncFromCtorPlus6 = (x) =>
            {
                return TestCase + 7;
            };
            Assert.AreEqual(TestCase + 7, overridePlus6(TestCase));
        }

        [Test]
        [TestCase(5), TestCase(10)]
        public void CheckLambdaExample3(int TestCase)
        {
            labmdaExample = new LambdaExample();
            Assert.AreEqual(TestCase + 6, labmdaExample.FuncFromCtorPlus6.Invoke(TestCase));
            Assert.AreEqual(TestCase + 6, labmdaExample.FuncFromCtorPlus6(TestCase));
        }

        [Test]
        [TestCase(5), TestCase(10)]
        public void CheckLambdaExample4(int TestCase)
        {
            string StrMethod() => "SayHi";
            labmdaExample = new LambdaExample(StrMethod);
            Assert.AreEqual("SayHi", labmdaExample.UseStringFunc());
            Assert.AreEqual("SayHi,you", labmdaExample.UseStringFuncModified());
        }



        [Test]
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