namespace ProductManagementUI
{
    partial class ProductManagement
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DateManufacturedBox = new System.Windows.Forms.DateTimePicker();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.PriceBox = new System.Windows.Forms.TextBox();
            this.ProductDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.SearchBy = new System.Windows.Forms.ComboBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CategoryList = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DateManufacturedBox);
            this.groupBox1.Controls.Add(this.CategoryComboBox);
            this.groupBox1.Controls.Add(this.DescriptionBox);
            this.groupBox1.Controls.Add(this.PriceBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 170);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // DateManufacturedBox
            // 
            this.DateManufacturedBox.Location = new System.Drawing.Point(6, 100);
            this.DateManufacturedBox.Name = "DateManufacturedBox";
            this.DateManufacturedBox.Size = new System.Drawing.Size(200, 20);
            this.DateManufacturedBox.TabIndex = 5;
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(6, 140);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(200, 21);
            this.CategoryComboBox.TabIndex = 4;
            this.CategoryComboBox.SelectedValueChanged += new System.EventHandler(this.CategoryComboBox_SelectedValueChanged);
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(6, 20);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(200, 20);
            this.DescriptionBox.TabIndex = 1;
            this.DescriptionBox.Text = "Description";
            // 
            // PriceBox
            // 
            this.PriceBox.Location = new System.Drawing.Point(6, 60);
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(200, 20);
            this.PriceBox.TabIndex = 2;
            this.PriceBox.Text = "Price";
            // 
            // ProductDataGridView
            // 
            this.ProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDataGridView.Location = new System.Drawing.Point(324, 12);
            this.ProductDataGridView.Name = "ProductDataGridView";
            this.ProductDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductDataGridView.Size = new System.Drawing.Size(390, 426);
            this.ProductDataGridView.TabIndex = 7;
            this.ProductDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductDataGridView_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeleteBtn);
            this.groupBox2.Controls.Add(this.EditBtn);
            this.groupBox2.Controls.Add(this.CreateBtn);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 173);
            this.groupBox2.TabIndex = 8;
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
            // SearchBy
            // 
            this.SearchBy.FormattingEnabled = true;
            this.SearchBy.Items.AddRange(new object[] {
            "Phone Number",
            "First Name",
            "Last Name",
            "ID"});
            this.SearchBy.Location = new System.Drawing.Point(12, 191);
            this.SearchBy.Name = "SearchBy";
            this.SearchBy.Size = new System.Drawing.Size(121, 21);
            this.SearchBy.TabIndex = 12;
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(146, 192);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(167, 20);
            this.SearchBox.TabIndex = 10;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(12, 229);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(301, 33);
            this.SearchBtn.TabIndex = 11;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox3.Controls.Add(this.CategoryList);
            this.groupBox3.Location = new System.Drawing.Point(146, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(167, 173);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Categories";
            // 
            // CategoryList
            // 
            this.CategoryList.AutoSize = true;
            this.CategoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryList.Location = new System.Drawing.Point(6, 31);
            this.CategoryList.Name = "CategoryList";
            this.CategoryList.Size = new System.Drawing.Size(0, 16);
            this.CategoryList.TabIndex = 14;
            // 
            // ProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ProductDataGridView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SearchBy);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.SearchBtn);
            this.Name = "ProductManagement";
            this.Text = "ProductManagement";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.TextBox PriceBox;
        private System.Windows.Forms.DataGridView ProductDataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.ComboBox SearchBy;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.DateTimePicker DateManufacturedBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label CategoryList;
    }
}