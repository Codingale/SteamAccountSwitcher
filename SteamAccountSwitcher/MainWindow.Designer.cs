namespace SteamAccountSwitcher
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
            this.BtnSave = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.AccountsGrid = new System.Windows.Forms.DataGridView();
            this.ColAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.AddAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteOption = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AccountsGrid)).BeginInit();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(13, 415);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(86, 23);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "Save to config";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.ButtonSave);
            // 
            // LogBox
            // 
            this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBox.BackColor = System.Drawing.Color.LightGray;
            this.LogBox.Location = new System.Drawing.Point(12, 304);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(776, 105);
            this.LogBox.TabIndex = 1;
            // 
            // AccountsGrid
            // 
            this.AccountsGrid.AllowUserToAddRows = false;
            this.AccountsGrid.AllowUserToDeleteRows = false;
            this.AccountsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAccount,
            this.ColPassword});
            this.AccountsGrid.Location = new System.Drawing.Point(13, 27);
            this.AccountsGrid.Name = "AccountsGrid";
            this.AccountsGrid.ReadOnly = true;
            this.AccountsGrid.ShowEditingIcon = false;
            this.AccountsGrid.Size = new System.Drawing.Size(775, 271);
            this.AccountsGrid.TabIndex = 2;
            // 
            // ColAccount
            // 
            this.ColAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColAccount.HeaderText = "Account Name";
            this.ColAccount.Name = "ColAccount";
            this.ColAccount.ReadOnly = true;
            // 
            // ColPassword
            // 
            this.ColPassword.HeaderText = "Password";
            this.ColPassword.Name = "ColPassword";
            this.ColPassword.ReadOnly = true;
            this.ColPassword.Visible = false;
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddAccount,
            this.DeleteOption});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(800, 24);
            this.MenuBar.TabIndex = 3;
            this.MenuBar.Text = "Menu";
            // 
            // AddAccount
            // 
            this.AddAccount.Name = "AddAccount";
            this.AddAccount.Size = new System.Drawing.Size(89, 20);
            this.AddAccount.Text = "&Add Account";
            this.AddAccount.Click += new System.EventHandler(this.AddAccount_Click);
            // 
            // DeleteOption
            // 
            this.DeleteOption.Name = "DeleteOption";
            this.DeleteOption.Size = new System.Drawing.Size(98, 20);
            this.DeleteOption.Text = "&Delete selected";
            this.DeleteOption.Click += new System.EventHandler(this.DeleteOption_Click);
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(713, 415);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(75, 23);
            this.BtnLogin.TabIndex = 5;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.AccountsGrid);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainWindow";
            this.Text = "Steam Account Switcher";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.AccountsGrid)).EndInit();
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.DataGridView AccountsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPassword;
        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem AddAccount;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.ToolStripMenuItem DeleteOption;
    }
}

