using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace pigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = "";
            Console.WriteLine("Enter word/sentence to be turned into Pig Latin: ");
            string userInput = Console.ReadLine();
            string[] outputWords = pigLatinizer(userInput);
            for(int i = 0; i < outputWords.Length; i++){
                if(i == outputWords.Length - 1){
                    output += outputWords[i];
                }else{
                    output += outputWords[i];
                    output += ' ';
                }
            }
            Console.WriteLine("Your input Pig Latinized is: " + output + "\nPress Any Key to Exit");
            Console.ReadKey();
            System.Environment.Exit(0);
        }

        static string[] pigLatinizer(string input)
        {
            List<string> output = new List<string>();
            input = Regex.Replace(input, "[^a-zA-Z ]", String.Empty);
            string[] words = input.Split(" ");
            for(int i = 0; i < words.Length; i++){
                string temp = "";
                string toOutput = words[i].Remove(0, 1);
                char firstLet = words[i][0];
                bool isVowel = "aeiouAEIOU".IndexOf(firstLet) >= 0;
                if(!isVowel){
                    temp += firstLet;
                    temp += "ay";
                    toOutput += temp;
                    output.Add(toOutput);
                }
            }
            return output.ToArray();
        }
    }
}
