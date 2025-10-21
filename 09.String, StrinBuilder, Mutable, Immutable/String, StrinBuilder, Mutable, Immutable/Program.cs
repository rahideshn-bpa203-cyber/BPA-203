namespace String__StrinBuilder__Mutable__Immutable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task 1
            //string word = "I am Backend DEVELOPER I LEARN C#";


            //int say = CountVowels(word);

            //Console.WriteLine("Saitlerin sayı: " + say);

            #region Task2-Sozlerin bosluga gore sayi
            //string text = "I am Backend DEVELOPER I LEARN C#";
            //string[] sozler = text.Split(' '); 
            //Console.WriteLine("Sözlerin sayı: " + sozler.Length); 
            #endregion
            #region Task 3-En uzun soz
            //string text = "I am Backend DEVELOPER I LEARN C#";
            //string[] sozler = text.Split(' ');

            //string enUzun = sozler[0];

            //foreach (string soz in sozler)
            //{
            //    if (soz.Length > enUzun.Length)
            //    {
            //        enUzun = soz;
            //    }
            //}

            //Console.WriteLine("En uzun söz: " + enUzun);

            #endregion

            #region task 4-butun herfleri boyuk olan sozu ve indeksini
            //string text = "I am Backend DEVELOPER I LEARN C#";
            //string[] sozler = text.Split(' ');

            //for (int i = 0; i < sozler.Length; i++)
            //{
            //    if (sozler[i] == sozler[i].ToUpper())
            //    {
            //        Console.WriteLine($"Böyük hərfli söz: {sozler[i]}, İndeksi: {i}");
            //    }
            //} 
            #endregion
            #region Task 5-
            //string sentence = "I am Backend DEVELOPER I LEARN C#";
            //string[] words = sentence.Split(' ');

            //for (int i = 0; i < words.Length; i++)
            //{
            //    int count = 0;

            //    for (int j = 0; j < words[i].Length; j++)
            //    {
            //        if (char.IsUpper(words[i][j]))
            //        {
            //            count++;
            //        }
            //    }

            //    if (count > 2)
            //    {
            //        Console.WriteLine($"2-den çox böyük herfi olan söz: {words[i]}");
            //    }
            //}
            #endregion

        }
        #region task1-Sait herflerin tapilmasi
        //    static int CountVowels(string text)
        //    {
        //        string vowels = "aeiouıəöüAEIOUİƏÖÜ";
        //        int count = 0;

        //        for (int i = 0; i < text.Length; i++)
        //        {
        //            string ch = text[i].ToString();
        //            if (vowels.Contains(ch))
        //            {
        //                count++;
        //            }
        //        }
        //        return count;
        //    }
        //} 
        #endregion




    }
}

