namespace DigitalWatch
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
            this.components = new System.ComponentModel.Container();
            this.btnMode = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnLight = new System.Windows.Forms.Button();
            this.ttMainForm = new System.Windows.Forms.ToolTip(this.components);
            this.sevenSegmentArray = new DigitalWatch.Controls.SevenSegmentArray();
            this.SuspendLayout();
            // 
            // btnMode
            // 
            this.btnMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode.Location = new System.Drawing.Point(433, 32);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(75, 23);
            this.btnMode.TabIndex = 1;
            this.btnMode.Text = "Mode";
            this.ttMainForm.SetToolTip(this.btnMode, "Changes the Mode of the Watch");
            this.btnMode.UseVisualStyleBackColor = true;
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click);
            // 
            // btnSet
            // 
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Location = new System.Drawing.Point(433, 61);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 2;
            this.btnSet.Text = "Set";
            this.ttMainForm.SetToolTip(this.btnSet, "Normal: Enables setting the time \r\nStopwatch: Starts/Stops the counter \r\nResets o" +
        "n when pressed down prolonged (>1.5s)");
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            this.btnSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSet_MouseDown);
            this.btnSet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSet_MouseUp);
            // 
            // btnLight
            // 
            this.btnLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLight.Location = new System.Drawing.Point(433, 90);
            this.btnLight.Name = "btnLight";
            this.btnLight.Size = new System.Drawing.Size(75, 23);
            this.btnLight.TabIndex = 3;
            this.btnLight.Text = "Light";
            this.ttMainForm.SetToolTip(this.btnLight, "Turns on the light for 5s");
            this.btnLight.UseVisualStyleBackColor = true;
            this.btnLight.Click += new System.EventHandler(this.btnLight_Click);
            // 
            // sevenSegmentArray
            // 
            this.sevenSegmentArray.ArrayCount = 4;
            this.sevenSegmentArray.ColorBackground = System.Drawing.SystemColors.Control;
            this.sevenSegmentArray.ColorDark = System.Drawing.Color.Gainsboro;
            this.sevenSegmentArray.ColorLight = System.Drawing.Color.Black;
            this.sevenSegmentArray.DecimalShow = true;
            this.sevenSegmentArray.ElementPadding = new System.Windows.Forms.Padding(16);
            this.sevenSegmentArray.ElementWidth = 10;
            this.sevenSegmentArray.ItalicFactor = 0F;
            this.sevenSegmentArray.Location = new System.Drawing.Point(12, 2);
            this.sevenSegmentArray.Name = "sevenSegmentArray";
            this.sevenSegmentArray.Size = new System.Drawing.Size(409, 138);
            this.sevenSegmentArray.TabIndex = 0;
            this.sevenSegmentArray.TabStop = false;
            this.sevenSegmentArray.Value = "___";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 137);
            this.Controls.Add(this.btnLight);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnMode);
            this.Controls.Add(this.sevenSegmentArray);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(540, 180);
            this.Name = "FormMain";
            this.Text = "DigitalWatch";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SevenSegmentArray sevenSegmentArray;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnLight;
        private System.Windows.Forms.ToolTip ttMainForm;
    }
}

