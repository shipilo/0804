using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0804
{
    public partial class FormGame : Form
    {
        static List<string> images = new List<string>()
        {  
            @"folder\1.png",
            @"folder\1-копия.png",
            @"folder\2.png",
            @"folder\2-копия.png",  
            @"folder\3.png",
                @"folder\3-копия.png",
                @"folder\4.png",
                @"folder\4-копия.png",
                @"folder\5.png",
                @"folder\5-копия.png",
                @"folder\6.png",
                @"folder\6-копия.png",
                @"folder\7.png",
                @"folder\7-копия.png",
                @"folder\8.png",
                @"folder\8-копия.png",
                @"folder\9.png",
                @"folder\9-копия.png",
                @"folder\10.png",
                @"folder\10-копия.png",
                @"folder\11.png",
                @"folder\11-копия.png",
                @"folder\12.png",
                @"folder\12-копия.png",
                @"folder\13.png",
                @"folder\13копия.png",
                @"folder\14.png",
                @"folder\14-копия.png",
                @"folder\15.png",
                @"folder\15-копия.png",
                @"folder\16.png",
                @"folder\16-копия.png",
                @"folder\17.png",
                @"folder\17-копия.png",
                @"folder\18.png",
                @"folder\18-копия.png" };
        Random rnd = new Random();

        public FormGame()
        {
            InitializeComponent();
            for (int i = 0; i < images.Count; i++)
            {
                int odd = rnd.Next(images.Count);
                Swap(images, i, odd, images[i], images[odd]);
            }
        }

        static void Swap(List<string> array, int i1, int i2, string value1, string value2)
        {
            array[i1] = value2;
            array[i2] = value1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
