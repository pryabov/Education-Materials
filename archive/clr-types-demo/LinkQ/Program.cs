using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var someClass = new SomeClass();

            //someClass.DefaultExecution();
            //someClass.DeferredExecution();
            //someClass.DeferredExecutionAlternative();
            //someClass.ImmediateExecution();
            //someClass.Join();
            //someClass.JoinAlternative();
            someClass.GroupJoin();
        }
    }

    class SomeClass
    {
        IList<CodeLanguage> codeLanguages = new List<CodeLanguage>
        {
            new CodeLanguage { Name = "Java", FrameworkName = "Java" },
            new CodeLanguage { Name = "Ruby", FrameworkName = "Ruby" },
            new CodeLanguage { Name = "Perl", FrameworkName = "Perl" },
            new CodeLanguage { Name = "F#", FrameworkName = ".NET" },
            new CodeLanguage { Name = "C++/CLI", FrameworkName = ".NET" },
            new CodeLanguage { Name = "C#", FrameworkName = ".NET" },
        };

        IList<Framework> frameworks = new List<Framework>
        {
            new Framework { Name = ".NET", Corporation = "Microsoft" },
            new Framework { Name = "Java", Corporation = "Sun" },
            new Framework { Name = "Ruby", Corporation = "Matz" },
            new Framework { Name = "Perl", Corporation = "Larry Wall" },
        };

        public void DefaultExecution()
        {
            var selectedCodeLanguages = from cl in codeLanguages where cl.Name.ToUpper().StartsWith("C") orderby cl select cl;

            foreach (var item in selectedCodeLanguages)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine();
        }

        public void DeferredExecution()
        {
            var selectedCodeLanguages = from cl in codeLanguages orderby cl select cl;

            codeLanguages.ElementAt(2).Name = "Haskel";

            foreach (var item in selectedCodeLanguages)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();

            codeLanguages.ElementAt(2).Name = "Perl";
        }

        public void DeferredExecutionAlternative()
        {
            var selectedCodeLanguages = codeLanguages.Select(cl => cl);

            codeLanguages.Add(new CodeLanguage { Name = "Haskel", FrameworkName = "test" });

            foreach (var item in selectedCodeLanguages)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine();

            codeLanguages.Add(new CodeLanguage { Name = "Haskel2", FrameworkName = "test" });

            foreach (var item in selectedCodeLanguages)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void ImmediateExecution()
        {
            var codeLanguagesCount = (from cl in codeLanguages orderby cl select cl).Count();

            Console.WriteLine($"array items count: {codeLanguagesCount}");

            codeLanguages.Add(new CodeLanguage { Name = "Haskel", FrameworkName = "test" });

            codeLanguagesCount = (from cl in codeLanguages orderby cl select cl).Count();

            Console.WriteLine($"array items count: {codeLanguagesCount}");

            Console.WriteLine();

            codeLanguages.ElementAt(2).Name = "Perl";
        }

        public void Join()
        {
            var result = from cl in codeLanguages
                         join f in frameworks on cl.FrameworkName equals f.Name
                         select new { Language = cl.Name, Framework = cl.FrameworkName, Corporation = f.Corporation };

            foreach (var item in result)
            {
                Console.WriteLine("{0} - {1} ({2})", item.Language, item.Framework, item.Corporation);
            }

            Console.WriteLine();
        }

        public void JoinAlternative()
        {
            var result = codeLanguages.Join(frameworks,
             cl => cl.FrameworkName,
             f => f.Name,
             (cl, f) => new { Language = cl.Name, Framework = cl.FrameworkName, Corporation = f.Corporation });

            foreach (var item in result)
            {
                Console.WriteLine("{0} - {1} ({2})", item.Language, item.Framework, item.Corporation);
            }

            Console.WriteLine();
        }

        public void GroupJoin()
        {
            var result2 = frameworks.GroupJoin(
                        codeLanguages,
                        f => f.Name,
                        cl => cl.FrameworkName,
                        (f, cl) => new 
                        {
                            Name = f.Name,
                            Corporation = f.Corporation,
                            CodeLanguages = cl.Select(c => c.Name)
                        });

            foreach (var framework in result2)
            {
                Console.WriteLine(framework.Name);
                foreach (string codeLanguage in framework.CodeLanguages)
                {
                    Console.WriteLine($"\t{codeLanguage}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }

    class Framework : IComparable
    {
        public string Name { get; set; }
        public string Corporation { get; set; }

        public int CompareTo(object obj)
        {
            var frameworkObj = obj as Framework;

            return string.Compare(Name, frameworkObj?.Name, StringComparison.InvariantCultureIgnoreCase);
        }
    }

    class CodeLanguage : IComparable
    {
        public string Name { get; set; }
        public string FrameworkName { get; set; }

        public int CompareTo(object obj)
        {
            var codeLanguageObj = obj as CodeLanguage;

            return string.Compare(Name, codeLanguageObj?.Name, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
