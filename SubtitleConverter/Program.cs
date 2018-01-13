using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SubtitleConverter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] Arguments)
        {
            
            //Wywo³anie programu z menu kontekstowego
            if (Arguments.Length > 0)
            {
                string fp = Arguments[0];

                if (!fp.Equals("") & !fp.Equals(null))
                {
                    //Convert2MicroDVD.Convert(fp);
                    Convert2Srt.Convert(fp);

                    Application.Exit();
                }

            }
            //Normalne uruchomie programu z pliku exe
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            } 
		}

       
    }
}