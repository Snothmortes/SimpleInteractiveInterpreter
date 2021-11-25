namespace SimpleInteractiveInterpreter.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture()]
    public class InterpreterTests
    {
        // ReSharper disable once InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles
        private static void check(ref Interpreter interpret, string inp, double? res) {
#pragma warning restore IDE1006 // Naming Styles
            double? result = -9999.99;
            try { result = interpret.input(inp); }
            catch (Exception e) { result = null; }
            if (Math.Abs(Math.Abs((double)(result - res))) > 0.000000000001)
                Assert.Fail("input(\"" + inp + "\") == <" + res + "> and not <" + result + "> => wrong solution, aborted!");
            else
                Console.WriteLine("input(\"" + inp + "\") == <" + res + "> was ok");
        }

        [TestCase(5, 7)]
        public void TestBasicArithmetic(double a, double b) {
            var interpreter = new Interpreter();

            check(ref interpreter, $"{a} - {b}", a - b);
            check(ref interpreter, $"{a} + {b}", a + b);
            check(ref interpreter, $"{a} * {b}", a * b);
            check(ref interpreter, $"{a} / {b}", a / b);
            check(ref interpreter, $"{a} % {b}", a % b);
        }

        [TestCase("x", 7)]
        [TestCase("y", 2)]
        [TestCase("z", 5)]
        public void TestAssignment(string a, double b) {
            var interpreter = new Interpreter();

            check(ref interpreter, $"{a} = {b}", b);
        }

        [Test]
        public void TestChainedAssignment() {
            var interpreter = new Interpreter();

            check(ref interpreter, $"x = y = 7", 7);
        }

        [Test]
        public void TestInvalidAssignment() => Assert.Throws<InvalidOperationException>(() => new Interpreter().input($"y + 6"));

        [TestCase("x", 7, 6)]
        public void TestVariableStorage(string x, double a, double b) {
            var interpreter = new Interpreter();

            check(ref interpreter, $"{x} = {a}", a);
            check(ref interpreter, $"{x} + {b}", a + b);
            check(ref interpreter, $"{x} - {b}", a - b);
            check(ref interpreter, $"{x} * {b}", a * b);
            check(ref interpreter, $"{x} / {b}", a / b);
            check(ref interpreter, $"{x} % {b}", a % b);
        }
    }
}