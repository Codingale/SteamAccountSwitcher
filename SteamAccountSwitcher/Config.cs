using System.Collections.Generic;

namespace SteamAccountSwitcher
{
    internal class Config
    {
        public Dictionary<string, SteamAccountDetails> accounts = new Dictionary<string, SteamAccountDetails>();
    }
}