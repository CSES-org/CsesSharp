namespace CsesSharp.Models;

/// <summary>
/// 代表一个 CSES 格式的配置文件
/// </summary>
public record Profile
{
    /// <summary>
    /// CSES 版本号
    /// </summary>
    public string Version { get; set; } = "1";

    /// <summary>
    /// 科目列表
    /// </summary>
    public List<Subject> Subjects { get; set; } = [];
    
    /// <summary>
    /// 课表列表
    /// </summary>
    public List<Schedule> Schedules { get; set; } = [];
}