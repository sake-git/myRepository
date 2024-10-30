using System.Text;

namespace Pig_Latin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!\n\n");
            do
            {
                Console.WriteLine("Please enter a word or phrase:"); //User input
                string userInput = Console.ReadLine();

                // Incase user entered a phrase, split it in a string array to translate it word by word
                string[] inputStringArray = userInput.Split([' ','\t']);  
                string[] pigLatinArray = new string[inputStringArray.Length]; //This array holds translated words

                
                for(int index = 0; index < inputStringArray.Length; index++  )
                {
                    if(inputStringArray[index] != "") //Call convert function only if input string is non empty
                    {
                        pigLatinArray[index] =  ConvertToPigLatin(inputStringArray[index]);
                    }
                }

                Console.WriteLine("Output: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(String.Join(" ", pigLatinArray)); // Join the output array to for a sentence
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("\n\nWould you like to translater another phrase? (y/n)"); // ceck if user wants to continue
            } while (Console.ReadLine().ToLower() == "y");

            
        }

        //This function return the index of vowel in word
        static int IndexOfVowel(string word)
        {
            int indexValue = word.ToLower().IndexOfAny(['a', 'e', 'i', 'o', 'u']);

            return indexValue;
        }


        //This function return true if word has special character or number in word
        static bool HasSpecialCharacterAndNumber(string word)
        {
            int indexValue = -1;
            indexValue = word.ToLower().IndexOfAny(['!','@','#','$','%','^','~','0','1','2','3','4','5','6','7','8','9']);

            if (indexValue < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        static string ConvertToPigLatin(string word)
        {
            //Do not translate if word has special character or number in it. 
            if (HasSpecialCharacterAndNumber(word)) 
            {
                return word;
            }                              

            int indexOfVowel =  IndexOfVowel(word); // check index of vowel

            //No vowel present. This should not happen but if does, do not translate
            if (indexOfVowel == -1) 
            {
                return word;
            }

            if (indexOfVowel == 0){
                return word + "way"; // First character is Vowel, append 'way' at the end of word.
            }
            else
            {
                
                //extract the consonants before the first vowel in the string.
                string stringToAppend = word.Substring(0, indexOfVowel);

                /* Substring the part of string from the vowel. 
                 * Append the previously extracted string(stringToAppend) at the end.
                 * Then concatenate "ay" at the end */
                string stringToPrepend = word.Substring(indexOfVowel, word.Length - indexOfVowel);


                //Below part is to preserve the case of word.
                bool isFirstCharUpperCaseOld = Char.IsUpper(word[0]);
                bool isFirstCharUpperCaseNew = Char.IsUpper(stringToPrepend[0]);

                //The the case of old word and new word is not same change it
                if (isFirstCharUpperCaseNew != isFirstCharUpperCaseOld)
                {
                    if (isFirstCharUpperCaseOld)
                    {
                        //We are here which means the case of Old word was upper and translated word is lower. 
                        //Change it
                        stringToPrepend = Char.ToUpper(stringToPrepend[0]) + stringToPrepend.Substring(1);
                        stringToAppend = Char.ToLower(stringToAppend[0]) + stringToAppend.Substring(1);
                    }
                    else
                    {
                        //We are here which means the case of Old word was lower and translated word is in upper case. 
                        //Change it
                        stringToPrepend = Char.ToLower(stringToPrepend[0]) + stringToPrepend.Substring(1);
                        stringToAppend = Char.ToUpper(stringToAppend[0]) + stringToAppend.Substring(1);
                    }                    
                }
                return stringToPrepend + stringToAppend + "ay";
            }
            
        }
    }
}
