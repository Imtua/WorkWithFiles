using FinalTask;
using System.Runtime.Serialization.Formatters.Binary;

BinaryFormatter formatter = new BinaryFormatter();
Student[] students = null;

using (var fs = new FileStream("Students.dat", FileMode.OpenOrCreate))
{
    try
    {
        students = (Student[])formatter.Deserialize(fs);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}

string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Students";
if (!Directory.Exists(path))
{
    Directory.CreateDirectory(path);
}

Student.SortStudents(students, path);