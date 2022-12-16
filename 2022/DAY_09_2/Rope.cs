namespace DAY_09_2;

public class Rope
{
    public static Rope CreateAtDefaultPosition(int knots)
        => CreateAtPosition(knots, Point.Default);

    public static Rope CreateAtPosition(int knots, Point position)
        => new(knots, position);

    public void Move(Point move)
    {
        MoveFirstKnot(move);

        for (int index = 0; index < _knots.Length; index++)
        {
            var nextIndex = index + 1;
            if (nextIndex < _knots.Length)
                MoveNextKnot(index, nextIndex);
        }
    }

    private Rope(int knots, Point position)
    {
        _knots = CreateKnots(knots, position);
        _lastKnotPositions.Add(position);
    }

    private static Point[] CreateKnots(int knots, Point position)
        => Enumerable.Repeat(position, knots).ToArray();

    private void MoveFirstKnot(Point move)
        => _knots[0].Add(move);

    private void MoveNextKnot(int index, int nextIndex)
    {
        _knots[nextIndex] += GetNextMove(index, nextIndex);
        
        bool isLastKnot = nextIndex == _knots.Length - 1;
        if (isLastKnot)
            _lastKnotPositions.Add(_knots[nextIndex]);
    }

    private Point GetNextMove(int index, int nextIndex)
    {
        var current = _knots[index];
        var next = _knots[nextIndex];
        var distance = current.GetDistance(next);

        var areVertically = current.X == next.X;
        var areHorizontally = current.Y == next.Y;

        var tooFarVertically = Math.Abs(distance.Y) > 1;
        var tooFarHorizontally = Math.Abs(distance.X) > 1;

        var x = tooFarHorizontally && areHorizontally ? Math.Sign(distance.X) : 0;
        var y = tooFarVertically && areVertically ? Math.Sign(distance.Y) : 0;

        if ((tooFarHorizontally && !areHorizontally) || (tooFarVertically && !areVertically))
        {
            x = Math.Sign(distance.X);
            y = Math.Sign(distance.Y);
        }

        return new(x, y);
    }

    public IEnumerable<Point> LastKnotPositions
        => _lastKnotPositions;

    private readonly List<Point> _lastKnotPositions = new();
    private readonly Point[] _knots;
}