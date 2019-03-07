namespace SimpleGUI
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
            this.list_hosts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_scan = new System.Windows.Forms.Button();
            this.list_devices = new System.Windows.Forms.ListView();
            this.adapter_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.adapter_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.adapter_mac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_devices = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progrBar_loading = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // list_hosts
            // 
            this.list_hosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_hosts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.list_hosts.Location = new System.Drawing.Point(12, 160);
            this.list_hosts.Name = "list_hosts";
            this.list_hosts.Size = new System.Drawing.Size(571, 97);
            this.list_hosts.TabIndex = 0;
            this.list_hosts.UseCompatibleStateImageBehavior = false;
            this.list_hosts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 256;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MAC";
            // 
            // btn_scan
            // 
            this.btn_scan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_scan.Location = new System.Drawing.Point(481, 263);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(102, 23);
            this.btn_scan.TabIndex = 1;
            this.btn_scan.Text = "Scan";
            this.btn_scan.UseVisualStyleBackColor = true;
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // list_devices
            // 
            this.list_devices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_devices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.adapter_name,
            this.adapter_ip,
            this.adapter_mac});
            this.list_devices.FullRowSelect = true;
            this.list_devices.Location = new System.Drawing.Point(12, 12);
            this.list_devices.Name = "list_devices";
            this.list_devices.Size = new System.Drawing.Size(571, 97);
            this.list_devices.TabIndex = 2;
            this.list_devices.UseCompatibleStateImageBehavior = false;
            this.list_devices.View = System.Windows.Forms.View.Details;
            // 
            // adapter_name
            // 
            this.adapter_name.Text = "Adapter";
            this.adapter_name.Width = 256;
            // 
            // adapter_ip
            // 
            this.adapter_ip.Text = "IP";
            this.adapter_ip.Width = 151;
            // 
            // adapter_mac
            // 
            this.adapter_mac.Text = "Mac";
            this.adapter_mac.Width = 113;
            // 
            // btn_devices
            // 
            this.btn_devices.Location = new System.Drawing.Point(481, 115);
            this.btn_devices.Name = "btn_devices";
            this.btn_devices.Size = new System.Drawing.Size(102, 23);
            this.btn_devices.TabIndex = 3;
            this.btn_devices.Text = "Get Interfaces";
            this.btn_devices.UseVisualStyleBackColor = true;
            this.btn_devices.Click += new System.EventHandler(this.btn_devices_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progrBar_loading});
            this.statusStrip1.Location = new System.Drawing.Point(0, 294);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(595, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progrBar_loading
            // 
            this.progrBar_loading.Enabled = false;
            this.progrBar_loading.MarqueeAnimationSpeed = 25;
            this.progrBar_loading.Name = "progrBar_loading";
            this.progrBar_loading.Size = new System.Drawing.Size(100, 16);
            this.progrBar_loading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progrBar_loading.Value = 100;
            this.progrBar_loading.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 316);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_devices);
            this.Controls.Add(this.list_devices);
            this.Controls.Add(this.btn_scan);
            this.Controls.Add(this.list_hosts);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lan Scanner";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView list_hosts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.ListView list_devices;
        private System.Windows.Forms.ColumnHeader adapter_name;
        private System.Windows.Forms.ColumnHeader adapter_ip;
        private System.Windows.Forms.ColumnHeader adapter_mac;
        private System.Windows.Forms.Button btn_devices;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progrBar_loading;
    }
}

