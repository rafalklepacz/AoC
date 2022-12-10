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

            var treesAbove = column.Take(new Range(0, Row)).ToArray();
            var treesBelow = column.Take(new Range(Row + 1, column.Length)).ToArray();
            var treesOnLeft = row.Take(new Range(0, Column)).ToArray();
            var treesOnRight = row.Take(new Range(Column + 1, row.Length)).ToArray();

            int scoreAbove = CalculateScenicScoreDesc(treesAbove);
            int scoreBelow = CalculateScenicScoreAsc(treesBelow);
            int scoreOnLeft = CalculateScenicScoreDesc(treesOnLeft);
            int scoreOnRight = CalculateScenicScoreAsc(treesOnRight);

            ScenicScore = scoreAbove * scoreBelow * scoreOnLeft * scoreOnRight;
        }

        private int CalculateScenicScoreDesc(MatrixTree[] array)
        {
            int result = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                result++;
                var tree = array[i];
                if (tree.Height >= Height)
                    break;
            }

            return result;
        }

        private int CalculateScenicScoreAsc(MatrixTree[] array)
        {
            int result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                result++;
                var tree = array[i];
                if (tree.Height >= Height)
                    break;
            }

            return result;
        }
    }
}