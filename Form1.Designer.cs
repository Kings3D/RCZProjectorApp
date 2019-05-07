using System;

namespace RCZProjectorApp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid1 = new System.Windows.Forms.DataGridView();
            this.viewInProjector = new System.Windows.Forms.DataGridViewButtonColumn();
            this.addToList = new System.Windows.Forms.DataGridViewLinkColumn();
            this.searchHymnText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bibleGrid = new System.Windows.Forms.DataGridView();
            this.txtBibleSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridVerse = new System.Windows.Forms.DataGridView();
            this.cbSelectedVs = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnViewVerse = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtSearchChapter = new System.Windows.Forms.TextBox();
            this.txtSearchVerse = new System.Windows.Forms.TextBox();
            this.btnAddBibleToList = new System.Windows.Forms.Button();
            this.gridChapter = new System.Windows.Forms.DataGridView();
            this.gridQuickVerses = new System.Windows.Forms.DataGridView();
            this.txtTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBody = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewVerses = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNotificationTitle = new System.Windows.Forms.TextBox();
            this.txtNotificationBody = new System.Windows.Forms.TextBox();
            this.btnNotificationAdd = new System.Windows.Forms.Button();
            this.gridNotifications = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.body = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShowNotification = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnShowAllNotifications = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bibleGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVerse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuickVerses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotifications)).BeginInit();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.AllowUserToAddRows = false;
            this.grid1.AllowUserToDeleteRows = false;
            this.grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.viewInProjector,
            this.addToList});
            this.grid1.Location = new System.Drawing.Point(12, 74);
            this.grid1.Name = "grid1";
            this.grid1.ReadOnly = true;
            this.grid1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grid1.Size = new System.Drawing.Size(306, 495);
            this.grid1.TabIndex = 0;
            this.grid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellContentClick);
            // 
            // viewInProjector
            // 
            this.viewInProjector.HeaderText = "";
            this.viewInProjector.MinimumWidth = 20;
            this.viewInProjector.Name = "viewInProjector";
            this.viewInProjector.ReadOnly = true;
            this.viewInProjector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.viewInProjector.Text = "View";
            this.viewInProjector.UseColumnTextForButtonValue = true;
            this.viewInProjector.Width = 50;
            // 
            // addToList
            // 
            this.addToList.HeaderText = "";
            this.addToList.MinimumWidth = 20;
            this.addToList.Name = "addToList";
            this.addToList.ReadOnly = true;
            this.addToList.Text = "List";
            this.addToList.UseColumnTextForLinkValue = true;
            this.addToList.Width = 50;
            // 
            // searchHymnText
            // 
            this.searchHymnText.Location = new System.Drawing.Point(12, 48);
            this.searchHymnText.Name = "searchHymnText";
            this.searchHymnText.Size = new System.Drawing.Size(306, 20);
            this.searchHymnText.TabIndex = 1;
            this.searchHymnText.Text = "Search Hymn";
            this.searchHymnText.TextChanged += new System.EventHandler(this.SearchHymnText_TextChanged);
            this.searchHymnText.GotFocus += new System.EventHandler(this.SearchHymnText_GotFocus);
            this.searchHymnText.LostFocus += new System.EventHandler(this.SearchHymnText_LostFocus);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hymns";
            // 
            // bibleGrid
            // 
            this.bibleGrid.AllowUserToAddRows = false;
            this.bibleGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bibleGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.bibleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bibleGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bibleGrid.Location = new System.Drawing.Point(336, 74);
            this.bibleGrid.MultiSelect = false;
            this.bibleGrid.Name = "bibleGrid";
            this.bibleGrid.ReadOnly = true;
            this.bibleGrid.RowHeadersWidth = 21;
            this.bibleGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bibleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bibleGrid.Size = new System.Drawing.Size(353, 89);
            this.bibleGrid.TabIndex = 3;
            this.bibleGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BibleGrid_CellClick);
            // 
            // txtBibleSearch
            // 
            this.txtBibleSearch.Location = new System.Drawing.Point(336, 48);
            this.txtBibleSearch.Name = "txtBibleSearch";
            this.txtBibleSearch.Size = new System.Drawing.Size(353, 20);
            this.txtBibleSearch.TabIndex = 4;
            this.txtBibleSearch.Text = "Search Book";
            this.txtBibleSearch.TextChanged += new System.EventHandler(this.TxtBibleSearch_TextChanged);
            this.txtBibleSearch.GotFocus += new System.EventHandler(this.TxtBibleSearch_GotFocus);
            this.txtBibleSearch.LostFocus += new System.EventHandler(this.TxtBibleSearch_LostFocus);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(331, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bible";
            // 
            // gridVerse
            // 
            this.gridVerse.AllowUserToAddRows = false;
            this.gridVerse.AllowUserToDeleteRows = false;
            this.gridVerse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVerse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbSelectedVs,
            this.btnViewVerse});
            this.gridVerse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridVerse.Location = new System.Drawing.Point(459, 195);
            this.gridVerse.Name = "gridVerse";
            this.gridVerse.ReadOnly = true;
            this.gridVerse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridVerse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVerse.Size = new System.Drawing.Size(230, 150);
            this.gridVerse.TabIndex = 7;
            this.gridVerse.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridVerse_CellClick);
            // 
            // cbSelectedVs
            // 
            this.cbSelectedVs.HeaderText = "";
            this.cbSelectedVs.Name = "cbSelectedVs";
            this.cbSelectedVs.ReadOnly = true;
            // 
            // btnViewVerse
            // 
            this.btnViewVerse.HeaderText = "";
            this.btnViewVerse.Name = "btnViewVerse";
            this.btnViewVerse.ReadOnly = true;
            this.btnViewVerse.Text = "Quick View";
            this.btnViewVerse.UseColumnTextForButtonValue = true;
            // 
            // txtSearchChapter
            // 
            this.txtSearchChapter.Location = new System.Drawing.Point(336, 169);
            this.txtSearchChapter.Name = "txtSearchChapter";
            this.txtSearchChapter.Size = new System.Drawing.Size(100, 20);
            this.txtSearchChapter.TabIndex = 8;
            this.txtSearchChapter.Text = "Chapter";
            this.txtSearchChapter.TextChanged += new System.EventHandler(this.TxtSearchChapter_TextChanged);
            this.txtSearchChapter.GotFocus += new System.EventHandler(this.TxtSearchChapter_GotFocus);
            this.txtSearchChapter.LostFocus += new System.EventHandler(this.TxtSearchChapter_LostFocus);
            // 
            // txtSearchVerse
            // 
            this.txtSearchVerse.Location = new System.Drawing.Point(459, 169);
            this.txtSearchVerse.Name = "txtSearchVerse";
            this.txtSearchVerse.Size = new System.Drawing.Size(230, 20);
            this.txtSearchVerse.TabIndex = 9;
            this.txtSearchVerse.Text = "Verse";
            this.txtSearchVerse.TextChanged += new System.EventHandler(this.TxtSearchVerse_TextChanged);
            this.txtSearchVerse.GotFocus += new System.EventHandler(this.TxtSearchVerse_GotFocus);
            this.txtSearchVerse.LostFocus += new System.EventHandler(this.TxtSearchVerse_LostFocus);
            // 
            // btnAddBibleToList
            // 
            this.btnAddBibleToList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBibleToList.Location = new System.Drawing.Point(336, 351);
            this.btnAddBibleToList.Name = "btnAddBibleToList";
            this.btnAddBibleToList.Size = new System.Drawing.Size(353, 23);
            this.btnAddBibleToList.TabIndex = 10;
            this.btnAddBibleToList.Text = "Add Verse Selection To List";
            this.btnAddBibleToList.UseVisualStyleBackColor = true;
            this.btnAddBibleToList.Click += new System.EventHandler(this.BtnAddBibleToList_Click);
            // 
            // gridChapter
            // 
            this.gridChapter.AllowUserToAddRows = false;
            this.gridChapter.AllowUserToDeleteRows = false;
            this.gridChapter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridChapter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridChapter.Location = new System.Drawing.Point(336, 195);
            this.gridChapter.Name = "gridChapter";
            this.gridChapter.ReadOnly = true;
            this.gridChapter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridChapter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridChapter.Size = new System.Drawing.Size(100, 150);
            this.gridChapter.TabIndex = 11;
            this.gridChapter.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridChapter_CellClick);
            // 
            // gridQuickVerses
            // 
            this.gridQuickVerses.AllowUserToAddRows = false;
            this.gridQuickVerses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridQuickVerses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtTitle,
            this.txtBody,
            this.btnViewVerses});
            this.gridQuickVerses.Location = new System.Drawing.Point(336, 399);
            this.gridQuickVerses.Name = "gridQuickVerses";
            this.gridQuickVerses.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridQuickVerses.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridQuickVerses.RowHeadersWidth = 30;
            this.gridQuickVerses.Size = new System.Drawing.Size(353, 170);
            this.gridQuickVerses.TabIndex = 12;
            this.gridQuickVerses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridQuickVerses_CellClick);
            this.gridQuickVerses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridQuickVerses_CellContentClick);
            // 
            // txtTitle
            // 
            this.txtTitle.HeaderText = "Title";
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            // 
            // txtBody
            // 
            this.txtBody.HeaderText = "Body";
            this.txtBody.Name = "txtBody";
            this.txtBody.ReadOnly = true;
            // 
            // btnViewVerses
            // 
            this.btnViewVerses.HeaderText = "";
            this.btnViewVerses.Name = "btnViewVerses";
            this.btnViewVerses.ReadOnly = true;
            this.btnViewVerses.Text = "View Now";
            this.btnViewVerses.UseColumnTextForButtonValue = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(699, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ziviso";
            // 
            // txtNotificationTitle
            // 
            this.txtNotificationTitle.Location = new System.Drawing.Point(704, 48);
            this.txtNotificationTitle.Name = "txtNotificationTitle";
            this.txtNotificationTitle.Size = new System.Drawing.Size(100, 20);
            this.txtNotificationTitle.TabIndex = 14;
            this.txtNotificationTitle.Text = "Title";
            // 
            // txtNotificationBody
            // 
            this.txtNotificationBody.Location = new System.Drawing.Point(810, 48);
            this.txtNotificationBody.Name = "txtNotificationBody";
            this.txtNotificationBody.Size = new System.Drawing.Size(160, 20);
            this.txtNotificationBody.TabIndex = 15;
            this.txtNotificationBody.Text = "Ziviso";
            // 
            // btnNotificationAdd
            // 
            this.btnNotificationAdd.Location = new System.Drawing.Point(976, 48);
            this.btnNotificationAdd.Name = "btnNotificationAdd";
            this.btnNotificationAdd.Size = new System.Drawing.Size(75, 23);
            this.btnNotificationAdd.TabIndex = 16;
            this.btnNotificationAdd.Text = "Add";
            this.btnNotificationAdd.UseVisualStyleBackColor = true;
            this.btnNotificationAdd.Click += new System.EventHandler(this.BtnNotificationAdd_Click);
            // 
            // gridNotifications
            // 
            this.gridNotifications.AllowUserToAddRows = false;
            this.gridNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNotifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title,
            this.body,
            this.btnShowNotification});
            this.gridNotifications.Location = new System.Drawing.Point(706, 76);
            this.gridNotifications.Name = "gridNotifications";
            this.gridNotifications.ReadOnly = true;
            this.gridNotifications.Size = new System.Drawing.Size(345, 456);
            this.gridNotifications.TabIndex = 17;
            this.gridNotifications.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridNotifications_CellClick);
            // 
            // title
            // 
            this.title.HeaderText = "Title";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // body
            // 
            this.body.HeaderText = "Body";
            this.body.Name = "body";
            this.body.ReadOnly = true;
            // 
            // btnShowNotification
            // 
            this.btnShowNotification.HeaderText = "";
            this.btnShowNotification.Name = "btnShowNotification";
            this.btnShowNotification.ReadOnly = true;
            this.btnShowNotification.Text = "Show Now";
            this.btnShowNotification.UseColumnTextForButtonValue = true;
            // 
            // btnShowAllNotifications
            // 
            this.btnShowAllNotifications.Enabled = false;
            this.btnShowAllNotifications.Location = new System.Drawing.Point(706, 546);
            this.btnShowAllNotifications.Name = "btnShowAllNotifications";
            this.btnShowAllNotifications.Size = new System.Drawing.Size(345, 23);
            this.btnShowAllNotifications.TabIndex = 18;
            this.btnShowAllNotifications.Text = "Show All Notifications";
            this.btnShowAllNotifications.UseVisualStyleBackColor = true;
            this.btnShowAllNotifications.Click += new System.EventHandler(this.BtnShowAllNotifications_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 613);
            this.Controls.Add(this.btnShowAllNotifications);
            this.Controls.Add(this.gridNotifications);
            this.Controls.Add(this.btnNotificationAdd);
            this.Controls.Add(this.txtNotificationBody);
            this.Controls.Add(this.txtNotificationTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridQuickVerses);
            this.Controls.Add(this.gridChapter);
            this.Controls.Add(this.btnAddBibleToList);
            this.Controls.Add(this.txtSearchVerse);
            this.Controls.Add(this.txtSearchChapter);
            this.Controls.Add(this.gridVerse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBibleSearch);
            this.Controls.Add(this.bibleGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchHymnText);
            this.Controls.Add(this.grid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bibleGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVerse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuickVerses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotifications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid1;
        private System.Windows.Forms.TextBox searchHymnText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn viewInProjector;
        private System.Windows.Forms.DataGridViewLinkColumn addToList;
        private System.Windows.Forms.DataGridView bibleGrid;
        private System.Windows.Forms.TextBox txtBibleSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridVerse;
        private System.Windows.Forms.TextBox txtSearchChapter;
        private System.Windows.Forms.TextBox txtSearchVerse;
        private System.Windows.Forms.Button btnAddBibleToList;
        private System.Windows.Forms.DataGridView gridChapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbSelectedVs;
        private System.Windows.Forms.DataGridViewButtonColumn btnViewVerse;
        private System.Windows.Forms.DataGridView gridQuickVerses;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBody;
        private System.Windows.Forms.DataGridViewButtonColumn btnViewVerses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNotificationTitle;
        private System.Windows.Forms.TextBox txtNotificationBody;
        private System.Windows.Forms.Button btnNotificationAdd;
        private System.Windows.Forms.DataGridView gridNotifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn body;
        private System.Windows.Forms.DataGridViewButtonColumn btnShowNotification;
        private System.Windows.Forms.Button btnShowAllNotifications;
    }
}

