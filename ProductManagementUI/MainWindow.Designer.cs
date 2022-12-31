namespace ProductManagementUI
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
            this.AdminPanel = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.CategoryManagerBtn = new System.Windows.Forms.Button();
            this.UserManagerBtn = new System.Windows.Forms.Button();
            this.ProductDataGridView = new System.Windows.Forms.DataGridView();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MinValue = new System.Windows.Forms.NumericUpDown();
            this.HighValue = new System.Windows.Forms.NumericUpDown();
            this.RatingSearchBar = new System.Windows.Forms.TrackBar();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RatingPanel = new System.Windows.Forms.GroupBox();
            this.RatingBar = new System.Windows.Forms.TrackBar();
            this.RateBtn = new System.Windows.Forms.Button();
            this.FlexibleSearchBtn = new System.Windows.Forms.Button();
            this.CSVExportBtn = new System.Windows.Forms.Button();
            this.JSONExportBtn = new System.Windows.Forms.Button();
            this.AdminPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatingSearchBar)).BeginInit();
            this.RatingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RatingBar)).BeginInit();
            this.SuspendLayout();
            // 
            // AdminPanel
            // 
            this.AdminPanel.Controls.Add(this.button3);
            this.AdminPanel.Controls.Add(this.CategoryManagerBtn);
            this.AdminPanel.Controls.Add(this.UserManagerBtn);
            this.AdminPanel.Location = new System.Drawing.Point(585, 290);
            this.AdminPanel.Name = "AdminPanel";
            this.AdminPanel.Size = new System.Drawing.Size(203, 148);
            this.AdminPanel.TabIndex = 0;
            this.AdminPanel.TabStop = false;
            this.AdminPanel.Text = "Admin Panel";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(84, 72);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "Products Manager";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CategoryManagerBtn
            // 
            this.CategoryManagerBtn.Location = new System.Drawing.Point(84, 110);
            this.CategoryManagerBtn.Name = "CategoryManagerBtn";
            this.CategoryManagerBtn.Size = new System.Drawing.Size(113, 32);
            this.CategoryManagerBtn.TabIndex = 1;
            this.CategoryManagerBtn.Text = "Category Manager";
            this.CategoryManagerBtn.UseVisualStyleBackColor = true;
            this.CategoryManagerBtn.Click += new System.EventHandler(this.CategoryManagerBtn_Click);
            // 
            // UserManagerBtn
            // 
            this.UserManagerBtn.Location = new System.Drawing.Point(84, 34);
            this.UserManagerBtn.Name = "UserManagerBtn";
            this.UserManagerBtn.Size = new System.Drawing.Size(113, 32);
            this.UserManagerBtn.TabIndex = 0;
            this.UserManagerBtn.Text = "User Manager";
            this.UserManagerBtn.UseVisualStyleBackColor = true;
            this.UserManagerBtn.Click += new System.EventHandler(this.UserManagerBtn_Click);
            // 
            // ProductDataGridView
            // 
            this.ProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDataGridView.Location = new System.Drawing.Point(12, 12);
            this.ProductDataGridView.Name = "ProductDataGridView";
            this.ProductDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductDataGridView.Size = new System.Drawing.Size(567, 426);
            this.ProductDataGridView.TabIndex = 1;
            this.ProductDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductDataGridView_CellClick);
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(661, 12);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.CategoryComboBox.TabIndex = 2;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(606, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Category";
            // 
            // MinValue
            // 
            this.MinValue.Location = new System.Drawing.Point(609, 87);
            this.MinValue.Name = "MinValue";
            this.MinValue.Size = new System.Drawing.Size(73, 20);
            this.MinValue.TabIndex = 4;
            this.MinValue.ValueChanged += new System.EventHandler(this.MinValue_ValueChanged);
            // 
            // HighValue
            // 
            this.HighValue.Location = new System.Drawing.Point(709, 87);
            this.HighValue.Name = "HighValue";
            this.HighValue.Size = new System.Drawing.Size(73, 20);
            this.HighValue.TabIndex = 5;
            this.HighValue.ValueChanged += new System.EventHandler(this.HighValue_ValueChanged);
            // 
            // RatingSearchBar
            // 
            this.RatingSearchBar.Location = new System.Drawing.Point(609, 130);
            this.RatingSearchBar.Maximum = 5;
            this.RatingSearchBar.Minimum = 1;
            this.RatingSearchBar.Name = "RatingSearchBar";
            this.RatingSearchBar.Size = new System.Drawing.Size(173, 45);
            this.RatingSearchBar.TabIndex = 6;
            this.RatingSearchBar.Value = 1;
            this.RatingSearchBar.ValueChanged += new System.EventHandler(this.RatingSearchBar_ValueChanged);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(661, 49);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(121, 20);
            this.NameBox.TabIndex = 7;
            this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(606, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name";
            // 
            // RatingPanel
            // 
            this.RatingPanel.Controls.Add(this.RatingBar);
            this.RatingPanel.Controls.Add(this.RateBtn);
            this.RatingPanel.Location = new System.Drawing.Point(585, 290);
            this.RatingPanel.Name = "RatingPanel";
            this.RatingPanel.Size = new System.Drawing.Size(203, 148);
            this.RatingPanel.TabIndex = 3;
            this.RatingPanel.TabStop = false;
            this.RatingPanel.Text = "Rating";
            // 
            // RatingBar
            // 
            this.RatingBar.Location = new System.Drawing.Point(6, 87);
            this.RatingBar.Maximum = 5;
            this.RatingBar.Minimum = 1;
            this.RatingBar.Name = "RatingBar";
            this.RatingBar.Size = new System.Drawing.Size(173, 45);
            this.RatingBar.TabIndex = 9;
            this.RatingBar.Value = 1;
            // 
            // RateBtn
            // 
            this.RateBtn.Location = new System.Drawing.Point(94, 49);
            this.RateBtn.Name = "RateBtn";
            this.RateBtn.Size = new System.Drawing.Size(85, 32);
            this.RateBtn.TabIndex = 3;
            this.RateBtn.Text = "Leave Rating";
            this.RateBtn.UseVisualStyleBackColor = true;
            this.RateBtn.Click += new System.EventHandler(this.RateBtn_Click);
            // 
            // FlexibleSearchBtn
            // 
            this.FlexibleSearchBtn.Location = new System.Drawing.Point(609, 169);
            this.FlexibleSearchBtn.Name = "FlexibleSearchBtn";
            this.FlexibleSearchBtn.Size = new System.Drawing.Size(173, 36);
            this.FlexibleSearchBtn.TabIndex = 9;
            this.FlexibleSearchBtn.Text = "Search by Rating";
            this.FlexibleSearchBtn.UseVisualStyleBackColor = true;
            this.FlexibleSearchBtn.Click += new System.EventHandler(this.FlexibleSearchBtn_Click);
            // 
            // CSVExportBtn
            // 
            this.CSVExportBtn.Location = new System.Drawing.Point(609, 244);
            this.CSVExportBtn.Name = "CSVExportBtn";
            this.CSVExportBtn.Size = new System.Drawing.Size(75, 23);
            this.CSVExportBtn.TabIndex = 10;
            this.CSVExportBtn.Text = "CSV";
            this.CSVExportBtn.UseVisualStyleBackColor = true;
            this.CSVExportBtn.Click += new System.EventHandler(this.CSVExportBtn_Click);
            // 
            // JSONExportBtn
            // 
            this.JSONExportBtn.Location = new System.Drawing.Point(707, 244);
            this.JSONExportBtn.Name = "JSONExportBtn";
            this.JSONExportBtn.Size = new System.Drawing.Size(75, 23);
            this.JSONExportBtn.TabIndex = 11;
            this.JSONExportBtn.Text = "JSON";
            this.JSONExportBtn.UseVisualStyleBackColor = true;
            this.JSONExportBtn.Click += new System.EventHandler(this.JSONExportBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.JSONExportBtn);
            this.Controls.Add(this.CSVExportBtn);
            this.Controls.Add(this.FlexibleSearchBtn);
            this.Controls.Add(this.RatingPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.RatingSearchBar);
            this.Controls.Add(this.HighValue);
            this.Controls.Add(this.MinValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.ProductDataGridView);
            this.Controls.Add(this.AdminPanel);
            this.Name = "MainWindow";
            this.Text = "Product Management";
            this.AdminPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatingSearchBar)).EndInit();
            this.RatingPanel.ResumeLayout(false);
            this.RatingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RatingBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox AdminPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button CategoryManagerBtn;
        private System.Windows.Forms.Button UserManagerBtn;
        private System.Windows.Forms.DataGridView ProductDataGridView;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown MinValue;
        private System.Windows.Forms.NumericUpDown HighValue;
        private System.Windows.Forms.TrackBar RatingSearchBar;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox RatingPanel;
        private System.Windows.Forms.TrackBar RatingBar;
        private System.Windows.Forms.Button RateBtn;
        private System.Windows.Forms.Button FlexibleSearchBtn;
        private System.Windows.Forms.Button CSVExportBtn;
        private System.Windows.Forms.Button JSONExportBtn;
    }
}

