﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc2022
{
    public partial class frmMain : Form
    {
        public struct BtnStruct
        {
            public char Content;
            public bool IsBold;
            public bool IsNumber;
            public bool IsDecimalSeparator;
            public bool IsPlusMinusSign;
            public bool IsOperator;
            public bool IsEqualSign;
            public BtnStruct(char content, bool isBold,
                bool isNumber = false, bool isDecimalSeparator = false,
                bool isPlusMinusSign = false, bool isOperator = false, bool isEqualSign = false)
            {
                this.Content = content;
                this.IsBold = isBold;
                this.IsNumber = isNumber;
                this.IsDecimalSeparator = isDecimalSeparator;
                this.IsPlusMinusSign = isPlusMinusSign;
                this.IsOperator = isOperator;
                this.IsEqualSign = isEqualSign;
            }
            public override string ToString()
            {
                return Content.ToString();
            }
        }

        private BtnStruct[,] buttons =
            {
                { new BtnStruct('%', false), new BtnStruct('Œ', false), new BtnStruct('C', false), new BtnStruct('←', false) },
                { new BtnStruct('⅟', false), new BtnStruct('²', false), new BtnStruct('√', false), new BtnStruct('/', false, false, false, false, true) },
                { new BtnStruct('7', true, true), new BtnStruct('8', true, true), new BtnStruct('9', true, true), new BtnStruct('x', false, false, false, false, true) },
                { new BtnStruct('4', true, true), new BtnStruct('5', true, true), new BtnStruct('6', true, true), new BtnStruct('-', false, false, false, false, true) },
                { new BtnStruct('1', true, true), new BtnStruct('2', true, true), new BtnStruct('3', true, true), new BtnStruct('+', false, false, false, false, true) },
                { new BtnStruct('±', false, false, false, true), new BtnStruct('0', true, true), new BtnStruct(',', false, false, true), new BtnStruct('=', false, false, false, false, false, true) }
            };

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            MakeButtons(buttons.GetLength(0), buttons.GetLength(1));
        }

        private void MakeButtons(int rows, int cols)
        {
            int btnWidth = 80;
            int btnHeight = 60;
            int posX = 0;
            int posY = 110;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button myButton = new Button();
                    myButton.Font = new Font("Segoe UI", 16);
                    myButton.Text = buttons[i, j].ToString();
                    myButton.Width = btnWidth;
                    myButton.Height = btnHeight;
                    myButton.Left = posX;
                    myButton.Top = posY;
                    this.Controls.Add(myButton);
                    posX += btnWidth;
                }
                posY += btnHeight;
                posX = 0;
            }
        }
    }
}
