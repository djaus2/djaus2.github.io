namespace FilterWF
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
            this.button1 = new System.Windows.Forms.Button();
            this.tbSrcFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSrcFolder = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbStartFilterCSVList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSkipListLines = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbEndFilterCSVList2 = new System.Windows.Forms.TextBox();
            this.tbNoLinesToSkipAtStart = new System.Windows.Forms.TextBox();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTopic = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSubTopic = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CategoriesComboBox = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 138);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(355, 100);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get new File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbSrcFilename
            // 
            this.tbSrcFilename.Location = new System.Drawing.Point(717, 48);
            this.tbSrcFilename.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbSrcFilename.Name = "tbSrcFilename";
            this.tbSrcFilename.Size = new System.Drawing.Size(751, 38);
            this.tbSrcFilename.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(509, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filename:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(544, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Folder:";
            // 
            // tbSrcFolder
            // 
            this.tbSrcFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSrcFolder.Location = new System.Drawing.Point(717, 122);
            this.tbSrcFolder.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbSrcFolder.Name = "tbSrcFolder";
            this.tbSrcFolder.Size = new System.Drawing.Size(1377, 38);
            this.tbSrcFolder.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(79, 408);
            this.button2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(357, 98);
            this.button2.TabIndex = 5;
            this.button2.Text = "Apply Filters";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbStartFilterCSVList
            // 
            this.tbStartFilterCSVList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStartFilterCSVList.Location = new System.Drawing.Point(717, 264);
            this.tbStartFilterCSVList.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbStartFilterCSVList.Name = "tbStartFilterCSVList";
            this.tbStartFilterCSVList.Size = new System.Drawing.Size(1377, 38);
            this.tbStartFilterCSVList.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 270);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Start Filter (Start after this):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 339);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(349, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Skip Filter (Skip ines with):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 608);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(297, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "End Fiter (End at this):";
            // 
            // tbSkipListLines
            // 
            this.tbSkipListLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSkipListLines.Location = new System.Drawing.Point(717, 331);
            this.tbSkipListLines.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbSkipListLines.Multiline = true;
            this.tbSkipListLines.Name = "tbSkipListLines";
            this.tbSkipListLines.Size = new System.Drawing.Size(1377, 223);
            this.tbSkipListLines.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 701);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "No. lines to include at start:";
            // 
            // tbEndFilterCSVList2
            // 
            this.tbEndFilterCSVList2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEndFilterCSVList2.Location = new System.Drawing.Point(720, 608);
            this.tbEndFilterCSVList2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbEndFilterCSVList2.Name = "tbEndFilterCSVList2";
            this.tbEndFilterCSVList2.Size = new System.Drawing.Size(1375, 38);
            this.tbEndFilterCSVList2.TabIndex = 11;
            // 
            // tbNoLinesToSkipAtStart
            // 
            this.tbNoLinesToSkipAtStart.Location = new System.Drawing.Point(720, 701);
            this.tbNoLinesToSkipAtStart.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbNoLinesToSkipAtStart.Name = "tbNoLinesToSkipAtStart";
            this.tbNoLinesToSkipAtStart.Size = new System.Drawing.Size(207, 38);
            this.tbNoLinesToSkipAtStart.TabIndex = 13;
            this.tbNoLinesToSkipAtStart.Text = "0";
            // 
            // tbOutput
            // 
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.Location = new System.Drawing.Point(32, 1004);
            this.tbOutput.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutput.Size = new System.Drawing.Size(2063, 261);
            this.tbOutput.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(81, 797);
            this.button3.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(355, 100);
            this.button3.TabIndex = 15;
            this.button3.Text = "Save As";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(563, 797);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 32);
            this.label7.TabIndex = 19;
            this.label7.Text = "Topic";
            // 
            // tbTopic
            // 
            this.tbTopic.Location = new System.Drawing.Point(717, 797);
            this.tbTopic.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbTopic.Name = "tbTopic";
            this.tbTopic.Size = new System.Drawing.Size(1377, 38);
            this.tbTopic.TabIndex = 18;
            this.tbTopic.Text = "Topic";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(506, 882);
            this.label8.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 32);
            this.label8.TabIndex = 21;
            this.label8.Text = "SubTopic";
            // 
            // tbSubTopic
            // 
            this.tbSubTopic.Location = new System.Drawing.Point(717, 876);
            this.tbSubTopic.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbSubTopic.Name = "tbSubTopic";
            this.tbSubTopic.Size = new System.Drawing.Size(751, 38);
            this.tbSubTopic.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(509, 959);
            this.label9.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 32);
            this.label9.TabIndex = 23;
            this.label9.Text = "Category";
            // 
            // comboBox1
            // 
            this.CategoriesComboBox.FormattingEnabled = true;
            this.CategoriesComboBox.Location = new System.Drawing.Point(724, 951);
            this.CategoriesComboBox.Name = "comboBox1";
            this.CategoriesComboBox.Size = new System.Drawing.Size(743, 39);
            this.CategoriesComboBox.TabIndex = 24;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(81, 20);
            this.button6.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(355, 100);
            this.button6.TabIndex = 25;
            this.button6.Text = "Load this File:";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2133, 1300);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.CategoriesComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbSubTopic);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbTopic);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.tbNoLinesToSkipAtStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbEndFilterCSVList2);
            this.Controls.Add(this.tbSkipListLines);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbStartFilterCSVList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbSrcFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSrcFilename);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Filter Markdown File";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbSrcFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSrcFolder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbStartFilterCSVList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSkipListLines;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbEndFilterCSVList2;
        private System.Windows.Forms.TextBox tbNoLinesToSkipAtStart;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTopic;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSubTopic;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CategoriesComboBox;
        private System.Windows.Forms.Button button6;
    }
}

