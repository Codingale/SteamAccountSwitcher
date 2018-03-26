using System.Collections.Generic;
using Newtonsoft.Json;

namespace SteamAccountSwitcher
{
    internal class Config
    {
        [JsonProperty(PropertyName = "Steam Install Location")]
        public string SteamPath = "";
        public Dictionary<string, SteamAccountDetails> accounts = new Dictionary<string, SteamAccountDetails>();
    }
}