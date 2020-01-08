using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        PictureBox[] picboxAry;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\kang\Desktop\penguin.jpg");//先在form1中拉入pictureBox1並載入圖檔
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            picboxAry = new PictureBox[3];//產生PictureBox陣列
            splitImage(@"C:\Users\kang\Desktop\PP", @"C:\Users\kang\Desktop\PP", Image.FromFile(@"C:\Users\kang\Desktop\penguin.jpg"), 75, 225);//切割
            for (Int32 i = 0; i < picboxAry.Length; i++)
            {
                picboxAry[i] = new PictureBox();
                picboxAry[i].Size = new Size(75, 75);//設定大小
                picboxAry[i].Location = new Point(pictureBox1.Width + 20, 105 * i);//設定座標
                picboxAry[i].SizeMode = PictureBoxSizeMode.StretchImage;
                picboxAry[i].Image = Image.FromFile(@"C:\Users\kang\Desktop\PP" + 75 * i + ".jpg");
                this.Controls.Add(picboxAry[i]);
            }
        }

        private void splitImage(String path, String file, Image img, Int32 sHeight, Int32 sWidth)
        {
            Bitmap Mybmp = new Bitmap(sWidth, sHeight);
            Graphics gr = Graphics.FromImage(Mybmp);
            //重新繪製圖像並存檔

            for (Int32 y = 0; y < img.Height; y += sHeight)
            {
                for (Int32 x = 0; x < img.Width; x += sWidth)
                {
                    gr.Clear(Color.Black);
                    gr.DrawImage(img, new Rectangle(0, 0, Mybmp.Width, Mybmp.Height), x, y, sWidth, sHeight, GraphicsUnit.Pixel);
                    gr.Save();
                    Mybmp.Save(Path.Combine(path, file + y.ToString() + ".jpg"));
                }
            }
        }
    }
}