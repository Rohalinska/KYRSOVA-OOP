namespace LibrarySystem.UI.Views
{
    partial class MainForm
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
            txtBookTitle = new TextBox();
            txtBookAuthor = new TextBox();
            txtReaderName = new TextBox();
            cmbBookType = new ComboBox();
            cmbReaderBorrow = new ComboBox();
            cmbBookBorrow = new ComboBox();
            cmbBookReturn = new ComboBox();
            numLoanDays = new NumericUpDown();
            gridBooks = new DataGridView();
            gridReaders = new DataGridView();
            gridHistory = new DataGridView();
            rtbLog = new RichTextBox();
            btnAddBook = new Button();
            btnAddReader = new Button();
            btnBorrow = new Button();
            btnReturn = new Button();
            splitContainer = new SplitContainer();
            leftPanel = new FlowLayoutPanel();
            gbBook = new GroupBox();
            lblTitle = new Label();
            lblAuthor = new Label();
            lblType = new Label();
            gbReader = new GroupBox();
            lblReaderName = new Label();
            gbBorrow = new GroupBox();
            lblReaderBorrow = new Label();
            lblBookBorrow = new Label();
            lblDays = new Label();
            gbReturn = new GroupBox();
            lblBookReturn = new Label();
            rightPanel = new SplitContainer();
            tabControl = new TabControl();
            tabBooks = new TabPage();
            tabReaders = new TabPage();
            tabHistory = new TabPage();
            gbLog = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numLoanDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridReaders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            leftPanel.SuspendLayout();
            gbBook.SuspendLayout();
            gbReader.SuspendLayout();
            gbBorrow.SuspendLayout();
            gbReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rightPanel).BeginInit();
            rightPanel.Panel1.SuspendLayout();
            rightPanel.Panel2.SuspendLayout();
            rightPanel.SuspendLayout();
            tabControl.SuspendLayout();
            tabBooks.SuspendLayout();
            tabReaders.SuspendLayout();
            tabHistory.SuspendLayout();
            gbLog.SuspendLayout();
            SuspendLayout();
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(80, 27);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(220, 25);
            txtBookTitle.TabIndex = 1;
            // 
            // txtBookAuthor
            // 
            txtBookAuthor.Location = new Point(80, 57);
            txtBookAuthor.Name = "txtBookAuthor";
            txtBookAuthor.Size = new Size(220, 25);
            txtBookAuthor.TabIndex = 3;
            // 
            // txtReaderName
            // 
            txtReaderName.Location = new Point(80, 27);
            txtReaderName.Name = "txtReaderName";
            txtReaderName.Size = new Size(220, 25);
            txtReaderName.TabIndex = 1;
            // 
            // cmbBookType
            // 
            cmbBookType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBookType.Items.AddRange(new object[] { "Стандартна", "Рідкісна" });
            cmbBookType.Location = new Point(80, 87);
            cmbBookType.Name = "cmbBookType";
            cmbBookType.Size = new Size(220, 25);
            cmbBookType.TabIndex = 5;
            // 
            // cmbReaderBorrow
            // 
            cmbReaderBorrow.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReaderBorrow.Location = new Point(80, 27);
            cmbReaderBorrow.Name = "cmbReaderBorrow";
            cmbReaderBorrow.Size = new Size(220, 25);
            cmbReaderBorrow.TabIndex = 1;
            // 
            // cmbBookBorrow
            // 
            cmbBookBorrow.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBookBorrow.Location = new Point(80, 57);
            cmbBookBorrow.Name = "cmbBookBorrow";
            cmbBookBorrow.Size = new Size(220, 25);
            cmbBookBorrow.TabIndex = 3;
            // 
            // cmbBookReturn
            // 
            cmbBookReturn.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBookReturn.Location = new Point(80, 27);
            cmbBookReturn.Name = "cmbBookReturn";
            cmbBookReturn.Size = new Size(220, 25);
            cmbBookReturn.TabIndex = 1;
            // 
            // numLoanDays
            // 
            numLoanDays.Location = new Point(80, 87);
            numLoanDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            numLoanDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numLoanDays.Name = "numLoanDays";
            numLoanDays.Size = new Size(80, 25);
            numLoanDays.TabIndex = 5;
            numLoanDays.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // gridBooks
            // 
            gridBooks.AllowUserToAddRows = false;
            gridBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridBooks.Dock = DockStyle.Fill;
            gridBooks.Location = new Point(0, 0);
            gridBooks.Name = "gridBooks";
            gridBooks.ReadOnly = true;
            gridBooks.Size = new Size(742, 467);
            gridBooks.TabIndex = 0;
            // 
            // gridReaders
            // 
            gridReaders.AllowUserToAddRows = false;
            gridReaders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridReaders.Dock = DockStyle.Fill;
            gridReaders.Location = new Point(0, 0);
            gridReaders.Name = "gridReaders";
            gridReaders.ReadOnly = true;
            gridReaders.Size = new Size(742, 469);
            gridReaders.TabIndex = 0;
            // 
            // gridHistory
            // 
            gridHistory.AllowUserToAddRows = false;
            gridHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridHistory.Dock = DockStyle.Fill;
            gridHistory.Location = new Point(0, 0);
            gridHistory.Name = "gridHistory";
            gridHistory.ReadOnly = true;
            gridHistory.Size = new Size(742, 469);
            gridHistory.TabIndex = 0;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.FromArgb(30, 30, 30);
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Font = new Font("Consolas", 10F);
            rtbLog.ForeColor = Color.Lime;
            rtbLog.Location = new Point(3, 21);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(744, 175);
            rtbLog.TabIndex = 0;
            rtbLog.Text = "";
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(80, 120);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(220, 30);
            btnAddBook.TabIndex = 6;
            btnAddBook.Text = "Додати книгу";
            btnAddBook.Click += BtnAddBook_Click;
            // 
            // btnAddReader
            // 
            btnAddReader.Location = new Point(80, 60);
            btnAddReader.Name = "btnAddReader";
            btnAddReader.Size = new Size(220, 30);
            btnAddReader.TabIndex = 2;
            btnAddReader.Text = "Додати читача";
            btnAddReader.Click += BtnAddReader_Click;
            // 
            // btnBorrow
            // 
            btnBorrow.Location = new Point(180, 85);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Size = new Size(120, 30);
            btnBorrow.TabIndex = 6;
            btnBorrow.Text = "Видати";
            btnBorrow.Click += BtnBorrow_Click;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(80, 60);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(220, 30);
            btnReturn.TabIndex = 2;
            btnReturn.Text = "Повернути зараз";
            btnReturn.Click += BtnReturn_Click;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(leftPanel);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(rightPanel);
            splitContainer.Size = new Size(1100, 700);
            splitContainer.SplitterDistance = 346;
            splitContainer.TabIndex = 0;
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(gbBook);
            leftPanel.Controls.Add(gbReader);
            leftPanel.Controls.Add(gbBorrow);
            leftPanel.Controls.Add(gbReturn);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.FlowDirection = FlowDirection.TopDown;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(10);
            leftPanel.Size = new Size(346, 700);
            leftPanel.TabIndex = 0;
            leftPanel.WrapContents = false;
            // 
            // gbBook
            // 
            gbBook.Controls.Add(lblTitle);
            gbBook.Controls.Add(txtBookTitle);
            gbBook.Controls.Add(lblAuthor);
            gbBook.Controls.Add(txtBookAuthor);
            gbBook.Controls.Add(lblType);
            gbBook.Controls.Add(cmbBookType);
            gbBook.Controls.Add(btnAddBook);
            gbBook.Location = new Point(13, 13);
            gbBook.Name = "gbBook";
            gbBook.Size = new Size(320, 160);
            gbBook.TabIndex = 0;
            gbBook.TabStop = false;
            gbBook.Text = "Додати книгу";
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(10, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(60, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Назва:";
            // 
            // lblAuthor
            // 
            lblAuthor.Location = new Point(10, 60);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(60, 20);
            lblAuthor.TabIndex = 2;
            lblAuthor.Text = "Автор:";
            // 
            // lblType
            // 
            lblType.Location = new Point(10, 90);
            lblType.Name = "lblType";
            lblType.Size = new Size(60, 20);
            lblType.TabIndex = 4;
            lblType.Text = "Тип:";
            // 
            // gbReader
            // 
            gbReader.Controls.Add(lblReaderName);
            gbReader.Controls.Add(txtReaderName);
            gbReader.Controls.Add(btnAddReader);
            gbReader.Location = new Point(13, 179);
            gbReader.Name = "gbReader";
            gbReader.Size = new Size(320, 100);
            gbReader.TabIndex = 1;
            gbReader.TabStop = false;
            gbReader.Text = "Додати читача";
            // 
            // lblReaderName
            // 
            lblReaderName.Location = new Point(10, 30);
            lblReaderName.Name = "lblReaderName";
            lblReaderName.Size = new Size(60, 20);
            lblReaderName.TabIndex = 0;
            lblReaderName.Text = "ПІБ:";
            // 
            // gbBorrow
            // 
            gbBorrow.Controls.Add(lblReaderBorrow);
            gbBorrow.Controls.Add(cmbReaderBorrow);
            gbBorrow.Controls.Add(lblBookBorrow);
            gbBorrow.Controls.Add(cmbBookBorrow);
            gbBorrow.Controls.Add(lblDays);
            gbBorrow.Controls.Add(numLoanDays);
            gbBorrow.Controls.Add(btnBorrow);
            gbBorrow.Location = new Point(13, 285);
            gbBorrow.Name = "gbBorrow";
            gbBorrow.Size = new Size(320, 140);
            gbBorrow.TabIndex = 2;
            gbBorrow.TabStop = false;
            gbBorrow.Text = "Видача книги";
            // 
            // lblReaderBorrow
            // 
            lblReaderBorrow.Location = new Point(10, 30);
            lblReaderBorrow.Name = "lblReaderBorrow";
            lblReaderBorrow.Size = new Size(60, 20);
            lblReaderBorrow.TabIndex = 0;
            lblReaderBorrow.Text = "Читач:";
            // 
            // lblBookBorrow
            // 
            lblBookBorrow.Location = new Point(10, 60);
            lblBookBorrow.Name = "lblBookBorrow";
            lblBookBorrow.Size = new Size(60, 20);
            lblBookBorrow.TabIndex = 2;
            lblBookBorrow.Text = "Книга:";
            // 
            // lblDays
            // 
            lblDays.Location = new Point(10, 90);
            lblDays.Name = "lblDays";
            lblDays.Size = new Size(60, 20);
            lblDays.TabIndex = 4;
            lblDays.Text = "Днів:";
            // 
            // gbReturn
            // 
            gbReturn.Controls.Add(lblBookReturn);
            gbReturn.Controls.Add(cmbBookReturn);
            gbReturn.Controls.Add(btnReturn);
            gbReturn.Location = new Point(13, 431);
            gbReturn.Name = "gbReturn";
            gbReturn.Size = new Size(320, 100);
            gbReturn.TabIndex = 3;
            gbReturn.TabStop = false;
            gbReturn.Text = "Повернення книги";
            // 
            // lblBookReturn
            // 
            lblBookReturn.Location = new Point(10, 30);
            lblBookReturn.Name = "lblBookReturn";
            lblBookReturn.Size = new Size(60, 20);
            lblBookReturn.TabIndex = 0;
            lblBookReturn.Text = "Книга:";
            // 
            // rightPanel
            // 
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(0, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.Orientation = Orientation.Horizontal;
            // 
            // rightPanel.Panel1
            // 
            rightPanel.Panel1.Controls.Add(tabControl);
            // 
            // rightPanel.Panel2
            // 
            rightPanel.Panel2.Controls.Add(gbLog);
            rightPanel.Size = new Size(750, 700);
            rightPanel.SplitterDistance = 497;
            rightPanel.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabBooks);
            tabControl.Controls.Add(tabReaders);
            tabControl.Controls.Add(tabHistory);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(750, 497);
            tabControl.TabIndex = 0;
            // 
            // tabBooks
            // 
            tabBooks.Controls.Add(gridBooks);
            tabBooks.Location = new Point(4, 26);
            tabBooks.Name = "tabBooks";
            tabBooks.Size = new Size(742, 467);
            tabBooks.TabIndex = 0;
            tabBooks.Text = "📚 База Книг";
            // 
            // tabReaders
            // 
            tabReaders.Controls.Add(gridReaders);
            tabReaders.Location = new Point(4, 24);
            tabReaders.Name = "tabReaders";
            tabReaders.Size = new Size(742, 469);
            tabReaders.TabIndex = 1;
            tabReaders.Text = "👥 Читачі";
            // 
            // tabHistory
            // 
            tabHistory.Controls.Add(gridHistory);
            tabHistory.Location = new Point(4, 24);
            tabHistory.Name = "tabHistory";
            tabHistory.Size = new Size(742, 469);
            tabHistory.TabIndex = 2;
            tabHistory.Text = "📜 Історія";
            // 
            // gbLog
            // 
            gbLog.Controls.Add(rtbLog);
            gbLog.Dock = DockStyle.Fill;
            gbLog.Location = new Point(0, 0);
            gbLog.Name = "gbLog";
            gbLog.Size = new Size(750, 199);
            gbLog.TabIndex = 0;
            gbLog.TabStop = false;
            gbLog.Text = "Журнал подій";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(splitContainer);
            Font = new Font("Segoe UI", 10F);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Система управління бібліотекою";
            ((System.ComponentModel.ISupportInitialize)numLoanDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridReaders).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridHistory).EndInit();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            gbBook.ResumeLayout(false);
            gbBook.PerformLayout();
            gbReader.ResumeLayout(false);
            gbReader.PerformLayout();
            gbBorrow.ResumeLayout(false);
            gbReturn.ResumeLayout(false);
            rightPanel.Panel1.ResumeLayout(false);
            rightPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rightPanel).EndInit();
            rightPanel.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabBooks.ResumeLayout(false);
            tabReaders.ResumeLayout(false);
            tabHistory.ResumeLayout(false);
            gbLog.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.TextBox txtBookAuthor;
        private System.Windows.Forms.TextBox txtReaderName;
        private System.Windows.Forms.ComboBox cmbBookType;
        private System.Windows.Forms.ComboBox cmbReaderBorrow;
        private System.Windows.Forms.ComboBox cmbBookBorrow;
        private System.Windows.Forms.ComboBox cmbBookReturn;
        private System.Windows.Forms.NumericUpDown numLoanDays;
        private System.Windows.Forms.DataGridView gridBooks;
        private System.Windows.Forms.DataGridView gridReaders;
        private System.Windows.Forms.DataGridView gridHistory;
        private System.Windows.Forms.RichTextBox rtbLog;
        private Button btnAddBook;
        private Button btnAddReader;
        private Button btnBorrow;
        private Button btnReturn;
        private SplitContainer splitContainer;
        private FlowLayoutPanel leftPanel;
        private GroupBox gbBook;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblType;
        private GroupBox gbReader;
        private Label lblReaderName;
        private GroupBox gbBorrow;
        private Label lblReaderBorrow;
        private Label lblBookBorrow;
        private Label lblDays;
        private GroupBox gbReturn;
        private Label lblBookReturn;
        private SplitContainer rightPanel;
        private TabControl tabControl;
        private TabPage tabBooks;
        private TabPage tabReaders;
        private TabPage tabHistory;
        private GroupBox gbLog;
    }
}