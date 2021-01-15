using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessImplementation
{
    public class ClientSettings
    {
        public string Identifier_IP { get; set; }
        public List<ClientSetting> Settings { get; set; } = new List<ClientSetting>();

        public List<ClientSetting> GetDefaultSettings() //Add new settings here
        {
            var ret = new List<ClientSetting>() { new ClientSetting.DashboardSetting(), new ClientSetting.AwaySetting() };

            ret.ForEach(x => x.LoadConfig());

            return ret;
        }

        public void AddClientSetting(ClientSetting clientSetting)
        {
            if (Settings.Any(x => x.GetType() == clientSetting.GetType()) == false)
            {
                Settings.Add(clientSetting);
            }
        }

        public ClientSetting GetClientSetting(ClientSetting.ClientSettingTypes clientSettingType)
        {
            ClientSetting ret = null;

            ret = Settings.Where(x => x.ClientSettingType == clientSettingType).FirstOrDefault();

            return ret;
        }
    }

    public class ClientSetting
    {
        [JsonIgnore]
        public virtual string Name { get; set; }
        public virtual ClientSettingTypes ClientSettingType { get; set; }

        public enum ClientSettingTypes
        {
            Dashboard,
            Away
        }

        public virtual void LoadConfig() { }

        public class DashboardSetting : ClientSetting
        {
            public override string Name => "Dashboard";

            [Display("Bopobs")]
            [DisplayType(DisplayTypeAttribute.DisplayTypes.text)]
            public string Test { get; set; }

            public override void LoadConfig()
            {
                this.ClientSettingType = ClientSettingTypes.Dashboard;
            }
        }

        public class AwaySetting : ClientSetting
        {
            public override string Name => "Away";

            [Display("AFK Time in Minutes")]
            [DisplayOrder(0)]
            [DisplayType(DisplayTypeAttribute.DisplayTypes.integer)]
            public int AFKTime { get; set; }

            [Display("Display Time")]
            [DisplayOrder(1)] //make this work in the future
            [DisplayType(DisplayTypeAttribute.DisplayTypes.checkbox)]
            public bool DisplayTime { get; set; } = true;

            [Display("Display Date")]
            [DisplayOrder(1)]
            [DisplayType(DisplayTypeAttribute.DisplayTypes.checkbox)]
            public bool DisplayDate { get; set; }

            public override void LoadConfig()
            {
                this.ClientSettingType = ClientSettingTypes.Away;
            }
        }
    }
}
