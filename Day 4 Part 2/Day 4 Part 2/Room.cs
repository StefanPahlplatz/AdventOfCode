using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_4_Part_2
{
    class Room
    {
        private static char[] alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();   // Alphabet array
        private int[] letters;                          // Occurence of each letter in the string
        private string checksum;                        // Checksum
        private string encryptedName;                   // Encrypted name of the room
        public int SectorId { get; private set; }       // Sector ID

        public Room(string roomName)
        {
            // Create char array for every char in the alphabet
            letters = new int[26];

            // Loop through string
            for (int i = 0; i < roomName.Length; i++)
            {
                int intvalue = roomName[i];

                // While we are not at the start of the checksum yet
                if (roomName[i] != '[')
                {
                    if (intvalue > 96 && intvalue < 123)
                    {
                        // Increment letter occurence
                        letters[CharToAlphabetPos(roomName[i])]++;
                    }
                }
                else
                {
                    // Get the full encrypted name
                    encryptedName = roomName.Substring(0, i - 4);

                    // Get the sector id
                    SectorId = int.Parse(roomName.Substring(i - 3, 3));

                    // Get the checksum
                    checksum = roomName.Substring(i + 1, 5);

                    // Stop the for loop
                    return;
                }
            }
        }

        // If the room is valid it returns the sector id otherwise it returns -1
        public bool IsValidRoom()
        {
            // Store highest indexes
            List<int> amount = new List<int>();

            // Get the indexes of the 5 highest values from 'letters'
            for (int i = 0; i < 5; i++)
            {
                amount.Add(Array.IndexOf(letters, letters.Max()));
                letters[Array.IndexOf(letters, letters.Max())] = 0;
            }

            // Loop through the checksum
            for (int i = 0; i < checksum.Length; i++)
            {
                // Check the char position against the amount value
                if (CharToAlphabetPos(checksum[i]) != amount[i])
                {
                    // Room is invalid
                    return false;
                }
            }

            // Room is valid
            return true;
        }

        // Get the position of the letter in the alphabet
        private static int CharToAlphabetPos(char letter)
        {
            for (int i = 0; i < alpha.Length; i++)
            {
                if (letter == alpha[i])
                    return i;
            }
            throw new ArgumentOutOfRangeException("Invalid letter.");
        }

        public string Decrypted()
        {
            // Store all decrypted chars
            List<char> decryptedchar = new List<char>();

            // Loop through the name
            for (int i = 0; i < encryptedName.Length; i++)
            {
                // Replace - with a space
                if (encryptedName[i] == '-')
                {
                    decryptedchar.Add(' ');
                }
                else
                {
                    // Get the int value of the current char
                    int temp = encryptedName[i];

                    // Increment with the sector id
                    for (int j = 0; j < SectorId; j++)
                    {
                        temp++;
                        if (temp > 122)     // Ascii value for z
                            temp = 97;      // Ascii value for a
                    }

                    // Add the decrypted char
                    decryptedchar.Add(Convert.ToChar(temp));
                }
            }

            // Full decrypted string
            string decrypted = "";
            foreach (char c in decryptedchar) { decrypted += c; }

            return decrypted;
        }
    }
}
