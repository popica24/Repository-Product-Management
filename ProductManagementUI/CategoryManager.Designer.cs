namespace ProductManagementUI
{
    partial class CategoryManager
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
            this.CategoryDataGridView = new System.Windows.Forms.DataGridView();
            this.ManagementGB = new System.Windows.Forms.GroupBox();
            this.CategoryNameBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.CreateBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDataGridView)).BeginInit();
            this.ManagementGB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CategoryDataGridView
            // 
            this.CategoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CategoryDataGridView.Location = new System.Drawing.Point(337, 12);
            this.CategoryDataGridView.Name = "CategoryDataGridView";
            this.CategoryDataGridView.Size = new System.Drawing.Size(251, 426);
            this.CategoryDataGridView.TabIndex = 0;
            // 
            // ManagementGB
            // 
            this.ManagementGB.Controls.Add(this.CategoryNameBox);
            this.ManagementGB.Location = new System.Drawing.Point(12, 338);
            this.ManagementGB.Name = "ManagementGB";
            this.ManagementGB.Size = new System.Drawing.Size(200, 100);
            this.ManagementGB.TabIndex = 1;
            this.ManagementGB.TabStop = false;
            // 
            // CategoryNameBox
            // 
            this.CategoryNameBox.Location = new System.Drawing.Point(6, 42);
            this.CategoryNameBox.Name = "CategoryNameBox";
            this.CategoryNameBox.Size = new System.Drawing.Size(122, 20);
            this.CategoryNameBox.TabIndex = 2;
            this.CategoryNameBox.Text = "Category Name";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Category ID",
            "Category Name"});
            this.comboBox1.Location = new System.Drawing.Point(12, 191);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(146, 192);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(167, 20);
            this.SearchBox.TabIndex = 8;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(12, 229);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(301, 33);
            this.SearchBtn.TabIndex = 9;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeleteBtn);
            this.groupBox2.Controls.Add(this.EditBtn);
            this.groupBox2.Controls.Add(this.CreateBtn);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 173);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Management";
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(6, 77);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 7;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Location = new System.Drawing.Point(6, 123);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(75, 23);
            this.EditBtn.TabIndex = 8;
            this.EditBtn.Text = "Edit";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // CreateBtn
            // 
            this.CreateBtn.Location = new System.Drawing.Point(6, 31);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(75, 23);
            this.CreateBtn.TabIndex = 6;
            this.CreateBtn.Text = "Create";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // CategoryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ManagementGB);
            this.Controls.Add(this.CategoryDataGridView);
            this.Name = "CategoryManager";
            this.Text = "CategoryManager";
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDataGridView)).EndInit();
            this.ManagementGB.ResumeLayout(false);
            this.ManagementGB.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CategoryDataGridView;
        private System.Windows.Forms.GroupBox ManagementGB;
        private System.Windows.Forms.TextBox CategoryNameBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button CreateBtn;
    }
}