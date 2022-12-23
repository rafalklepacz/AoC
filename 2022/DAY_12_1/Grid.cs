namespace DAY_12_1;

public record Grid
{
    public Grid(Square[][] squares)
    {
        Squares = squares;
        RowsCount = Squares.FirstOrDefault()?.Length ?? 0;
        ColumnsCount = Squares.Length;
        StartSquare = Squares.SelectMany(s => s).FirstOrDefault(s => s.Letter == 'S');
        EndSquare = Squares.SelectMany(s => s).FirstOrDefault(s => s.Letter == 'E');

        UpdateAvailableSquares();
        SearchPath();
    }

    public Square[][] Squares { get; init; }
    public int ColumnsCount { get; init; }
    public int RowsCount { get; init; }
    public Square StartSquare { get; init; }
    public Square EndSquare { get; init; }

    private void SearchPath()
    {
        var visited = new HashSet<Square>();

        var queue = new Queue<Square>();
        queue.Enqueue(StartSquare);

        while (queue.Count > 0)
        {
            var square = queue.Dequeue();

            if (visited.Contains(square))
                continue;

            visited.Add(square);

            foreach (var neighbor in square.AvailableSquares)
                if (!visited.Contains(neighbor))
                    queue.Enqueue(neighbor);
        }

        // var squares = Squares.SelectMany(s => s).SelectMany(q => q.AvailableSquares);
        // var orderedSquares = squares.OrderByDescending(s => s.Height).ToList();
        // Square previous = null, current = null, next = null;

        // List<Square> list = new();
        // List<Square> excluded = new();

        // for(int i = 0; i < orderedSquares.Count; i++)
        // {
        //     current = orderedSquares[i];
        //     if (excluded.Contains(current))
        //         continue;

        //     if (i < orderedSquares.Count - 1)
        //         next = orderedSquares[(i + 1)];

        //     if (excluded.Contains(next))
        //         continue;

        //     if (next is not null)
        //     {
        //         if (!next.CheckSquareIsAvailable(current))
        //         {
        //             excluded.Add(next);
        //             i--;
        //             continue;
        //         }

        //         list.Add(current);
        //     }
        // }
    }

    private void UpdateAvailableSquares()
    {
        var squares = Squares.SelectMany(s => s);
        foreach (var square in squares)
            SetAvailableSquares(square);
    }

    private void SetAvailableSquares(Square square)
    {
        var columnSquares = Squares.SelectMany(s => s).Where(s => s.Position.X == square.Position.X &&
                                                                 (s.Position.Y == square.Position.Y + 1 || s.Position.Y == square.Position.Y - 1) &&
                                                                 (s.Height == square.Height + 1 || s.Height == square.Height));

        var rowSquares = Squares.SelectMany(s => s).Where(s => s.Position.Y == square.Position.Y &&
                                                              (s.Position.X == square.Position.X + 1 || s.Position.X == square.Position.X - 1) &&
                                                              (s.Height == square.Height + 1 || s.Height == square.Height));

        var availableSquares = columnSquares.Concat(rowSquares);
        square.SetAvailableSquares(availableSquares);
    }

    // public Func<T, IEnumerable<T>> ShortestPathFunction<T>(Graph<T> graph, T start) {
    //     var previous = new Dictionary<T, T>();

    //     var queue = new Queue<T>();
    //     queue.Enqueue(start);

    //     while (queue.Count > 0) {
    //         var vertex = queue.Dequeue();
    //         foreach(var neighbor in graph.AdjacencyList[vertex]) {
    //             if (previous.ContainsKey(neighbor))
    //                 continue;

    //             previous[neighbor] = vertex;
    //             queue.Enqueue(neighbor);
    //         }
    //     }

    //     Func<T, IEnumerable<T>> shortestPath = v => {
    //         var path = new List<T>{};

    //         var current = v;
    //         while (!current.Equals(start)) {
    //             path.Add(current);
    //             current = previous[current];
    //         };

    //         path.Add(start);
    //         path.Reverse();

    //         return path;
    //     };

    //     return shortestPath;
    // }
}