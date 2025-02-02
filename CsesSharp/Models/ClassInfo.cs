using CsesSharp.Enums;

namespace CsesSharp.Models;

/// <summary>
/// 代表一节课程
/// </summary>
public record ClassInfo
{
    /// <summary>
    /// 科目名称。需要和 Profile.Subjects 中的 Name 字段匹配。
    /// </summary>
    public string Subject { get; set; } = "";
    
    /// <summary>
    /// 这节课在一天中的开始时间
    /// </summary>
    public TimeSpan StartTime { get; set; } = TimeSpan.Zero;
    
    /// <summary>
    /// 这节课在一天中的结束时间
    /// </summary>
    public TimeSpan EndTime { get; set; } = TimeSpan.Zero;

}