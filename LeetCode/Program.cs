using LeetCode;

var leetCodeTasks = new LeetCodeTasks();


//Console.WriteLine(leetCodeTasks.CountOfSubstrings("iqeaouqi", 2));
//Console.WriteLine(leetCodeTasks.CountOfSubstrings("ieaouqqieaouqq", 1));
//Console.WriteLine(leetCodeTasks.IntToRoman(13));
//Console.WriteLine(leetCodeTasks.CombinationSum([8, 2, 6, 3], 13));
//Console.WriteLine(leetCodeTasks.LetterCombinations("23"));

//var queensList = leetCodeTasks.SolveNQueens(5);

//foreach (var set in queensList)
//{
//    foreach (var row in set)
//    {
//        Console.WriteLine(row);
//    }
//    Console.WriteLine("-----------------------------------");
//}

//Console.WriteLine(LeetCodeTest.ReverseWords("the sky is blue"));

//leetCodeTasks.Permute([ 1, 2, 3 ]);

//var recipeList = leetCodeTasks.FindAllRecipes2(
//    new string[] { "ju", "fzjnm", "x", "e", "zpmcz", "h", "q" },
//    new List<IList<string>>
//    {
//        new List<string> {"d"},
//        new List<string> {"hveml", "f", "cpivl"},
//        new List<string> {"cpivl", "zpmcz", "h", "e", "fzjnm", "ju"},
//        new List<string> {"cpivl", "hveml", "zpmcz", "ju", "h"},
//        new List<string> {"h", "fzjnm", "e", "q", "x"},
//        new List<string> {"d", "hveml", "cpivl", "q", "zpmcz", "ju", "e", "x"},
//        new List<string> {"f", "hveml", "cpivl"}
//    },
//    new string[] { "f", "hveml", "cpivl", "d" }
//    );

//foreach (var recipe in recipeList)
//{
//    Console.WriteLine(recipe);
//}

//var result = leetCodeTasks.CountDays(24, new int[][] { 
//    [21, 24], [9, 18], [6, 20], [8, 21], [14, 24], [19, 24], [13, 21], [1, 23], [13, 24], [7, 18] });
//Console.WriteLine(result);


//Console.WriteLine(leetCodeTasks.CheckValidCuts(4, new int[][] { 
//    [0, 2, 2, 4], [1, 0, 3, 2], [2, 2, 3, 4], [3, 0, 4, 2], [3, 2, 4, 4] }));

//Console.WriteLine(leetCodeTasks.MinOperations(new int[][] { [1, 2], [3, 4] }, 2));

//leetCodeTasks.Rotate(new int[][] { [5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16] });

//leetCodeTasks.MaxPoints(new int[][] { [1, 2, 3], [2, 5, 7], [3, 5, 1] }, [5, 6, 2]);

//leetCodeTasks.MaxPoints(new int[][] {
//[249472,735471,144880,992181,760916,920551,898524,37043,422852,194509,714395,325171],[295872,922051,900801,634980,644237,912433,857189,98466,725226,984534,370121,399006],[618420,573065,587011,298153,694872,12760,880413,593508,474772,291113,852444,77998],[67650,426517,146447,190319,379151,184754,479219,106819,138473,865661,799297,228827],[390392,789371,772048,730506,7144,862164,650590,21524,879440,396198,408897,851020],[932044,662093,436861,246956,128943,167432,267483,148325,458128,418348,900594,831373],[742255,795191,598857,441846,243888,777685,313717,560586,257220,488025,846817,554722],[252507,621902,87704,599753,651175,305330,620166,631193,385405,183376,432598,706692],[984416,996917,586571,324595,784565,300514,101313,685863,703194,729430,732044,349877],[155629,290992,539879,173659,989930,373725,701670,992137,893024,455455,454886,559081],[252809,641084,632837,764260,68790,732601,349257,208701,613650,429049,983008,76324],[918085,126894,909148,194638,915416,225708,184408,462852,40392,964501,436864,785076],[875475,442333,111818,494972,486734,901577,46210,326422,603800,176902,315208,225178],[171174,458473,744971,872087,680060,95371,806370,322605,349331,736473,306720,556064],[207705,587869,129465,543368,840821,977451,399877,486877,327390,8865,605705,481076]
//},
//[690474, 796832, 913701, 939418, 46696, 266869, 150594, 948153, 718874]
//);

//leetCodeTasks.PartitionLabels("ababcbacadefegdehijhklij");

//leetCodeTasks.MostPoints([
//        [21, 2], [1, 2], [12, 5], [7, 2], [35, 3], [32, 2], [80, 2], [91, 5], [92, 3], [27, 3], [19, 1], [37, 3], [85, 2], [33, 4], [25, 1], [91, 4], [44, 3], [93, 3], [65, 4], [82, 3], [85, 5], [81, 3], [29, 2], [25, 1], [74, 2], [58, 1], [85, 1], [84, 2], [27, 2], [47, 5], [48, 4], [3, 2], [44, 3], [60, 5], [19, 2], [9, 4], [29, 5], [15, 3], [1, 3], [60, 2], [63, 3], [79, 3], [19, 1], [7, 1], [35, 1], [55, 4], [1, 4], [41, 1], [58, 5]]);
//leetCodeTasks.MaximumTripletValue([1000000, 1, 1000000]);
//leetCodeTasks.Convert("ABCD", 2);

//Console.WriteLine(leetCodeTasks.SubsetXORSum([5, 1, 6]));
//Console.WriteLine(leetCodeTasks.CanPartition([1, 2, 3, 2]));
//Console.WriteLine(leetCodeTasks.MinimumOperations([1, 2, 3, 4, 2, 3, 3, 5, 7]));
//leetCodeTasks.CountGoodTriplets([3, 0, 1, 1, 9, 7], 7, 2, 3);
//Console.WriteLine(leetCodeTasks.GoodTriplets(
//    [13, 14, 10, 2, 12, 3, 9, 11, 15, 8, 4, 7, 0, 6, 5, 1],
//    [8, 7, 9, 5, 6, 14, 15, 10, 2, 11, 4, 13, 3, 12, 1, 0]));

//Console.WriteLine(leetCodeTasks.NumberOfArrays([1, -3, 4], 1, 6));
//Console.WriteLine(leetCodeTasks.CountSubarrays([1, 3, 2, 3, 3], 2));

//leetCodeTasks.Reverse(-123);

//Console.WriteLine(leetCodeTasks.NumEquivDominoPairs([[2, 1], [5, 4], [3, 7], [6, 2], [4, 4], [1, 8], [9, 6], [5, 3], [7, 4], [1, 9], [1, 1], [6, 6], [9, 6], [1, 3], [9, 7], [4, 7], [5, 1], [6, 5], [1, 6], [6, 1], [1, 8], [7, 2], [2, 4], [1, 6], [3, 1], [3, 9], [3, 7], [9, 1], [1, 9], [8, 9]]));
//Console.WriteLine(leetCodeTasks.PushDominoes("...RL....R.L.L........RR......L....R.L.....R.L..RL....R....R......R.......................LR.R..L.R."));
//Console.WriteLine(leetCodeTasks.NumEquivDominoPairs([[2, 8]]));

//Console.WriteLine(leetCodeTasks.StrStr("a", "a"));

//leetCodeTasks.SpiralOrder([[1, 2, 3], [4, 5, 6], [7, 8, 9]]);
