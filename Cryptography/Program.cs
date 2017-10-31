/*
Name: Cryptography
Author: Daniel Bearman, Angelo Hague
Date: 24/10/17
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please select a mode:\n\n1)Encrypt\n2)Decrypt\n3)Stretch Task\n");
            int mode = Convert.ToInt32(Console.ReadLine());
            if (mode != 3)
            {
                Console.Write("Enter your text: ");
                string input = Console.ReadLine().Replace("\n", "");
                Console.Write("What is the character shift? ");
                int shift = Convert.ToInt32(Console.ReadLine());

                if (mode == 1)
                {
                    string encrypted = Encrypt(input, shift);
                    Console.WriteLine(encrypted);
                }
                else if (mode == 2)
                {
                    string decrypted = Decrypt(input, shift);
                    Console.WriteLine(decrypted);
                }
                Console.ReadKey();
            }
            else
            {
                Stretch();
            }

        }

        static string Encrypt(string text, int shift)
        {
            char[] characters = text.ToCharArray(); //Convert our text into a char array
            for (int i = 0; i < characters.Length; i++) //for loop for each letter in the array
            {
                char c = characters[i]; //Used to hold the original character, for correct case conversion
                char letter = Char.ToLower(characters[i]); //Get our letter into a variable to make things easier
                if (char.IsLetter(letter))
                {
                    letter = (char)(letter + shift); //Shift our letters the desired amount
                    if (letter > 'z') //The upper limit is 'z' (because we only have 26 letters), so subtract 26 (the alphabet) if we overflow the max
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'a') //The lower limit is 'a' (because a is the lowest letter), so add 26 if we underflow the array
                    {
                        letter = (char)(letter + 26);
                    }
                    //Replaces the letter in the appropiate case:
                    if (char.IsLower(c))
                        characters[i] = letter; //replace the original letter with the 'encrypted' letter
                    else
                        characters[i] = Char.ToUpper(letter);
                }
            }
            return new string(characters);
        }

        static string Decrypt(string text, int shift)
        {
            char[] characters = text.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                char c = characters[i]; //Used to hold the original character, for correct case conversion
                char letter = Char.ToLower(characters[i]); //Get our letter into a variable to make things easier
                if (char.IsLetter(letter))
                {
                    letter = (char)(letter - shift); //Shift our letters back the desired amount
                    if (letter > 'z') //The upper limit is 'z' (because we only have 26 letters), so subtract 26 (the alphabet) if we overflow the max
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'a') //The lower limit is 'a' (because a is the lowest letter), so add 26 if we underflow the array
                    {
                        letter = (char)(letter + 26);
                    }
                    //Replaces the letter in the appropiate case:
                    if (char.IsLower(c))
                        characters[i] = letter; //replace the original letter with the 'encrypted' letter
                    else
                        characters[i] = Char.ToUpper(letter);
                }
            }
            return new string(characters);
        }

        static void Stretch()
        {
            string text = @"Mu husudjbo iqm, veh jxu vyhij jycu, jxu huikbj ev q iefxyijysqjut hqdiecmqhu qjjqsa, qdt
jxu uvvusji jxqj yj xqt ed jxu Dqjyedqb Xuqbjx Iuhlysu, ydsbktydw qcrkbqdsui ruydw jkhdut
qmqo qdt fqjyudji xqlydw jxuyh efuhqjyedi sqdsubbut mxybij fhufqhydw je we yd je
jxuqjhu.Jxu MqddqSho lyhki, qi yj rusqcu ademd, xqt vekdt q auo lkbduhqrybyjo, qdt yj
xqt q tulqijqjydw ycfqsj qi edu xeifyjqb qvjuh qdejxuh hufehjut jxqj yj xqt ruud qvvusjut;
duqhbo vyvjo yd jejqb. Yd jxu yccutyqju qvjuhcqjx, unfuhji qdt ydiytuhi qbyau mudj ed je
dumi ekjbuji qdt ed je iesyqb cutyq, myjx jxuyh unfbqdqjyedi eh xem jxyi sekbt xqlu
xqffudut.Mxqj yi sbuqh yi jxqj iecujxydw duutut je ru tedu je udikhu jxqj iksx qd qjjqsa
mybb duluh xqlu jxu iqcu ycfqsj ed jxu Dqjyedqb Xuqb Iuhlysu yd jxu vkjkhu.";

            //Count each character in text using a Dictionary
            var characterCount = new Dictionary<char, int>();
            foreach (char c in text)
            {
                if (characterCount.ContainsKey(c))
                    characterCount[c]++;
                else
                    characterCount[c] = 1;
            }

            //Using LINQ to sort Dictionary:
            var items = from pair in characterCount
                        orderby pair.Value ascending
                        select pair;

            //Sort (descending) and iterate through Dictionary to find the value of all letters:
            foreach (KeyValuePair<char, int> pair in characterCount.OrderByDescending(i => i.Value))
            {
                int shift = 0;
                char c = pair.Key;

                if (char.IsLetter(c))
                {
                    Console.WriteLine("{0} - {1}", pair.Key, pair.Value); //Print shift

                    //Find the shift between the current letter and 'E', as 'E' is considered the most frequent letter in the English Alphabet:
                    while (c != 'e')
                    {
                        c--;
                        shift++;
                        if (c > 'z') //The upper limit is 'z' (because we only have 26 letters), so subtract 26 (the alphabet) if we overflow the max
                        {
                            c = (char)(c - 26);
                        }
                        else if (c < 'a') //The lower limit is 'a' (because a is the lowest letter), so add 26 if we underflow the array
                        {
                            c = (char)(c + 26);
                        }
                    }
                    if (c == 'e')
                    {
                        Console.WriteLine("Shift is {0}", shift); //Print Shift
                        string decrypted = Decrypt(text, shift);  //Use the 'decrypt' function to decrypt the text with the discovered shift
                        Console.WriteLine(decrypted);             //Print decrypted text
                    }

                    //Check to see if the cipher is readible to the user:
                    Console.WriteLine("Is this cipher correct? (Y/N)");
                    char next = char.Parse(Console.ReadLine().ToLower());
                    if (next == 'y')
                        break;
                    else
                        continue;

                }
            }


        }


        //End:
    }
}
