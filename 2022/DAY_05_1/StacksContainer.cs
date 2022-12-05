namespace DAY_05_1
{
    public class StacksContainer
    {
        IList<CrateStack> _stacks = new List<CrateStack>();

        public StacksContainer()
        {
        }

        public void AddStack(CrateStack stack)
            => _stacks.Add(stack);

        public void CreateStack(int stackNo)
            => _stacks.Add(new CrateStack(stackNo));

        public void PutCrateToStack(int stackNo, Crate crate)
        {
            var stack = _stacks.FirstOrDefault(s => s.No == stackNo);
            if (stack is null)
                return;

            stack.PutCrate(crate);
        }

        public Crate? TakeCrateFromStack(int stackNo)
            => _stacks.FirstOrDefault(s => s.No == stackNo)?.TakeCrate();

        public void MakeMove(CrateMove move)
        {
            var sourceStack = _stacks.FirstOrDefault(s => s.No == move.SourceStackNo);
            var destinationStack = _stacks.FirstOrDefault(s => s.No == move.DestinationStackNo);

            if (sourceStack is null || destinationStack is null)
                return;

            for(int i = 0; i < move.Quantity; i++)
            {
                var crate = sourceStack.TakeCrate();
                destinationStack.PutCrate(crate);
            }
        }

        public void MakeMoves(Queue<CrateMove> moves)
        {
            while(moves.Count > 0)
            {
                var move = moves.Dequeue();
                MakeMove(move);
            }
        }

        public string GetTopCratesLabels()
            => string.Join(string.Empty, _stacks.OrderBy(s => s.No).Select(s => s.Stack.Peek().Label));

        public override string ToString()
            => $"{string.Join(Environment.NewLine, _stacks.Select(s => s))}";
    }
}