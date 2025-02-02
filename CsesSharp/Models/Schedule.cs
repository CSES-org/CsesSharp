using CsesSharp.Enums;

namespace CsesSharp.Models;

/// <summary>
/// 代表一个课表
/// </summary>
public record Schedule
{

    /// <summary>
    /// 课表名称
    /// </summary>
    public string Name { get; set; } = "";
    
    /// <summary>
    /// 一天中的课程
    /// </summary>
    public List<ClassInfo> Classes { get; set; } = [];

    /// <summary>
    /// 这个课程表启用的星期数，从星期日（0）开始
    /// </summary>
    public DayOfWeek EnableDay { get; set; } = DayOfWeek.Monday;
    
    /// <summary>
    /// 单双周启用类型
    /// </summary>
    public WeekType Weeks { get; set; } = WeekType.All;
}