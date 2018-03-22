namespace SteamAccountSwitcher
{
    partial class AddAccountPopup
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
            this.TextAccount = new System.Windows.Forms.TextBox();
            this.TextPassword = new System.Windows.Forms.TextBox();
            this.AccountNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.TextConfirm = new System.Windows.Forms.TextBox();
            this.PasswordConfirm = new System.Windows.Forms.Label();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.HintLabel = new System.Windows.Forms.Label();
            this.MatchBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextAccount
            // 
            this.TextAccount.Location = new System.Drawing.Point(12, 25);
            this.TextAccount.Name = "TextAccount";
            this.TextAccount.Size = new System.Drawing.Size(216, 20);
            this.TextAccount.TabIndex = 0;
            // 
            // TextPassword
            // 
            this.TextPassword.Location = new System.Drawing.Point(12, 96);
            this.TextPassword.Name = "TextPassword";
            this.TextPassword.PasswordChar = '*';
            this.TextPassword.Size = new System.Drawing.Size(216, 20);
            this.TextPassword.TabIndex = 1;
            this.TextPassword.UseSystemPasswordChar = true;
            this.TextPassword.TextChanged += new System.EventHandler(this.TextPasswordOnChange);
            // 
            // AccountNameLabel
            // 
            this.AccountNameLabel.AutoSize = true;
            this.AccountNameLabel.Location = new System.Drawing.Point(12, 9);
            this.AccountNameLabel.Name = "AccountNameLabel";
            this.AccountNameLabel.Size = new System.Drawing.Size(78, 13);
            this.AccountNameLabel.TabIndex = 2;
            this.AccountNameLabel.Text = "Account Name";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(12, 80);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password";
            // 
            // TextConfirm
            // 
            this.TextConfirm.Location = new System.Drawing.Point(12, 153);
            this.TextConfirm.Name = "TextConfirm";
            this.TextConfirm.PasswordChar = '*';
            this.TextConfirm.Size = new System.Drawing.Size(216, 20);
            this.TextConfirm.TabIndex = 4;
            this.TextConfirm.UseSystemPasswordChar = true;
            this.TextConfirm.TextChanged += new System.EventHandler(this.TextPasswordConfirmOnChange);
            // 
            // PasswordConfirm
            // 
            this.PasswordConfirm.AutoSize = true;
            this.PasswordConfirm.Location = new System.Drawing.Point(9, 137);
            this.PasswordConfirm.Name = "PasswordConfirm";
            this.PasswordConfirm.Size = new System.Drawing.Size(91, 13);
            this.PasswordConfirm.TabIndex = 5;
            this.PasswordConfirm.Text = "Confirm Password";
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.ForeColor = System.Drawing.Color.Green;
            this.ButtonAdd.Location = new System.Drawing.Point(154, 249);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 6;
            this.ButtonAdd.Text = "Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.ForeColor = System.Drawing.Color.Red;
            this.ButtonCancel.Location = new System.Drawing.Point(15, 249);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 7;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // HintLabel
            // 
            this.HintLabel.AutoSize = true;
            this.HintLabel.Location = new System.Drawing.Point(12, 201);
            this.HintLabel.Name = "HintLabel";
            this.HintLabel.Size = new System.Drawing.Size(64, 13);
            this.HintLabel.TabIndex = 8;
            this.HintLabel.Text = "Passwords: ";
            // 
            // MatchBox
            // 
            this.MatchBox.AutoSize = true;
            this.MatchBox.ForeColor = System.Drawing.Color.Green;
            this.MatchBox.Location = new System.Drawing.Point(82, 201);
            this.MatchBox.Name = "MatchBox";
            this.MatchBox.Size = new System.Drawing.Size(37, 13);
            this.MatchBox.TabIndex = 9;
            this.MatchBox.Text = "Match";
            // 
            // AddAccountPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 284);
            this.Controls.Add(this.MatchBox);
            this.Controls.Add(this.HintLabel);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.PasswordConfirm);
            this.Controls.Add(this.TextConfirm);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.AccountNameLabel);
            this.Controls.Add(this.TextPassword);
            this.Controls.Add(this.TextAccount);
            this.Name = "AddAccountPopup";
            this.Text = "Add new account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextAccount;
        private System.Windows.Forms.TextBox TextPassword;
        private System.Windows.Forms.Label AccountNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox TextConfirm;
        private System.Windows.Forms.Label PasswordConfirm;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label HintLabel;
        private System.Windows.Forms.Label MatchBox;
    }
}