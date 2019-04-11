namespace Instant.Training.UI
{
    using System.Collections.Generic;

    public static class Constants
    {
        public const string AppName = "Rocket League Instant Training Mod";

        public static readonly string[] ArenaDevNames =
        {
            "ARC",
            "ARC_Standard",
            "Beach",
            "Farm",
            "HoopsStadium",
            "Labs_CirclePillars",
            "Labs_Cosmic",
            "Labs_DoubleGoal",
            "Labs_Octagon",
            "Labs_Underpass",
            "Labs_Utopia",
            "NeoTokyo",
            "NeoTokyo_Standard",
            "Park",
            "Park_Night",
            "Park_Rainy",
            "ShatterShot",
            "Stadium",
            "Stadium_Day",
            "Stadium_Foggy",
            "Stadium_Winter",
            "ThrowbackStadium",
            "TrainStation",
            "TrainStation_Dawn",
            "TrainStation_Night",
            "Underwater",
            "UtopiaStadium",
            "UtopiaStadium_Dusk",
            "UtopiaStadium_Snow",
            "Wasteland"
        };

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
    }
}