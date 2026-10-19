using ConsoleApp1;

//https://bytebytego.com/exercises/coding-patterns/two-pointers/is-palindrome-valid
//https://bytebytego.com/exercises/coding-patterns/two-pointers/is-palindrome-valid


Console.WriteLine("TwoSumPairSumSorted");

Console.WriteLine(string.Join(", ", new TwoSumPairSumSorted().TwoSum(new int[] { 2, 7, 11, 15 }, 9)));
Console.WriteLine(string.Join(", ", new TwoSumPairSumSorted().TwoSumDevTry1(new int[] { 2, 7, 11, 15 }, 9)));
Console.WriteLine(string.Join(", ", new TwoSumPairSumSorted().TwoSumDevTry2(new int[] { 2, 7, 11, 15 }, 9)));

Console.WriteLine("TripletSumToZero");
Console.WriteLine(string.Join(", ", new TripletSumToZero().TripletSum(new int[] { 0, -1, 2, -3, 1 }).Select(t => $"[{t.x1}, {t.x2}, {t.x3}]")));

Console.WriteLine("IsPalindrome");
Console.WriteLine(new Palindrome().IsPalindrome("a dog! a panic in a pagoda."));
Console.WriteLine(new Palindrome().IsPalindrome("abc123"));