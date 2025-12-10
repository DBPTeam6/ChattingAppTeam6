namespace ChattingAppTeam6.Chat.UI
{
    partial class ChatSearchForm
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
this.panelTop = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
          this.txtSearch = new System.Windows.Forms.TextBox();
     this.lblTitle = new System.Windows.Forms.Label();
            this.panelResults = new System.Windows.Forms.Panel();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.columnSender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.columnTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
       this.lblResultCount = new System.Windows.Forms.Label();
       this.panelTop.SuspendLayout();
            this.panelResults.SuspendLayout();
     this.SuspendLayout();
      // 
            // panelTop
            // 
 this.panelTop.Controls.Add(this.btnSearch);
   this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.lblTitle);
         this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
    this.panelTop.Name = "panelTop";
this.panelTop.Padding = new System.Windows.Forms.Padding(10);
            this.panelTop.Size = new System.Drawing.Size(500, 100);
     this.panelTop.TabIndex = 0;
            // 
 // btnSearch
            // 
    this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
     this.btnSearch.Font = new System.Drawing.Font("¸¼Àº °íµñ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
          this.btnSearch.Location = new System.Drawing.Point(400, 50);
            this.btnSearch.Name = "btnSearch";
 this.btnSearch.Size = new System.Drawing.Size(85, 35);
     this.btnSearch.TabIndex = 2;
  this.btnSearch.Text = "?? °Ë»ö";
            this.btnSearch.UseVisualStyleBackColor = true;
    this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
   // 
      // txtSearch
   // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
 | System.Windows.Forms.AnchorStyles.Right)));
   this.txtSearch.Font = new System.Drawing.Font("¸¼Àº °íµñ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
    this.txtSearch.Location = new System.Drawing.Point(15, 52);
    this.txtSearch.Name = "txtSearch";
 this.txtSearch.Size = new System.Drawing.Size(375, 25);
       this.txtSearch.TabIndex = 1;
 this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
         // 
            // lblTitle
    // 
            this.lblTitle.AutoSize = true;
 this.lblTitle.Font = new System.Drawing.Font("¸¼Àº °íµñ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
        this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
   this.lblTitle.Size = new System.Drawing.Size(106, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ã¤ÆÃ ±â·Ï °Ë»ö";
  // 
            // panelResults
            // 
            this.panelResults.Controls.Add(this.listViewResults);
            this.panelResults.Controls.Add(this.lblResultCount);
  this.panelResults.Dock = System.Windows.Forms.DockStyle.Fill;
  this.panelResults.Location = new System.Drawing.Point(0, 100);
         this.panelResults.Name = "panelResults";
      this.panelResults.Padding = new System.Windows.Forms.Padding(10);
            this.panelResults.Size = new System.Drawing.Size(500, 400);
    this.panelResults.TabIndex = 1;
  // 
     // listViewResults
 // 
            this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
         this.columnSender,
         this.columnMessage,
            this.columnTimestamp});
      this.listViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
   this.listViewResults.Font = new System.Drawing.Font("¸¼Àº °íµñ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
          this.listViewResults.FullRowSelect = true;
            this.listViewResults.GridLines = true;
  this.listViewResults.HideSelection = false;
  this.listViewResults.Location = new System.Drawing.Point(10, 30);
   this.listViewResults.Name = "listViewResults";
     this.listViewResults.Size = new System.Drawing.Size(480, 360);
            this.listViewResults.TabIndex = 1;
    this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
    this.listViewResults.DoubleClick += new System.EventHandler(this.ListViewResults_DoubleClick);
        // 
            // columnSender
        // 
            this.columnSender.Text = "¹ß½ÅÀÚ";
        this.columnSender.Width = 100;
            // 
 // columnMessage
            // 
         this.columnMessage.Text = "¸Þ½ÃÁö";
 this.columnMessage.Width = 250;
            // 
      // columnTimestamp
   // 
          this.columnTimestamp.Text = "½Ã°£";
        this.columnTimestamp.Width = 120;
 // 
        // lblResultCount
      // 
     this.lblResultCount.AutoSize = true;
       this.lblResultCount.Dock = System.Windows.Forms.DockStyle.Top;
this.lblResultCount.Font = new System.Drawing.Font("¸¼Àº °íµñ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblResultCount.Location = new System.Drawing.Point(10, 10);
   this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
      this.lblResultCount.Size = new System.Drawing.Size(111, 20);
            this.lblResultCount.TabIndex = 0;
            this.lblResultCount.Text = "°Ë»ö °á°ú: 0°³";
     // 
      // ChatSearchForm
            // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
this.Controls.Add(this.panelResults);
            this.Controls.Add(this.panelTop);
    this.MinimumSize = new System.Drawing.Size(400, 300);
   this.Name = "ChatSearchForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Ã¤ÆÃ °Ë»ö";
       this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
      this.panelResults.ResumeLayout(false);
     this.panelResults.PerformLayout();
            this.ResumeLayout(false);

        }

 #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panelResults;
     private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.ColumnHeader columnSender;
        private System.Windows.Forms.ColumnHeader columnMessage;
        private System.Windows.Forms.ColumnHeader columnTimestamp;
        private System.Windows.Forms.Label lblResultCount;
    }
}
