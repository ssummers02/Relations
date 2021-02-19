using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Relations_project
{
    public partial class Form1 : Form
    {
        private readonly List<int> xList = new List<int>();
        private readonly List<int> yList = new List<int>();
        private readonly List<List<int>> list = new List<List<int>>();
        private readonly List<TextBox> xListTextBoxes = new List<TextBox>();
        private readonly List<TextBox> yListTextBoxes = new List<TextBox>();
        private readonly List<List<TextBox>> matrixList = new List<List<TextBox>>();
        private int countX = 1;
        private int countY = 1;
        Brush brush = new SolidBrush(Color.Blue);
        Pen pen = new Pen(Color.Blue, 5.0F);
        private List<string> pairslist = new List<string>();

        private string createString()
        {
            var s = "";
            var c = 1;

            for (int i = 0; i < pairslist.Count; i++)
            {
                if (i + 1 != pairslist.Count)
                    s += pairslist[i] + ", ";
                else
                    s += pairslist[i];

                if (c % 8 == 0 && i != 0)
                    s += "\n";
                c++;
            }

            if (c > 80)
                this.ClientSize = new System.Drawing.Size(800, 600);

            return s;
        }

        private void PrintPairsLabel()
        {
            PairsLabel = new Label();
            PairsLabel.AutoSize = true;
            PairsLabel.BackColor = Color.Transparent;
            PairsLabel.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            PairsLabel.ForeColor = Color.Gray;
            PairsLabel.Location = new Point(20, 300);
            PairsLabel.Name = "PairsLabel";
            PairsLabel.Size = new Size(200, 20);
            PairsLabel.Text = createString();
            this.Controls.Add(PairsLabel);
        }

        readonly List<Pen> pens = new List<Pen>()
        {
            new Pen(Color.White, 5.0F),
            new Pen(Color.Indigo, 5.0F),
            new Pen(Color.PaleGreen, 5.0F),
            new Pen(Color.YellowGreen, 5.0F),
            new Pen(Color.DarkGoldenrod, 5.0F),
            new Pen(Color.BlueViolet, 5.0F),
            new Pen(Color.RosyBrown, 5.0F),
            new Pen(Color.Gray, 5.0F),
            new Pen(Color.Peru, 5.0F),
            new Pen(Color.Olive, 5.0F),
        };

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

        private void IncreaseValue(PointF[] points, int count)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X += count;
                points[i].Y += count;
            }
        }

        private void PaintLine(Graphics graphics, PointF[] xpoints, PointF[] ypoints)
        {
            IncreaseValue(xpoints, 15);
            IncreaseValue(ypoints, 15);

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

            IncreaseValue(xpoints, -15);
            IncreaseValue(ypoints, -15);
        }

        private void CreatePointF(int x, int count, PointF[] points)
        {
            for (int i = 0; i < count; i++)
            {
                int y = 20 + 50 * i;
                points[i] = new PointF(x, y);
            }
        }

        private void DrawEllipseInPictureBox(int x, int count, Graphics graphics, PointF[] points)
        {
            for (int i = 0; i < count; i++)
            {
                graphics.DrawEllipse(pen, points[i].X, points[i].Y, 30, 30);
                graphics.FillEllipse(brush, new Rectangle((int) points[i].X, (int) points[i].Y, 30, 30));
            }

            IncreaseValue(points, 15);
        }

        private void PictureBoxPaint()
        {
            grafPictureBox.Refresh();
            var xpoints = new PointF[countX];
            var ypoints = new PointF[countY];
            var graphics = grafPictureBox.CreateGraphics();
            CreatePointF(50, countX, xpoints);
            CreatePointF(300, countY, ypoints);
            PaintLine(graphics, xpoints, ypoints);
            DrawEllipseInPictureBox(50, countX, graphics, xpoints);
            DrawEllipseInPictureBox(300, countY, graphics, ypoints);
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
            foreach (var t in yListTextBoxes)
                Controls.Remove(t);
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
            Controls.Remove(PairsLabel);
            pairslist.Clear();

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
                bool success = Int32.TryParse(yListTextBoxes[j].Text, out var number);

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
                PrintPairsLabel();
                PictureBoxPaint();
            }
        }

        private bool FillingList()
        {
            var index = operComboBox.SelectedIndex;

            for (var j = 0; j < countY; j++)
            {
                for (var i = 0; i < countX; i++)
                {
                    list[j][i] = 0;

                    switch (index)
                    {
                        case 0:
                            if (xList[i] + yList[j] == Convert.ToInt32(operTextBox.Text))
                            {
                                list[j][i] = 1;
                                pairslist.Add($"({xList[i]};{yList[j]})");
                            }

                            break;
                        case 1:
                            if (xList[i] - yList[j] == Convert.ToInt32(operTextBox.Text))
                            {
                                list[j][i] = 1;
                                pairslist.Add($"({xList[i]};{yList[j]})");
                            }

                            break;
                        case 2:
                            if (xList[i] * yList[j] == Convert.ToInt32(operTextBox.Text))
                            {
                                list[j][i] = 1;
                                pairslist.Add($"({xList[i]};{yList[j]})");
                            }

                            break;
                        case 3:
                            if (yList[j] == 0)
                            {
                                MessageBox.Show(@"НА НОЛЬ НЕ ДЕЛИТЬ!");
                                return false;
                            }

                            if (xList[i] / yList[j] == Convert.ToInt32(operTextBox.Text))
                            {
                                list[j][i] = 1;
                                pairslist.Add($"({xList[i]};{yList[j]})");
                            }

                            break;
                        case 4:
                            if (yList[j] == 0)
                            {
                                MessageBox.Show(@"НА НОЛЬ НЕ ДЕЛИТЬ!");
                                return false;
                            }

                            if (xList[i] % yList[j] == Convert.ToInt32(operTextBox.Text))
                            {
                                list[j][i] = 1;
                                pairslist.Add($"({xList[i]};{yList[j]})");
                            }

                            break;
                        case 5:
                            if (xList[i] < yList[j])
                            {
                                list[j][i] = 1;
                                pairslist.Add($"({xList[i]};{yList[j]})");
                            }

                            break;
                        case 6:
                            if (xList[i] <= yList[j])
                            {
                                list[j][i] = 1;
                                pairslist.Add($"({xList[i]};{yList[j]})");
                            }

                            break;
                        case 7:
                            if (xList[i] == yList[j])
                            {
                                list[j][i] = 1;
                                pairslist.Add($"({xList[i]};{yList[j]})");
                            }

                            break;
                        case 8:
                            if (xList[i] != yList[j])
                            {
                                list[j][i] = 1;
                                pairslist.Add($"({xList[i]};{yList[j]})");
                            }

                            break;
                        case 9:
                            if (xList[i] > yList[j])
                            {
                                list[j][i] = 1;
                                pairslist.Add($"({xList[i]};{yList[j]})");
                            }

                            break;
                        case 10:
                            if (xList[i] >= yList[j])
                            {
                                list[j][i] = 1;
                                pairslist.Add($"({xList[i]};{yList[j]})");
                            }

                            break;
                    }
                }
            }

            return true;
        }

        private void ClearButtonOnClick(object sender, EventArgs e)
        {
            DeleteControls();
            DisposeImages();
        }
    }
}