using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class LeetCodeTasks
    {
        public long CountOfSubstrings(string word, int k)
        {
            return atLeastResult(word, k) - atLeastResult(word, k + 1);
        }

        private long atLeastResult(string word, int k)
        {
            long result = 0;

            Dictionary<char, int> vowelsDict = new Dictionary<char, int>();
            int consonantsCount = 0;
            int leftIndex = 0;

            for (int i = 0; i < word.Length; i++)
            {
                char wordChar = word[i];
                if ("aeiou".Contains(wordChar))
                {
                    if (!vowelsDict.ContainsKey(wordChar)) vowelsDict.Add(wordChar, 1);
                    else vowelsDict[wordChar] += 1;
                }
                else consonantsCount += 1;

                while (consonantsCount >= k && vowelsDict.Count == 5)
                {
                    result += word.Length - i;
                    if ("aeiou".Contains(word[leftIndex]))
                    {
                        vowelsDict[word[leftIndex]] -= 1;

                        if (vowelsDict[word[leftIndex]] == 0) vowelsDict.Remove(word[leftIndex]);
                    }
                    else consonantsCount -= 1;

                    leftIndex++;
                }
            }

            return result;
        }

        public long CountOfSubstringsOther(string word, int k)
        {
            var n = word.Length;
            int lastA = -1, lastE = -1, lastI = -1, lastO = -1, lastU = -1;
            var consonantCount = 0;
            int left1 = 0, left2 = 0, prevConsonant1 = 0, prevConsonant2 = 0;
            var result = 0L;

            for (var r = 0; r < n; r++)
            {
                var ch = word[r];
                if (ch != 'a' && ch != 'e' && ch != 'i' && ch != 'o' && ch != 'u')
                {
                    consonantCount++;
                }
                else
                {
                    switch (ch)
                    {
                        case 'a': lastA = r; break;
                        case 'e': lastE = r; break;
                        case 'i': lastI = r; break;
                        case 'o': lastO = r; break;
                        case 'u': lastU = r; break;
                    }
                }

                var extraConsonants = consonantCount - k;
                while (left1 <= r && prevConsonant1 < extraConsonants)
                {
                    var c = word[left1];
                    if (c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u')
                        prevConsonant1++;
                    left1++;
                }

                while (left2 <= r && prevConsonant2 <= extraConsonants)
                {
                    var c = word[left2];
                    if (c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u')
                        prevConsonant2++;
                    left2++;
                }

                if (lastA == -1 || lastE == -1 || lastI == -1 || lastO == -1 || lastU == -1) continue;
                var vowelThreshold = Math.Min(lastA, Math.Min(lastE, Math.Min(lastI, Math.Min(lastO, lastU)))) + 1;
                var validLeft = Math.Min(left2, vowelThreshold);
                if (validLeft > left1)
                    result += validLeft - left1;
            }

            return result;
        }
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> canditateList = candidates.ToList();

            foreach (int candidate in candidates)
            {
                if (candidate == target)
                {
                    result.Add(new List<int>() { candidate });
                }
                else if (candidate < target)
                {
                    IList<IList<int>> candidateCombinationSum = CombinationSum(canditateList.ToArray(), target - candidate);
                    for (int i = 0; i < candidateCombinationSum.Count; i++)
                    {
                        candidateCombinationSum[i].Insert(0, candidate);
                        result.Add(candidateCombinationSum[i]);
                    }
                }

                canditateList.RemoveAt(0);
            }

            return result;
        }
        public int NumberOfSubstrings(string s)
        {
            int result = 0;

            int leftIndex = 0;
            Dictionary<char, int> lettersCountDict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                char letter = s[i];

                if (!lettersCountDict.ContainsKey(letter)) lettersCountDict.Add(letter, 1);
                else lettersCountDict[letter] += 1;

                while (lettersCountDict.Count == 3)
                {
                    result += s.Length - i;

                    lettersCountDict[s[leftIndex]] -= 1;

                    if (lettersCountDict[s[leftIndex]] <= 0) lettersCountDict.Remove(s[leftIndex]);

                    leftIndex++;
                }
            }

            return result;
        }

        public int MinOperations(int[] nums)
        {
            if (nums.Length < 3) return -1;

            int result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == nums.Length - 3)
                {
                    if (nums[i + 1] == nums[i] && nums[i + 2] == nums[i])
                    {
                        if (nums[i] == 0) result++;
                    }
                    else result = -1;
                    break;
                }

                if (nums[i] == 0)
                {
                    nums[i] = 1;
                    nums[i + 1] = nums[i + 1] == 0 ? 1 : 0;
                    nums[i + 2] = nums[i + 2] == 0 ? 1 : 0;
                    result++;
                }
            }


            return result;
        }

        public int TotalNQueens(int n)
        {
            int result = 0;

            int[] queensArr = new int[n];

            int row = 1;
            int queenArrIndex = 0;
            bool returnToPrev, acceptablePos;

            while (true)
            {
                queenArrIndex = row - 1;
                if (row != 1)
                {
                    returnToPrev = true;
                    for (int i = queensArr[queenArrIndex] + 1; i <= n; i++)
                    {
                        acceptablePos = true;
                        for (int k = 1; k < row; k++)
                        {
                            if (i == queensArr[queenArrIndex - k] ||
                                (i == queensArr[queenArrIndex - k] - k || i == queensArr[queenArrIndex - k] + k))
                            {
                                acceptablePos = false;
                                break;
                            }
                        }

                        if (!acceptablePos) continue;

                        queensArr[queenArrIndex] = i;
                        returnToPrev = false;
                        break;
                    }

                    if (returnToPrev)
                    {
                        queensArr[queenArrIndex] = 0;
                        row--;
                        continue;
                    }
                }
                else
                {
                    queensArr[queenArrIndex]++;

                    if (queensArr[queenArrIndex] > n) break;
                }

                if (row == n) result++;
                else
                    row++;
            }

            return result;
        }

        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> result = new List<IList<string>>();

            int[] queensArr = new int[n];

            int row = 1;
            int queenArrIndex = 0;

            while (true)
            {
                queenArrIndex = row - 1;
                if (row != 1)
                {
                    bool returnToPrev = true;
                    for (int i = queensArr[queenArrIndex] + 1; i <= n; i++)
                    {
                        bool acceptablePos = true;
                        for (int k = 1; k < row; k++)
                        {
                            if (i == queensArr[queenArrIndex - k] ||
                                (i == queensArr[queenArrIndex - k] - k || i == queensArr[queenArrIndex - k] + k))
                            {
                                acceptablePos = false;
                                break;
                            }
                        }

                        if (!acceptablePos) continue;

                        queensArr[queenArrIndex] = i;
                        returnToPrev = false;
                        break;
                    }

                    if (returnToPrev)
                    {
                        queensArr[queenArrIndex] = 0;
                        row--;
                        continue;
                    }
                }
                else
                {
                    queensArr[queenArrIndex]++;

                    if (queensArr[queenArrIndex] > n) break;
                }

                if (row == n)
                {
                    List<string> queensSet = new List<string>();

                    for (int i = 0; i < n; i++)
                    {
                        string rowStr = "";

                        for (int k = 1; k <= n; k++)
                        {
                            if (queensArr[i] == k) rowStr += "Q";
                            else rowStr += ".";

                        }
                        queensSet.Add(rowStr);
                    }

                    result.Add(queensSet);
                }
                else
                    row++;
            }

            return result;
        }

        public string ReverseWords(string s)
        {
            string[] wordsArr = s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (wordsArr.Length == 0) return "";

            var reversedArr = wordsArr.Reverse();

            return String.Join(" ", reversedArr);
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            var resultList = new List<IList<int>>();

            if (nums.Length == 1) resultList.Add(nums.ToList());
            if (nums.Length <= 1) return resultList;

            for (int i = 0; i < nums.Length; i++)
            {
                int[] newArray = new int[nums.Length - 1];

                int newArrayIndex = 0;
                for (int k = 0; k < nums.Length; k++)
                {
                    if (k == i) continue;

                    newArray[newArrayIndex] = nums[k];
                    newArrayIndex++;
                }

                foreach (List<int> list in Permute(newArray))
                {
                    list.Insert(0, nums[i]);
                    resultList.Add(list);
                }
            }

            return resultList;
        }

        public int RemoveDuplicates(int[] nums)
        {
            int currentIndex = 0;
            int currentValue = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > currentValue)
                {
                    nums[++currentIndex] = nums[i];
                    currentValue = nums[i];
                }
            }

            return currentIndex + 1;
        }

        public double MyPow(double x, int n)
        {
            if (x == 1) return 1;

            double result = 1;

            if (n >= 0)
            {
                for (int i = 0; i < n; i++) { result *= x; }
            }
            else
            {
                for (int i = 0; i > n; i--) { result /= x; }
            }

            return result;
        }

        public IList<string> FindAllRecipes(string[] recipes,
           IList<IList<string>> ingredients, string[] supplies)
        {
            List<string> suppliesList = supplies.ToList();
            List<string> invalidRecipes = new List<string>();

            Action<string, IList<string>, IList<string>> createRecipe = null;
            createRecipe = (recipe, recipeIngredients, executionStack) =>
            {
                bool recipeValid = true;
                foreach (var recipeIngredient in recipeIngredients)
                {
                    if (suppliesList.Contains(recipeIngredient)) continue;

                    if (invalidRecipes.Contains(recipeIngredient) || executionStack.Contains(recipeIngredient))
                    {
                        recipeValid = false;
                        break;
                    }

                    int indexOfRecipe = Array.IndexOf(recipes, recipeIngredient);
                    if (indexOfRecipe > -1)
                    {
                        executionStack.Add(recipeIngredient);
                        createRecipe(
                            recipeIngredient,
                            ingredients[indexOfRecipe],
                            executionStack
                        );
                        executionStack.RemoveAt(executionStack.Count - 1);

                        if (suppliesList.Contains(recipeIngredient)) continue;

                        recipeValid = false;
                        break;
                    }

                    recipeValid = false;
                    break;
                }

                if (recipeValid) suppliesList.Add(recipe);
                else invalidRecipes.Add(recipe);
            };

            for (int i = 0; i < recipes.Length; i++)
            {
                if (suppliesList.Contains(recipes[i])) continue;

                createRecipe(recipes[i], ingredients[i], new List<string>() { recipes[i] });
            }

            suppliesList.RemoveRange(0, supplies.Length);

            return suppliesList;
        }

        public int CountCompleteComponents(int n, int[][] edges)
        {
            int count = 0;
            var visitedList = new List<int>();

            Action<int, List<int>> getBindingVertice = null;
            getBindingVertice = (vertice, componentList) =>
            {
                if (visitedList.Contains(vertice)) return;

                visitedList.Add(vertice);
                componentList.Add(vertice);

                foreach (var edge in edges.Where(e => e.Contains(vertice)))
                {
                    int neigVert = edge.First(v => v != vertice);
                    getBindingVertice(neigVert, componentList);
                }
            };

            for (int v = 0; v < n; v++)
            {
                if (visitedList.Contains(v)) continue;

                var componentList = new List<int>();
                getBindingVertice(v, componentList);

                bool completeComp = true;
                foreach (var componentVertice in componentList)
                {
                    int verticeEdges = edges.Count(e => e.Contains(componentVertice));

                    if (componentList.Count() != verticeEdges + 1)
                    {
                        completeComp = false;
                        break;
                    }
                }

                if (completeComp) count++;
            }

            return count;
        }

        public int CountDays(int days, int[][] meetings)
        {
            int resultDays = days;
            List<List<int>> usedPeriods = new List<List<int>>();
            List<int> periodsToRemove = new List<int>();

            foreach (var meeting in meetings)
            {
                int meetingDays = meeting[1] - meeting[0] + 1;

                int left = meeting[0];
                int right = meeting[1];

                for (int i = 0; i < usedPeriods.Count; i++)
                {
                    if ((meeting[0] < usedPeriods[i][0] && meeting[1] < usedPeriods[i][0]) ||
                       (meeting[0] > usedPeriods[i][1] && meeting[1] > usedPeriods[i][1])) continue;
                    else if (meeting[0] >= usedPeriods[i][0] &&
                        meeting[1] <= usedPeriods[i][1])
                    {
                        meetingDays = 0;
                        break;
                    }
                    else if (meeting[0] < usedPeriods[i][0] &&
                        meeting[1] > usedPeriods[i][1])
                    {
                        meetingDays -= usedPeriods[i][1] - usedPeriods[i][0] + 1;
                        periodsToRemove.Insert(0, i);
                    }
                    else if (meeting[0] >= usedPeriods[i][0] &&
                        meeting[0] <= usedPeriods[i][1] &&
                        meeting[1] > usedPeriods[i][1])
                    {
                        left = usedPeriods[i][0];
                        periodsToRemove.Insert(0, i);
                        meetingDays -= usedPeriods[i][1] - meeting[0] + 1;
                    }
                    else if (meeting[1] <= usedPeriods[i][1] &&
                      meeting[1] >= usedPeriods[i][0] &&
                      meeting[0] < usedPeriods[i][0])
                    {
                        right = usedPeriods[i][1];
                        periodsToRemove.Insert(0, i);
                        meetingDays -= meeting[1] - usedPeriods[i][0] + 1;
                    }
                }

                if (meetingDays > 0)
                {
                    foreach (var removeIndex in periodsToRemove)
                    {
                        usedPeriods.RemoveAt(removeIndex);
                    }
                    usedPeriods.Add(new List<int> { left, right });
                }

                periodsToRemove.Clear();

                resultDays -= meetingDays;
            }

            return resultDays;
        }

        public bool CheckValidCuts(int n, int[][] rectangles)
        {
            int[][] sortedByX = rectangles.OrderBy(r => r[0]).ToArray();
            int[][] sortedByY = rectangles.OrderBy(r => r[1]).ToArray();

            var sectionsByX = new List<int[]>() { new int[] { sortedByX[0][0], sortedByX[0][2] } };
            var sectionsByY = new List<int[]>() { new int[] { sortedByY[0][1], sortedByY[0][3] } };


            for (int i = 1; i < sortedByX.Length; i++)
            {
                if (sortedByX[i][0] < sectionsByX[sectionsByX.Count - 1][1])
                    sectionsByX[sectionsByX.Count - 1][1] = sortedByX[i][2] > sectionsByX[sectionsByX.Count - 1][1] ?
                                                                sortedByX[i][2] :
                                                                sectionsByX[sectionsByX.Count - 1][1];
                else sectionsByX.Add(new int[] { sortedByX[i][0], sortedByX[i][2] });
            }

            for (int i = 1; i < sortedByY.Length; i++)
            {
                if (sortedByY[i][1] < sectionsByY[sectionsByY.Count - 1][1])
                    sectionsByY[sectionsByY.Count - 1][1] = sortedByY[i][3] > sectionsByY[sectionsByY.Count - 1][1] ?
                                                                sortedByY[i][3] :
                                                                sectionsByY[sectionsByY.Count - 1][1];
                else sectionsByY.Add(new int[] { sortedByY[i][1], sortedByY[i][3] });
            }

            return sectionsByX.Count > 2 || sectionsByY.Count > 2;
        }

        public int MinOperations(int[][] grid, int x)
        {
            int result = 0;
            int[] allValues = new int[grid.Length * grid[0].Length];

            int i = 0;
            foreach (var row in grid)
            {
                foreach (var cell in row)
                {
                    allValues[i] = cell;
                    i++;
                }
            }

            Array.Sort(allValues);

            int middleValue = allValues[allValues.Length / 2];

            foreach (var value in allValues)
            {
                int difference = Math.Abs(middleValue - value);

                if (difference == 0) continue;

                if (difference % x != 0) return -1;

                result += difference / x;
            }

            return result;
        }

        public void Rotate(int[][] matrix)
        {
            int matrixLength = matrix.Length;
            int lastIndex = matrixLength - 1;

            int[][] reverseColumnsMatrix = new int[matrixLength][];

            for (int i = 0; i < matrixLength; i++)
            {
                reverseColumnsMatrix[i] = new int[matrixLength];
                for (int k = lastIndex; k >= 0; k--)
                {
                    reverseColumnsMatrix[i][k] = matrix[k][lastIndex - i];
                    matrix[k][lastIndex - i] = (i > lastIndex - k || (lastIndex - k == i && lastIndex - i < i))
                        ? reverseColumnsMatrix[lastIndex - k][i] : matrix[i][k];
                }
            }
        }

        public int[] MaxPoints(int[][] grid, int[] queries)
        {
            if (grid.Length <= 0 || grid[0].Length <= 0
                || queries.Length <= 0) return new int[0];

            int[] result = new int[queries.Length];
            int[] sortedQueries = new int[queries.Length];

            int rowNum = grid.Length;
            int columnNum = grid[0].Length;

            List<List<int>> visitedCells = new List<List<int>>(rowNum);
            List<int[]> cellsToCheck = new List<int[]>(rowNum);

            for (int i = 0; i < rowNum; i++) visitedCells.Add(new List<int>(columnNum));
            visitedCells[0].Add(0);

            Dictionary<int, int> queriesResults = new Dictionary<int, int>();

            Array.Copy(queries, sortedQueries, queries.Length);
            Array.Sort(sortedQueries);

            int maxQuery = sortedQueries[sortedQueries.Length - 1];

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue([0, 0]);

            var checkIsCellVisited = (int[] cell) =>
                visitedCells[cell[0]].Count != 0 &&
                visitedCells[cell[0]].Contains(cell[1]);

            var addCellToQueue = (bool coondition, int[] cell) =>
            {
                if (!coondition || checkIsCellVisited(cell)) return;

                visitedCells[cell[0]].Add(cell[1]);
                queue.Enqueue(cell);

            };

            var addNextCells = (int[] cell) =>
            {
                addCellToQueue(cell[0] + 1 < rowNum, [cell[0] + 1, cell[1]]);
                addCellToQueue(cell[1] + 1 < columnNum, [cell[0], cell[1] + 1]);
                addCellToQueue(cell[0] - 1 >= 0, [cell[0] - 1, cell[1]]);
                addCellToQueue(cell[1] - 1 >= 0, [cell[0], cell[1] - 1]);
            };

            for (int i = 0; i < sortedQueries.Length; i++)
            {
                int queryValue = sortedQueries[i];

                if (i - 1 >= 0)
                {
                    result[i] = result[i - 1];

                    if (queryValue == sortedQueries[i - 1]) continue;
                }

                if (cellsToCheck.Count > 0)
                {
                    for (int k = cellsToCheck.Count - 1; k >= 0; k--)
                    {
                        int[] cell = cellsToCheck[k];

                        if (cell[2] >= queryValue) continue;

                        result[i]++;

                        cellsToCheck.RemoveAt(k);

                        addNextCells(cell);
                    }
                }

                while (queue.TryDequeue(out int[] currentCell))
                {
                    int cellValue = grid[currentCell[0]][currentCell[1]];
                    if (cellValue >= queryValue)
                    {
                        if (cellValue < maxQuery)
                        {
                            cellsToCheck.Add(new int[] { currentCell[0], currentCell[1], cellValue });
                        }
                        continue;
                    }

                    result[i]++;

                    addNextCells(currentCell);
                }

                queriesResults.Add(queryValue, result[i]);
            }

            for (int i = 0; i < queries.Length; i++)
            {
                result[i] = queriesResults[queries[i]];
            }

            return result;
        }

        public IList<int> PartitionLabels(string s)
        {
            Dictionary<char, int[]> charsDict = new Dictionary<char, int[]>();

            for (int i = 0; i < s.Length; i++)
            {
                if (charsDict.ContainsKey(s[i])) charsDict[s[i]][1] = i;
                else charsDict.Add(s[i], new int[] { i, i });
            }

            int[][] charIntervalList = charsDict.Values.ToArray();
            charIntervalList.OrderBy(s => s[0]);

            List<int[]> sectionsList = new List<int[]>(charIntervalList.Length);
            sectionsList.Add(new int[] { charIntervalList[0][0], charIntervalList[0][1] });

            for (int i = 1; i < charIntervalList.Length; i++)
            {
                var lastSection = sectionsList.Last();
                if (charIntervalList[i][0] < lastSection[1])
                    lastSection[1] = charIntervalList[i][1] > lastSection[1] ? charIntervalList[i][1] : lastSection[1];
                else
                    sectionsList.Add(new int[] { charIntervalList[i][0], charIntervalList[i][1] });
            }

            return sectionsList.Select(s => s[1] - s[0]).ToList();
        }

        public long MostPoints(int[][] questions)
        {
            long maxValue = 0;
            long maxPrevValue = 0;

            var indexMaxValue = new long[questions.Length];

            for (int i = 0; i < questions.Length; i++)
            {
                long value = questions[i][0];
                int elToSkip = questions[i][1];

                if (indexMaxValue[i] > maxPrevValue) maxPrevValue = indexMaxValue[i];

                value += maxPrevValue;

                int nextElIndex = i + elToSkip + 1;

                if (nextElIndex > questions.Length - 1)
                {
                    maxValue = Math.Max(maxValue, value);
                    continue;
                }

                indexMaxValue[nextElIndex] = Math.Max(indexMaxValue[nextElIndex], value);
            }

            return maxValue;
        }

        public long MaximumTripletValue(int[] nums)
        {
            if (nums.Length < 3) return 0;
            long result = 0;

            int num1 = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] >= num1) num1 = nums[i];
                else
                {
                    for (int k = i + 1; k < nums.Length; k++)
                    {
                        result = Math.Max(result, (long)(num1 - nums[i]) * nums[k]);
                    }
                }
            }

            return result;
        }

        public string Convert(string s, int numRows)
        {
            if (numRows <= 1 || s.Length == 0) return s;

            string[] zigzagArr = new string[numRows];

            int i = 0;
            bool zigzagColumn = false;
            bool breakLoop = false;

            while (!breakLoop)
            {
                int k = zigzagColumn ? numRows - 2 : 0;

                while (true)
                {
                    if (zigzagColumn ? k <= 0 : k >= numRows) break;

                    zigzagArr[k] += s[i];
                    i++;

                    if (i >= s.Length)
                    {
                        breakLoop = true;
                        break;
                    }

                    k = zigzagColumn ? k - 1 : k + 1;
                }

                zigzagColumn = !zigzagColumn;
            }

            return String.Join("", zigzagArr);
        }

        public TreeNode LcaDeepestLeaves(TreeNode root)
        {
            if (root == null) return root;

            return GetCommonAncestor(0, root).Item2;
        }

        private static (int, TreeNode) GetCommonAncestor(int layout, TreeNode node)
        {
            if (node.left == null && node.right == null) return (layout, node);

            if (node.right == null) return GetCommonAncestor(layout + 1, node.left);
            if (node.left == null) return GetCommonAncestor(layout + 1, node.right);

            var leftItem = GetCommonAncestor(layout + 1, node.left);
            var rightItem = GetCommonAncestor(layout + 1, node.right);

            if (leftItem.Item1 == rightItem.Item1) return (leftItem.Item1, node);
            if (leftItem.Item1 > rightItem.Item1) return leftItem;

            return rightItem;
        }

        public int SubsetXORSum(int[] nums)
        {
            if (nums.Length == 0) return 0;

            return getXORSets(nums, 0).Sum();
        }

        private List<int> getXORSets(int[] nums, int index)
        {
            if (nums.Length - index == 1) return new List<int> { nums[index] };

            var result = getXORSets(nums, index + 1);
            var resultLength = result.Count;
            for (int i = 0; i < resultLength; i++)
            {
                result.Add(nums[index] ^ result[i]);
            }

            result.Add(nums[index]);

            return result;
        }

        public bool CanPartition(int[] nums)
        {
            if (nums.Length < 2) return false;

            int sum = nums.Sum();

            if (sum % 2 != 0) return false;

            int halfSum = sum / 2;

            HashSet<int> allSets = new HashSet<int>();
            HashSet<int> numSet = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > halfSum) return false;
                if (nums[i] == halfSum) return true;

                numSet.Clear();
                numSet.Add(nums[i]);

                foreach (var set in allSets)
                {
                    int newSet = set + nums[i];

                    if (newSet > halfSum) continue;
                    if (newSet == halfSum) return true;

                    numSet.Add(newSet);
                }

                foreach (var set in numSet) allSets.Add(set);
            }

            return false;
        }

        public int MinimumOperations(int[] nums)
        {
            int result = (int)Math.Ceiling((double)nums.Length / 3);
            int uniqueGroup = 3 - (nums.Length % 3);

            if (uniqueGroup == 3) uniqueGroup = 0;

            List<int> uniqueValues = new List<int>(nums.Length);

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (uniqueValues.Contains(nums[i])) break;

                uniqueValues.Add(nums[i]);
                uniqueGroup++;

                if (uniqueGroup == 3)
                {
                    result--;
                    uniqueGroup = 0;
                }
            }

            return result;
        }

        public int CountSymmetricIntegers(int low, int high)
        {
            int result = 0;

            for (int num = low; num <= high; num++)
            {
                var numStr = num.ToString();

                if (numStr.Length % 2 != 0) continue;

                int firstHalfSum = 0;
                int secondHalfSum = 0;

                int middleIndex = numStr.Length / 2;

                for (int i = 0; i < middleIndex; i++)
                {
                    firstHalfSum += numStr[i] - '0';
                    secondHalfSum += numStr[middleIndex + i] - '0';
                }

                if (firstHalfSum == secondHalfSum) result++;
            }

            return result;
        }

        public int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            int result = 0;

            var listIJ = new List<(int, int)>((int)Math.Pow(arr.Length, 2));

            for (int index = 0; index < arr.Length; index++)
            {
                foreach (var ij in listIJ)
                {
                    int numB = Math.Abs(ij.Item2 - arr[index]);
                    int numC = Math.Abs(ij.Item1 - arr[index]);

                    if (numC <= c && numB <= b)
                        result++;
                }

                for (int iIndex = 0; iIndex < index; iIndex++)
                {
                    int numA = Math.Abs(arr[iIndex] - arr[index]);

                    if (numA <= a)
                        listIJ.Add((arr[iIndex], arr[index]));
                }
            }

            return result;
        }

        public long GoodTriplets(int[] nums1, int[] nums2)
        {
            long result = 0;
            int length = nums1.Length;

            int[] indexArr = new int[length];
            int[] lessIndexes = new int[length];

            for (int i = 0; i < length; i++)
            {
                for (int k = 0; k < nums2.Length; k++)
                {
                    if (nums1[i] == nums2[k])
                    {
                        indexArr[i] = k;
                        break;
                    }
                }

                for (int j = 0; j < i; j++)
                {
                    if (indexArr[i] > indexArr[j])
                    {
                        lessIndexes[i]++;
                    }
                }

                if (i < 2) continue;

                for (int k = 1; k < i; k++)
                {
                    if (indexArr[k] > indexArr[i]) continue;

                    result += lessIndexes[k];
                }
            }

            return result;
        }

        public int NumberOfArrays(int[] differences, int lower, int upper)
        {
            int upperBorder = upper;
            int lowerBorder = lower;

            foreach (int diff in differences)
            {
                upperBorder += diff;
                lowerBorder += diff;

                if (upperBorder > upper) upperBorder = upper;
                if (lowerBorder < lower) lowerBorder = lower;

                if (upperBorder < lowerBorder) return 0;
            }

            return upperBorder - lowerBorder + 1;
        }

        public long CountSubarrays(int[] nums, int k)
        {
            long result = 0;

            int maxValue = nums.Max();

            List<int> maxIndexes = new List<int>(nums.Length);

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == maxValue) maxIndexes.Add(i);

                if (maxIndexes.Count >= k)
                    result += maxIndexes[maxIndexes.Count - k] + 1;
            }

            return result;
        }

        public int Reverse(int x)
        {
            bool isNegative = x < 0;

            string numStr = x.ToString();

            char[] reversedCharArray = new char[numStr.Length];
            int chIndex = 0;

            for (int i = numStr.Length - 1; i >= (isNegative ? 1 : 0); i--)
            {
                reversedCharArray[chIndex] = numStr[i];
                chIndex++;
            }

            string? reversedString = new string(reversedCharArray);

            if (reversedString == null) return 0;

            if (isNegative) reversedString = '-' + reversedString;

            return Int32.TryParse(reversedString, out int reversedInt) ? reversedInt : 0;
        }

        public string PushDominoes(string dominoes)
        {
            char[] dominoesArr = new char[dominoes.Length];
            char[] nextIterArr = new char[dominoes.Length];

            Queue<(int, char)> pushedDominoesQueue = new Queue<(int, char)>();
            List<(int, char)> addToQueueList = new List<(int, char)>();

            for (int i = 0; i < dominoes.Length; i++)
            {
                dominoesArr[i] = dominoes[i];
                nextIterArr[i] = dominoes[i];
                if (dominoes[i] != '.') pushedDominoesQueue.Enqueue((i, dominoes[i]));
            }

            while (true)
            {
                int nextIndex;

                while (pushedDominoesQueue.TryDequeue(out (int, char) pushedDomino))
                {
                    switch (pushedDomino.Item2)
                    {
                        case 'L':
                            if (pushedDomino.Item1 == 0) break;
                            nextIndex = pushedDomino.Item1 - 1;
                            if (nextIndex == 27)
                            {
                                int k = 0;
                            }
                            if (dominoesArr[nextIndex] == '.' &&
                                    (nextIndex == 0 || dominoesArr[nextIndex - 1] != 'R'))
                            {
                                nextIterArr[nextIndex] = 'L';
                                addToQueueList.Add((nextIndex, 'L'));
                            }
                            break;
                        case 'R':
                            if (pushedDomino.Item1 == dominoesArr.Length - 1) break;
                            nextIndex = pushedDomino.Item1 + 1;
                            if (nextIndex == 26)
                            {
                                int k = 0;
                            }
                            if (dominoesArr[nextIndex] == '.' &&
                                    (nextIndex == dominoesArr.Length - 1 || dominoesArr[nextIndex + 1] != 'L'))
                            {
                                nextIterArr[nextIndex] = 'R';
                                addToQueueList.Add((nextIndex, 'R'));
                            }
                            break;
                    }
                }

                for (int i = 0; i < nextIterArr.Length; i++)
                {
                    dominoesArr[i] = nextIterArr[i];
                }

                if (addToQueueList.Count == 0) break;

                foreach (var item in addToQueueList)
                {
                    pushedDominoesQueue.Enqueue(item);
                }

                addToQueueList.Clear();
            }

            return new string(dominoesArr);
        }

        public int NumEquivDominoPairs(int[][] dominoes)
        {
            int result = 0;
            int[] pairCounts = new int[100];

            foreach (int[] domino in dominoes)
            {
                int index = domino[0] < domino[1] ?
                        domino[0] * 10 + domino[1] :
                        domino[1] * 10 + domino[0];

                result += pairCounts[index];
                pairCounts[index]++;
            }

            return result;
        }

        public int StrStr(string haystack, string needle)
        {
            int index = -1;

            List<int> posList = new List<int>(5);
            for (int i = 0; i < haystack.Length; i++)
            {
                for (int k = posList.Count - 1; k >= 0; k--)
                {
                    int nextIndex = posList[k] + 1;
                    if (haystack[i] != needle[nextIndex])
                    {
                        posList.RemoveAt(k);
                        continue;
                    }

                    if (nextIndex >= needle.Length - 1)
                    {
                        index = i - nextIndex;
                        break;
                    }

                    posList[k]++;
                }

                if (index != -1) break;

                if (haystack[i] == needle[0])
                {
                    if (needle.Length == 1)
                    {
                        index = i;
                        break;
                    }
                    posList.Add(0);
                }
            }

            return index;
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int[] resultArray = new int[m * n];

            int iteration = 0;
            int direction = 0;

            int m1 = 0, m2 = 0;

            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = matrix[m1][m2];

                switch (direction)
                {
                    case 0:
                        if (m2 + 1 < n - iteration) m2 += 1;
                        else
                        {
                            direction = 1;
                            m1 += 1;
                        }
                        break;
                    case 1:
                        if (m1 + 1 < m - iteration) m1 += 1;
                        else
                        {
                            direction = 2;
                            m2 -= 1;
                        }
                        break;
                    case 2:
                        if (m2 - 1 >= iteration) m2 -= 1;
                        else
                        {
                            direction = 3;
                            m1 -= 1;
                        }
                        break;
                    case 3:
                        if (m1 - 1 > iteration) m1 -= 1;
                        else
                        {
                            direction = 0;
                            m2 += 1;
                            iteration += 1;
                        }
                        break;
                }
            }

            return resultArray;
        }

        public int LengthAfterTransformations(string s, int t)
        {
            int result = s.Length;
            int zIndex = 'z' - 0;
            int minTNum = 0;

            Action<int> calculateNum = null;
            calculateNum = (int num) => {
                if (num > 25)
                {
                    minTNum++;
                    calculateNum(num - 25);
                    calculateNum(num - 24);
                    return;
                }
            };


            return result;
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var anagramsDict = new Dictionary<string, IList<string>>();

            foreach (var str in strs)
            {
                char[] chArr = str.ToCharArray();
                Array.Sort(chArr);
                string key = new string(chArr);

                if (anagramsDict.ContainsKey(key)) anagramsDict[key].Add(str);
                else anagramsDict.Add(key, new List<string>() { str });
            }

            return anagramsDict.Values.ToList();
        }

        public int Candy(int[] ratings)
        {
            var candiesArr = new int[ratings.Length];

            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                    candiesArr[i] = candiesArr[i - 1] + 1;
            }

            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                    candiesArr[i] = Math.Max(candiesArr[i], candiesArr[i + 1] + 1);
            }

            int result = 0;

            foreach (var candy in candiesArr)
            {
                result += candy + 1;
            }

            return result;
        }

        #region Roman

        private Dictionary<char, int> romanValuesDict = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10},
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };
        public int RomanToInt(string s)
        {
            int result = 0;

            int i = 0;
            while (i < s.Length)
            {
                int romanValue = romanValuesDict[s[i]];
                if ("IXC".Contains(s[i]) && i != s.Length - 1)
                {
                    int nextCharValue = romanValuesDict[s[i + 1]];
                    if (nextCharValue > romanValue && nextCharValue <= romanValue * 10)
                    {
                        result += nextCharValue - romanValue;
                        i += 2;
                        continue;
                    }
                }

                result += romanValue;

                i++;
            }

            return result;
        }

        public string IntToRoman(int num)
        {
            StringBuilder result = new StringBuilder();

            string numstr = num.ToString();
            int zeros = numstr.Length - 1;

            foreach (char numChar in numstr)
            {
                int charIntValue = Int32.Parse(numChar.ToString());

                if (zeros >= 3)
                {
                    int multi = 1;
                    if (zeros > 3) multi = (zeros - 3) * 10;

                    result.Append('M', charIntValue * multi);
                    zeros--;
                    continue;
                }

                if (charIntValue < 4 || (charIntValue > 5 && charIntValue < 9))
                {
                    int numberOfChars = charIntValue < 4 ? charIntValue : charIntValue - 5;

                    if (charIntValue > 5)
                    {
                        switch (zeros)
                        {
                            case 2:
                                result.Append('D');
                                break;
                            case 1:
                                result.Append('L');
                                break;
                            default:
                                result.Append('V');
                                break;
                        }
                    }

                    char romanLetter;
                    switch (zeros)
                    {
                        case 2:
                            romanLetter = 'C';
                            break;
                        case 1:
                            romanLetter = 'X';
                            break;
                        default:
                            romanLetter = 'I';
                            break;

                    }

                    result.Append(romanLetter, numberOfChars);
                }
                else if (charIntValue == 4 || charIntValue == 9)
                {
                    switch (zeros)
                    {
                        case 2:
                            result.Append('C');
                            result.Append(charIntValue == 4 ? 'D' : 'M');
                            break;
                        case 1:
                            result.Append('X');
                            result.Append(charIntValue == 4 ? 'L' : 'C');
                            break;
                        default:
                            result.Append('I');
                            result.Append(charIntValue == 4 ? 'V' : 'X');
                            break;
                    }
                }
                else if (charIntValue == 5)
                {
                    switch (zeros)
                    {
                        case 2:
                            result.Append('D');
                            break;
                        case 1:
                            result.Append('L');
                            break;
                        default:
                            result.Append('V');
                            break;
                    }
                }
                zeros--;
            }

            return result.ToString();
        }
        #endregion

        #region Letter
        private static Dictionary<char, string> lettersDict = new Dictionary<char, string>()
        {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };
        public IList<string> LetterCombinations(string digits)
        {
            List<string> resultList = new List<string>();

            if (digits.Length <= 0) return resultList;

            char firstDigit = digits[0];
            string letters = lettersDict[firstDigit];

            if (digits.Length == 1)
            {
                foreach (char letter in letters)
                    resultList.Add(letter.ToString());
            }
            else
            {
                foreach (string combination in LetterCombinations(digits.Substring(1)))
                {
                    foreach (char letter in letters)
                        resultList.Add(letter + combination);
                }
            }

            return resultList;
        }
        #endregion
    }
}
