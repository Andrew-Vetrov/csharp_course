using App;

namespace AppTests;

public class DistanceTests
{
    [TestCase(0, 0, 0, 0, 0, 0, 0)]
    [TestCase(1, 1, 1, 1, 1, 1, 0)]
    [TestCase(3, 3, 2, 2, 3, 3, 0)]
    [TestCase(-1, -1, -1, -1, 500, 123, 0)]
    [TestCase(1, -5, -2, 0, 4, 0, 5)]
    [TestCase(1, 3, 1, 1, 3, 3, 1.4142135623730951)]
    public void TestPasses_When_Result_Correct(
        // позиция курсора
        double x, double y,
        // отрезок
        double x1, double y1, double x2, double y2,
        double expected)
    {
        var actual = Distance.DistanceToSegment(x, y, x1, y1, x2, y2);
        Assert.That(actual, Is.EqualTo(expected));
    }
}