using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MediaInfoLib;
using System.Globalization;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SubtitleConverter
{
    public static class Convert2MicroDVD
    {

        /// <summary>
        /// Metoda konwertuje plik z napisami do formatu MicroDVD
        /// {5222}{5271}Wiesz co bêdzie pierwsz¹ rzecz¹,|jak¹ zrobiê po powrocie do domu?
        /// {5272}{5292}Pozbêdziesz siê pryszczy?
        /// </summary>
        /// <param name="filePath">Œcie¿ka do pliku</param>
        public static void Convert(string filePath)
        {

            string newFileName = filePath;
            string oldFileName = filePath + ".old";

            string directory = Path.GetDirectoryName(newFileName);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(newFileName);
            string fileFilter = fileNameWithoutExt + ".*";

            if (File.Exists(oldFileName)) File.Delete(oldFileName);

            File.Move(newFileName, oldFileName);


            string[] filePaths = Directory.GetFiles(directory, fileFilter);

            string videoFile = filePaths[0];


            MediaInfo MI = new MediaInfo();
            MI.Open(videoFile);
            string framRateString = MI.Get(StreamKind.Video, 0, "FrameRate");

            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";
            double frameRate = 0;

            frameRate = (System.Convert.ToDouble(framRateString, provider));

            StreamReader reader = new StreamReader(oldFileName, Encoding.GetEncoding(1250));
            StreamWriter writer = new StreamWriter(newFileName, false, Encoding.GetEncoding(1250));

            String line;

            while ((line = reader.ReadLine()) != null)
            {
                int start = 0;
                int stop = 0;
                string text = "";


                if (line.StartsWith("["))
                { //MPL 2 [1000][1100]Tekst dialogu

                    string[] temp = line.Split(new string[] { "][" } , StringSplitOptions.RemoveEmptyEntries);

                    start = (int)(int.Parse(temp[0].Replace("[", "")) * frameRate) / 10;

                    int index = temp[1].IndexOf("]");
                    if (index > 0)
                    {
                        stop = (int)(int.Parse(temp[1].Substring(0, index)) * frameRate) / 10;
                        text = temp[1].Substring(index + 1);

                    }
                    else stop = (int)(int.Parse(temp[1]) * frameRate) / 10;


                    if (temp.Length > 2)
                    {
                        for (int i = 2; i < temp.Length; i++) text += temp[i];
                    }


                }
                else if (Regex.IsMatch(line.Substring(0, 1), @"\d"))
                { //TMP 00:10:15:Tekst dialogu

                    string[] temp = line.Split(new string[] { ":" } , StringSplitOptions.RemoveEmptyEntries);

                    int h = int.Parse(temp[0]);
                    int m = int.Parse(temp[1]);
                    int s = int.Parse(temp[2]);


                    start = (int)((h * 3600 + m * 60 + s) * frameRate);

                    //Gdy dialog jest d³u¿szy wyœwietlamy napisy przez 4 sekundy
                    if (line.Length > 40) stop = start + (int)(4 * frameRate);
                    else stop = start + (int)(2 * frameRate);

                    if (temp.Length > 3)
                    {
                        for (int i = 3; i < temp.Length; i++) text += temp[i];
                    }


                }

                writer.WriteLine("{" + start.ToString() + "}{" + stop.ToString() + "}" + text);

            }
            reader.Close();
            writer.Close();

        }
    }
}
