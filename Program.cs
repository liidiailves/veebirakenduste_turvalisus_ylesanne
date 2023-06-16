namespace Hackthissite_programming_1_Ilves
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] scrambledLines = System.IO.File.ReadAllLines("scrambledwords.txt");
            string[] wordlistLines = System.IO.File.ReadAllLines("wordlist.txt");

            int wordFound = 0;
            int i = 0;
            int goodChar = 0;
            List<int> idxUsedSW = new List<int>();
            List<int> idxUsedWL = new List<int>();
            List<string> finalWord = new List<string>();

            // loop for each scrambled words
            foreach (string scrambledLine in scrambledLines)
            {
                i++;
                Console.WriteLine("Scrambled Word nr {0} : {1} ", i, scrambledLine);

                foreach (string wordlistLine in wordlistLines)
                {
                    if (wordFound != i)
                    {
                        // Check if ScrambleWord length === WordList length
                        if (scrambledLine.Length == wordlistLine.Length)
                        {
                            for (int idx = 0; idx <= (scrambledLine.Length - 1); idx++)
                            {
                                for (int idx2 = 0; idx2 <= (wordlistLine.Length - 1); idx2++)
                                {
                                    if (scrambledLine[idx] == wordlistLine[idx2])
                                    {
                                        if (!idxUsedSW.Contains(idx) && !idxUsedWL.Contains(idx2))
                                        {
                                            idxUsedSW.Add(idx);
                                            idxUsedWL.Add(idx2);
                                            goodChar++;
                                        }

                                    }
                                }
                            }

                        }

                        if (scrambledLine.Length == goodChar)
                        {
                            Console.WriteLine("-------> {0}", wordlistLine);
                            Console.WriteLine("\t");
                            wordFound++;
                            finalWord.Add(wordlistLine);
                        }
                    }
                    idxUsedSW.Clear();
                    idxUsedWL.Clear();
                    goodChar = 0;

                }

            }

            string finalText = string.Empty;
            foreach (string word in finalWord)
            {
                finalText = finalText + word + ",";

            }
            // Take off the last character " , "
            finalText = finalText.Remove(finalText.Length - 1);

            System.IO.File.WriteAllText("finalwords.txt", finalText);
            Console.ReadLine();

        }
    }
}