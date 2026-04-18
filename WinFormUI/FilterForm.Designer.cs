namespace WinFormUI
{
    partial class FilterForm
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
            this.dgvFilter = new System.Windows.Forms.DataGridView();
            this.btnBestItems = new System.Windows.Forms.Button();
            this.cmbAgents = new System.Windows.Forms.ComboBox();
            this.btnFilterByAgent = new System.Windows.Forms.Button();
            this.cmbItems = new System.Windows.Forms.ComboBox();
            this.btnFilterByItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFilter
            // 
            this.dgvFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilter.Location = new System.Drawing.Point(33, 101);
            this.dgvFilter.Name = "dgvFilter";
            this.dgvFilter.Size = new System.Drawing.Size(755, 325);
            this.dgvFilter.TabIndex = 0;
            // 
            // btnBestItems
            // 
            this.btnBestItems.Location = new System.Drawing.Point(33, 24);
            this.btnBestItems.Name = "btnBestItems";
            this.btnBestItems.Size = new System.Drawing.Size(162, 23);
            this.btnBestItems.TabIndex = 1;
            this.btnBestItems.Text = "Show Best Selling";
            this.btnBestItems.UseVisualStyleBackColor = true;
            this.btnBestItems.Click += new System.EventHandler(this.btnBestItems_Click);
            // 
            // cmbAgents
            // 
            this.cmbAgents.FormattingEnabled = true;
            this.cmbAgents.Location = new System.Drawing.Point(276, 26);
            this.cmbAgents.Name = "cmbAgents";
            this.cmbAgents.Size = new System.Drawing.Size(121, 21);
            this.cmbAgents.TabIndex = 2;
            // 
            // btnFilterByAgent
            // 
            this.btnFilterByAgent.Location = new System.Drawing.Point(403, 26);
            this.btnFilterByAgent.Name = "btnFilterByAgent";
            this.btnFilterByAgent.Size = new System.Drawing.Size(84, 23);
            this.btnFilterByAgent.TabIndex = 3;
            this.btnFilterByAgent.Text = "Filter By Agent";
            this.btnFilterByAgent.UseVisualStyleBackColor = true;
            this.btnFilterByAgent.Click += new System.EventHandler(this.btnFilterByAgent_Click);
            // 
            // cmbItems
            // 
            this.cmbItems.FormattingEnabled = true;
            this.cmbItems.Location = new System.Drawing.Point(558, 30);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.Size = new System.Drawing.Size(121, 21);
            this.cmbItems.TabIndex = 4;
            // 
            // btnFilterByItem
            // 
            this.btnFilterByItem.Location = new System.Drawing.Point(685, 28);
            this.btnFilterByItem.Name = "btnFilterByItem";
            this.btnFilterByItem.Size = new System.Drawing.Size(84, 23);
            this.btnFilterByItem.TabIndex = 5;
            this.btnFilterByItem.Text = "Filter By Item";
            this.btnFilterByItem.UseVisualStyleBackColor = true;
            this.btnFilterByItem.Click += new System.EventHandler(this.btnFilterByItem_Click);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFilterByItem);
            this.Controls.Add(this.cmbItems);
            this.Controls.Add(this.btnFilterByAgent);
            this.Controls.Add(this.cmbAgents);
            this.Controls.Add(this.btnBestItems);
            this.Controls.Add(this.dgvFilter);
            this.Name = "FilterForm";
            this.Text = "FilterForm";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFilter;
        private System.Windows.Forms.Button btnBestItems;
        private System.Windows.Forms.ComboBox cmbAgents;
        private System.Windows.Forms.Button btnFilterByAgent;
        private System.Windows.Forms.ComboBox cmbItems;
        private System.Windows.Forms.Button btnFilterByItem;
    }
}