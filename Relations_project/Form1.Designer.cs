﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Relations_project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grafPictureBox = new System.Windows.Forms.PictureBox();
            this.listXComboBox = new System.Windows.Forms.ComboBox();
            this.listYComboBox = new System.Windows.Forms.ComboBox();
            this.operComboBox = new System.Windows.Forms.ComboBox();
            this.operTextBox = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.grafPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // grafPictureBox
            // 
            this.grafPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.grafPictureBox.Location = new System.Drawing.Point(430, 0);
            this.grafPictureBox.Name = "grafPictureBox";
            this.grafPictureBox.Size = new System.Drawing.Size(380, 560);
            this.grafPictureBox.TabIndex = 1;
            this.grafPictureBox.TabStop = false;
            // 
            // operTextBox
            // 
            this.operTextBox.Name = "Oper";
            this.operTextBox.Location = new Point(30 + 20  , 95);
            this.operTextBox.Size = new System.Drawing.Size(25, 20);
            this.operTextBox.TextAlign = HorizontalAlignment.Center;
            this.operTextBox.Text = "0";
            this.operTextBox.KeyPress += KeyPress;
            // 
            // listXComboBox
            // 
            this.listXComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listXComboBox.FormattingEnabled = true;
            this.listXComboBox.Items.AddRange(new object[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            this.listXComboBox.Location = new System.Drawing.Point(50, 20);
            this.listXComboBox.Name = "listXComboBox";
            this.listXComboBox.Size = new System.Drawing.Size(40, 20);
            this.listXComboBox.TabIndex = 6;
            this.listXComboBox.SelectedIndexChanged += ListXComboBoxOnSelectedIndexChanged;
            // 
            // listYComboBox
            // 
            this.listYComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listYComboBox.FormattingEnabled = true;
            this.listYComboBox.Items.AddRange(new object[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            this.listYComboBox.Location = new System.Drawing.Point(50, 20+25);
            this.listYComboBox.Name = "listYComboBox";
            this.listYComboBox.Size = new System.Drawing.Size(40, 20);
            this.listYComboBox.TabIndex = 6;
            this.listYComboBox.SelectedIndexChanged += ListYComboBoxOnSelectedIndexChanged;
            // 
            // operComboBox
            // 
            this.operComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operComboBox.FormattingEnabled = true;
            this.operComboBox.Items.AddRange(new object[] {"X+Y", "X-Y", "X*Y", "X/Y", "X%Y", "X<Y", "X<=Y", "X==Y", "X!=Y", "X>Y", "X>=Y"});
            this.operComboBox.Location = new System.Drawing.Point(20, 70);
            this.operComboBox.Name = "operComboBox";
            this.operComboBox.Size = new System.Drawing.Size(60, 20);
            this.operComboBox.TabIndex = 6;
            this.operComboBox.SelectedIndexChanged += OperComboBoxOnSelectedIndexChanged;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(20, 120);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(70, 20);
            this.createButton.TabIndex = 10;
            this.createButton.Text = "Решить";
            this.createButton.Click += CreateButtonOnClick;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(20, 140);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(70, 20);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "Очистить";
            this.clearButton.Click += ClearButtonOnClick;
            // 
            // xLabel
            // 
            this.xLabel.Location = new System.Drawing.Point(20, 20);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(25, 20);
            this.xLabel.TabIndex = 11;
            this.xLabel.Text = "X";
            this.xLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yLabel
            // 
            this.yLabel.Location = new System.Drawing.Point(20, 20+25);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(25, 20);
            this.yLabel.TabIndex = 12;
            this.yLabel.Text = "Y";
            this.yLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Relations_project.Properties.Resources.color_2174049_1280;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.listXComboBox);
            this.Controls.Add(this.listYComboBox);
            this.Controls.Add(this.operComboBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.grafPictureBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Графы";
            ((System.ComponentModel.ISupportInitialize) (this.grafPictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.ComboBox listYComboBox;
        private System.Windows.Forms.ComboBox listXComboBox;
        private System.Windows.Forms.ComboBox operComboBox;
        private System.Windows.Forms.TextBox operTextBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button clearButton;

        private System.Windows.Forms.Label PairsLabel;


        private System.Windows.Forms.PictureBox grafPictureBox;
        #endregion
    }
}