using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class MassageTool
{
    // 序列化并写入文件
    public static void SaveToFile<T>(T obj, string path)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = false,
            // 如果需要保留对象引用（对象图），启用下面一行（需要 .NET 5+）
            ReferenceHandler = ReferenceHandler.Preserve
        };
        using var fs = File.Create(path);
        JsonSerializer.Serialize(fs, obj, options);
    }

    // 从文件反序列化
    public static T LoadFromFile<T>(string path)
    {
        using var fs = File.OpenRead(path);
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };
        return JsonSerializer.Deserialize<T>(fs, options)!;
    }
}