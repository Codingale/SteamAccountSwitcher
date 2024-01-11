using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using System.Management;
using System.Threading.Tasks;

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
#if !(DEBUG)
                MessageBox.Show($"This program is not associated with Valve.\nNever share {ConfigFile}");
#endif
        }

        #region Login stuff
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Login();
            });
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

            #region Close Steam...
            if (steam != null && !steam.HasExited)
            {
                steam.Kill();
                steam.Dispose();
                steam = null;
            }

            foreach (Process process in Process.GetProcessesByName("steam"))
            {
                try
                {
                    KillChildren(process.Id);
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                }

            }
            Thread.Sleep(2000);
            Process[] steaminstances = Process.GetProcessesByName("steam.exe");
            if (steaminstances.Length > 0)
            {
                ForceCloseSteam();
            }
            #endregion

            #region Start Steam
            ProcessStartInfo info = new ProcessStartInfo(config.SteamPath)
            {
                Arguments = $"-login \"{UserName}\" \"{Password}"
            };
            steam = Process.Start(info);
            #endregion
        }
        #endregion

        #region Helper functions
        private void Log(string str = "")
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
        private static void KillChildren(int pid)
        {
            ManagementObjectSearcher processSearcher = new ManagementObjectSearcher
              ("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection processCollection = processSearcher.Get();

            // We must kill child processes first!
            if (processCollection != null)
            {
                foreach (ManagementObject mo in processCollection)
                {
                    KillChildren(Convert.ToInt32(mo["ProcessID"])); //kill child processes(also kills childrens of childrens etc.)
                }
            }

            // Then kill parents.
            try
            {
                Process proc = Process.GetProcessById(pid);
                if (!proc.HasExited) proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }
        }
        private static void ForceCloseSteam()
        {
            ProcessStartInfo info = new ProcessStartInfo("taskkill")
            {
                Arguments = "/f /im steam.exe"
            };
            Process.Start(info);
            //should exit out after it's done..
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
            if (string.IsNullOrEmpty(config.SteamPath))
            {
                //Detect Steam Install...
                config.SteamPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamExe", "");
                if (string.IsNullOrEmpty(config.SteamPath))
                {
                    MessageBox.Show("Could not detect Steam Install, please set it manually.");
                    ToolStripItem Steam = MenuBar.Items.Add("&Set Steam Install Location");
                    Steam.Click += SetSteamInstall;
                    return;
                }
            }
        }

        private void SetSteamInstall(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                config.SteamPath = dialog.FileName;
                SaveConfig();
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
