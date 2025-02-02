using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace CsesSharp.Converters;

/// <summary>
/// 将 <see cref="DayOfWeek"/> 转换为 YAML 的类型转换器
/// </summary>
public class DayOfWeekConverter : IYamlTypeConverter
{
    /// <summary>
    /// 一个 <see cref="DayOfWeekConverter"/> 实例
    /// </summary>
    public static readonly IYamlTypeConverter Instance = new DayOfWeekConverter();
    
    /// <inheritdoc />
    public bool Accepts(Type type)
    {
        return type == typeof(DayOfWeek);
    }

    /// <inheritdoc />
    public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer)
    {
        var str = parser.Consume<Scalar>().Value;
        return str.ToLower() switch
        {
            "1" => DayOfWeek.Monday,
            "2" => DayOfWeek.Tuesday,
            "3" => DayOfWeek.Wednesday,
            "4" => DayOfWeek.Thursday,
            "5" => DayOfWeek.Friday,
            "6" => DayOfWeek.Saturday,
            "7" => DayOfWeek.Sunday,
            _ => throw new YamlException($"Unknown day of week: {str}")
        };
    }

    /// <inheritdoc />
    public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer)
    {
        var str = value switch
        {
            DayOfWeek.Monday => "1",
            DayOfWeek.Tuesday => "2",
            DayOfWeek.Wednesday => "3",
            DayOfWeek.Thursday => "4",
            DayOfWeek.Friday => "5",
            DayOfWeek.Saturday => "6",
            DayOfWeek.Sunday => "7",
            _ => throw new YamlException($"Unknown day of week: {value}")
        };
        emitter.Emit(new Scalar(str));
    }
}