﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.CommandLineUtils;

namespace hrk {
    class EntryPoint {
        private static readonly Assembly asm = Assembly.GetAssembly(typeof(EntryPoint));
        private static readonly string mainTest = "MainTest";
        private static readonly string nameSpace = "hrk";
        private static SortedSet<string> GetAllTestClasses() {
            Type[] types = asm.GetTypes().Where(t => (t.IsPublic && t.GetMethod(mainTest) != null)).ToArray();
            Regex genericType = new Regex(@"\w+`\d");
            SortedSet<string> allNames = new SortedSet<string>();
            foreach (var t0 in types) {
                string name;
                if (genericType.IsMatch(t0.Name)) {
                    Match m = genericType.Match(t0.Name);
                    name = m.Value;
                    name = name.Substring(0, name.Length - 2);
                }
                else
                    name = t0.Name;

                allNames.Add(name);
            }
            return allNames;
        }

        private static MethodInfo GetMainTest(string className) {
            string fullName;
            if (!className.Contains(nameSpace))
                fullName = nameSpace + "." + className;
            else
                fullName = className;

            Type type = asm.GetType(fullName);
            MethodInfo testMethod = type.GetMethod(mainTest);
            return testMethod;
        }


        private static void ListTestCases() {
            try {
                SortedSet<string> classNames = GetAllTestClasses();

                Console.Write(@"
==========================================
TEST CASES
==========================================
");
                int i = 1;
                foreach (var name in classNames) {
                    Console.WriteLine($" {i++}. {name}");
                }

                Console.WriteLine();
            }
            catch (Exception ex) {
                string inner = ex.Message;
                Console.WriteLine("Error: {0}", inner);
            }
        }

        [STAThread]
        static void Main(string[] args) {
            CommandLineApplication app = new CommandLineApplication(throwOnUnexpectedArg: false);
            var test = app.Option("-t | --test <class>", "Test Class", CommandOptionType.SingleValue);
            var list = app.Option("-l | --list", "List Test Class", CommandOptionType.NoValue);
            app.HelpOption("-? | -h | --help");
            app.OnExecute(() => {
                if (!list.HasValue() && !test.HasValue()) {
                    app.ShowHelp();
                }
                else if (list.HasValue()) {
                    ListTestCases();
                }
                else {
                    try {
                        // test method invocation
                        string className = test.Value();
                        MethodInfo testMethod = GetMainTest(className);
                        if (testMethod != null) {
                            string[] testArgs = new string[app.RemainingArguments.Count];
                            for (int i = 0; i < testArgs.Length; i++) {
                                testArgs[i] = app.RemainingArguments[i];
                            }
                            testMethod.Invoke(null, new object[] { testArgs });
                        }
                        else
                            Console.WriteLine("No demo test for: {0}", className);
                    }
                    catch (Exception ex) {
                        string inner = ex.InnerException.Message;
                        Console.WriteLine("Test run error: {0}", inner);
                    }
                }

                return 1;
            });
            app.Execute(args);
        }
    }
}
