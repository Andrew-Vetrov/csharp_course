namespace App;

public static class Rectangles
{
    private static bool IsPointInRectangle(int x, int y, int x1, int y1, int x2, int y2)
    {
        return x1 <= x && x <= x2 && y1 <= y && y <= y2;
    }

    private static bool IsCrossed(
        int x1, int y1, int x2, int y2,
        int x3, int y3, int x4, int y4)
    {
        return x3 <= x1 && x2 <= x4 && y1 <= y3 && y4 <= y2;
    }
    public static bool IsIntersected(
        // первый прямоугольник
        int x1, int y1, int x2, int y2,
        // второй прямоугольник
        int x3, int y3, int x4, int y4)
    {
        return (IsPointInRectangle(x1, y1, x3, y3, x4, y4) ||
                IsPointInRectangle(x1, y2, x3, y3, x4, y4) ||
                IsPointInRectangle(x2, y1, x3, y3, x4, y4) ||
                IsPointInRectangle(x2, y2, x3, y3, x4, y4) ||
                IsPointInRectangle(x3, y3, x1, y1, x2, y2) ||
                IsPointInRectangle(x3, y4, x1, y1, x2, y2) ||
                IsPointInRectangle(x4, y3, x1, y1, x2, y2) ||
                IsPointInRectangle(x4, y4, x1, y1, x2, y2) ||
                IsCrossed(x1, y1, x2, y2, x3, y3, x4, y4) ||
                IsCrossed(x3, y3, x4, y4, x1, y1, x2, y2));
    }
    
    public static bool IsNested(
        // первый прямоугольник
        int x1, int y1, int x2, int y2,
        // второй прямоугольник
        int x3, int y3, int x4, int y4)
    {
        return (IsPointInRectangle(x1, y1, x3, y3, x4, y4) &&
                IsPointInRectangle(x1, y2, x3, y3, x4, y4) &&
                IsPointInRectangle(x2, y1, x3, y3, x4, y4) &&
                IsPointInRectangle(x2, y2, x3, y3, x4, y4) ||
                IsPointInRectangle(x3, y3, x1, y1, x2, y2) &&
                IsPointInRectangle(x3, y4, x1, y1, x2, y2) &&
                IsPointInRectangle(x4, y3, x1, y1, x2, y2) &&
                IsPointInRectangle(x4, y4, x1, y1, x2, y2));
    }
}