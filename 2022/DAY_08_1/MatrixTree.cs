namespace DAY_08_1
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
        public bool Visible { get; private set; }

        public void UpdateVisibility(MatrixTree[][] matrix)
        {
            var row = matrix[Row];
            bool visibleInRow = GetRowVisibility(row);

            Visible = visibleInRow;

            if (Visible)
                return;

            var column = matrix.SelectMany(t => t).Where(t => t.Column == Column).OrderBy(t => t.Row).ToArray();
            bool visibleInColumn = GetColumnVisibility(column);

            Visible = visibleInColumn;
        }

        private bool GetColumnVisibility(MatrixTree[] column)
        {
            var top = column.Take(new Range(0, Row));
            var bottom = column.Take(new Range(Row + 1, column.Length));

            var heighestTop = top.Max(l => l.Height);
            var heighestBottom = bottom.Max(r => r.Height);

            bool visibleInColumn = Height > heighestTop || Height > heighestBottom;

            return visibleInColumn;
        }

        private bool GetRowVisibility(MatrixTree[] row)
        {
            var left = row.Take(new Range(0, Column));
            var right = row.Take(new Range(Column + 1, row.Length));

            var heighestLeft = left.Max(l => l.Height);
            var heighestRight = right.Max(r => r.Height);

            bool visibleInRow = Height > heighestLeft || Height > heighestRight;

            return visibleInRow;
        }

    }
}