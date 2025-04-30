namespace App;

public static class Distance
{
    private static double DistanceBetweenPoints(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
    }
    public static double DistanceToSegment(
        // позиция курсора
        double x, double y,
        // отрезок
        double x1, double y1, double x2, double y2)
    {
        if (x1 == x2 && y1 == y2)
        {
            return DistanceBetweenPoints(x, y, x1, y1);
        }

        double pointProjection = ((x - x1) * (x2 - x1) + (y - y1) * (y2 - y1)) /
                                 ((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

        if (pointProjection <= 0)
        {
            return DistanceBetweenPoints(x, y, x1, y1);
        }

        if (pointProjection >= 1)
        {
            return DistanceBetweenPoints(x, y, x2, y2);
        }
        
        return DistanceBetweenPoints(x, y, x1 + pointProjection * (x2 - x1), y1 + pointProjection * (y2 - y1));
    }
}