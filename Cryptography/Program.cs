/*
Name: Cryptography 
Author: Daniel Bearman, Angelo Hague
Date: 24/10/17
*/
using System;

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
            text = text.ToLower(); //make the letters all lower case so we dont have to deal with case
            char[] characters = text.ToCharArray(); //Convert our text into a char array
            for (int i = 0; i < characters.Length; i++) //for loop for each letter in the array
            {
                char letter = characters[i]; //Get our letter into a variable to make things easier
                letter = (char)(letter + shift); //Shift our letters the desired amount
                if (letter > 'z') //The upper limit is 'z' (because we only have 26 letters), so subtract 26 (the alphabet) if we overflow the max
                {
                    letter = (char)(letter - 26);
                }
                else if (letter < 'a') //The lower limit is 'a' (because a is the lowest letter), so add 26 if we underflow the array
                {
                    letter = (char)(letter + 26);
                }
                characters[i] = letter; //replace the origional letter with the 'encrypted' letter
            }
            return new string(characters);
        }

        static string Decrypt(string text, int shift)
        {
            text = text.ToLower();
            char[] characters = text.ToCharArray();
            for(int i =0; i < characters.Length; i++)
            {
                char letter = characters[i]; //Get our letter into a variable to make things easier
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
                    characters[i] = letter; //replace the origional letter with the 'encrypted' letter
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
            for (int i = 0; i < 26; i++)
            {
                string Decrypted = Decrypt(text, i);
                if (Decrypted.Contains("he") && Decrypted.Contains("the"))
                {
                    Console.Write($"Shift {i}\n\nSolution:\n{Decrypted}");
                    Console.ReadKey();
                }
            }
        }
    }
}

