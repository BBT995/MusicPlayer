using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
namespace _01音乐播放器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<String> list = new List<string>();
        /// <summary>
        /// 添加音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择要打开音乐文件";
            ofd.Multiselect = true;
            ofd.InitialDirectory = @"C:\Users\99583\Desktop\Music";
            ofd.Filter = "WAV格式|*.wav|所有格式|*.*";
            ofd.ShowDialog();
            //将选中的音乐文件名添加到listBox中
            string[] path = ofd.FileNames;
            if (path==null)
            {
                return;
            }
            for (int i = 0; i < path.Length; i++)
            {
                listBox1.Items.Add(Path.GetFileName(path[i]));
                list.Add(path[i]);
            }
            listBox1.SelectedIndex = 0;
        }
        SoundPlayer sp = new SoundPlayer();
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            sp.SoundLocation = list[listBox1.SelectedIndex];
            sp.Play();
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            if ((listBox1.SelectedIndex < 0) || (listBox1.SelectedIndex >= list.Count))
            {
                MessageBox.Show("你还没有添加歌曲呢！");
                return;
            }
            int index = listBox1.SelectedIndex;
             index--;
            if ((index == 0)||(listBox1.SelectedIndex == 0))
            {
                index = listBox1.Items.Count-1;
               
            }
            listBox1.SelectedIndex = index;
            sp.SoundLocation = list[index];
            sp.Play();
            btnSP.Text = "暂停";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if ((listBox1.SelectedIndex < 0) || (listBox1.SelectedIndex >= list.Count))
            {
                MessageBox.Show("你还没有添加歌曲呢！");
                return;
            }
            int index = listBox1.SelectedIndex;
            index++;
            if ((index == listBox1.Items.Count) || (listBox1.SelectedIndex == listBox1.Items.Count))
            {
                index = 0;
               
            }
            listBox1.SelectedIndex = index;
            sp.SoundLocation = list[index];
            sp.Play();
            btnSP.Text = "暂停";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((listBox1.SelectedIndex < 0) || (listBox1.SelectedIndex >= list.Count))
            {
                MessageBox.Show("你还没有添加歌曲呢！");
                return;
            }
            if (btnSP.Text == "暂停")
            {
                sp.Stop();
            btnSP.Text = "播放";
            }
            else if (btnSP.Text == "播放")
            {
                sp.Play();
                btnSP.Text ="暂停";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎进入汪医晕音乐");
        }
    }
}
