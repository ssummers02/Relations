using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Relations_project
{
    public partial class Form1 : Form
    {
        private int countGraf = 10;
        private int check;
        private List<int> xList = new List<int>();
        private List<int> yList = new List<int>();

        List<List<int>> list = new List<List<int>>();
        List<TextBox> xListTextBoxes = new List<TextBox>();
        List<TextBox> yListTextBoxes = new List<TextBox>();
        int countX = 1;
        int countY = 1;

        public Form1()
        {
            InitializeComponent();
            listXComboBox.SelectedIndex = 0;
            listYComboBox.SelectedIndex = 0;
            operComboBox.SelectedIndex = 7;
        }


        private void PaintLine(Graphics graphics, Pen pen, PointF[] points)
        {
            for (int i = 0; i < countGraf; i++)
            {
                points[i].X += 15;
                points[i].Y += 15;
            }

            for (int i = 0; i < countGraf; i++)
            {
                for (int j = 0; j < countGraf; j++)
                {
                    if (list[i][j] > 0)
                        graphics.DrawLine(pen, points[i], points[j]);
                }
            }
        }

        private void PictureBoxPaint()
        {
            grafPictureBox.Refresh();
            double alfa = 2 * Math.PI / countGraf;
            PointF[] points = new PointF[countGraf];
            Graphics graphics = grafPictureBox.CreateGraphics();
            Brush brush = new SolidBrush(Color.Blue);
            Pen pen = new Pen(Color.Blue, 3F);

            for (int i = 0; i < countGraf; i++)
            {
                int x = Convert.ToInt32(200 + 150 * Math.Cos(alfa * i));
                int y = Convert.ToInt32(200 + 150 * Math.Sin(alfa * i));
                if (countGraf == 1)
                    x = y = 200;
                points[i] = new PointF(x, y);
                graphics.DrawEllipse(pen, points[i].X, points[i].Y, 30, 30);
                graphics.FillEllipse(brush, new Rectangle((int) points[i].X, (int) points[i].Y, 30, 30));
            }


            PaintLine(graphics, pen, points);
            for (int i = 0; i < countGraf; i++)
                PaintText(points, graphics, i);
        }


        private void creatGrafButton_Click(object sender, EventArgs e)
        {
            if (grafPictureBox.Image != null)
            {
                grafPictureBox.Image.Dispose();
                grafPictureBox.Image = null;
            }

            grafPictureBox.Refresh();
        }

        private void PaintText(PointF[] points, Graphics graphics, int i)
        {
            var f = new Font(Font.FontFamily, 15);
            string text = Convert.ToString(i + 1);
            var size = graphics.MeasureString(text, f);
            var pt = new PointF(points[i].X + 7 - 15, points[i].Y + 3 - 15);
            var rect = new RectangleF(pt, size);
            graphics.DrawString(text, f, Brushes.FloralWhite, rect);
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
                e.Handled = true;
        }

        private void ListYComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 30 + 35 * 2;
            int y = 20 + 35;

            for (int i = 0; i < yListTextBoxes.Count; i++)
            {
                Controls.Remove(yListTextBoxes[i]);
            }

            yListTextBoxes.Clear();
            countY = Convert.ToInt32(listYComboBox.SelectedItem.ToString());

            for (int i = 0; i < countY; i++)
            {
                TextBox tempTextBox = new TextBox()
                {
                    Name = Convert.ToString(i),
                    Location = new Point(x + 30 * i, y),
                    Size = new System.Drawing.Size(25, 20),
                    TextAlign = HorizontalAlignment.Center,
                    Text = "0"
                };
                tempTextBox.KeyPress += KeyPress;

                yListTextBoxes.Add(tempTextBox);
                Controls.Add(yListTextBoxes[i]);
            }
        }

        private void ListXComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 30 + 35 * 2;
            int y = 20;

            for (int i = 0; i < xListTextBoxes.Count; i++)
            {
                Controls.Remove(xListTextBoxes[i]);
            }

            xListTextBoxes.Clear();

            countX = Convert.ToInt32(listXComboBox.SelectedItem.ToString());

            for (int i = 0; i < countX; i++)
            {
                TextBox tempTextBox = new TextBox()
                {
                    Name = Convert.ToString(i),
                    Location = new Point(x + 30 * i, y),
                    Size = new System.Drawing.Size(25, 20),
                    TextAlign = HorizontalAlignment.Center,
                    Text = "0",
                };
                tempTextBox.KeyPress += KeyPress;
                xListTextBoxes.Add(tempTextBox);
                Controls.Add(xListTextBoxes[i]);
            }
        }

        private void OperComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (operComboBox.SelectedIndex > 4)
                Controls.Add(operTextBox);
            else
                Controls.Remove(operTextBox);
        }
    }
}