using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandelbrotSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool IsConverge(Complex c)
        {
            // 初項の定義
            Complex z = new Complex(0, 0);

            // 第31項を計算するまでに3.5より大きくなったら発散
            // 第31項まで break せずに計算できたら収束
            for (int i = 0; i < 100; i++)
            {
                z = z * z + c;

                if (z.Magnitude >= 3.5)
                {
                    return false;
                }
            }

            return true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 枠線を赤で描画
            e.Graphics.DrawRectangle(Pens.Red, 0, 0, 300, 300);
            // x 軸を青で描画
            e.Graphics.DrawLine(Pens.Blue, 200, 0, 200, 300);
            // y 軸を青で描画
            e.Graphics.DrawLine(Pens.Blue, 0, 150, 300, 150);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // プロット用の下地を用意
            Bitmap bm = new Bitmap(301, 301);

            for (int y = 0; y <= 300; y++)
            {
                for (int x = 0; x <= 300; x++)
                {
                    Complex c = new Complex(((x - 200) / 100.0), ((150 - y) / 100.0));

                    // 収束したらその点を黒にする
                    if (IsConverge(c))
                    {
                        bm.SetPixel(x, y, Color.Black);
                    }
                }
            }

            // マンデルブロー集合をまとめて描画
            this.BackgroundImage = bm;
        }

    }
}
