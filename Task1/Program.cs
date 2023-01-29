RemoveAll(@"C:\test");

static void RemoveAll(string path)
{
    try
    {
        var folder = CheckFolder(path);
        ClearFolder(folder);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
    Console.WriteLine("Папка очищена. Удалены все элементы, которые не использовались более 30 минут.");
}

static DirectoryInfo CheckFolder(string path)
{
    if (!Directory.Exists(path))
    {
        throw new Exception("Указаная папка не найдена.");
    }
    return new DirectoryInfo(path);
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