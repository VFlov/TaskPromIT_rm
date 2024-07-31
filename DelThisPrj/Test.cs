namespace DelThisPrj
{
    static class Test
    {
        static string PathOfFile = "C:\\Users\\Milana\\source\\repos\\DelThisPrj\\DelThisPrj\\test.txt";
        static Dictionary<int, string> dictionary = new Dictionary<int, string>()
        {
            { 1,"Один"},
            { 2, "Два"},
            { 3, "Три"},
            { 4, "Четыре"},
            { 5, "Пь"}, //NO
            { 6, "Шесть"},
            { 7, "Семь"},
            { 8, "Восемь"},
            { 9, "Девять"},
            { 10, "ДесятьДесятьДесятьДесять"} //NO
        };
        public static void StartTest()
        {
            Random random = new Random();
            string str = "";
            int i = 0;
            while (i != 1024*1024)
            {
                str += dictionary.GetValueOrDefault(random.Next(0, 10)) + " ";
                i++;
            }
            CreateFile(str);
        }
        static void CreateFile(string str)
        {
            File.WriteAllText(PathOfFile, str);
        }
    }
    
}