using System;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using System.Linq;

namespace Est_Groups
{
    public class sorterGroups
    {
        private static Random random = new Random();

        public static List<Groups> GenerateRandomGroups(int groupSize, List<string> studentList, List<string> topicsList)
        {
            List<Groups> groupList = new List<Groups>();

            if (groupSize > 1)
            {
                int cantGroup = studentList.Count / groupSize;
                bool cantStudents = studentList.Count >= groupSize;
                bool cantTopics = topicsList.Count >= cantGroup;

                if (cantStudents && cantTopics)
                {
                    int Topics_Groups = topicsList.Count / cantGroup;

                    int distStudent = studentList.Count % groupSize;
                    int distTopics = topicsList.Count % cantGroup;

                    for (int i = 0; i < cantGroup; i++)
                    {
                        Groups group = new Groups();

                        group.Num = i + 1;

                        group.Est = RandomizeGroupLimit(group.Est, studentList, groupSize);
                        group.Topic = RandomizeGroupLimit(group.Topic, topicsList, Topics_Groups);

                        groupList.Add(group);
                    }

                    if (distStudent != 0)
                    {
                        groupList = DistributeRem(groupList, studentList, cantGroup, "students");
                    }
                    if (distTopics != 0)
                    {
                        groupList = DistributeRem(groupList, topicsList, cantGroup, "topics");
                    }
                }
                else
                {

                    if (!cantStudents)
                    {
                        Console.WriteLine("Error: No hay suficientes estudiantes para formar grupos");
                    }
                    if (!cantTopics)
                    {
                        Console.WriteLine("Error: No hay suficientes temas para la cantidad de grupos");
                    }
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Error: Los grupos deben tener al menos dos estudiante");
                return null;
            }
                return groupList;
            }

        
            private static List<string> RandomizeGroupLimit(List<string> groupLimit, List<string> list, int randLimit)
            {
               while (groupLimit.Count != randLimit)
               {
                 int id = GetRandomInteger(list.Count);
                 groupLimit.Add(list[id]);
                 list.RemoveAt(id);
               }
            return groupLimit;
           }
            private static List<Groups> DistributeRem(List<Groups> groupList, List<string> list, int cantGroup, string limit)
            {
                bool valid = limit == "students" || limit == "topics";
                List<int> extraGroup = new List<int>(new int[cantGroup]);
                List<string> limitList = new List<string>();

                if(valid)
                {
                    while (list.Count != 0)
                    {
                        int groupId = GetRandomInteger(cantGroup);

                        if (extraGroup[groupId] == extraGroup.Min())
                        {
                           int id = GetRandomInteger(list.Count);

                           if (limit == "students")
                           {
                              limitList = groupList[groupId].Est;
                           }
                           else
                           {
                              limitList = groupList[groupId].Topic;

                           }
                            limitList.Add(list[id]);
                            list.RemoveAt(id);
                            extraGroup[groupId]++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error: Grupo invalido");
                }
                return groupList;
            }

            private static int GetRandomInteger(int maxValue)
            {
                return random.Next(0, maxValue);
            }
            public static void PrintGroups(List<Groups> groupList)
            {
                foreach (Groups group in groupList)
                {
                    Console.Write(group.ToString());
                    Console.WriteLine();
                }
            }
        }

    }

