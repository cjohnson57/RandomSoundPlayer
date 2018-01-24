using System;
using System.IO;
using WMPLib;
using System.Windows.Forms;

namespace RandomSoundPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filepath = textBox1.Text;
            if(Directory.Exists(filepath))
            {
                string[] files = Directory.GetFiles(filepath);
                Random r = new Random();
                int selectedfile = r.Next(1, files.Length + 1) - 1;
                try
                {
                    WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
                    wplayer.URL = @files[selectedfile];
                    wplayer.controls.play();
                    label2.Text = files[selectedfile].Replace(filepath, "").Replace("\\", "").Replace(".mp3", "");
                }
                catch
                {
                    label2.Text = "Sound " + files[selectedfile].Replace(filepath, "").Replace("\\", "") +  " failed to play.";
                }
            }
            else
            {
                label2.Text = "Could not find directory.";
            }
        }
    }
}
