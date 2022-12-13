namespace DAY_09_1;

public class Rope
{
    public static Rope CreateAtDefaultPoint()
        => CreateAtPoint(Point.Default);

    public static Rope CreateAtPoint(Point startPoint)
        => new(startPoint, startPoint);

    public static Rope CreateAtPoint(int x, int y)
        => CreateAtPoint(new Point(x, y));

    public void Move(Point move)
    {
        MoveHead(move);

        if (TailNeedsToMove)
            MoveTail();

        _tailMove += move;
    }

    public Point DistanceBetweenHeadAndTail
        => Head.GetDistance(Tail);

    private Rope(Point head, Point tail)
    {
        Head = head;
        Tail = tail;

        _tailPositions.Add(Tail);
    }

    public Point Head { get; private set; }
    public Point Tail { get; private set; }

    private void MoveHead(Point move)
        => Head += move;

    private void MoveTail()
    {
        Tail += _tailMove;

        ResetTailMove();

        _tailPositions.Add(Tail);
    }

    public void ResetTailMove()
        => _tailMove = Point.Default;

    private bool TailNeedsToMove
        => Math.Abs(DistanceBetweenHeadAndTail.X) > 1 || Math.Abs(DistanceBetweenHeadAndTail.Y) > 1;

    public IEnumerable<Point> TailPositions
        => _tailPositions;

    private Point _tailMove = Point.Default;
    private readonly List<Point> _tailPositions = new();
}