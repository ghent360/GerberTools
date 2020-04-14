﻿namespace FitBitmapToOutlineAndMerge
{
    partial class FitBitmapToOutlineAndMergeForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FitBitmapToOutlineAndMergeForm));
            this.BitmapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BitmapFileTopBox = new System.Windows.Forms.TextBox();
            this.OutlineFileBox = new System.Windows.Forms.TextBox();
            this.SilkFileTopBox = new System.Windows.Forms.TextBox();
            this.GerberFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.FlipBox = new System.Windows.Forms.CheckBox();
            this.InvertBox = new System.Windows.Forms.CheckBox();
            this.DPIbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sizebox = new System.Windows.Forms.Label();
            this.InvertBitmapBottom = new System.Windows.Forms.CheckBox();
            this.FlipInputBottom = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SilkFileBottomBox = new System.Windows.Forms.TextBox();
            this.BitmapFileBottomBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.OutputFolderBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.copperfolderselect = new System.Windows.Forms.Button();
            this.copperfilebox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.soldermaskselectbutton = new System.Windows.Forms.Button();
            this.soldermaskfilebox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bitmap file top";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Outline File";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Original Silk Top";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BitmapFileTopBox
            // 
            this.BitmapFileTopBox.Location = new System.Drawing.Point(179, 242);
            this.BitmapFileTopBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BitmapFileTopBox.Name = "BitmapFileTopBox";
            this.BitmapFileTopBox.Size = new System.Drawing.Size(572, 22);
            this.BitmapFileTopBox.TabIndex = 3;
            // 
            // OutlineFileBox
            // 
            this.OutlineFileBox.Location = new System.Drawing.Point(175, 68);
            this.OutlineFileBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutlineFileBox.Name = "OutlineFileBox";
            this.OutlineFileBox.Size = new System.Drawing.Size(572, 22);
            this.OutlineFileBox.TabIndex = 4;
            this.OutlineFileBox.TextChanged += new System.EventHandler(this.OutlineFileBox_TextChanged);
            // 
            // SilkFileTopBox
            // 
            this.SilkFileTopBox.Location = new System.Drawing.Point(179, 282);
            this.SilkFileTopBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SilkFileTopBox.Name = "SilkFileTopBox";
            this.SilkFileTopBox.Size = new System.Drawing.Size(572, 22);
            this.SilkFileTopBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(767, 242);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BitmapButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(767, 66);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OutlineButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(767, 281);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SilkFileButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(244, 758);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(313, 60);
            this.button4.TabIndex = 9;
            this.button4.Text = "Process";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // FlipBox
            // 
            this.FlipBox.AutoSize = true;
            this.FlipBox.Location = new System.Drawing.Point(25, 324);
            this.FlipBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FlipBox.Name = "FlipBox";
            this.FlipBox.Size = new System.Drawing.Size(133, 21);
            this.FlipBox.TabIndex = 10;
            this.FlipBox.Text = "Flip input bitmap";
            this.FlipBox.UseVisualStyleBackColor = true;
            // 
            // InvertBox
            // 
            this.InvertBox.AutoSize = true;
            this.InvertBox.Location = new System.Drawing.Point(219, 324);
            this.InvertBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InvertBox.Name = "InvertBox";
            this.InvertBox.Size = new System.Drawing.Size(153, 21);
            this.InvertBox.TabIndex = 11;
            this.InvertBox.Text = "Invert bitmap colors";
            this.InvertBox.UseVisualStyleBackColor = true;
            // 
            // DPIbox
            // 
            this.DPIbox.Location = new System.Drawing.Point(179, 101);
            this.DPIbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DPIbox.Name = "DPIbox";
            this.DPIbox.Size = new System.Drawing.Size(100, 22);
            this.DPIbox.TabIndex = 13;
            this.DPIbox.Text = "400";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "DPI";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sizebox
            // 
            this.sizebox.AutoSize = true;
            this.sizebox.Location = new System.Drawing.Point(480, 106);
            this.sizebox.Name = "sizebox";
            this.sizebox.Size = new System.Drawing.Size(52, 17);
            this.sizebox.TabIndex = 14;
            this.sizebox.Text = "0x0mm";
            // 
            // InvertBitmapBottom
            // 
            this.InvertBitmapBottom.AutoSize = true;
            this.InvertBitmapBottom.Location = new System.Drawing.Point(220, 659);
            this.InvertBitmapBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InvertBitmapBottom.Name = "InvertBitmapBottom";
            this.InvertBitmapBottom.Size = new System.Drawing.Size(153, 21);
            this.InvertBitmapBottom.TabIndex = 16;
            this.InvertBitmapBottom.Text = "Invert bitmap colors";
            this.InvertBitmapBottom.UseVisualStyleBackColor = true;
            this.InvertBitmapBottom.CheckedChanged += new System.EventHandler(this.InvertBitmapBottom_CheckedChanged);
            // 
            // FlipInputBottom
            // 
            this.FlipInputBottom.AutoSize = true;
            this.FlipInputBottom.Checked = true;
            this.FlipInputBottom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FlipInputBottom.Location = new System.Drawing.Point(25, 659);
            this.FlipInputBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FlipInputBottom.Name = "FlipInputBottom";
            this.FlipInputBottom.Size = new System.Drawing.Size(133, 21);
            this.FlipInputBottom.TabIndex = 15;
            this.FlipInputBottom.Text = "Flip input bitmap";
            this.FlipInputBottom.UseVisualStyleBackColor = true;
            this.FlipInputBottom.CheckedChanged += new System.EventHandler(this.FlipInputBottom_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(768, 614);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(64, 23);
            this.button5.TabIndex = 22;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(768, 576);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(64, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // SilkFileBottomBox
            // 
            this.SilkFileBottomBox.Location = new System.Drawing.Point(176, 615);
            this.SilkFileBottomBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SilkFileBottomBox.Name = "SilkFileBottomBox";
            this.SilkFileBottomBox.Size = new System.Drawing.Size(572, 22);
            this.SilkFileBottomBox.TabIndex = 20;
            // 
            // BitmapFileBottomBox
            // 
            this.BitmapFileBottomBox.Location = new System.Drawing.Point(176, 576);
            this.BitmapFileBottomBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BitmapFileBottomBox.Name = "BitmapFileBottomBox";
            this.BitmapFileBottomBox.Size = new System.Drawing.Size(572, 22);
            this.BitmapFileBottomBox.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 617);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Original Silk Bottom";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 579);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Bitmap file Bottom";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(388, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Outline size:";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(21, 12);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(313, 38);
            this.button7.TabIndex = 24;
            this.button7.Text = "Fill From Folder";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(767, 150);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(64, 23);
            this.button8.TabIndex = 27;
            this.button8.Text = "...";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // OutputFolderBox
            // 
            this.OutputFolderBox.Location = new System.Drawing.Point(179, 151);
            this.OutputFolderBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutputFolderBox.Name = "OutputFolderBox";
            this.OutputFolderBox.Size = new System.Drawing.Size(572, 22);
            this.OutputFolderBox.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "Output Folder";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // copperfolderselect
            // 
            this.copperfolderselect.Location = new System.Drawing.Point(766, 412);
            this.copperfolderselect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.copperfolderselect.Name = "copperfolderselect";
            this.copperfolderselect.Size = new System.Drawing.Size(64, 23);
            this.copperfolderselect.TabIndex = 30;
            this.copperfolderselect.Text = "...";
            this.copperfolderselect.UseVisualStyleBackColor = true;
            // 
            // copperfilebox
            // 
            this.copperfilebox.Location = new System.Drawing.Point(178, 412);
            this.copperfilebox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.copperfilebox.Name = "copperfilebox";
            this.copperfilebox.Size = new System.Drawing.Size(572, 22);
            this.copperfilebox.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 416);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Copper file top";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soldermaskselectbutton
            // 
            this.soldermaskselectbutton.Location = new System.Drawing.Point(767, 454);
            this.soldermaskselectbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.soldermaskselectbutton.Name = "soldermaskselectbutton";
            this.soldermaskselectbutton.Size = new System.Drawing.Size(64, 23);
            this.soldermaskselectbutton.TabIndex = 33;
            this.soldermaskselectbutton.Text = "...";
            this.soldermaskselectbutton.UseVisualStyleBackColor = true;
            // 
            // soldermaskfilebox
            // 
            this.soldermaskfilebox.Location = new System.Drawing.Point(179, 454);
            this.soldermaskfilebox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.soldermaskfilebox.Name = "soldermaskfilebox";
            this.soldermaskfilebox.Size = new System.Drawing.Size(572, 22);
            this.soldermaskfilebox.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 458);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 17);
            this.label10.TabIndex = 31;
            this.label10.Text = "Soldermask file top";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusbox
            // 
            this.statusbox.Location = new System.Drawing.Point(82, 718);
            this.statusbox.Name = "statusbox";
            this.statusbox.Size = new System.Drawing.Size(665, 22);
            this.statusbox.TabIndex = 34;
            // 
            // FitBitmapToOutlineAndMergeForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(851, 846);
            this.Controls.Add(this.statusbox);
            this.Controls.Add(this.soldermaskselectbutton);
            this.Controls.Add(this.soldermaskfilebox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.copperfolderselect);
            this.Controls.Add(this.copperfilebox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.OutputFolderBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.SilkFileBottomBox);
            this.Controls.Add(this.BitmapFileBottomBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.InvertBitmapBottom);
            this.Controls.Add(this.FlipInputBottom);
            this.Controls.Add(this.sizebox);
            this.Controls.Add(this.DPIbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.InvertBox);
            this.Controls.Add(this.FlipBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SilkFileTopBox);
            this.Controls.Add(this.OutlineFileBox);
            this.Controls.Add(this.BitmapFileTopBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FitBitmapToOutlineAndMergeForm";
            this.Text = "Bitmap Merger";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FitBitmapToOutlineAndMergeForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FitBitmapToOutlineAndMergeForm_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog BitmapFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BitmapFileTopBox;
        private System.Windows.Forms.TextBox OutlineFileBox;
        private System.Windows.Forms.TextBox SilkFileTopBox;
        private System.Windows.Forms.OpenFileDialog GerberFileDialog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox FlipBox;
        private System.Windows.Forms.CheckBox InvertBox;
        private System.Windows.Forms.TextBox DPIbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label sizebox;
        private System.Windows.Forms.CheckBox InvertBitmapBottom;
        private System.Windows.Forms.CheckBox FlipInputBottom;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox SilkFileBottomBox;
        private System.Windows.Forms.TextBox BitmapFileBottomBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox OutputFolderBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button copperfolderselect;
        private System.Windows.Forms.TextBox copperfilebox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button soldermaskselectbutton;
        private System.Windows.Forms.TextBox soldermaskfilebox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox statusbox;
    }
}

