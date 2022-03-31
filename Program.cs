using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

//Console.WriteLine(string.Join(",", Kata.DescendingOrder(12345)));
//Console.WriteLine(string.Join(",", Kata.RemoveSmallest(new List<int>())));
//Console.WriteLine(Kata.CalculateYears(3106.6259756249497,0.24119108274634513,0.18,1000));
//Console.WriteLine(Kata.print(43));
//Console.WriteLine(Kata.DecipherThis("65cb"));
//Console.WriteLine(Kata.Solve("mischtschenkoana"));
Console.WriteLine(string.Join(",", Kata.UpArray(new int[] {9, 9, 9, 9})));
public static class Kata
{
  //Returns the mid of the filename -> 1231231223123131_myFile.tar.gz2 -> myFile.tar
  public static string ExtractFileName(string s){
    return s[(s.IndexOf('_') + 1) .. s.LastIndexOf('.')];
  }

  //Increases the array by 1 -> goes from 9,9,9 to 1,0,0,0, from 1,0,0,9 to 1,0,1,0  
  public static int[] UpArray(int[] num){
		
    //Checks if num isn't empty or if it has any number lower than 0 or bigger than 9
    if (num.Length == 0 || num.Any(n => n < 0 || n > 9)) return null;

    //Runs though the array backwards
    for (int i = num.Length -1; i >= 0; i--){

      //If the number isn't 9, add 1 and quit the loop
      if (num[i] < 9){
        num[i]++;
        return num;

      //If the number is 9, changes to zero than keep running
      } else {
        num[i] = 0;
      }
    }

    //Assuming it got to the end, we need a bigger array (for 999, the return must be 1000)
    return new []{1}.Concat(num).ToArray();
	}
  
  //Split the string by vowels and sums the value of the substrings
  public static int Solve(string s){
    return s.Split('a', 'e', 'i', 'o', 'u').Max(x => x.Sum(c => c - 96));
  }
  
  //Decipher a message
  public static string DecipherThis(string s){
    
    string[] words = s.Split(" ");
    string result = "";
    string firstLetter = "";
    char secondLetter = ' ';

    foreach (string word in words){

      //Find the unicode. It will always be at the begning of every word
      for (int i = 0; i < word.Length; i++){

        if (char.IsDigit(word[i])){
          firstLetter += word[i];
        } else {
          break;
        }

      }  
        
      for (int i = firstLetter.Length; i < word.Length; i++){

        //If it's the first iteration, saves the letter to add to the end of the word
        if (i == firstLetter.Length){
          secondLetter = word[i];
          result += (char)int.Parse(firstLetter); //Transforms the code into a letter
          result += word[word.Length -1]; //Places the last letter as the second
        } else if (i == word.Length -1){
          result += secondLetter + " "; //At the last iteration places the second letter at the end
        } else {
          result += word[i]; //If it's not the second nor last letter, just add
        }
      
      firstLetter = "";
      }  
    }
    
    return result;
  }
  
  //Prints a diamond
  public static string print(int n)
	{
		if (n <= 0 || n % 2 == 0) return new string("");

        string diamond = "";
        //TOP of the diamond
        for (int i = 1; i <= n ; i += 2){
            
            //Adding space before *
            for (int space = (n - i) / 2; space >= 1; space--) diamond += " ";
            for (int j = 1; j <= i; j++) diamond += "*";
            diamond += "\n";

            //Bottom of the diamond
            if (i == n){
                for (int l = n - 2; l >= 1; l -= 2){
                    for (int space = (n - l) / 2; space >= 1; space--) diamond += " ";
                    for (int j = l; j >= 1; j--) diamond += "*";
                    diamond += "\n";
                }
            }
        }

        return diamond;

	}

  //Calculates how many years it takes to value increae until it reaches the desired value
  public static int CalculateYears(double principal, double interest,  double tax, double desiredPrincipal){

    if (principal == desiredPrincipal) return 0;

    double added = 0;
    int years = 0;
    while (principal < desiredPrincipal){
        
        added += (principal * interest);
        principal += added;

        added -= (added * tax);
        principal -= added;

        years++;
    }

    return years;
  }

  //Remove the smallest number
  public static List<int> RemoveSmallest(List<int> numbers)
  {

    return numbers.Any() && numbers.Remove(numbers.Min()) ? numbers : new List<int>();

    /*if (!numbers.Any()) return new List<int>();

    int min = numbers.Min();
    bool changed = false;
    List<int> lst = new List<int>();
    
    for (int i = 0; i < numbers.Count; i++){
      if (numbers[i] == min && changed == false){
        changed = true;
      } else {
        lst.Add(numbers[i]);
      }
    }
    
    return lst;*/
  }

//Changes the order of the array
  public static int DescendingOrder(int num)
  {
    string str = num.ToString();
    char[] charArr = new char[str.Length];

    for (int i = 0; i < charArr.Length; i++) charArr[i] = str[i];

    Array.Sort(charArr);
    Array.Reverse(charArr);

    str = "";
    for (int i = 0; i < charArr.Length; i++) str += charArr[i];
    
    return Int32.Parse(str);

    /* Works in version 10, but the kata is using the version 8
    char[] charArr = num.ToString().ToArray();
    Array.Sort(charArr);
    Array.Reverse(charArr);

    string str = "";
    for (int i = 0; i < charArr.Length; i++) str += charArr[i];

    return Int32.Parse(str);
    */
  }
}