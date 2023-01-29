using System;

namespace FinalTask
{
    [Serializable]
    internal class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"Имя: {Name}, день рождения {DateOfBirth.ToShortDateString()}";
        }

        public static void SortStudents(Student[] students, string pathOfDirectory)
        {
            foreach (var student in students)
            {
                var file = new FileInfo(pathOfDirectory + @"\" + student.Group + ".txt");
                if (!file.Exists)
                {
                    file.Create();
                }
                using (StreamWriter sw = file.AppendText())
                {
                    sw.WriteLine(student.ToString());
                }
            }
        }
    }
}