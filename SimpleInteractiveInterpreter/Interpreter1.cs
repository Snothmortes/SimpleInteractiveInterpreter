﻿using System.Data;
using System.Diagnostics;

namespace SimpleInteractiveInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class Interpreter
    {
        static void Main(string[] args) {
            Debug.WriteLine(double.Parse(new DataTable().Compute("6 + 7", null).ToString()));
        }
    }
}