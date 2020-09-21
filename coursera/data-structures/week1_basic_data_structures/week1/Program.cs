using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.CommandLineUtils;

namespace week1
{
    class EntryPoint {
        private static readonly Assembly asm = Assembly.GetAssembly(typeof(StdIn));
        private static readonly string mainTest = "MainTest";
        private static readonly string nameSpace = "week1";

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
            CommandLineApplication app = new CommandLineApplication(throwOnUnexpectedArg: true);
            var test = app.Option("-t | --test <class>", "Test Class", CommandOptionType.SingleValue);
            var list = app.Option("-l | --list", "List Test Class", CommandOptionType.NoValue);
            app.HelpOption("-? | -h | --help");
            app.OnExecute(() => {
                if (!list.HasValue() && !test.HasValue()) {
                    app.ShowHelp();
                }

                if (list.HasValue()) {
                    ListTestCases();
                }
                else {

                    // test method invocation
                    string className = test.Value();
                    try {
                        MethodInfo testMethod = GetMainTest(className);
                        if (testMethod != null) {
                            string[] testArgs = new string[args.Length];
                            for (int i = 0; i < args.Length; i++) {
                                testArgs[i] = args[i];
                            }

                            
                            testMethod.Invoke(null, new object[] {testArgs});
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
