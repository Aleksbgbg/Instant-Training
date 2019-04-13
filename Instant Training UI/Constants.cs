namespace Instant.Training.UI
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Constants
    {
        public const string AppName = "Rocket League Instant Training Mod";

        public static class Mod
        {
            public const string EnabledCvar = "instant_training_enabled";

            public const string TrainingMapCvar = "instant_training_map";
        }

        public static class RCON
        {
            public const string Host = "127.0.0.1";

            public const int Port = 9002;

            public const string Password = "password";
        }

        public static class DataNames
        {
            public const string ArenaIndex = "Arena Index";
        }

        public static class Steam
        {
            public const string Win32RegistryKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam";

            public const string Win64RegistryKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam";

            public const string InstallPathValue = "InstallPath";

            public const string LibraryFoldersPath = @"steamapps\libraryfolders.vdf";

            public const string RocketLeaguePath = @"steamapps\common\rocketleague";
        }

        public static readonly Dictionary<string, string> ArenaDevToInGameNameMappings = new Dictionary<string, string>
        {
            ["Underwater_P"] = "Aquadome",
            ["Park_P"] = "Beckwith Park",
            ["Park_Rainy_P"] = "Beckwith Park (Stormy)",
            ["Park_Night_P"] = "Beckwith Park (Midnight)",
            ["CS_P"] = "Champions Field",
            ["CS_Day_P"] = "Champions Field (Day)",
            ["Stadium_P"] = "DFH Stadium",
            ["Stadium_Day_P"] = "DFH Stadium (Day)",
            ["Stadium_Foggy_P"] = "DFH Stadium (Stormy)",
            ["Stadium_Winter_P"] = "DFH Stadium (Snowy)",
            ["EuroStadium_P"] = "Mannfield",
            ["EuroStadium_Rainy_P"] = "Mannfield (Stormy)",
            ["EuroStadium_Night_P"] = "Mannfield (Night)",
            ["EuroStadium_SnowNight_P"] = "Mannfield (Snowy)",
            ["NeoTokyo_Standard_P"] = "Neo Tokyo",
            ["Beach_P"] = "Salty Shores",
            ["ARC_Standard_P"] = "Starbase ARC",
            ["TrainStation_P"] = "Urban Central",
            ["TrainStation_Dawn_P"] = "Urban Central (Dawn)",
            ["TrainStation_Night_P"] = "Urban Central (Night)",
            ["UtopiaStadium_P"] = "Utopia Coliseum",
            ["UtopiaStadium_Dusk_P"] = "Utopia Coliseum (Dusk)",
            ["UtopiaStadium_Snow_P"] = "Utipia Coliseum (Snowy)",
            ["Wasteland_S_P"] = "Wasteland",
            ["Wasteland_Night_S_P"] = "Wasteland (Night)",
            ["CS_HW_P"] = "Rivals Arena",
            ["Farm_P"] = "Farmstead",
            ["HoopsStadium_P"] = "Dunk House",
            ["ShatterShot_P"] = "Core 707",
            ["ARC_P"] = "ARCtagon",
            ["Wasteland_P"] = "Badlands",
            ["Wasteland_Night_P"] = "Badlands (Night)",
            ["ThrowbackStadium_P"] = "Throwback Stadium",
            ["NeoTokyo_P"] = "Tokyo Underpass",
            ["Labs_CirclePillars_P"] = "Pillars (Labs)",
            ["Labs_Cosmic_P"] = "Cosmic (Labs)",
            ["Labs_Cosmic_V4_P"] = "Cosmic (Labs) V4",
            ["Labs_DoubleGoal_P"] = "Double Goal (Labs)",
            ["Labs_DoubleGoal_V2_P"] = "Double Goal (Labs) V2",
            ["Labs_Octagon_02_P"] = "Octagon (Labs)",
            ["Labs_Underpass_P"] = "Underpass (Labs)",
            ["Labs_Utopia_P"] = "Utopia Retro (Labs)",
        };

        public static readonly string[] ArenaDevNames = ArenaDevToInGameNameMappings.Keys.ToArray();
    }
}