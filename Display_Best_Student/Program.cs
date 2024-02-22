using Microsoft.VisualBasic.FileIO;
using System.Globalization;

namespace Display_Best_Student
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Data", "STUDENT_RESULTS.csv");
            Student bestStudent = FindBestStudent(csvFilePath);
            DisplayBestStudent(bestStudent);
        }
        
        static Student FindBestStudent(string csvFilePath)
        {
            Student student = new Student("",float.MinValue,float.MinValue);

            using (TextFieldParser parser = new TextFieldParser(csvFilePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");

                // Skip header row
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    string name = fields[0];
                    float avgTest = float.Parse(fields[1]);
                    float avgYear = float.Parse(fields[2]);

                    if (avgYear > student.AverageAnnual || (avgYear == student.AverageAnnual && avgTest > student.AverageTestResult))
                    {
                        student.Name = name;
                        student.AverageAnnual = avgYear;
                        student.AverageTestResult = avgTest;
                    }
                }
            }

            return student;
        }

        static void DisplayBestStudent(Student student)
        {
            Console.WriteLine($"The best student is {student.Name} with an average test result of {student.AverageTestResult} and an annual score of {student.AverageAnnual}.");
        }
    }
}
