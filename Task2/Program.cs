string path = @"C:\VSPROJ";
GetFolderSize(path);

static void GetFolderSize(string path)
{
    try
    {
        var folder = CheckFolder(path);
        long folderSize = CountFolderSize(folder);
        Console.WriteLine($"Папка весит: {folderSize} байт");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка {ex.Message}");
    }
}

static DirectoryInfo CheckFolder(string path)
{
    if (!Directory.Exists(path))
    {
        throw new Exception("Указаная папка не найдена.");
    }
    return new DirectoryInfo(path);
}

static long CountFolderSize(DirectoryInfo folder)
{
    long counter = 0;
    foreach (var item in folder.GetFiles())
    {
        counter += item.Length;
    }

    foreach (var item in folder.GetDirectories())
    {
        counter += CountFolderSize(item);
    }

    return counter;

}