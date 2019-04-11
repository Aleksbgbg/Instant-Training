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

            public const string MapSuffix = "_P";
        }

        public static class RCON
        {
            public const string Host = "127.0.0.1";

            public const int Port = 9002;

            public const string Password = "password";
        }

        public static readonly Dictionary<string, string> ArenaDevToInGameNameMappings = new Dictionary<string, string>
        {
            ["ARC"] = "ARCtagon",
            ["ARC_Standard"] = "ARC",
            ["Beach"] = "Salty Shores",
            ["Farm"] = "Farmstead",
            ["HoopsStadium"] = "Dunk House",
            ["Labs_CirclePillars"] = "Pillars (Labs)",
            ["Labs_Cosmic"] = "Cosmic (Labs)",
            ["Labs_DoubleGoal"] = "Double Goal (Labs)",
            ["Labs_Octagon"] = "Octagon (Labs)",
            ["Labs_Underpass"] = "Underpass (Labs)",
            ["Labs_Utopia"] = "Utopia Retro (Labs)",
            ["NeoTokyo"] = "Tokyo Underpass",
            ["NeoTokyo_Standard"] = "Neo Tokyo",
            ["Park"] = "Beckwith Park",
            ["Park_Night"] = "Beckwith Park (Midnight)",
            ["Park_Rainy"] = "Beckwith Park (Stormy)",
            ["ShatterShot"] = "Core 707",
            ["Stadium"] = "DFH Stadium",
            ["Stadium_Day"] = "DFH Stadium (Day)",
            ["Stadium_Foggy"] = "DFH Stadium (Stormy)",
            ["Stadium_Winter"] = "DFH Stadium (Snowy)",
            ["ThrowbackStadium"] = "Throwback Stadium",
            ["TrainStation"] = "Urban Central",
            ["TrainStation_Dawn"] = "Urban Central (Dawn)",
            ["TrainStation_Night"] = "Urban Central (Night)",
            ["Underwater"] = "Aquadome",
            ["UtopiaStadium"] = "Utopia Coliseum",
            ["UtopiaStadium_Dusk"] = "Utopia Coliseum (Dusk)",
            ["UtopiaStadium_Snow"] = "Utipia Coliseum (Snowy)",
            ["Wasteland"] = "Wasteland"
        };

        public static readonly string[] ArenaDevNames = ArenaDevToInGameNameMappings.Keys.ToArray();
    }
}