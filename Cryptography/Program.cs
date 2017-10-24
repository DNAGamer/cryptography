/*
Name: Cryptography 
Author: Daniel Bearman
Date: 24/10/17
*/
using System;

namespace Cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please select a mode:\n\n1)Encrypt\n2)Decrypt\n");
            int mode = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your text: ");
            string input = Console.ReadLine();
            Console.Write("What is the character shift? ");
            int shift = Convert.ToInt32(Console.ReadLine());

            if (mode == 1)
            {
                string encrypted = encrypt(input, shift);
                Console.WriteLine(encrypted);
            }
            else if (mode == 2)
            {
                //string decrypted = decrypt(input, shift);
            }

            Console.ReadKey();
        }

        static string encrypt(string text, int shift)
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

        //static string decrypt(string text, int shift)
        //{
        //}
    }
}

