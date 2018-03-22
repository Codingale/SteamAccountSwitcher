using System;
using System.Security;
using Newtonsoft.Json;

namespace SteamAccountSwitcher
{
    internal class SteamAccountDetails
    {
        public SteamAccountDetails(string AccountName, string Password)
        {
            this.AccountName = AccountName;
            this.Password = Password;
        }

        [JsonProperty(PropertyName = "Account Name")]
        public string AccountName { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }

        //[JsonProperty(PropertyName = "Salt")]
        //byte[] Salt { get; set; }

        
    }

}