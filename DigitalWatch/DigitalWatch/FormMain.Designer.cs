﻿namespace DigitalWatch
{
    partial class FormMain
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
            this.sevenSegmentArray = new DigitalWatch.Controls.SevenSegmentArray();
            this.btnMode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sevenSegmentArray
            // 
            this.sevenSegmentArray.ArrayCount = 4;
            this.sevenSegmentArray.ColorBackground = System.Drawing.SystemColors.Control;
            this.sevenSegmentArray.ColorDark = System.Drawing.Color.DimGray;
            this.sevenSegmentArray.ColorLight = System.Drawing.Color.Red;
            this.sevenSegmentArray.DecimalShow = true;
            this.sevenSegmentArray.ElementPadding = new System.Windows.Forms.Padding(4);
            this.sevenSegmentArray.ElementWidth = 10;
            this.sevenSegmentArray.ItalicFactor = 0F;
            this.sevenSegmentArray.Location = new System.Drawing.Point(12, 2);
            this.sevenSegmentArray.Name = "sevenSegmentArray";
            this.sevenSegmentArray.Size = new System.Drawing.Size(409, 131);
            this.sevenSegmentArray.TabIndex = 0;
            this.sevenSegmentArray.TabStop = false;
            this.sevenSegmentArray.Value = null;
            // 
            // btnMode
            // 
            this.btnMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode.Location = new System.Drawing.Point(427, 2);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(75, 23);
            this.btnMode.TabIndex = 1;
            this.btnMode.Text = "Mode";
            this.btnMode.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 237);
            this.Controls.Add(this.btnMode);
            this.Controls.Add(this.sevenSegmentArray);
            this.Name = "FormMain";
            this.Text = "DigitalWatch";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SevenSegmentArray sevenSegmentArray;
        private System.Windows.Forms.Button btnMode;
    }
}

