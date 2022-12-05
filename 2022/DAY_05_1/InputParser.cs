using System.Text.RegularExpressions;

namespace DAY_05_1
{
    public class InputParser
    {

        public StacksContainer StacksContainer { get; private set; }
        public Queue<CrateMove> CrateMoves { get; private set; }

        private const string NewLine = "\r\n";

        private InputParser(StacksContainer stacksContainer, Queue<CrateMove> crateMoves)
        {
            StacksContainer = stacksContainer;
            CrateMoves = crateMoves;
        }

        public static InputParser Parse(string input)
        {
            string[] splitted = input.Split($"{NewLine}{NewLine}");
            string[] inputStacks = splitted[0].Split(NewLine);
            string[] inputMoves = splitted[1].Split(NewLine);

            var stacksContainer = ParseStacksContainer(inputStacks);
            var crateMoves = ParseCrateMoves(inputMoves);
            var inputParser = new InputParser(stacksContainer, crateMoves);

            return inputParser;
        }

        private static StacksContainer ParseStacksContainer(string[] inputStacks)
        {
            var stacksCount = Regex.Split(inputStacks[inputStacks.Length - 1].Trim(), @"\s{1,}").Length;
            var container = new StacksContainer();
            foreach (int i in Enumerable.Range(0, stacksCount))
            {
                var crateStack = ParseStack(i, inputStacks);
                container.AddStack(crateStack);
            }

            return container;
        }

        private static CrateStack ParseStack(int index, string[] inputStacks)
        {
            int length = 3;
            int startIndex = index == 0 ? 0 : index + (index * length);

            int stackNo = index + 1;
            var crateStack = new CrateStack(stackNo);

            for (int i = inputStacks.Length - 2; i >= 0; i--)
            {
                string crateString = inputStacks[i].Substring(startIndex, length);
                string crateLabel = Regex.Matches(crateString, @"\[(\w)\]").Cast<Match>().Select(m => m.Groups[1].Value).FirstOrDefault() ?? "";

                if (string.IsNullOrWhiteSpace(crateLabel))
                    continue;

                var crate = new Crate(crateLabel);
                crateStack.PutCrate(crate);
            }

            return crateStack;
        }

        private static Queue<CrateMove> ParseCrateMoves(string[] inputMoves)
        {
            Queue<CrateMove> queue = new Queue<CrateMove>();

            for (int i = 0; i < inputMoves.Length; i++)
            {
                int[] numbers = Regex.Matches(inputMoves[i], @"\d+").Select(m => int.Parse(m.Value)).ToArray();
                int quantity = numbers[0],
                    sourceStackNo = numbers[1],
                    destinationStackNo = numbers[2];

                var move = new CrateMove(quantity, sourceStackNo, destinationStackNo);
                queue.Enqueue(move);
            }

            return queue;
        }
    }
}