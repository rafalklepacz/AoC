namespace DAY_08_2
{
    public class MatrixTree
    {
        public MatrixTree(int height, int row, int column)
        {
            Height = height;
            Row = row;
            Column = column;
        }

        public int Height { get; init; }
        public int Row { get; init; }
        public int Column { get; init; }
        public int ScenicScore { get; private set; }

        public void UpdateScenicScore(MatrixTree[][] matrix)
        {
            var row = matrix[Row];
            var column = matrix.SelectMany(t => t)
                               .Where(t => t.Column == Column)
                               .OrderBy(t => t.Row)
                               .ToArray();

            var top = column.Take(new Range(0, Row)).ToArray();
            var bottom = column.Take(new Range(Row + 1, column.Length)).ToArray();
            var left = row.Take(new Range(0, Column)).ToArray();
            var right = row.Take(new Range(Column + 1, row.Length)).ToArray();

            int topScore = 0,
                bottomScore = 0,
                leftScore = 0,
                rightScore = 0;

            for (int i = top.Length - 1; i >= 0; i--)
            {
                topScore++;
                var tree = top[i];
                if (tree.Height >= Height)
                    break;
            }

            for (int i = 0; i < bottom.Length; i++)
            {
                bottomScore++;
                var tree = bottom[i];
                if (tree.Height >= Height)
                    break;
            }

            for (int i = left.Length - 1; i >= 0; i--)
            {
                leftScore++;
                var tree = left[i];
                if (tree.Height >= Height)
                    break;
            }

            for (int i = 0; i < right.Length; i++)
            {
                rightScore++;
                var tree = right[i];
                if (tree.Height >= Height)
                    break;
            }

            ScenicScore = topScore * bottomScore * leftScore * rightScore;
        }
    }
}