namespace GermaniBot
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ElapsedTime = new System.Windows.Forms.Label();
            this.GamePLayed_Label = new System.Windows.Forms.Label();
            this.ElapsedTime_Label = new System.Windows.Forms.Label();
            this.GamePlayed = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aZERTYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qWERTYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.showStatsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestWorker = new System.ComponentModel.BackgroundWorker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(136, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Start_Button);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aquamarine;
            this.label1.Location = new System.Drawing.Point(155, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "BELLO FISHO";
            // 
            // button2
            // 
            this.button2.AccessibleDescription = "stopButton";
            this.button2.AccessibleName = "stopButton";
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(306, 525);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 47);
            this.button2.TabIndex = 3;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Stop_Button);
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.Color.White;
            this.richTextBox.CausesValidation = false;
            this.richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.richTextBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.richTextBox.Location = new System.Drawing.Point(506, 27);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox.Size = new System.Drawing.Size(350, 471);
            this.richTextBox.TabIndex = 4;
            this.richTextBox.Text = "";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ElapsedTime
            // 
            this.ElapsedTime.AutoSize = true;
            this.ElapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElapsedTime.Location = new System.Drawing.Point(681, 562);
            this.ElapsedTime.Name = "ElapsedTime";
            this.ElapsedTime.Size = new System.Drawing.Size(71, 20);
            this.ElapsedTime.TabIndex = 5;
            this.ElapsedTime.Text = "00:00:00";
            // 
            // GamePLayed_Label
            // 
            this.GamePLayed_Label.AutoSize = true;
            this.GamePLayed_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GamePLayed_Label.Location = new System.Drawing.Point(563, 533);
            this.GamePLayed_Label.Name = "GamePLayed_Label";
            this.GamePLayed_Label.Size = new System.Drawing.Size(112, 20);
            this.GamePLayed_Label.TabIndex = 6;
            this.GamePLayed_Label.Text = "GamePlayed : ";
            // 
            // ElapsedTime_Label
            // 
            this.ElapsedTime_Label.AutoSize = true;
            this.ElapsedTime_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElapsedTime_Label.Location = new System.Drawing.Point(558, 562);
            this.ElapsedTime_Label.Name = "ElapsedTime_Label";
            this.ElapsedTime_Label.Size = new System.Drawing.Size(117, 20);
            this.ElapsedTime_Label.TabIndex = 7;
            this.ElapsedTime_Label.Text = "Elapsed Time : ";
            // 
            // GamePlayed
            // 
            this.GamePlayed.AutoSize = true;
            this.GamePlayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GamePlayed.Location = new System.Drawing.Point(681, 533);
            this.GamePlayed.Name = "GamePlayed";
            this.GamePlayed.Size = new System.Drawing.Size(18, 20);
            this.GamePlayed.TabIndex = 8;
            this.GamePlayed.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filerToolStripMenuItem1,
            this.settingToolStripMenuItem,
            this.StatsToolStripMenuItem2,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(868, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filerToolStripMenuItem1
            // 
            this.filerToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.filerToolStripMenuItem1.Name = "filerToolStripMenuItem1";
            this.filerToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.filerToolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KeyboardToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingToolStripMenuItem.Text = "Settings";
            // 
            // KeyboardToolStripMenuItem
            // 
            this.KeyboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aZERTYToolStripMenuItem,
            this.qWERTYToolStripMenuItem});
            this.KeyboardToolStripMenuItem.Name = "KeyboardToolStripMenuItem";
            this.KeyboardToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.KeyboardToolStripMenuItem.Text = "Keyboard";
            this.KeyboardToolStripMenuItem.Click += new System.EventHandler(this.showStatsToolStripMenuItem_Click);
            // 
            // aZERTYToolStripMenuItem
            // 
            this.aZERTYToolStripMenuItem.Checked = true;
            this.aZERTYToolStripMenuItem.CheckOnClick = true;
            this.aZERTYToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aZERTYToolStripMenuItem.Name = "aZERTYToolStripMenuItem";
            this.aZERTYToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.aZERTYToolStripMenuItem.Text = "AZERTY";
            this.aZERTYToolStripMenuItem.Click += new System.EventHandler(this.aZERTYToolStripMenuItem_Click);
            // 
            // qWERTYToolStripMenuItem
            // 
            this.qWERTYToolStripMenuItem.CheckOnClick = true;
            this.qWERTYToolStripMenuItem.Name = "qWERTYToolStripMenuItem";
            this.qWERTYToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.qWERTYToolStripMenuItem.Text = "QWERTY";
            this.qWERTYToolStripMenuItem.Click += new System.EventHandler(this.qWERTYToolStripMenuItem_Click);
            // 
            // StatsToolStripMenuItem2
            // 
            this.StatsToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showStatsToolStripMenuItem1});
            this.StatsToolStripMenuItem2.Name = "StatsToolStripMenuItem2";
            this.StatsToolStripMenuItem2.Size = new System.Drawing.Size(44, 20);
            this.StatsToolStripMenuItem2.Text = "Stats";
            // 
            // showStatsToolStripMenuItem1
            // 
            this.showStatsToolStripMenuItem1.Name = "showStatsToolStripMenuItem1";
            this.showStatsToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.showStatsToolStripMenuItem1.Text = "Show Stats";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // TestWorker
            // 
            this.TestWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.TestingWorker);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(506, 504);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "debug";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.Debug_CheckBox);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(868, 617);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.GamePlayed);
            this.Controls.Add(this.ElapsedTime_Label);
            this.Controls.Add(this.GamePLayed_Label);
            this.Controls.Add(this.ElapsedTime);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "BELLO FISHO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label ElapsedTime;
        private System.Windows.Forms.Label GamePLayed_Label;
        private System.Windows.Forms.Label ElapsedTime_Label;
        private System.Windows.Forms.Label GamePlayed;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KeyboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StatsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showStatsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem qWERTYToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aZERTYToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker TestWorker;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

