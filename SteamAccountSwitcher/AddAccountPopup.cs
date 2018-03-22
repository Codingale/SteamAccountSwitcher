using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccountSwitcher
{
    public partial class AddAccountPopup : Form
    {
        public bool Canceled = true;
        public string AccountName { get { return TextAccount.Text; } }
        public string Password { get { return TextPassword.Text; } }

        public AddAccountPopup()
        {
            InitializeComponent();
        }

        private void TextPasswordOnChange(object sender, EventArgs e)
        {
            ComparePasswords();
        }

        private void TextPasswordConfirmOnChange(object sender, EventArgs e)
        {
            ComparePasswords();
        }

        private void ComparePasswords()
        {
            if (TextPassword.Text == TextConfirm.Text)
            {
                MatchBox.ForeColor = Color.Green;
                MatchBox.Text = "Match";
                return;
            }
            MatchBox.ForeColor = Color.Red;
            MatchBox.Text = "Do not match.";
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Canceled = false;
            this.Hide();
        }
    }
}
