using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

//11-4-2025
/*
Write a function

Vowel2Index(string s)
that takes in a string and replaces all the vowels [a,e,i,o,u] with their respective positions within that string.
E.g:

Kata.Vowel2Index("this is my string") == "th3s 6s my str15ng"
Kata.Vowel2Index("Codewars is the best site in the world") == "C2d4w6rs 10s th15 b18st s23t25 27n th32 w35rld"
Your function should be case insensitive to the vowels.
*/

public class Kata
{
  public static string Vowel2Index(string str)
  {
    var vowels = "aeiou";
    var newString = new StringBuilder ("");
    var charToReplace = '\0';
    var intToSwapIn = "";
    
    for(int i = 0; i < str.Length; i++){
      if(vowels.Contains(str[i])){
        charToReplace = str[i];
        intToSwapIn = (i + 1).ToString();
        
        newString.Append(intToSwapIn);
      } else {
        newString.Append(str[i]);
      }
      
    }
    
    return newString.ToString();
  }
}

//11-6-2025
/*Write a function partlist that gives all the ways to divide a list (an array) of at least two elements into two non-empty parts.

Each two non empty parts will be in a pair.
Each part will be in a string.
Elements of a pair must be in the same order as in the original array.
a = ["az", "toto", "picaro", "zone", "kiwi"] -->
[["az", "toto picaro zone kiwi"], ["az toto", "picaro zone kiwi"], ["az toto picaro", "zone kiwi"], ["az toto picaro zone", "kiwi"]] */

public class PartList
{
    public static string[][] Partlist(string[] arr) 
    {
        var finalList = new List<string[]>();
      
        for(int i = 1; i < arr.Length; i++){
          var firstElement = string.Join(" ", arr, 0, i);
          var secondElement = string.Join(" ", arr, i, arr.Length - i);
          var elementList = new List<string>();
          elementList.Add(firstElement);
          elementList.Add(secondElement);
          finalList.Add(elementList.ToArray());          
        }
      
      return finalList.ToArray();
    }
}

//NOTES: Ended up using ChatGPT for help finding solution. My logic was off with the iterations beginning and ending where they needed to, and also with unnecessary use of StringBuilder for first and second Elements. Key takeaway is that string.Join's fourth parameter is COUNT of elements to take, NOT ENDING INDEX of selected elements.

//11-7-25
/*Determine the total number of digits in the integer (n>=0) given as input to the function. For example, 9 is a single digit, 66 has 2 digits and 128685 has 6 digits. Be careful to avoid overflows/underflows.

All inputs will be valid.
*/

public class DecTools {
  public static int Digits(ulong n) {
    return n.ToString().Length;
  }
}

//11-10-25
/*In this kata, we will make a function to test whether a period is late.

Our function will take three parameters:

last - The Date object with the date of the last period

today - The Date object with the date of the check

cycleLength - Integer representing the length of the cycle in days

Return true if the number of days passed from last to today is greater than cycleLength. Otherwise, return false.
*/

public static class Kata
{
  public static bool PeriodIsLate(DateTime last, DateTime today, int cycleLength)
  {
    var timeElapsed = last.Add(today - last);
    var nextCycle = last.AddDays(cycleLength);
    return timeElapsed > nextCycle;
  }
}

//NOTES: last-today results in a TimeSpan object, which can be accessed with properties like .Days. I need .Add for timeElapsed bc it's adding TimeSpan to a DateTime, but I need .AddDays for nextCycle because it's adding an int to a Datetime.

//11-11-25
/*Remove the duplicates from a list of integers, keeping the last ( rightmost ) occurrence of each element.
Example:

For input: [3, 4, 4, 3, 6, 3]

    remove the 3 at index 0
    remove the 4 at index 1
    remove the 3 at index 3

Expected output: [4, 6, 3]

More examples can be found in the test cases.

Good luck!
*/

public class Solution
{
    public static int [] solve (int [] arr){
      //identify which elements are duplicated
      var duplicates = arr.GroupBy(x => x).Where(y => y.Count() > 1).Select(y => y.Key).ToArray();
      List<int> newArr = new List<int>();
      
      //find the indexOf the highest occurence of the duplicate
      foreach (var x in duplicates){
        var highestIndex = Array.LastIndexOf(arr, x);
        newArr = arr.Where((y, index) => y != x && index != highestIndex).ToList();
      }
     
      return newArr.ToArray();
    }
}

//NOTES: THIS SOLUTION DOESN"T WORK. But I learned that GroupBy returns a dictionary with key/values like (for an int collection) {0: 0, 1: 1, 1} etc. This solution doesn't work because I re-evaluate newArr every time. A better solution would be to work from right to left in a for loop OR use linq for reversing/distinct. This is my favorite solution on codewars (not mine!)

/* public static int [] solve (int [] arr){
       return arr.Reverse().Distinct().Reverse().ToArray();            
  }*/

//11-12-2025
/*Count the number of occurrences of each character and return it as a (list of tuples) in order of appearance. For empty output return (an empty list).

Consult the solution set-up for the exact data structure implementation depending on your language.

Example:

Kata.OrderedCount("abracadabra") == new List<Tuple<char, int>> () {
  new Tuple<char, int>('a', 5),
  new Tuple<char, int>('b', 2),
  new Tuple<char, int>('r', 2), 
  new Tuple<char, int>('c', 1),
  new Tuple<char, int>('d', 1)
}
*/

namespace Solution {
    
  public class Kata {
        
  public static List<Tuple<char, int>> OrderedCount(string input) {
      var groupedData = input.GroupBy(x => x);
      List<Tuple<char, int>> result = groupedData.Select(y => Tuple.Create(y.Key, y.Count())).ToList(); 
      
      return result;
        }
    }
}

/*NOTES: Luckily had a GroupBy question yesterday and remembered that it returns an IGrouping with Key and Element. Had to look up how to instantiate a Tuple to return the right data type*/

//11-14-25
/*Complete the solution so that it returns a formatted string. The return value should equal "Value is VALUE" where value is a 5 digit padded number.

Example:

solution(5); // should return "Value is 00005"
*/

public class PaddedNumbers
{
  public static string Solution(int value)
  {
    var givenLength = value.ToString().Length;
    var neededPadding = 5 - givenLength;
    var zeroes = "00000";
    var padding = new string(zeroes.Take(neededPadding).ToArray());
    return $"Value is {padding}{value.ToString()}";
  }
}

//NOTES: A better solution (that I found after solving) is public static string Solution(int value)
// {
//     return $"Value is {value:00000}";
// }
//which makes use of built in .NET formatting. But, it's good to know that .Take() returns an IEnumerable<char>, which I couldn't use in the interpolation and needed to convert it to a character Array and then a string (which is what makes this solution so wordy).