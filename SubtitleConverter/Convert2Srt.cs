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
    /// <summary>
    /// Metoda konwertuje plik z napisami do formatu SRT
    /// 22
    /// 00:05:22,010 --> 00:05:23,500
    /// Wiesz co bêdzie pierwsz¹ rzecz¹,
    /// jak¹ zrobiê po powrocie do domu?
    /// </summary>
    /// <param name="filePath">Œcie¿ka do pliku</param>
    public static class Convert2Srt
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

            newFileName = fileNameWithoutExt + ".srt";

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
            int counter = 0;
            while ((line = reader.ReadLine()) != null)
            {
                counter++;
                int start = 0;
                int stop = 0;
                double startD = 0d;
                double stopD = 0d;
                string startS = "";
                string stopS = "";
                string text = "";
                TimeSpan startTS = new TimeSpan();
                TimeSpan stopTS = new TimeSpan();



                if (line.StartsWith("["))
                { //MPL 2 [1000][1100]Tekst dialogu

                    string[] temp = line.Split(new string[] { "][" } , StringSplitOptions.RemoveEmptyEntries);

                    start = (int)(int.Parse(temp[0].Replace("[", "")) );

                    int index = temp[1].IndexOf("]");
                    if (index > 0)
                    {
                        stop = (int)(int.Parse(temp[1].Substring(0, index)));
                        text = temp[1].Substring(index + 1).Replace("|", "\r\n");

                    }
                    else stop = (int)(int.Parse(temp[1])) ;

                    startTS = new TimeSpan(0,0, 0, (int)start/10, start%10 * 100);
                    stopTS = new TimeSpan(0, 0, 0, (int)stop / 10, stop%10 * 100);


                    if (temp.Length > 2)
                    {
                        for (int i = 2; i < temp.Length; i++) text += temp[i].Replace("|","\r\n");
                    }

                    

                }
                else if (Regex.IsMatch(line.Substring(0, 1), @"\d"))
                { //TMP 00:10:15:Tekst dialogu

                    
                    string[] temp = line.Split(new string[] { ":" } , StringSplitOptions.RemoveEmptyEntries);

                    int h = int.Parse(temp[0]);
                    int m = int.Parse(temp[1]);
                    int s = int.Parse(temp[2]);

                    startTS = new TimeSpan(0,h, m, s,0);

                    //Gdy dialog jest d³u¿szy wyœwietlamy napisy przez 4 sekundy
                    if (line.Length > 40) stopTS = startTS.Add( new TimeSpan(0,0,4) );
                    else stopTS = startTS.Add(new TimeSpan(0, 0, 2));

                    if (temp.Length > 3)
                    {
                        for (int i = 3; i < temp.Length; i++) text += temp[i].Replace("|", "\r\n"); ;
                    }

                    
                }
                else if (line.StartsWith("{"))
                { //MicroDVD {1000}{1100}Tekst dialogu

                    string[] temp = line.Split(new string[] { "}{" } , StringSplitOptions.RemoveEmptyEntries);

                    startD = (double.Parse(temp[0].Replace("{", ""))) / frameRate;

                    int index = temp[1].IndexOf("}");
                    if (index > 0)
                    {
                        stopD =  (double.Parse(temp[1].Substring(0, index))) / frameRate;
                        text = temp[1].Substring(index + 1).Replace("|", "\r\n");

                    }
                    else stopD= (double.Parse(temp[1])) / frameRate;

                    startTS = new TimeSpan(0, 0, 0, 0, (int) (startD * 1000d) );
                    stopTS = new TimeSpan(0, 0, 0, 0, (int) (stopD * 1000d) );

                    if (temp.Length > 2)
                    {
                        for (int i = 2; i < temp.Length; i++) text += temp[i].Replace("|", "\r\n");
                    }
                }

                //Formatowanie czasu
                startS = string.Format("{0:00}:{1:00}:{2:00},{3:000}", startTS.Hours, startTS.Minutes, startTS.Seconds, startTS.Milliseconds);
                stopS = string.Format("{0:00}:{1:00}:{2:00},{3:000}", stopTS.Hours, stopTS.Minutes, stopTS.Seconds, stopTS.Milliseconds);

                //I zapis wiersza do pliku
                writer.WriteLine(counter.ToString());
                writer.WriteLine(startS + " --> " + stopS);
                writer.WriteLine(text);
                writer.WriteLine();

            }
            reader.Close();
            writer.Close();
        }
    }
}
