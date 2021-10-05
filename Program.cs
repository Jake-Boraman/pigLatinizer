using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace pigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = "";
            Console.WriteLine("Enter word/list of words (space separated) to be turned into Pig Latin: ");
            string userInput = Console.ReadLine();
            string[] outputWords = pigLatinizer(userInput);
            for (int i = 0; i < outputWords.Length; i++)
            {
                if (i == outputWords.Length - 1)
                {
                    output += outputWords[i];
                }
                else
                {
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
            input = Regex.Replace(input, "[^a-zA-Z ]", String.Empty); //Removes any non alphabet characters, just in case
            string[] words = input.Split(" ");
            for (int i = 0; i < words.Length; i++)
            {
                string temp = "";
                string main = words[i].Remove(0, 1);
                string addOn = getConPart(words[i]);
                if (addOn == "vowel_start")
                {
                    temp += words[i];
                    temp += "yay";
                    output.Add(temp);
                }
                else if (addOn.Length == 3)
                {
                    temp += words[i].Remove(0, 1);
                    temp += addOn;
                    output.Add(temp);
                }
                else if (addOn.Length == 4)
                {
                    temp += words[i].Remove(0, 2);
                    temp += addOn;
                    output.Add(temp);
                }
                else if (addOn.Length == 5)
                {
                    temp += words[i].Remove(0, 3);
                    temp += addOn;
                    output.Add(temp);
                }
            }
            return output.ToArray();
        }

        static string getConPart(string word)
        {
            string output = "";
            //TODO find a better way of checking all possible consonant clusters
            //Arrays hold most common consonant clusters
            string[] consBlendsTwo = new string[] { "bl", "cl", "fl", "gl", "pl", "sl", "br", "cr", "dr", "fr", "gr", "pr", "tr", "sc", "sk", "sm", "sn", "sp", "st", "sw", "tw", "ch", "sh", "th", "wh" };
            string[] consBlendsThr = new string[] { "thr", "str", "spr", "spl", "shr", "scr" };

            bool isFirstVowel = "aeiouAEIOU".IndexOf(word[0]) >= 0;

            if (!isFirstVowel)
            {
                bool isSecVowel = "aeiouAEIOU".IndexOf(word[1]) >= 0;
                if (!isSecVowel)
                {
                    bool isThrVowel = "aeiouAEIOU".IndexOf(word[2]) >= 0;
                    if (!isThrVowel)
                    { //When there are three letters before a vowel
                        string temp = word.Substring(0, 3);
                        if (consBlendsThr.Any(temp.Contains))
                        { //Contains the three letter substring
                            output += temp;
                            output += "ay";
                            return output;
                        }
                        else
                        { //Substring not found, therefore return just first letter
                            output += word[0];
                            output += "ay";
                            return output;
                        }
                    }
                    else
                    { //When there are only two letters before a vowel
                        string temp = word.Substring(0, 2);
                        if (consBlendsTwo.Any(temp.Contains))
                        { //Contains the two letter substring
                            output += temp;
                            output += "ay";
                            return output;
                        }
                        else
                        { //Substring not found, therefore return just first letter
                            output += word[0];
                            output += "ay";
                            return output;
                        }
                    }
                }
                else //When there is only one letter before a vowel
                {
                    output += word[0];
                    output += "ay";
                    return output;
                }
            }
            else
            {
                return "vowel_start"; //Inform pigLatinizer to handle differently
            }
        }
    }
}
