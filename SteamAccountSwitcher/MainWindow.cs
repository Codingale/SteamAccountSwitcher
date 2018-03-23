using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using System.Management;

namespace SteamAccountSwitcher
{
    public partial class MainWindow : Form
    {
        #region Setup Globals
        Process steam = null;
        Config config = null;
        string ConfigFile = "_DO_NOT_SHARE_THIS_FILE.json";

        Dictionary<string, bool> AccountsRegistered = new Dictionary<string, bool>();
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show($"This program is not associated with Valve.\nNever share {ConfigFile}");
        }
        
        #region Login stuff
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if (AccountsGrid.SelectedCells.Count == 0)
            {
                Log("Please select a row first.");
                return;
            }

            #region Detect and get current row, with password.
            int RowIndex = AccountsGrid.SelectedCells[0].RowIndex;
            DataGridViewRow row = AccountsGrid.Rows[RowIndex];
            string UserName = (string)row.Cells["ColAccount"].Value;
            string Password = (string)row.Cells["ColPassword"].Value;
            Log($"Logging into {UserName}");
            #endregion

            //Detect Steam Install...
            string result = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamExe","");
            if (string.IsNullOrEmpty(result)) { MessageBox.Show("Could not detect Steam Install");  return; }

            #region Close Steam...
            if (steam != null)
            {
                steam.Kill();
            }

            foreach (Process process in Process.GetProcessesByName("Steam.exe"))
            {
                try
                {
                    KillProcessAndChildren(process.Id);
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                }

            }
            Thread.Sleep(1000);
            #endregion

            #region Start Steam
            ProcessStartInfo info = new ProcessStartInfo(result)
            {
                Arguments = $"-login \"{UserName}\" \"{Password}"
            };
            steam = Process.Start(info);
            #endregion
        }
        #endregion

        #region Helper functions
        private void Log(string str="")
        {
            Action act = new Action(() => { LogBox.AppendText(str + "\r\n"); });
            if (LogBox.InvokeRequired)
            {
                LogBox.Invoke(act);
            }
            else
            {
                act();
            }
        }

        /// <summary>
        /// Kill a process, and all of its children.
        /// </summary>
        /// <param name="pid">Process ID.</param>
        private static void KillProcessAndChildren(int pid)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection moc = searcher.Get();
            foreach (ManagementObject mo in moc)
            {
                KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
            }
            try
            {
                Process proc = Process.GetProcessById(pid);
                proc.CloseMainWindow();
                proc.Close();
                proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }
        }
        #endregion

        #region Account management.
        private void AddAccount_Click(object sender, EventArgs e)
        {
            AddAccountPopup popup = new AddAccountPopup();
            popup.ShowDialog();

            if (AccountsRegistered.ContainsKey(popup.AccountName))
            {
                MessageBox.Show("Account already exists, please delete it first.");
                return;
            }

            AccountsRegistered.Add(popup.AccountName, true);
            AccountsGrid.Rows.Add(popup.AccountName, popup.Password);

            popup.Close();
            popup.Dispose();
        }
        
        private void DeleteOption_Click(object sender, EventArgs e)
        {
            if (AccountsGrid.Rows.Count == 0) { Log("Please select entry(s) you wish to remove."); return; }

            foreach (DataGridViewCell item in AccountsGrid.SelectedCells)
            {
                AccountsGrid.Rows.RemoveAt(item.RowIndex);
            }

            foreach (DataGridViewRow item in AccountsGrid.SelectedRows)
            {
                AccountsGrid.Rows.RemoveAt(item.Index);
            }
            AccountsRegistered = new Dictionary<string, bool>();
            foreach (DataGridViewRow row in AccountsGrid.Rows)
            {
                string AccountName = (string)row.Cells["ColAccount"].Value;
                AccountsRegistered.Add(AccountName, true);
            }
        }
        #endregion

        #region Config
        private void ButtonSave(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (!File.Exists(ConfigFile))
            {
                File.Create(ConfigFile).Dispose();
                config = new Config();
                return;
            }

            string rawConfig = File.ReadAllText(ConfigFile);
            config = JsonConvert.DeserializeObject<Config>(rawConfig);
            if (config == null)
            {
                config = new Config();
            }

            foreach (SteamAccountDetails account in config.accounts.Values)
            {
                if (AccountsRegistered.ContainsKey(account.AccountName)) { continue; }

                AccountsRegistered.Add(account.AccountName, true);
                AccountsGrid.Rows.Add(account.AccountName, account.Password);

            }
        }

        private void SaveConfig()
        {

            config.accounts = new Dictionary<string, SteamAccountDetails>();
            foreach (DataGridViewRow row in AccountsGrid.Rows)
            {
                string AccountName = (string)row.Cells["ColAccount"].Value;
                string Password = (string)row.Cells["ColPassword"].Value;

                if (string.IsNullOrEmpty(AccountName) || string.IsNullOrEmpty(Password)) { continue; }

                SteamAccountDetails account = new SteamAccountDetails(AccountName, Password);
                config.accounts.Add(AccountName, account);
            }
            File.WriteAllText(ConfigFile, JsonConvert.SerializeObject(config, Formatting.Indented));
        }
        #endregion

    }
}
