// Licensed to Laurent Ellerbach and contributors under one or more agreements.
// Laurent Ellerbach and contributors license this file to you under the MIT license.

namespace LegoDimensions.Tag;

/// <summary>
/// Vehicle class for Lego Dimensions.
/// </summary>
public class Vehicle : ILegoTag
{
    /// <summary>
    /// The ID of the vehicle.
    /// </summary>
    public ushort Id { get; set; }

    /// <summary>
    /// The name of the vehicle.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The world the vehicle is from.
    /// </summary>
    public string World { get; set; }

    /// <summary>
    /// Gets or sets the list of abilities of the vehicle.
    /// </summary>
    public List<string> Abilities { get; set; }

    /// <summary>
    /// Gets the vehicle rebuild.
    /// </summary>
    public VehicleRebuild Rebuild
    {
        get
        {
            int id = Id - 1000;
            if (id < 155)
            {
                return (VehicleRebuild)(id % 3);
            }

            return (VehicleRebuild)((id + 1) % 3);
        }
    }

    /// <summary>
    /// The vehicle's constructor.
    /// </summary>
    /// <param name="id">The ID of the vehicle.</param>
    /// <param name="name">The name of the vehicle.</param>
    /// <param name="world">The world the vehicle is from.</param>
    public Vehicle(ushort id, string name, string world, List<string> abilities)
    {
        Id = id;
        Name = name;
        World = world;
        Abilities = abilities;
    }

    /// <summary>
    /// The list of all known vehicles.
    /// </summary>
    public static readonly List<Vehicle> Vehicles =
    [
        new(0000, "Empty Vehicle Tag", "Unknown", [""]),

        new(1000, "Police Car", "The Lego Movie", ["Accelerator Switches", "Tow Bar"]),
        new(1001, "Aerial Squad Car", "The Lego Movie",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Accelerator Switches", "Tow Bar"]),
        new(1002, "Missile Striker", "The Lego Movie",
        [
            "Flying", "Flight Docks and Flight Cargo Hooks", "Silver LEGO Blowup", "Accelerator Switches",
            "Tow Bar"
        ]),

        new(1003, "Gravity Sprinter", "The Simpsons", ["Accelerator Switches"]),
        new(1004, "Street Shredder", "The Simpsons",
            ["Accelerator Switches", "Speed Boost", "Tow Bar"]),
        new(1005, "Sky Clobberer", "The Simpsons",
        [
            "Flying", "Flight Docks and Flight Cargo Hooks", "Special Attack", "Accelerator Switches",
            "Speed Boost", "Tow Bar"
        ]),

        new(1006, "Batmobile", "DC Comics", ["Accelerator Switches"]),
        new(1007, "Batblaster", "DC Comics",
            ["Accelerator Switches", "Sonar Smash", "Tow Bar"]),
        new(1008, "Sonic Batray", "DC Comics",
            ["Accelerator Switches", "Special Attack", "Sonar Smash", "Tow Bar"]),

        new(1009, "Benny's Spaceship", "The Lego Movie",
            ["Flying", "Flight Docks and Flight Cargo Hooks"]),
        new(1010, "Lasercraft", "The Lego Movie",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Gold LEGO Blowup"]),
        new(1011, "The Annihilator", "The Lego Movie",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Silver LEGO Blowup", "Gold LEGO Blowup"]),

        new(1012, "DeLorean Time Machine", "Back to the Future",
            ["Accelerator Switches", "Time Travel"]),
        new(1013, "Ultra Time Machine", "Back to the Future",
            ["Special Attack", "Electricity", "Tow Bar", "Accelerator Switches", "Time Travel"]),
        new(1014, "Electric Time Machine", "Back to the Future",
        [
            "Silver LEGO Blowup", "Flying", "Flight Docks and Flight Cargo Hooks", "Time Travel",
            "Special Attack", "Electricity", "Tow Bar"
        ]),

        new(1015, "Hoverboard", "Back to the Future", ["Hover"]),
        new(1016, "Cyclone Board", "Back to the Future", ["Special Attack", "Hover"]),
        new(1017, "Ultimate Hoverjet", "Back to the Future",
            ["Flying", "Special Attack", "Silver LEGO Blowup", "Hover"]),

        new(1018, "Eagle Interceptor", "Lego Legends of Chima",
            ["Flying", "Flight Docks and Flight Cargo Hooks"]),
        new(1019, "Eagle Skyblazer", "Lego Legends of Chima",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Speed Boost", "Silver LEGO Blowup"]),
        new(1020, "Eagle Swoop Diver", "Lego Legends of Chima",
        [
            "Flying", "Flight Docks and Flight Cargo Hooks", "Special Attack", "Gold LEGO Blowup",
            "Speed Boost", "Silver LEGO Blowup"
        ]),

        new(1021, "Swamp Skimmer", "Lego Legends of Chima", ["Sail"]),
        new(1022, "Croc Command Sub", "Lego Legends of Chima",
            ["Sail", "Speed Boost", "Special Attack"]),
        new(1023, "Cragger's Fireship", "Lego Legends of Chima",
            ["Dive", "Silver LEGO Blowup", "Sail", "Speed Boost", "Special Attack"]),

        new(1024, "Cyber Guard", "DC Comics", ["Mech Walker"]),
        new(1025, "Cyber-Wrecker", "DC Comics",
            ["Mech Walker", "Super Strength", "Dig"]),
        new(1026, "Laser Robot Walker", "DC Comics",
            ["Gold LEGO Blowup", "Mech Walker", "Super Strength", "Dig"]),

        new(1027, "K9", "Doctor Who", ["Silver LEGO Blowup"]),
        new(1028, "K9 Ruff Rover", "Doctor Who",
            ["Sonar Smash", "Silver LEGO Blowup"]),
        new(1029, "K9 Laser Cutter", "Doctor Who",
            ["Gold LEGO Blowup", "Sonar Smash", "Silver LEGO Blowup"]),

        new(1030, "TARDIS", "Doctor Who",
            ["TARDIS Travel", "Stealth", "Flying", "Flight Docks and Flight Cargo Hooks"]),
        new(1031, "Laser-Pulse TARDIS", "Doctor Who",
            ["TARDIS Travel", "Stealth", "Flying", "Gold LEGO Blowup"]),
        new(1032, "Energy-Burst TARDIS", "Doctor Who",
            ["TARDIS Travel", "Stealth", "Flying", "Flight Docks and Flight Cargo Hooks", "Gold LEGO Blowup"]),

        new(1033, "Emmet's Excavator", "The Lego Movie",
            ["Accelerator Switches", "Dig"]),
        new(1034, "The Destroydozer", "The Lego Movie",
            ["Accelerator Switches", "Dig", "Tow Bar"]),
        new(1035, "Destruct-o-Mech", "The Lego Movie",
            ["Mech Walker", "Super Strength", "Accelerator Switches", "Dig", "Tow Bar"]),

        new(1036, "Winged Monkey", "Wizard of Oz", [""]),
        new(1037, "Battle Monkey", "Wizard of Oz",
            ["Special Attack", "Silver LEGO Blowup", "Flying"]),
        new(1038, "Commander Monkey", "Wizard of Oz",
            ["Flying", "Special Weapon", "Sonar Smash", "Special Attack", "Silver LEGO Blowup"]),

        new(1039, "Axe Chariot", "Lord of the Rings",
            ["Accelerator Switches", "Tow Bar"]),
        new(1040, "Axe Hurler", "Lord of the Rings",
            ["Accelerator Switches", "Special Attack", "Tow Bar"]),
        new(1041, "Soaring Chariot", "Lord of the Rings",
            ["Accelerator Switches", "Flying", "Flight Docks and Flight Cargo Hooks", "Tow Bar", "Special Attack"]),

        new(1042, "Shelob the Great", "Lord of the Rings", ["Dig"]),
        new(1043, "8-Legged Stalker", "Lord of the Rings",
            ["Super Strength", "Special Attack", "Dig"]),
        new(1044, "Poison Slinger", "Lord of the Rings",
            ["Special Attack", "Dig", "Super Strength"]),

        new(1045, "Homer's Car", "The Simpsons", ["Accelerator Switches", "Tow Bar"]),
        new(1046, "The SubmaHomer", "The Simpsons",
            ["Dive", "Silver LEGO Blowup", "Accelerator Switches", "Tow Bar"]),
        new(1047, "The Homecraft", "The Simpsons",
            ["Sail", "Dive", "Silver LEGO Blowup", "Accelerator Switches", "Tow Bar"]),

        new(1048, "Taunt-o-Vision", "The Simpsons", ["Taunt", "Silver LEGO Blowup"]),
        new(1049, "The MechaHomer", "The Simpsons",
            ["Gold LEGO Blowup", "Taunt", "Silver LEGO Blowup"]),
        new(1050, "Blast Cam", "The Simpsons",
            ["Special Weapon", "Gold LEGO Blowup", "Taunt", "Silver LEGO Blowup"]),

        new(1051, "Velociraptor", "Jurassic World", ["Guardian Ability", "Vine Cut"]),
        new(1052, "Spike Attack Raptor", "Jurassic World",
            ["Special Attack", "Vine Cut", "Guardian Ability", "Super Strength"]),
        new(1053, "Venom Raptor", "Jurassic World",
            ["Super Strength", "Dig", "Vine Cut", "Guardian Ability", "Special Attack"]),

        new(1054, "Gyrosphere", "Jurassic World", ["Gyrosphere Switch"]),
        new(1055, "Sonic Beam Gyrosphere", "Jurassic World",
            ["Gyrosphere Switch", "Sonar Smash"]),
        new(1056, "Speed Boost Gyrosphere", "Jurassic World",
            ["Gyrosphere Switch", "Speed Boost", "Sonar Smash"]),

        new(1057, "Clown Bike", "The Simpsons", ["Accelerator Switches"]),
        new(1058, "Cannon Bike", "The Simpsons",
            ["Accelerator Switches", "Special Attack", "Tow Bar"]),
        new(1059, "Anti-Gravity Rocket Bike", "The Simpsons",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Accelerator Switches", "Special Attack", "Tow Bar"]),

        new(1060, "Mighty Lion Rider", "Lego Legends of Chima",
            ["Accelerator Switches"]),
        new(1061, "Lion Blazer", "Lego Legends of Chima",
            ["Special Attack", "Tow Bar", "Accelerator Switches"]),
        new(1062, "Fire Lion", "Lego Legends of Chima",
            ["Special Weapon", "Special Attack", "Tow Bar", "Accelerator Switches"]),

        new(1063, "Arrow Launcher", "Lord of the Rings", ["Accelerator Switches"]),
        new(1064, "Seeking Shooter", "Lord of the Rings",
            ["Accelerator Switches", "Special Attack", "Tow Bar"]),
        new(1065, "Triple Ballista", "Lord of the Rings",
            ["Accelerator Switches", "Special Weapon", "Special Attack", "Tow Bar"]),

        new(1066, "Mystery Machine", "Scooby-Doo", ["Accelerator Switches"]),
        new(1067, "Mystery Tow", "Scooby-Doo", ["Accelerator Switches", "Tow Bar"]),
        new(1068, "Mystery Monster", "Scooby-Doo",
            ["Accelerator Switches", "Water Spray", "Tow Bar"]),

        new(1069, "Boulder Bomber", "Lego Ninjago",
            ["Flying", "Flight Docks and Flight Cargo Hooks"]),
        new(1070, "Boulder Blaster", "Lego Ninjago",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Silver LEGO Blowup"]),
        new(1071, "Cyclone Jet", "Lego Ninjago",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Special Attack", "Silver LEGO Blowup"]),

        new(1072, "Storm Fighter", "Lego Ninjago",
            ["Flying", "Flight Docks and Flight Cargo Hooks"]),
        new(1073, "Lightning Jet", "Lego Ninjago",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Gold LEGO Blowup", "Electricity"]),
        new(1074, "Electro-Shooter", "Lego Ninjago",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Gold LEGO Blowup", "Electricity", "Special Attack"]),

        new(1075, "Blade Bike", "Lego Ninjago", ["Accelerator Switches"]),
        new(1076, "Flying Fire Bike", "Lego Ninjago",
            ["Accelerator Switches", "Special Attack", "Flying", "Flight Docks and Flight Cargo Hooks"]),
        new(1077, "Blades of Fire", "Lego Ninjago",
            ["Accelerator Switches", "Special Attack", "Flying", "Flight Docks and Flight Cargo Hooks"]),

        new(1078, "Samurai Mech", "Lego Ninjago", ["Mech Walker", "Super Strength"]),
        new(1079, "Samurai Shooter", "Lego Ninjago",
            ["Silver LEGO Blowup", "Mech Walker", "Super Strength"]),
        new(1080, "Soaring Samurai Mech", "Lego Ninjago",
        [
            "Flying", "Flight Docks and Flight Cargo Hooks", "Silver LEGO Blowup", "Mech Walker",
            "Super Strength"
        ]),

        new(1081, "Companion Cube", "Portal 2", ["Weight Switch"]),
        new(1082, "Laser Deflector", "Portal 2", ["Laser Deflector", "Weight Switch"]),
        new(1083, "Gold Heart Emitter", "Portal 2",
            ["Hearts Regenerate", "Weight Switch", "Laser Deflector"]),

        new(1084, "Sentry Turret", "Portal 2", ["Turret Switches"]),
        new(1085, "Turret Striker", "Portal 2",
            ["Gold LEGO Blowup", "Turret Switches"]),
        new(1086, "Flying Turret Carrier", "Portal 2",
        [
            "Silver LEGO Blowup", "Flying", "Flight Docks and Flight Cargo Hooks", "Gold LEGO Blowup",
            "Turret Switches"
        ]),

        new(1087, "Scooby Snack", "Scooby-Doo", ["Super Strength"]),
        new(1088, "Scooby Fire Snack", "Scooby-Doo",
            ["Gold LEGO Blowup", "Super Strength"]),
        new(1089, "Scooby Ghost Snack", "Scooby-Doo",
            ["Stealth", "Gold LEGO Blowup", "Super Strength"]),

        new(1090, "Cloud Cukko Car", "The Lego Movie",
            ["Flying", "Flight Docks and Flight Cargo Hooks"]),
        new(1091, "X-Stream Soaker", "The Lego Movie",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Water Spray"]),
        new(1092, "Rainbow Cannon", "The Lego Movie",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Special Attack", "Water Spray"]),

        new(1093, "Invisible Jet", "DC Comics",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Stealth"]),
        new(1094, "Stealth Laser Shooter", "DC Comics",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Stealth", "Gold LEGO Blowup"]),
        new(1095, "Torpedo Bomber", "DC Comics",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Stealth", "Gold LEGO Blowup", "Silver LEGO Blowup"]),

        new(1096, "Ninja Copter", "Lego Ninjago",
            ["Flying", "Flight Docks and Flight Cargo Hooks"]),
        new(1097, "Glaciator", "Lego Ninjago",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Special Attack"]),
        new(1098, "Freeze Fighter", "Lego Ninjago",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Gold LEGO Blowup", "Special Attack"]),

        new(1099, "Traveling Time Train", "Back to the Future",
            ["Accelerator Switches", "Time Travel"]),
        new(1100, "Flying Time Train ", "Back to the Future",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Time Travel", "Accelerator Switches", "Tow Bar"]),
        new(1101, "Missile Blast Time Train", "Back to the Future",
        [
            "Flying", "Flight Docks and Flight Cargo Hooks", "Silver LEGO Blowup", "Time Travel",
            "Accelerator Switches", "Tow Bar"
        ]),

        new(1102, "Aqua Watercraft", "DC Comics", ["Sail", "Dive"]),
        new(1103, "Seven Seas Speeder", "DC Comics",
            ["Speed Boost", "Special Weapon", "Sail", "Dive"]),
        new(1104, "Trident of Fire", "DC Comics",
            ["Silver LEGO Blowup", "Special Attack", "Speed Boost", "Special Weapon", "Sail", "Dive"]),

        new(1105, "Drill Driver", "DC Comics",
            ["Accelerator Switches", "Drill", "Dig"]),
        new(1106, "Bane Dig 'n' Drill", "DC Comics",
            ["Tow Bar", "Dig", "Drill", "Accelerator Switches"]),
        new(1107, "Bane Drill 'n' Blast", "DC Comics",
            ["Special Attack", "Silver LEGO Blowup", "Drill", "Dig", "Accelerator Switches", "Tow Bar"]),

        new(1108, "Quinn-mobile", "DC Comics", ["Accelerator Switches"]),
        new(1109, "Quinn Ultra Racer", "DC Comics",
            ["Speed Boost", "Tow Bar", "Accelerator Switches"]),
        new(1110, "Missile Launcher", "DC Comics",
            ["Silver LEGO Blowup", "Speed Boost", "Tow Bar", "Accelerator Switches"]),

        new(1111, "The Jokers Chopper", "DC Comics",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Special Attack"]),
        new(1112, "Mischievous Missile Blaster", "DC Comics",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Special Attack"]),
        new(1113, "Lock 'n' Laser Jet", "DC Comics",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Gold LEGO Blowup", "Special Attack"]),

        new(1114, "Hover Pod", "DC Comics",
            ["Flying", "Flight Docks and Flight Cargo Hooks"]),
        new(1115, "Krypton Striker", "DC Comics",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Special Weapon"]),
        new(1116, "Hover Pod 2", "DC Comics",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Silver LEGO Blowup", "Special Weapon"]),

        new(1117, "Dalek", "Doctor Who", [""]),
        new(1118, "Fire 'n' Ride Dalek", "Doctor Who", ["Gold LEGO Blowup"]),
        new(1119, "Silver Shooter Dalek", "Doctor Who",
            ["Flying", "Flight Docks and Flight Cargo Hooks", "Silver LEGO Blowup", "Gold LEGO Blowup"]),

        new(1120, "Ecto-1", "Ghostbusters", ["Accelerator Switches"]),
        new(1121, "Ecto-1 Blaster", "Ghostbusters",
            ["Accelerator Switches", "Water Spray", "Tow Bar"]),
        new(1122, "Ecto-1 Water Diver", "Ghostbusters",
            ["Dive", "Silver LEGO Blowup", "Accelerator Switches", "Water Spray", "Tow Bar"]),

        new(1123, "Ghost Trap", "Ghostbusters", ["Ghost Trap"]),
        new(1124, "Ghost Stun'n'Trap", "Ghostbusters",
            ["Ghost Trap", "Special Attack"]),
        new(1125, "Proton Zapper", "Ghostbusters",
            ["Gold LEGO Blowup", "Special Weapon", "Ghost Trap", "Special Attack"]),

        new(1126, "Unknown", "Unknown", ["Unknown"]),
        new(1127, "Unknown", "Unknown", ["Unknown"]),
        new(1128, "Unknown", "Unknown", ["Unknown"]),

        new(1129, "Unknown", "Unknown", ["Unknown"]),
        new(1130, "Unknown", "Unknown", ["Unknown"]),
        new(1131, "Unknown", "Unknown", ["Unknown"]),

        new(1132, "Llyod's Golden Dragon", "Lego Ninjago", ["Flying"]),
        new(1133, "Sword Projector Dragon", "Lego Ninjago",
            ["Flying", "Special Attack"]),
        new(1134, "Llyod's Golden Dragon 2", "Lego Ninjago", ["Unknown"]),

        new(1135, "Unknown", "Unknown", ["Unknown"]),
        new(1136, "Unknown", "Unknown", ["Unknown"]),
        new(1137, "Unknown", "Unknown", ["Unknown"]),

        new(1138, "Unknown", "Unknown", ["Unknown"]),
        new(1139, "Unknown", "Unknown", ["Unknown"]),
        new(1140, "Unknown", "Unknown", ["Unknown"]),

        new(1141, "Unknown", "Unknown", ["Unknown"]),
        new(1142, "Unknown", "Unknown", ["Unknown"]),
        new(1143, "Unknown", "Unknown", ["Unknown"]),

        new(1144, "Mega Flight Dragon", "Lego Ninjago",
            ["Flying", "Special Weapon", "Special Attack"]),
        new(1145, "Mega Flight Dragon 1", "Lego Ninjago", ["Unknown"]),
        new(1146, "Mega Flight Dragon 2", "Lego Ninjago", ["Unknown"]),

        new(1147, "Unknown", "Unknown", ["Unknown"]),
        new(1148, "Unknown", "Unknown", ["Unknown"]),
        new(1149, "Unknown", "Unknown", ["Unknown"]),

        new(1150, "Unknown", "Unknown", ["Unknown"]),
        new(1151, "Unknown", "Unknown", ["Unknown"]),
        new(1152, "Unknown", "Unknown", ["Unknown"]),

        new(1153, "Unknown", "Unknown", ["Unknown"]),
        new(1154, "Unknown", "Unknown", ["Unknown"]),

        new(1155, "Flying White Dragon", "Lego Ninjago", ["Flying"]),
        new(1156, "Golden Fire Dragon", "Lego Ninjago", ["Flying", "Special Attack"]),
        new(1157, "Ultra Destruction Dragon", "Lego Ninjago",
            ["Flying", "Special Weapon", "Special Attack"]),

        new(1158, "Arcade Machine", "Midway Arcade", ["Arcade Docks"]),
        new(1159, "8-bit Shooter", "Midway Arcade", ["Flying", "Arcade Docks"]),
        new(1160, "The Pixelator", "Midway Arcade",
            ["Special Attack", "Arcade Docks", "Flying"]),

        new(1161, "G-61555 Spy Hunter", "Midway Arcade",
            ["Accelerator Switches", "Tow Bar"]),
        new(1162, "The Interdiver", "Midway Arcade",
            ["Sail", "Silver LEGO Blowup", "Accelerator Switches", "Tow Bar"]),
        new(1163, "Aerial Spyhunter", "Midway Arcade",
        [
            "Flying", "Flight Docks and Flight Cargo Hooks", "Gold LEGO Blowup", "Sail", "Silver LEGO Blowup",
            "Accelerator Switches", "Tow Bar"
        ]),

        new(1164, "Slime Shooter", "Ghostbusters", ["Slime Bolts", "Special Attack"]),
        new(1165, "Slime Exploder", "Ghostbusters",
            ["Slime Beam", "Slime Bolts", "Special Attack"]),
        new(1166, "Slime Streamer", "Ghostbusters",
            ["Slime Bomb", "Silver LEGO Blowup", "Slime Beam", "Slime Bolts", "Special Attack"]),

        new(1167, "Terror Dog", "Ghostbusters", ["Guardian Ability"]),
        new(1168, "Terror Dog Destroyer", "Ghostbusters",
            ["Silver LEGO Blowup", "Dig", "Guardian Ability"]),
        new(1169, "Soaring Terror Dog", "Ghostbusters",
            ["Flying", "Special Weapon", "Silver LEGO Blowup", "Dig", "Guardian Ability"]),

        new(1170, "Tandem War Elefant", "Adventure Time",
            ["Hover", "Gold LEGO Blowup", "Guardian Ability"]),
        new(1171, "Cosmic Squid", "Adventure Time",
        [
            "Flight Docks and Flight Cargo Hooks", "Tow Bar", "Water Spray", "Hover", "Gold LEGO Blowup",
            "Guardian Ability"
        ]),
        new(1172, "Psychic Submarine", "Adventure Time",
        [
            "Gold LEGO Blowup", "Underwater Interactions", "Underwater Drone",
            "Flight Docks and Flight Cargo Hooks", "Tow Bar", "Water Spray", "Hover", "Guardian Ability"
        ]),

        new(1173, "BMO", "Adventure Time",
            ["BMO Docks", "Illumination", "Guardian Ability"]),
        new(1174, "DOGMO", "Adventure Time",
            ["Dig", "Illumination", "Guardian Ability", "BMO Docks"]),
        new(1175, "SNAKEMO", "Adventure Time",
            ["Electricity", "Dig", "Illumination", "Guardian Ability", "BMO Docks"]),

        new(1176, "Jakemobile", "Adventure Time",
            ["Tow Bar", "Guardian Ability", "Accelerator Switches"]),
        new(1177, "Snail Dude Jake", "Adventure Time",
            ["Sonar Smash", "Super Jump", "Super Strength", "Guardian Ability", "Tow Bar", "Accelerator Switches"]),
        new(1178, "Hover Jake", "Adventure Time",
        [
            "Sail", "Tow Bar", "Water Spray", "Guardian Ability", "Sonar Smash", "Super Jump", "Super Strength",
            "Tow Bar", "Accelerator Switches"
        ]),

        new(1179, "Lumpy Car", "Adventure Time",
            ["Accelerator Switches", "Tow Bar", "Jump"]),
        new(1180, "Lumpy Land Whale", "Adventure Time",
        [
            "Underwater Drone", "Sonar Smash", "Underwater Interactions", "Accelerator Switches", "Tow Bar",
            "Jump"
        ]),
        new(1181, "Lumpy Truck", "Adventure Time",
        [
            "Rainbow LEGO Objects", "Gold LEGO Blowup", "Flight Docks and Flight Cargo Hooks",
            "Underwater Drone", "Sonar Smash", "Underwater Interactions", "Accelerator Switches", "Tow Bar",
            "Jump"
        ]),

        new(1182, "Lunatic Amp", "Adventure Time",
            ["Sonar Smash", "Super Jump", "Dig", "Tow Bar"]),
        new(1183, "Shadow Scorpion", "Adventure Time",
        [
            "Flight Docks and Flight Cargo Hooks", "Special Attack", "Tow Bar", "Sonar Smash", "Super Jump",
            "Dig"
        ]),
        new(1184, "Heavy Metal Monster", "Adventure Time",
        [
            "Guardian Ability", "Super Strength", "Cursed Red LEGO Objects",
            "Flight Docks and Flight Cargo Hooks", "Special Attack", "Tow Bar", "Sonar Smash", "Super Jump",
            "Dig"
        ]),

        new(1185, "B.A.'s Van", "The A-Team", ["Accelerator Switches", "Tow Bar"]),
        new(1186, "Fool Shmasher", "The A-Team",
            ["Accelerator Switches", "Silver LEGO Blowup", "Special Attack", "Super Strength", "Tow Bar"]),
        new(1187, "Pain Plane", "The A-Team",
        [
            "Flying", "Flight Docks and Flight Cargo Hooks", "Sail", "Accelerator Switches",
            "Silver LEGO Blowup", "Special Attack", "Super Strength", "Tow Bar"
        ]),

        new(1188, "Phone Home", "E.T. the Extra-Terrestrial",
            ["Phone Home", "Sonar Smash"]),
        new(1189, "Mobile Uplink", "E.T. the Extra-Terrestrial",
            ["Phone Home", "Special Attack", "Sonar Smash"]),
        new(1190, "Super-Charged Satellite", "E.T. the Extra-Terrestrial",
        [
            "Silver LEGO Blowup", "Gold LEGO Blowup", "Flight Docks and Flight Cargo Hooks", "Tow Bar",
            "Phone Home", "Special Attack", "Sonar Smash"
        ]),

        new(1191, "Niffler", "Fantastic Beasts and Where to Find Them",
            ["Playable Character", "Enhanced Stud Attraction", "Dig", "Guardian Ability"]),
        new(1192, "Sinister Scorpion", "Fantastic Beasts and Where to Find Them",
        [
            "Vine Cut", "Special Weapon", "Playable Character", "Enhanced Stud Attraction", "Dig",
            "Guardian Ability"
        ]),
        new(1193, "Vicious Vulture", "Fantastic Beasts and Where to Find Them",
        [
            "Gold LEGO Blowup", "Guardian Ability", "Vine Cut", "Special Weapon", "Playable Character",
            "Enhanced Stud Attraction", "Dig"
        ]),

        new(1194, "Swooping Evil", "Fantastic Beasts and Where to Find Them",
            ["Playable Character", "Guardian Ability"]),
        new(1195, "Brutal Bloom", "Fantastic Beasts and Where to Find Them",
            ["Special Weapon", "Guardian Ability", "Tow Bar", "Vine Cut", "Playable Character"]),
        new(1196, "Crawling Creeper", "Fantastic Beasts and Where to Find Them",
        [
            "Super Jump", "Electricity", "Dig", "Special Weapon", "Guardian Ability", "Tow Bar", "Vine Cut",
            "Playable Character"
        ]),

        new(1197, "Ecto-1 (2016)", "Ghostbusters 2016",
            ["Accelerator Switches", "Tow Bar"]),
        new(1198, "Ectozer", "Ghostbusters 2016",
            ["Accelerator Switches", "Tow Bar", "Special Attack", "Super Strength"]),
        new(1199, "PerfEcto", "Ghostbusters 2016",
        [
            "Electricity", "Water Spray", "Flying", "Sail", "Accelerator Switches", "Tow Bar", "Special Attack",
            "Super Strength"
        ]),

        new(1200, "Flash 'n' Finish", "Gremlins",
            ["Illumination", "Sonar Smash", "Gold LEGO Blowup"]),
        new(1201, "Rampage Record Player", "Gremlins",
            ["Special Attack", "Special Weapon", "Illumination", "Sonar Smash", "Gold LEGO Blowup"]),
        new(1202, "Stripe's Throne", "Gremlins",
        [
            "Super Jump", "Cursed Red LEGO Objects", "Special Attack", "Special Weapon", "Illumination",
            "Sonar Smash", "Gold LEGO Blowup"
        ]),

        new(1203, "R.C. Car", "Gremlins",
            ["Accelerator Switches", "Special Attack", "Electricity"]),
        new(1204, "Gadget-o-matic", "Gremlins",
            ["Accelerator Switches", "Special Attack", "Tow Bar", "Electricity"]),
        new(1205, "Scarlet Scorpion", "Gremlins",
            ["Super Jump", "Vine Cut", "Accelerator Switches", "Special Attack", "Tow Bar", "Electricity"]),

        new(1206, "Hogward Express", "Harry Potter",
            ["Accelerator Switches", "Tow Bar", "Sonar Smash"]),
        new(1207, "Steam Warrior", "Harry Potter",
        [
            "Super Strength", "Super Jump", "Special Attack", "Guardian Ability", "Accelerator Switches",
            "Tow Bar", "Sonar Smash"
        ]),
        new(1208, "Soaring Steam Plane", "Harry Potter",
        [
            "Gold LEGO Blowup", "Flight Docks and Flight Cargo Hooks", "Super Strength", "Super Jump",
            "Special Attack", "Guardian Ability", "Accelerator Switches", "Tow Bar", "Sonar Smash"
        ]),

        new(1209, "Enchanted Car", "Harry Potter",
            ["Accelerator Switches", "Tow Bar", "Flight Docks and Flight Cargo Hooks"]),
        new(1210, "Shark Sub", "Harry Potter",
        [
            "Underwater Drone", "Underwater Interactions", "Sonar Smash", "Accelerator Switches", "Tow Bar",
            "Flight Docks and Flight Cargo Hooks"
        ]),
        new(1211, "Monstrous Mouth", "Harry Potter",
        [
            "Vine Cut", "Gold LEGO Blowup", "Underwater Drone", "Underwater Interactions", "Sonar Smash",
            "Accelerator Switches", "Tow Bar", "Flight Docks and Flight Cargo Hooks"
        ]),

        new(1212, "IMF Scrambler", "Mission: Impossible",
            ["Accelerator Switches", "Jump", "Special Attack"]),
        new(1213, "Shock Cycle", "Mission: Impossible",
            ["Accelerator Switches", "Jump", "Special Weapon", "Silver LEGO Blowup", "Special Attack"]),
        new(1214, "IMF Covert Jet", "Mission: Impossible",
        [
            "Flight Docks and Flight Cargo Hooks", "Underwater Interactions", "Special Weapon", "Tow Bar",
            "Accelerator Switches", "Jump", "Silver LEGO Blowup", "Special Attack"
        ]),

        new(1215, "IMF Sports Car", "Mission: Impossible",
            ["Accelerator Switches", "Tow Bar"]),
        new(1216, "IMF Tank", "Mission: Impossible",
            ["Super Strength", "Gold LEGO Blowup", "Tow Bar", "Accelerator Switches"]),
        new(1217, "IMF Splorer", "Mission: Impossible",
        [
            "Underwater Drone", "Underwater Interactions", "Super Strength", "Gold LEGO Blowup", "Tow Bar",
            "Accelerator Switches"
        ]),

        new(1218, "Sonic Speedster", "Sonic the Hedgehog",
            ["Accelerator Switches", "Tow Bar"]),
        new(1219, "Blue Typhoon", "Sonic the Hedgehog",
            ["Flight Docks and Flight Cargo Hooks", "Sail", "Sonar Smash", "Tow Bar", "Accelerator Switches"]),
        new(1220, "Moto Bug", "Sonic the Hedgehog",
        [
            "Accelerator Switches", "Dig", "Vine Cut", "Super Jump", "Flight Docks and Flight Cargo Hooks",
            "Sail", "Sonar Smash", "Tow Bar"
        ]),

        new(1221, "The Tornado", "Sonic the Hedgehog",
            ["Tow Bar", "Flight Docks and Flight Cargo Hooks"]),
        new(1222, "Crabmeat", "Sonic the Hedgehog",
        [
            "Jump", "Gold LEGO Blowup", "Super Jump", "Guardian Ability", "Tow Bar",
            "Flight Docks and Flight Cargo Hooks"
        ]),
        new(1223, "Eggcatcher", "Sonic the Hedgehog",
        [
            "Tow Bar", "Flight Docks and Flight Cargo Hooks", "Electricity", "Jump", "Gold LEGO Blowup",
            "Super Jump", "Guardian Ability"
        ]),

        new(1224, "K.I.T.T.", "Knight Rider",
            ["Accelerator Switches", "Gold LEGO Blowup"]),
        new(1225, "Goliath Armored Semi", "Knight Rider",
            ["Tow Bar", "Super Strength", "Electricity", "Accelerator Switches", "Gold LEGO Blowup"]),
        new(1226, "K.I.T.T. Jet", "Knight Rider",
        [
            "Flight Docks and Flight Cargo Hooks", "Gold LEGO Blowup", "Silver LEGO Blowup", "Tow Bar",
            "Super Strength", "Electricity", "Accelerator Switches"
        ]),

        new(1227, "Police helicopter", "LEGO City: Undercover",
            ["Flight Docks and Flight Cargo Hooks", "Special Attack", "Tow Bar"]),
        new(1228, "Unknown", "LEGO City: Undercover",
        [
            "Gold LEGO Blowup", "Accelerator Switches", "Super Jump", "Special Attack",
            "Flight Docks and Flight Cargo Hooks", "Tow Bar"
        ]),
        new(1229, "Unknown", "LEGO City: Undercover",
        [
            "Flight Docks and Flight Cargo Hooks", "Tow Bar", "Drone Mazes", "Gold LEGO Blowup",
            "Accelerator Switches", "Super Jump", "Special Attack"
        ]),

        new(1230, "Bionic Steed", "The LEGO Batman Movie",
            ["Super Jump", "Special Weapon"]),
        new(1231, "Bat Raptor", "The LEGO Batman Movie",
            ["Super Jump", "Super Strength", "Special Weapon"]),
        new(1232, "Ultrabat", "The LEGO Batman Movie",
            ["Sonar Smash", "Super Strength", "Super Jump", "Super Strength", "Special Weapon"]),

        new(1233, "Batwing", "The LEGO Batman Movie",
            ["Tow Bar", "Flight Docks and Flight Cargo Hooks"]),
        new(1234, "The Black Thunder", "The LEGO Batman Movie",
            ["Accelerator Switches", "Tow Bar", "Flight Docks and Flight Cargo Hooks"]),
        new(1235, "Bat-Tank", "The LEGO Batman Movie",
            ["Accelerator Switches", "Tow Bar", "Silver LEGO Blowup", "Flight Docks and Flight Cargo Hooks"]),

        new(1236, "Skeleton Orga", "The Goonies",
            ["Organ Docks", "Special Weapon", "Sonar Smash"]),
        new(1237, "Skeleton Jukebox", "The Goonies",
            ["Jump", "Special Weapon", "Electricity", "Organ Docks", "Sonar Smash"]),
        new(1238, "Skele-Turkey", "The Goonies",
        [
            "Gold LEGO Blowup", "Flight Docks and Flight Cargo Hooks", "Tow Bar", "Jump", "Special Weapon",
            "Electricity", "Organ Docks", "Sonar Smash"
        ]),

        new(1239, "One-Eyed Willy's Pirate Ship", "The Goonies",
            ["Sail", "Silver LEGO Blowup", "Special Attack"]),
        new(1240, "Fanged Fortune", "The Goonies",
            ["Water Spray", "Special Attack", "Vine Cut", "Sail", "Silver LEGO Blowup"]),
        new(1241, "Inferno Cannon", "The Goonies",
            ["Special Attack", "Special Weapon", "Silver LEGO Blowup", "Water Spray", "Vine Cut", "Sail"]),

        new(1242, "Buckbeak", "Harry Potter",
            ["Super Strength", "Flying", "Guardian Ability", "Silver LEGO Blowup"]),
        new(1243, "Giant Owl", "Harry Potter",
            ["Flying", "Electricity", "Super Strength", "Guardian Ability", "Silver LEGO Blowup"]),
        new(1244, "Fierce Falcon", "Harry Potter",
        [
            "Flying", "Special Weapon", "Sonar Smash", "Electricity", "Super Strength", "Guardian Ability",
            "Silver LEGO Blowup"
        ]),

        new(1245, "Saturn's Sandworm", "Beetlejuice", ["Sonar Smash"]),
        new(1246, "Spooky Spider", "Beetlejuice",
            ["Special Weapon", "Super Jump", "Cursed Red LEGO Objects", "Enhanced Stud Attraction", "Sonar Smash"]),
        new(1247, "Haunted Vacuum", "Beetlejuice",
        [
            "Gold LEGO Blowup", "Tow Bar", "Silver LEGO Blowup", "Special Weapon", "Super Jump",
            "Cursed Red LEGO Objects", "Enhanced Stud Attraction", "Sonar Smash"
        ]),

        new(1248, "PPG Smartphone", "The Powerpuff Girls",
            ["Flight Docks and Flight Cargo Hooks", "Gold LEGO Blowup"]),
        new(1249, "PPG Hotline", "The Powerpuff Girls",
            ["Special Weapon", "Rainbow LEGO Objects", "Flight Docks and Flight Cargo Hooks", "Gold LEGO Blowup"]),
        new(1250, "Powerpuff Mag-Net", "The Powerpuff Girls",
        [
            "Special Weapon", "Enhanced Stud Attraction", "Silver LEGO Blowup", "Rainbow LEGO Objects",
            "Flight Docks and Flight Cargo Hooks", "Gold LEGO Blowup"
        ]),

        new(1251, "Ka-Pow Cannon", "The Powerpuff Girls",
            ["Special Weapon", "Silver LEGO Blowup"]),
        new(1252, "Slammin' Guitar", "The Powerpuff Girls",
            ["Special Weapon", "Super Strength", "Accelerator Switches", "Tow Bar", "Silver LEGO Blowup"]),
        new(1253, "Megablast-Bot", "The Powerpuff Girls",
        [
            "Special Attack", "Special Weapon", "Sonar Smash", "Super Strength", "Accelerator Switches",
            "Tow Bar", "Silver LEGO Blowup"
        ]),

        new(1254, "Octi", "The Powerpuff Girls", ["Gold LEGO Blowup"]),
        new(1255, "Super SKunk", "The Powerpuff Girls",
            ["Vine Cut", "Super Jump", "Dig", "Gold LEGO Blowup"]),
        new(1256, "Sonic Squid", "The Powerpuff Girls",
            ["Water Spray", "Vine Cut", "Super Jump", "Dig", "Gold LEGO Blowup"]),

        new(1257, "T-Car", "Teen Titans Go!",
            ["Super Jump", "Accelerator Switches", "Tow Bar"]),
        new(1258, "T-Forklift", "Teen Titans Go!",
            ["Super Jump", "Accelerator Switches", "Drone Mazes", "Tow Bar"]),
        new(1259, "T-Plane", "Teen Titans Go!",
        [
            "Accelerator Switches", "Flight Docks and Flight Cargo Hooks", "Tow Bar", "Sail", "Super Jump",
            "Drone Mazes"
        ]),

        new(1260, "Spellbook of Azarath", "Teen Titans Go!",
            ["Summon Ability", "Rainbow LEGO Objects", "Cursed Red LEGO Objects", "Sonar Smash"]),
        new(1261, "Raven Wings", "Teen Titans Go!",
        [
            "Cursed Red LEGO Objects", "Flying", "Gold LEGO Blowup", "Tow Bar", "Sonar Smash", "Summon Ability",
            "Rainbow LEGO Objects"
        ]),
        new(1262, "Giant Hand", "Teen Titans Go!",
        [
            "Super Jump", "Dig", "Super Strength", "Cursed Red LEGO Objects", "Flying", "Gold LEGO Blowup",
            "Tow Bar", "Sonar Smash", "Summon Ability", "Rainbow LEGO Objects"
        ]),

        new(1263, "Titan Robot", "Teen Titans Go!",
            ["Special Weapon", "Super Strength", "Tow Bar", "Silver LEGO Blowup"]),
        new(1264, "T-Rocket", "Teen Titans Go!",
            ["Gold LEGO Blowup", "Flying", "Special Weapon", "Super Strength", "Tow Bar", "Silver LEGO Blowup"]),
        new(1265, "Robot Retriever", "Teen Titans Go!",
        [
            "Super Jump", "Dig", "Electricity", "Gold LEGO Blowup", "Flying", "Special Weapon",
            "Super Strength", "Tow Bar", "Silver LEGO Blowup"
        ])
    ];
}