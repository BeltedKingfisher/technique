using System;
using System.Linq;
using System.Text;

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