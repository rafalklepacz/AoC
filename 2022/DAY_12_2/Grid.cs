namespace DAY_12_2;

public record Grid
{
    private readonly Square[][] _squares;

    public Grid(Square[][] squares)
    {
        _squares = squares;
        UpdateAvailableSquares();
    }

    public int CalculateDistance()
    {
        int distance = 0;
        var visited = new List<Square>();
        var queue = new Queue<(int Distance, Square Square)>();
        
        var endSquare = _squares.SelectMany(s => s).First(s => s.Letter == 'E');

        visited.Add(endSquare);
        queue.Enqueue((distance, endSquare));

        while (queue.Count > 0)
        {
            var queueItem = queue.Dequeue();

            foreach (var availableSquare in queueItem.Square.AvailableSquares)
            {
                if (visited.Contains(availableSquare))
                    continue;
                
                distance = queueItem.Distance + 1;

                if (availableSquare.Letter == 'a')
                    return distance;

                visited.Add(availableSquare);
                queue.Enqueue((distance, availableSquare));
            }
        }
        
        return distance;
    }

    private void UpdateAvailableSquares()
    {
        var squares = _squares.SelectMany(s => s);
        foreach (var square in squares)
            SetAvailableSquares(square);
    }

    private void SetAvailableSquares(Square square)
    {
        var columnSquares = _squares.SelectMany(s => s)
                                    .Where(s => s.Position.X == square.Position.X &&
                                            !(s.Height - square.Height < -1) &&
                                            Math.Abs(s.Position.Y - square.Position.Y) == 1);

        var rowSquares = _squares.SelectMany(s => s)
                                    .Where(s => s.Position.Y == square.Position.Y &&
                                            !(s.Height - square.Height < -1) &&
                                            Math.Abs(s.Position.X - square.Position.X) == 1);

        var availableSquares = columnSquares.Concat(rowSquares);
        square.SetAvailableSquares(availableSquares);
    }
}