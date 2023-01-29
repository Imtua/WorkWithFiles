string path1 = @"C:\VSPROJ\ArraysApp";
AnalysisFolder(path1);

void AnalysisFolder(string path)
{
    try
    {
        var folder = CheckFolder(path);
        long spaceBeforeClear = CountFolderSize(folder);
        ClearFolder(folder);
        long spaceAfterClear = CountFolderSize(folder);
        long vacatedSpace = spaceBeforeClear - spaceAfterClear;

        Console.WriteLine($"Исходный размер папки: {spaceBeforeClear} байт");
        Console.WriteLine($"Освобождено: {vacatedSpace} байт");
        Console.WriteLine($"Текущий размер папки: {spaceAfterClear} байт");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
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

static void ClearFolder(DirectoryInfo folder)
{
    foreach (var item in folder.GetFiles())
    {
        if ((DateTime.Now - item.LastAccessTime) > TimeSpan.FromMinutes(30))
        {
            item.Delete();
        }
    }

    foreach (var item in folder.GetDirectories())
    {
        if ((DateTime.Now - item.LastAccessTime) > TimeSpan.FromMinutes(30))
        {
            ClearFolder(item);
            item.Delete();
        }
    }
}