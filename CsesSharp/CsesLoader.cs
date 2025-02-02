using CsesSharp.Converters;
using CsesSharp.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CsesSharp;

/// <summary>
/// 负责解析和保存 CSES 配置的静态类
/// </summary>
public static class CsesLoader
{
    private static readonly IDeserializer Deserializer = new DeserializerBuilder()
        .IgnoreUnmatchedProperties()
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .WithEnumNamingConvention(UnderscoredNamingConvention.Instance)
        .WithTypeConverter(DayOfWeekConverter.Instance)
        .Build();
    
    private static readonly ISerializer Serializer = new SerializerBuilder()
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .WithEnumNamingConvention(UnderscoredNamingConvention.Instance)
        .WithTypeConverter(DayOfWeekConverter.Instance)
        .DisableAliases()
        .Build();
    
    /// <summary>
    /// 从 YAML 字符串中加载 CSES 配置
    /// </summary>
    /// <param name="content">YAML 字符串</param>
    /// <returns>CSES 配置</returns>
    public static Profile LoadFromYamlString(string content)
    {
        var profile = Deserializer.Deserialize<Profile>(content);
        foreach (var i in profile.Schedules)
        {
            i.Classes.Sort((x, y) => x.StartTime < y.StartTime ? -1 : 1);
        }
        return profile;
    }

    /// <summary>
    /// 从 YAML 文件中加载 CSES 配置
    /// </summary>
    /// <param name="path">YAML 文件路径</param>
    /// <returns>CSES 配置</returns>
    public static Profile LoadFromYamlFile(string path)
    {
        return LoadFromYamlString(File.ReadAllText(path));
    }
    
    /// <summary>
    /// 将 CSES 配置保存为 YAML 字符串
    /// </summary>
    /// <param name="profile">要保存的 CSES 配置</param>
    /// <returns>YAML 字符串</returns>
    public static string SaveToYamlString(Profile profile)
    {
        return Serializer.Serialize(profile);
    }
    
    /// <summary>
    /// 将 CSES 配置保存到 YAML 文件
    /// </summary>
    /// <param name="profile">要保存的 CSES 配置</param>
    /// <param name="path">要写入的文件路径</param>
    public static void SaveToYamlFile(Profile profile, string path)
    {
        File.WriteAllText(path, SaveToYamlString(profile));
    }
}