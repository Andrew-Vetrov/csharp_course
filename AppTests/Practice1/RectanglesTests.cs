using App;

namespace AppTests;

public class RectanglesTests
{
    [TestCase(0, 0, 1, 1, 1, 1, 2, 2, true)] // one common point
    [TestCase(0, 0, 1, 1, 2, 2, 3, 3, false)]
    [TestCase(1, 0, 2, 3, 0, 1, 3, 2, true)] // cross
    [TestCase(1, 0, 2, 1, 0, 2, 3, 3, false)]
    [TestCase(0, 0, 5, 5, 2, 2, 6, 2, true)] // two points in rectangle
    [TestCase(0, 0, 0, 0, 0, 0, 0, 0, true)]
    [TestCase(2, 0, 2, 5, 1, 2, 3, 4, true)] // line segment and rectangle
    [TestCase(2, 0, 2, 1, 1, 2, 3, 4, false)]
    [TestCase(1, 1, 3, 1, 0, 0, 4, 4, true)] // line segment in rectangle
    [TestCase(2, 2, 3, 2, 0, 0, 1, 1, false)]
    public void TestPasses_When_IsIntersectedResult_Correct(
        // первый прямоугольник
        int x1, int y1, int x2, int y2,
        // второй прямоугольник
        int x3, int y3, int x4, int y4,
        bool expected)
    {
        var actual = Rectangles.IsIntersected(x1, y1, x2, y2, x3, y3, x4, y4);
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    //TODO напишите свои тесты
    [TestCase(0, 0, 3, 3, 1, 1, 2, 2, true)]
    [TestCase(0, 0, 1, 1, 1, 1, 2, 2, false)]
    public void TestPasses_WhenIsNestedResult_Correct(
        // первый прямоугольник
        int x1, int y1, int x2, int y2,
        // второй прямоугольник
        int x3, int y3, int x4, int y4,
        bool expected)
    {
        var actual = Rectangles.IsNested(x1, y1, x2, y2, x3, y3, x4, y4);
        Assert.That(actual, Is.EqualTo(expected));
    }
}