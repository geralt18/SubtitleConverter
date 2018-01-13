using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MediaInfoLib;

namespace SubtitleConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void xOpen_Click(object sender, EventArgs e)
        {

            xOpenFile.Filter = "Pliki avi|*.avi|Pliki mkv|*.mkv|Wszystkie pliki|*.*";
            if (DialogResult.OK == xOpenFile.ShowDialog(this))
            {
                VideoInfo(xOpenFile.FileName);
            }

        }

        private void VideoInfo(string filePath)
        {
            xPath.Text = filePath;

            MediaInfo MI = new MediaInfo();
            MI.Open(filePath);

            xName.Text = MI.Get(StreamKind.Video, 0, "FileName") + MI.Get(StreamKind.Video, 0, "FileExtension") + MI.Get(StreamKind.Video, 0, "FileDirectory");
            xResolution.Text = MI.Get(StreamKind.Video, 0, "Width") + 'x' + MI.Get(StreamKind.Video, 0, "Height"); ;
            xFramerate.Text = MI.Get(StreamKind.Video, 0, "FrameRate");
            xUwagi.Text = MI.Get(StreamKind.Video, 0, "Duration/String1");
        }



        private void xOpenSub_Click(object sender, EventArgs e)
        {
            xOpenFile.Filter = "Pliki napisów|*.txt|Wszystkie pliki|*.*";
            if (DialogResult.OK == xOpenFile.ShowDialog(this))
            {
                for (int i = 0; i < xOpenFile.FileNames.Length; i++)
                {
                    //Convert2MicroDVD.Convert(xOpenFile.FileNames[i]);
                    Convert2Srt.Convert(xOpenFile.FileNames[i]);
                }
                MessageBox.Show(this, "Zakoñczono konwersje");

            }
            else MessageBox.Show(this, "Konwersja przerwana");
           

        }

    }
}