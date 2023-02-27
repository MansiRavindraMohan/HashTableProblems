using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HashTableProblems
{
    public class HashTable
    {
        public static void hashTable()
        {
            int numBuckets = 16;
            List<string>[] hashTable = new List<string>[numBuckets];
            string sentence = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            string[] words = sentence.Split(new char[] { ' ', ',', '.', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);


            foreach (string word in words)
            {
                int index = ComputeHashCode(word, numBuckets);

                if (hashTable[index] == null)
                {
                    hashTable[index] = new List<string>();
                }

                bool found = false;
                foreach (string node in hashTable[index])
                {
                    if (node.Split(',')[0] == word)
                    {
                        int frequency = int.Parse(node.Split(',')[1]) + 1;
                        hashTable[index].Remove(node);
                        hashTable[index].Add(word + "," + frequency);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    hashTable[index].Add(word + ",1");
                }
            }

            foreach (List<string> bucket in hashTable)
            {
                if (bucket != null)
                {
                    foreach (string node in bucket)
                    {
                        Console.WriteLine(node.Split(',')[0] + ": " + node.Split(',')[1]);
                    }
                }
            }
        }

        static int ComputeHashCode(string word, int numBuckets)
        {
            int hashCode = 0;
            foreach (char c in word.ToLower())
            {
                hashCode += (int)c;
            }
            return hashCode % numBuckets;
        }
    }

}
