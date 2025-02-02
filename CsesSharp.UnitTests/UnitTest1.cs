namespace CsesSharp.UnitTests;

public class TestLoadProfile
{
    private const string Config1 = 
        """
        version: 1
        subjects:
          - name: 数学
            simplified_name: 数 # 可选，适合中文科目名，ClassIsland 等紧凑课程表软件一般需要
            teacher: 李梅 # 可选
            room: 101 # 可选
          - name: 语文
            simplified_name: 语
            teacher: 王芳
            room: 102
          - name: 英语
            simplified_name: 英
            teacher: 张伟
            room: 103
          - name: 物理
            simplified_name: 物
            teacher: 赵军
            room: 104
        
        schedules:
          - name: 星期一
            enable_day: 1
            weeks: all
            classes:
              - subject: 数学
                start_time: "08:00:00"
                end_time: "09:00:00"
              - subject: 语文
                start_time: "09:00:00"
                end_time: "10:00:00"
          - name: 星期二-单周
            enable_day: 2
            weeks: odd
            classes:
              - subject: 物理
                start_time: "08:00:00"
                end_time: "09:00:00"
              - subject: 英语
                start_time: "09:00:00"
                end_time: "10:00:00"
          - name: 星期二-双周
            enable_day: 2
            weeks: even
            classes:
              - subject: 物理
                start_time: "08:00:00"
                end_time: "09:00:00"
              - subject: 英语
                start_time: "09:00:00"
                end_time: "10:00:00"                           
        """;
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var profile = CsesLoader.LoadFromYamlString(Config1);
        Assert.Multiple(() =>
        {
            Assert.That(profile.Version, Is.EqualTo("1"));
            Assert.That(profile.Subjects, Has.Count.EqualTo(4));
            Assert.That(profile.Schedules, Has.Count.EqualTo(3));
        });
    }
}