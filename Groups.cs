using System;
using System.Collections.Generic;
using System.Text;

namespace Est_Groups
{
    public class Groups
    {
        public int Num { get; set; }
        public List<string> Est { get; set; }
        public List<string> Topic { get; set; }

        public Groups()
        {
            Est = new List<string>();
            Topic = new List<string>();
        }

        public override string ToString()
        {
            return $"Grupo {Num}" + $"(Estudiantes: {Est.Count}, Temas: {Topic.Count})\n" +
                $"\nEstudiantes:\n {string.Join("\n", Est)}\n" +
                $"Temas: \n{string.Join("\n", Topic)}\n" +
                $"----------------------------------------------------------";
        }
    }
}
