﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace week1
{    
    public class Brackets
    {
        public static bool Parse(TextReader input,
                          out IList<PassError> errors)
        {
            errors = new List<PassError>();

            return false;
        }
    }

    public class PassError
    {
        public char Type { get; }
        public int Position { get; set; }
    }


    public class CheckBrackets
    {
        public static void MainTest(string[] args) {
        }
    }
}
