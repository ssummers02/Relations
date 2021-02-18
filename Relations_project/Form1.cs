﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Relations_project
{
    public partial class Form1 : Form
    {
        private List<int> xList = new List<int>();
        private List<int> yList = new List<int>();
        private List<List<int>> list = new List<List<int>>();
        private List<TextBox> xListTextBoxes = new List<TextBox>();
        private List<TextBox> yListTextBoxes = new List<TextBox>();
        private List<List<TextBox>> matrixList = new List<List<TextBox>>();
        private int countX = 1;
        private int countY = 1;

        public Form1()
        {
            InitializeComponent();
            listXComboBox.SelectedIndex = 0;
            listYComboBox.SelectedIndex = 0;
            operComboBox.SelectedIndex = 7;

            for (var i = 0; i < 10; i++)
            {
                list.Add(new List<int>());

                for (var j = 0; j < 10; j++)
                {
                    list[i].Add(0);
                }
            }
        }


        private void PaintLine(Graphics graphics, PointF[] xpoints, PointF[] ypoints)
        {
            for (int i = 0; i < countX; i++)
            {
                xpoints[i].X += 15;
                xpoints[i].Y += 15;
            }

            for (int i = 0; i < countY; i++)
            {
                ypoints[i].X += 15;
                ypoints[i].Y += 15;
            }

            List<Pen> pens = new List<Pen>()
            {
                new Pen(Color.White, 5.0F),
                new Pen(Color.Indigo, 5.0F),
                new Pen(Color.YellowGreen, 5.0F),
                new Pen(Color.DarkGoldenrod, 5.0F),
                new Pen(Color.BlueViolet, 5.0F),
                new Pen(Color.RosyBrown, 5.0F),
                new Pen(Color.Gray, 5.0F),
                new Pen(Color.Peru, 5.0F),
                new Pen(Color.Olive, 5.0F),
                new Pen(Color.PaleGreen, 5.0F)
            };

            for (int i = 0; i < countY; i++)
            {
                for (int j = 0; j < countX; j++)
                {
                    if (list[i][j] == 1)
                    {
                        ypoints[i].X -= 15;
                        pens[j].EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                        graphics.DrawLine(pens[j], xpoints[j], ypoints[i]);
                        ypoints[i].X += 15;
                    }
                }
            }
        }

        private void PictureBoxPaint()
        {
            grafPictureBox.Refresh();
            PointF[] xpoints = new PointF[countX];
            PointF[] ypoints = new PointF[countY];
            Graphics graphics = grafPictureBox.CreateGraphics();
            Brush brush = new SolidBrush(Color.Blue);
            Pen pen = new Pen(Color.Blue, 5.0F);

            for (int i = 0; i < countX; i++)
            {
                int x = 50;
                int y = 20 + 50 * i;
                xpoints[i] = new PointF(x, y);
                graphics.DrawEllipse(pen, xpoints[i].X, xpoints[i].Y, 30, 30);
                graphics.FillEllipse(brush, new Rectangle((int) xpoints[i].X, (int) xpoints[i].Y, 30, 30));
            }

            for (int i = 0; i < countY; i++)
            {
                int x = 300;
                int y = 20 + 50 * i;
                ypoints[i] = new PointF(x, y);
                graphics.DrawEllipse(pen, ypoints[i].X, ypoints[i].Y, 30, 30);
                graphics.FillEllipse(brush, new Rectangle((int) ypoints[i].X, (int) ypoints[i].Y, 30, 30));
            }

            PaintLine(graphics, xpoints, ypoints);
            for (var i = 0; i < countX; i++)
                PaintText(xpoints, graphics, i, xList);
            for (var i = 0; i < countY; i++)
                PaintText(ypoints, graphics, i, yList);
        }


        private void DisposeImages()
        {
            if (grafPictureBox.Image != null)
            {
                grafPictureBox.Image.Dispose();
                grafPictureBox.Image = null;
            }

            grafPictureBox.Refresh();
        }

        private void PaintText(PointF[] points, Graphics graphics, int i, List<int> list)
        {
            var f = new Font(Font.FontFamily, 15);
            string text = Convert.ToString(list[i]);
            var size = graphics.MeasureString(text, f);
            var pt = new PointF(points[i].X + 7 - 15, points[i].Y + 3 - 15);
            var rect = new RectangleF(pt, size);
            graphics.DrawString(text, f, Brushes.FloralWhite, rect);
        }

        private new void KeyPress(object sender, KeyPressEventArgs e)
        {
            var number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 45)
                e.Handled = true;
        }

        private void ListYComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            DisposeImages();

            int x = 30 + 35 * 2;
            int y = 20 + 25;

            for (int i = 0; i < yListTextBoxes.Count; i++)
            {
                Controls.Remove(yListTextBoxes[i]);
            }

            DeleteControls();

            yListTextBoxes.Clear();

            countY = Convert.ToInt32(listYComboBox.SelectedItem.ToString());

            for (int i = 0; i < countY; i++)
            {
                TextBox tempTextBox = new TextBox()
                {
                    Name = Convert.ToString(i),
                    Location = new Point(x, y + 25 * i),
                    Size = new Size(25, 20),
                    TextAlign = HorizontalAlignment.Center,
                    Text = @"0"
                };
                tempTextBox.KeyPress += KeyPress;

                yListTextBoxes.Add(tempTextBox);
                Controls.Add(yListTextBoxes[i]);
            }
        }

        private void ListXComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            DisposeImages();

            var x = 25 + 35 * 3;
            var y = 20;

            foreach (var t in xListTextBoxes)
                Controls.Remove(t);

            DeleteControls();

            xListTextBoxes.Clear();
            countX = Convert.ToInt32(listXComboBox.SelectedItem.ToString());

            for (var i = 0; i < countX; i++)
            {
                TextBox tempTextBox = new TextBox()
                {
                    Name = Convert.ToString(i),
                    Location = new Point(x + 30 * i, y),
                    Size = new Size(25, 20),
                    TextAlign = HorizontalAlignment.Center,
                    Text = @"0",
                };
                tempTextBox.KeyPress += KeyPress;
                xListTextBoxes.Add(tempTextBox);
                Controls.Add(xListTextBoxes[i]);
            }
        }

        private void OperComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            DisposeImages();

            DeleteControls();
            if (operComboBox.SelectedIndex <= 4)
                Controls.Add(operTextBox);
            else
                Controls.Remove(operTextBox);
        }

        private void DeleteControls()
        {
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    string a = "i" + Convert.ToString(i) + "j" + Convert.ToString(j);
                    Controls.RemoveByKey(a);
                }

                matrixList.Clear();
            }
        }

        private void CreateMatrixTextBoxes()
        {
            for (var i = 0; i < countY; i++)
            {
                matrixList.Add(new List<TextBox>());

                for (var j = 0; j < countX; j++)
                {
                    matrixList.Add(new List<TextBox>());
                    TextBox tempTextBox = new TextBox()
                    {
                        Name = "i" + Convert.ToString(i) + "j" + Convert.ToString(j),
                        Location = new Point(60 + 35 * 2 + 30 * j, 45 + 25 * i),
                        Size = new Size(25, 20),
                        Text = list[i][j] == 1 ? "T" : "F",
                        TextAlign = HorizontalAlignment.Center
                    };
                    tempTextBox.KeyPress += KeyPress;

                    matrixList[i].Add(tempTextBox);
                    Controls.Add(matrixList[i][j]);
                }
            }
        }

        private bool ListChecker()
        {
            xList.Clear();
            yList.Clear();

            for (int j = 0; j < countX; j++)
            {
                int number;
                bool success = Int32.TryParse(xListTextBoxes[j].Text, out number);

                if (success)
                    xList.Add(number);
                else
                {
                    MessageBox.Show($@"Неверные значения!");
                    return false;
                }
            }

            for (int j = 0; j < countY; j++)
            {
                int number;
                bool success = Int32.TryParse(yListTextBoxes[j].Text, out number);

                if (success)
                    yList.Add(number);
                else
                {
                    MessageBox.Show($@"Неверные значения!");
                    return false;
                }
            }

            return true;
        }

        private void CreateButtonOnClick(object sender, EventArgs e)
        {
            DeleteControls();
            DisposeImages();

            if (ListChecker() && FillingList())
            {
                CreateMatrixTextBoxes();
                PictureBoxPaint();
            }
        }

        private bool FillingList()
        {
            int index = operComboBox.SelectedIndex;

            for (var j = 0; j < countY; j++)
            {
                for (var i = 0; i < countX; i++)
                {
                    list[j][i] = 0;

                    switch (index)
                    {
                        case 0:
                            if (xList[i] + yList[j] == Convert.ToInt32(operTextBox.Text))
                                list[j][i] = 1;
                            break;
                        case 1:
                            if (xList[i] - yList[j] == Convert.ToInt32(operTextBox.Text))
                                list[j][i] = 1;
                            break;
                        case 2:
                            if (xList[i] * yList[j] == Convert.ToInt32(operTextBox.Text))
                                list[j][i] = 1;
                            break;
                        case 3:
                            if (yList[j] == 0)
                            {
                                MessageBox.Show(@"НА НОЛЬ НЕ ДЕЛИТЬ!");
                                return false;
                            }

                            if (xList[i] / yList[j] == Convert.ToInt32(operTextBox.Text))
                                list[j][i] = 1;
                            break;
                        case 4:
                            if (yList[j] == 0)
                            {
                                MessageBox.Show(@"НА НОЛЬ НЕ ДЕЛИТЬ!");
                                return false;
                            }

                            if (xList[i] % yList[j] == Convert.ToInt32(operTextBox.Text))
                                list[j][i] = 1;
                            break;
                        case 5:
                            if (xList[i] < yList[j])
                                list[j][i] = 1;
                            break;
                        case 6:
                            if (xList[i] <= yList[j])
                                list[j][i] = 1;
                            break;
                        case 7:
                            if (xList[i] == yList[j])
                                list[j][i] = 1;
                            break;
                        case 8:
                            if (xList[i] != yList[j])
                                list[j][i] = 1;
                            break;
                        case 9:
                            if (xList[i] > yList[j])
                                list[j][i] = 1;
                            break;
                        case 10:
                            if (xList[i] >= yList[j])
                                list[j][i] = 1;
                            break;
                    }
                }
            }

            return true;
        }
    }
}