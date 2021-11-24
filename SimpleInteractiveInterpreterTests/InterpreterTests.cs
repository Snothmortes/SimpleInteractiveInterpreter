using System;
using NUnit.Framework;
using SimpleInteractiveInterpreter;

namespace SimpleInteractiveInterpreter.Tests
{
    [TestFixture()]
    public class InterpreterTests
    {
        private static void check(ref Interpreter interpret, string inp, double? res) {
            double? result = -9999.99;
            try { result = interpret.input(inp); }
            catch (Exception) { result = null; }
            if (result != res)
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

        [TestCase("a", 7)]
        [TestCase("a", 2)]
        [TestCase("a", 5)]
        public void TestAssignment(string a, double b) {
            var interpreter = new Interpreter();

            check(ref interpreter, $"{a} = {b}", b);
        }

        [TestCase("a", 7, 6)]
        public void TestVariableStorage(string a, double b, double c) {
            var interpreter = new Interpreter();

            check(ref interpreter, $"{a} = {b}", b);
            check(ref interpreter, $"{a} + {b}", c);
        }
    }
}