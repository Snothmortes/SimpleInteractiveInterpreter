using System;
using NUnit.Framework;

namespace SimpleInteractiveInterpreter.Tests
{
    [TestFixture()]
    public class InterpreterTests
    {
        private static void check(ref Interpreter interpret, string inp, double? res) {
            double? result = -9999.99;
            try { result = interpret.input(inp); }
            catch (Exception e) { result = null; }
            if (Math.Abs(Math.Abs((double) (result - res))) > 0.000000000001)
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
        [TestCase("x", 2)]
        [TestCase("x", 5)]
        public void TestAssignment(string a, double b) {
            var interpreter = new Interpreter();

            check(ref interpreter, $"{a} = {b}", b);
        }

        [TestCase("x", 7, 6)]
        public void TestVariableStorage(string x, double a, double b) {
            var interpreter = new Interpreter();

            check(ref interpreter, $"{x} = {a}", a);
            check(ref interpreter, $"{x} + {b}", a + b);
        }
    }
}