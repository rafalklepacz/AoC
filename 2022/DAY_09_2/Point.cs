namespace DAY_09_2;

public struct Point
{
    public Point()
    {
        X = 0;
        Y = 0;
    }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Point Default
        => Zero;
    
    public static Point Zero
        => new(0, 0);

    public int X { get; private set; }
    public int Y { get; private set; }

    public void Add(Point point)
    {
        X += point.X;
        Y += point.Y;
    }

    public Point GetDistance(Point point)
        => new(X - point.X, Y - point.Y);

    public static Point operator +(Point a, Point b)
        => new(a.X + b.X, a.Y + b.Y);

    public static Point operator -(Point a, Point b)
        => new(a.X - b.X, a.Y - b.Y);

    public static bool operator ==(Point a, Point b)
        => a.X == b.X && a.Y == b.Y;

    public static bool operator !=(Point a, Point b)
        => !(a == b);

    public override bool Equals(object obj)
        => obj is Point p && X == p.X && Y == p.Y;

    public override int GetHashCode()
        => HashCode.Combine(X, Y);

    public override string ToString()
        => $"Point {{ X: {X}, Y: {Y} }}";
}