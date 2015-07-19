namespace SoundPcStream_SPS_
{
    partial class MainWindow
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
            this.record = new System.Windows.Forms.Button();
            this.stopRecord = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sourceList = new System.Windows.Forms.ListView();
            this.errorPortL = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.portTB = new System.Windows.Forms.TextBox();
            this.startServeur = new System.Windows.Forms.Button();
            this.ipAdressTB = new System.Windows.Forms.TextBox();
            this.ipAdress = new System.Windows.Forms.Label();
            this.refresh = new System.Windows.Forms.Button();
            this.stopServeur = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // record
            // 
            this.record.Location = new System.Drawing.Point(16, 176);
            this.record.Name = "record";
            this.record.Size = new System.Drawing.Size(145, 23);
            this.record.TabIndex = 0;
            this.record.Text = "Record";
            this.record.UseVisualStyleBackColor = true;
            this.record.Click += new System.EventHandler(this.record_Click);
            // 
            // stopRecord
            // 
            this.stopRecord.Location = new System.Drawing.Point(16, 224);
            this.stopRecord.Name = "stopRecord";
            this.stopRecord.Size = new System.Drawing.Size(145, 25);
            this.stopRecord.TabIndex = 1;
            this.stopRecord.Text = "Stop Recording";
            this.stopRecord.UseVisualStyleBackColor = true;
            this.stopRecord.Click += new System.EventHandler(this.stopRecord_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sourceList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.stopServeur);
            this.splitContainer1.Panel2.Controls.Add(this.errorPortL);
            this.splitContainer1.Panel2.Controls.Add(this.portLabel);
            this.splitContainer1.Panel2.Controls.Add(this.portTB);
            this.splitContainer1.Panel2.Controls.Add(this.startServeur);
            this.splitContainer1.Panel2.Controls.Add(this.ipAdressTB);
            this.splitContainer1.Panel2.Controls.Add(this.ipAdress);
            this.splitContainer1.Panel2.Controls.Add(this.refresh);
            this.splitContainer1.Panel2.Controls.Add(this.record);
            this.splitContainer1.Panel2.Controls.Add(this.stopRecord);
            this.splitContainer1.Size = new System.Drawing.Size(724, 261);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 2;
            // 
            // sourceList
            // 
            this.sourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceList.Location = new System.Drawing.Point(0, 0);
            this.sourceList.MultiSelect = false;
            this.sourceList.Name = "sourceList";
            this.sourceList.Size = new System.Drawing.Size(314, 261);
            this.sourceList.TabIndex = 0;
            this.sourceList.UseCompatibleStateImageBehavior = false;
            this.sourceList.View = System.Windows.Forms.View.List;
            // 
            // errorPortL
            // 
            this.errorPortL.AutoSize = true;
            this.errorPortL.Location = new System.Drawing.Point(130, 101);
            this.errorPortL.Name = "errorPortL";
            this.errorPortL.Size = new System.Drawing.Size(107, 13);
            this.errorPortL.TabIndex = 8;
            this.errorPortL.Text = "Nméro de port érroné";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(13, 64);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 7;
            this.portLabel.Text = "Port";
            // 
            // portTB
            // 
            this.portTB.Location = new System.Drawing.Point(84, 64);
            this.portTB.Name = "portTB";
            this.portTB.Size = new System.Drawing.Size(62, 20);
            this.portTB.TabIndex = 6;
            // 
            // startServeur
            // 
            this.startServeur.Location = new System.Drawing.Point(216, 28);
            this.startServeur.Name = "startServeur";
            this.startServeur.Size = new System.Drawing.Size(118, 23);
            this.startServeur.TabIndex = 5;
            this.startServeur.Text = "Start Server";
            this.startServeur.UseVisualStyleBackColor = true;
            this.startServeur.Click += new System.EventHandler(this.startServeur_Click);
            // 
            // ipAdressTB
            // 
            this.ipAdressTB.Location = new System.Drawing.Point(84, 25);
            this.ipAdressTB.Name = "ipAdressTB";
            this.ipAdressTB.Size = new System.Drawing.Size(77, 20);
            this.ipAdressTB.TabIndex = 4;
            // 
            // ipAdress
            // 
            this.ipAdress.AutoSize = true;
            this.ipAdress.Location = new System.Drawing.Point(13, 28);
            this.ipAdress.Name = "ipAdress";
            this.ipAdress.Size = new System.Drawing.Size(65, 13);
            this.ipAdress.TabIndex = 3;
            this.ipAdress.Text = "Adresse ip : ";
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(16, 137);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(145, 23);
            this.refresh.TabIndex = 2;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // stopServeur
            // 
            this.stopServeur.Location = new System.Drawing.Point(216, 60);
            this.stopServeur.Name = "stopServeur";
            this.stopServeur.Size = new System.Drawing.Size(118, 23);
            this.stopServeur.TabIndex = 9;
            this.stopServeur.Text = "Stop Serveur";
            this.stopServeur.UseVisualStyleBackColor = true;
            this.stopServeur.Click += new System.EventHandler(this.stopServeur_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 261);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainWindow";
            this.Text = "Sound PC Stream";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button record;
        private System.Windows.Forms.Button stopRecord;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView sourceList;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Label ipAdress;
        private System.Windows.Forms.Button startServeur;
        private System.Windows.Forms.TextBox ipAdressTB;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTB;
        private System.Windows.Forms.Label errorPortL;
        private System.Windows.Forms.Button stopServeur;
    }
}

