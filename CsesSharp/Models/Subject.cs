
namespace CsesSharp.Models;

/// <summary>
/// 代表一个科目
/// </summary>
public record Subject
{
    /// <summary>
    /// 科目名称
    /// </summary>
        
    public string Name { get; set; } = "";
        
    /// <summary>
    /// 科目简称
    /// </summary>
    public string SimplifiedName { get; set; } = "";

    /// <summary>
    /// 教室名称
    /// </summary>
    public string Teacher { get; set; } = "";
        
    /// <summary>
    /// 房间号
    /// </summary>
    public string Room { get; set; } = "";
}