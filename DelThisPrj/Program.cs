

namespace DelThisPrj
{
    class Program
    {
        static string BigMistake; //Because its so bad decision 
        static HashSet<string> UniqueWords = new HashSet<string>();
        static void Main()
        {
            //DelThisPrj.Test.StartTest();
            //return;
            while (true)
            {
                Console.WriteLine("Введите номер действия, например: \"1\" \n 1) Указать файл \n 2) Удалить базу данных");
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Console.WriteLine("Укажите путь к файлу");
                            StartOfProgram(Console.ReadLine());
                            break;
                        }
                        /*
                    case "2":
                        {
                            Console.WriteLine("База данных удалена");
                            break;
                        }
                        */
                    default:
                        {
                            Console.WriteLine("Не верно выбрано действие");
                            break;
                        }

                }
                Console.WriteLine("Готово");
            }
        }
        static void StartOfProgram(string path)
        {
            ReadFile(path);
            FindAllExists();
        }
        public static void ReadFile(string path)
        {
            BigMistake = File.ReadAllText(path);
            string[] bigMistakeTemp = BigMistake.Split(new char[]{' ','\n' });
            for (int i = 0; i < bigMistakeTemp.Length; i++)
            {
                if (bigMistakeTemp[i].Length >= 3 || bigMistakeTemp.Length <= 20)
                    UniqueWords.Add(bigMistakeTemp[i]);
            }
        }
        public static void FindAllExists()
        {
            foreach (var word in UniqueWords)
            {
                int wordExists = 0;
                while (true)
                {
                    int position = Search(BigMistake, word);
                    if (position == -1)
                        break;
                    wordExists++;
                    BigMistake = BigMistake.Remove(position, word.Length);
                }
                if (wordExists > 3)
                    DbOperations.Update(word, wordExists);
            }
        }

        public static int Search(string text, string pattern)
        {
            
            Dictionary<char, int> shiftTable = CreateShiftTable(pattern);
            int i = pattern.Length - 1;
            int j = pattern.Length - 1;
            while (i < text.Length)
            {
                if (text[i] == pattern[j])
                {
                    if (j == 0)
                        return i;
                    i--;
                    j--;
                }
                else
                {

                    int shift = shiftTable.ContainsKey(text[i]) ? shiftTable[text[i]] : pattern.Length;
                    i += shift;
                    j = pattern.Length - 1;
                }
            }
            return -1;
        }
        private static Dictionary<char, int> CreateShiftTable(string pattern)
        {
            Dictionary<char, int> table = new Dictionary<char, int>();
            for (int i = 0; i < pattern.Length - 1; i++)
            {
                table[pattern[i]] = pattern.Length - i - 1;
            }
            return table;
        }
        
    }
}