using System;
using System.IO;
using System.Collections.Generic;

namespace Est_Groups
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            int groupSize;

            List<string> student = new List<string>();
            List<string> topics = new List<string>();
            string readline = "";

            StreamReader readerEst = new StreamReader(File.OpenRead(@"./estudiantes.txt"));
            StreamReader readerTopic = new StreamReader(File.OpenRead(@"./temas.txt"));

            Console.Write("Ingrese la cantidad de estudiantes por cada grupo: ");
            string input = Console.ReadLine();

            bool validation = Int32.TryParse(input, out groupSize);

            if(validation)
            {
                while (!readerEst.EndOfStream)
                {
                    readline = readerEst.ReadLine();
                    string[] values = readline.Split(',');

                    student.Add(values[0]);
                }
                while (!readerTopic.EndOfStream)
                {
                    readline = readerTopic.ReadLine();
                    string[] values = readline.Split(',');

                    topics.Add(values[0]);
                }
                List<Groups> groupList = new List<Groups>();

                groupList = sorterGroups.GenerateRandomGroups(groupSize, student, topics);

                if (groupList != null)
                {
                    sorterGroups.PrintGroups(groupList);
                }
                else
                {
                    Console.WriteLine("Valores invalidos");
                }
            }
        }
    }
}
