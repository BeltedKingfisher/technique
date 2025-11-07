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