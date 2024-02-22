using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Display_Best_Student
{
    public class Student
    {
        public string Name { get; set; }
        public float AverageTestResult { get; set; }
        public float AverageAnnual {  get; set; }

        public Student(string name, float averageTestResult, float averageAnnual) 
        {
            Name = name;
            AverageTestResult = averageTestResult;
            AverageAnnual = averageAnnual;
        }
    }
}
