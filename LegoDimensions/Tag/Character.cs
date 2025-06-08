// Licensed to Laurent Ellerbach and contributors under one or more agreements.
// Laurent Ellerbach and contributors license this file to you under the MIT license.

namespace LegoDimensions.Tag;

/// <summary>
/// Character class for Lego Dimensions.
/// </summary>
public class Character : ILegoTag
{
    /// <summary>
    /// Gets or sets the ID of the character.
    /// </summary>
    public ushort Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the character.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the world the character is from..
    /// </summary>
    public string World { get; set; }

    /// <summary>
    /// Gets or sets the list of abilities of the character.
    /// </summary>
    public List<string> Abilities { get; set; }

    /// <summary>
    /// Character class constructor.
    /// </summary>
    /// <param name="id">The ID of the character.</param>
    /// <param name="name">The name of the character.</param>
    /// <param name="world">The world the character is from.</param>
    /// <param name="abilities">The list of abilities of the character.</param>
    public Character(ushort id, string name, string world, List<string> abilities)
    {
        Id = id;
        Name = name;
        World = world;
        Abilities = abilities;
    }

    /// <summary>
    /// The list of all known characters.
    /// </summary>
    public static readonly List<Character> Characters =
    [
        new(00, "Unknown", "Unknown", []),
        new(01, "Batman", "DC Comics",
            ["Grapple", "Boomerang", "Stealth", "Rope Swing", "Glide", "Detective Mode", "Master Build"]),
        new(02, "Gandalf", "Lord of the Rings",
            ["Magic", "Magical Shield", "Illumination"]),
        new(03, "Wyldstyle", "The Lego Movie",
            ["Relic Detector", "Acrobat", "Master Build"]),
        new(04, "Aquaman", "DC Comics",
            ["Atlantis Elemental", "Dive", "Hazard Cleaner", "Growth", "Water Spray"]),
        new(05, "Bad Cop", "The Lego Movie", ["Laser", "Relic Detector", "Target"]),
        new(06, "Bane", "DC Comics",
            ["Big Transform", "Super Strength", "Super Strength Handles", "Hazard Protection"]),
        new(07, "Bart Simpson", "The Simpsons", ["Target", "Mini Access"]),
        new(08, "Benny", "The Lego Movie",
            ["Hacking", "Sonar Smash", "Target", "Master Build", "Technology", "Glide"]),
        new(09, "Chell", "Portal 2", ["Acrobat", "Portal Gun"]),

        new(10, "Cole", "Lego Ninjago",
            ["Spinjitzu", "Acrobat", "Stealth", "Laser Deflector", "Super Strength"]),
        new(11, "Cragger", "Lego Legends of Chima",
            ["CHI", "Super Strength", "Super Strength Handles", "Dive", "Hazard Protection"]),
        new(12, "Cyborg", "DC Comics",
        [
            "Target", "Dive", "Laser", "Underwater Laser", "Technology", "Underwater Technology",
            "Big Transform", "Super Strength", "Super Strength Handles", "Character Changing", "Flying",
            "Fix-It", "Hearts Regenerate"
        ]),
        new(13, "Cyberman", "Doctor Who",
            ["Mind Control", "Hacking", "Drone Mazes", "Silver LEGO Blowup", "X-Ray Vision", "Dive", "Technology"]),
        new(14, "Doc Brown", "Back to the Future",
            ["Hacking", "Technology", "Fix-It", "Drone Mazes", "Intelligence"]),
        new(15, "The Doctor", "Doctor Who",
            ["Hacking", "Technology", "Fix-It", "Sonar Smash", "Intelligence"]),
        new(16, "Emmet", "The Lego Movie", ["Drill", "Master Build", "Fix-It"]),
        new(17, "Eris", "Lego Legends of Chima",
            ["Super Strength", "CHI", "Target", "Flying"]),
        new(18, "Gimli", "Lord of the Rings",
            ["Super Strength", "Super Strength Handles", "Mini Access"]),
        new(19, "Gollum", "Lord of the Rings",
            ["Boomerang", "Silver LEGO Blowup", "Mini Access", "Acrobat", "Dive"]),

        new(20, "Harley Quinn", "DC Comics", ["Acrobat", "Super Strength"]),
        new(21, "Homer Simpson", "The Simpsons",
            ["Sonar Smash", "Chili Eating", "Big Transform", "Super Strength", "Super Strength Handles"]),
        new(22, "Jay", "Lego Ninjago",
            ["Spinjitzu", "Fix-It", "Acrobat", "Stealth", "Electricity", "Intelligence"]),
        new(23, "Joker", "DC Comics",
            ["Electricity", "Target", "Grapple", "Hazard Protection"]),
        new(24, "Kai", "Lego Ninjago",
            ["Spinjitzu", "Acrobat", "Stealth", "Laser Deflector"]),
        new(25, "ACU Trooper", "Jurassic World", ["Electricity", "Illumination"]),
        new(26, "Gamer Kid", "Midway Arcade",
            ["Super Strength", "Super Strength Handles", "Laser", "Invulnerability", "Stealth", "Speed"]),
        new(27, "Krusty", "The Simpsons",
            ["Growth", "Hazard Cleaner", "Water Spray"]),
        new(28, "Laval", "Lego Legends of Chima",
            ["CHI", "Super Strength", "Acrobat", "Laser Deflector", "Sonar Smash"]),
        new(29, "Legolas", "Lord of the Rings",
            ["Pole Vault", "Target", "Acrobat", "Grind Rails"]),

        new(30, "Lloyd", "Lego Ninjago",
            ["Spinjitzu", "Acrobat", "Stealth", "Laser Deflector", "Illumination"]),
        new(31, "Marty McFly", "Back to the Future", ["Sonar Smash"]),
        new(32, "Nya", "Lego Ninjago",
            ["Spinjitzu", "Acrobat", "Stealth", "Laser Deflector", "Fix-It"]),
        new(33, "Owen", "Jurassic World",
            ["Tracking", "Stealth", "Target", "Vine Cut"]),
        new(34, "Peter Venkman", "Ghostbusters",
            ["Suspend Ghost", "Laser", "Hazard Protection"]),
        new(35, "Slimer", "Ghostbusters",
        [
            "Boomerang", "Flying", "Slurp Access", "Dive", "Hazard Cleaner", "Sonar Smash", "Illumination",
            "Mini Access", "Hazard Protection"
        ]),
        new(36, "Scooby Doo", "Scooby-Doo",
            ["Tracking", "Dig", "Dive", "Stealth", "Glide"]),
        new(37, "Sensei Wu", "Lego Ninjago",
            ["Spinjitzu", "Stealth", "Pole Vault", "Acrobat", "Glide"]),
        new(38, "Shaggy", "Scooby-Doo",
            ["Tracking", "Illumination", "Stealth", "Glide"]),
        new(39, "Stay Puft", "Ghostbusters",
            ["Big Transform", "Super Strength", "Super Strength Handles", "Hazard Protection"]),

        new(40, "Superman", "DC Comics",
        [
            "Flying", "Dive", "Invulnerability", "Super Strength", "Super Strength Handles", "Freeze Breath",
            "Laser", "X-Ray Vision"
        ]),
        new(41, "Unikitty", "The Lego Movie",
            ["Rainbow LEGO Objects", "Master Build", "Big Transform"]),
        new(42, "Wicked Witch", "Wizard of Oz",
            ["Silver LEGO Blowup", "Flying", "Magic", "Illumination", "Mind Control", "Magical Shield"]),
        new(43, "Wonder Woman", "DC Comics",
        [
            "Acrobat", "Flying", "Mind Control", "Laser Deflector", "Invulnerability", "Grapple", "Boomerang",
            "Dive", "Super Strength", "Super Strength Handles"
        ]),
        new(44, "Zane", "Lego Ninjago",
            ["Acrobat", "Spinjitzu", "Stealth", "Boomerang", "Dive", "X-Ray Vision"]),
        new(45, "Green Arrow", "DC Comics",
            ["Pole Vault", "Target", "Acrobat", "Grapple"]),
        new(46, "Supergirl", "DC Comics",
        [
            "Flying", "Laser", "Invulnerability", "Super Strength", "Super Strength Handles", "X-Ray Vision",
            "Dive", "Freeze Breath", "Red Lantern Transformation", "Lantern Constructs", "Dig", "Grapple"
        ]),
        new(47, "Abby Yates", "Ghostbusters 2016",
        [
            "Intelligence", "Ghost Trap", "Suspend Ghost", "Ghost Puzzles", "Laser", "Hazard Protection",
            "Charge Transfer", "P.K.E. Meter", "Character Changing", "Technology", "Silver LEGO Blowup",
            "Fix-It", "Grapple", "Rope Swing", "Super Strength", "Super Strength Handles", "Ghost Chipper"
        ]),
        new(48, "Finn", "Adventure Time",
        [
            "Acrobat", "Laser", "Target", "Laser Deflector", "Pole Vault", "Sword Switch",
            "Cursed Red LEGO Objects", "Grapple", "Vine Cut", "Rope Swing"
        ]),
        new(49, "Ethan Hunt", "Mission: Impossible",
        [
            "Acrobat", "Target", "Technology", "Fuse Box", "Magno Gloves", "Drone Mazes", "Grapple",
            "Silver LEGO Blowup", "Stealth", "Scan Disguise", "Dive", "X-Ray Vision", "Rope Swing"
        ]),

        new(50, "Lumpy Space Princess", "Adventure Time",
            ["Boomerang", "Hazard Protection", "Rainbow LEGO Objects", "Mini Access", "Slurp Access", "Target"]),
        new(51, "Jake the Dog", "Adventure Time",
        [
            "Grapple", "Illumination", "Slurp Access", "Tracking", "Dig", "Rope Swing", "Shape Shift",
            "Super Strength", "Super Strength Handles", "Drill", "Gyrosphere Switch", "Sonar Smash", "Dive",
            "Mini Access", "Drone Mazes", "Big Transform"
        ]),
        new(52, "Harry Potter", "Harry Potter",
        [
            "Water Spray", "Target", "Laser Deflector", "Diffindo", "Flying", "Illumination",
            "Silver LEGO Blowup", "Stealth", "Magic", "Parseltongue Doors", "Apparate Access", "Hazard Cleaner",
            "Growth"
        ]),
        new(53, "Lord Voldemort", "Harry Potter",
        [
            "Water Spray", "Target", "Laser Deflector", "Diffindo", "Flying", "Illumination", "Mind Control",
            "Silver LEGO Blowup", "Magic", "Parseltongue Doors", "Apparate Access", "Hazard Cleaner", "Growth"
        ]),
        new(54, "Michael Knight", "Knight Rider",
            ["Acrobat", "Hacking", "Technology", "Tracking", "X-Ray Vision"]),
        new(55, "B.A.Baracus", "The A-Team",
        [
            "Target", "Fix-It", "Silver LEGO Blowup", "Super Strength", "Super Strength Handles",
            "A-Team Master Build", "Laser Deflector", "Character Changing"
        ]),
        new(56, "Newt Scamander", "Fantastic Beasts and Where to Find Them",
        [
            "Water Spray", "Target", "Laser Deflector", "Diffindo", "Illumination", "Silver LEGO Blowup",
            "Stealth", "Magic", "Intelligence", "Fix-It", "Lockpicking", "Fantastical Briefcase",
            "Apparate Access", "Hazard Cleaner", "Growth"
        ]),
        new(57, "Sonic the Hedgehog", "Sonic the Hedgehog",
        [
            "Speed", "Grind Rails", "Acrobat", "Super Strength", "Super Transformation", "Invulnerability",
            "Laser Deflector", "Super Jump"
        ]),
        new(58, "Unknown", "Unknown", ["Unknown"]),
        new(59, "Gizmo", "Gremlins",
            ["Target", "Mini Access", "Grapple", "Rope Swing", "Vine Cut", "Acrobat", "Dig", "Silver LEGO Blowup"]),

        new(60, "Stripe", "Gremlins", ["Target", "Acrobat", "Dig", "Vine Cut"]),
        new(61, "E.T.", "E.T. the Extra-Terrestrial",
            ["Growth", "Fix-It", "Hearts Regenerate", "Illumination", "Stealth", "Magic", "Mini Access"]),
        new(62, "Tina Goldstein", "Fantastic Beasts and Where to Find Them",
        [
            "Acrobat", "Water Spray", "Target", "Laser Deflector", "Diffindo", "Illumination",
            "Silver LEGO Blowup", "Stealth", "Magic", "Apparate Access", "Magical Shield", "Growth",
            "Hazard Cleaner", "Mind Control"
        ]),
        new(63, "Marceline Abadeer", "Adventure Time",
        [
            "Sonar Smash", "Flying", "Magic", "Slurp Access", "Dig", "Tracking", "Stealth", "Acrobat",
            "Cursed Red LEGO Objects", "Hearts Regenerate", "Mini Access", "Vine Cut", "Super Strength"
        ]),
        new(64, "Batgirl", "The LEGO Batman Movie",
            ["Boomerang", "Detective Mode", "Stealth", "Grapple", "High Security Access", "Glide", "Rope Swing"]),
        new(65, "Robin (Lego Movie)", "The LEGO Batman Movie",
        [
            "Acrobat", "Fix-It", "Vent Access", "Illumination", "Suit Rip", "Dive", "Pole Vault",
            "Laser Deflector", "Glide", "Grapple", "Rope Swing"
        ]),
        new(66, "Sloth", "The Goonies",
        [
            "Super Strength", "Super Strength Handles", "Grapple", "Rope Swing", "Dig", "Dive", "Target",
            "Uniform Changing", "Character Changing", "Mini Access", "Intelligence", "Silver LEGO Blowup",
            "Acrobat", "Laser Deflector", "Technology", "X-Ray Vision", "Fix-It", "Tracking", "Illumination",
            "Sonar Smash", "Truffle Shuffle", "Vine Cut"
        ]),
        new(67, "Hermione Granger", "Harry Potter",
        [
            "Acrobat", "Water Spray", "Target", "Laser Deflector", "Diffindo", "Illumination",
            "Silver LEGO Blowup", "Magic", "Intelligence", "Apparate Access", "Hazard Cleaner", "Growth"
        ]),
        new(68, "Chase McCain", "LEGO City: Undercover",
        [
            "Acrobat", "Grapple", "Rope Swing", "Tracking", "Relic Detector", "Uniform Changing",
            "Illumination", "Silver LEGO Blowup", "Super Strength", "Water Spray", "Growth", "Hazard Cleaner",
            "Glide", "Target", "Hacking", "Flying", "Drill"
        ]),
        new(69, "Excalibur Batman", "The LEGO Batman Movie",
        [
            "Boomerang", "Sword Switch", "Stealth", "Laser Deflector", "Grapple", "Rope Swing",
            "Super Strength", "Master Build"
        ]),

        new(70, "Raven", "Teen Titans Go!",
        [
            "Magic", "Raven Portals", "Flying", "Laser", "Electricity", "Drone Mazes", "Hazard Protection",
            "Intelligence", "Lantern Constructs"
        ]),
        new(71, "Beast Boy", "Teen Titans Go!",
        [
            "Atlantis Elemental", "Acrobat", "Dig", "Flying", "Drone Mazes", "Slurp Access", "Mini Access",
            "Tracking", "Dive"
        ]),
        new(72, "Beetlejuice", "Beetlejuice",
        [
            "Mind Control", "Magic", "Slurp Access", "Illumination", "Mini Access", "Super Strength",
            "Apparate Access"
        ]),
        new(73, "Unknown", "Unknown", ["Unknown"]),
        new(74, "Blossom", "The Powerpuff Girls",
        [
            "Flying", "Lantern Constructs", "Laser", "Freeze Breath", "Energy Shield", "Intelligence",
            "Super Strength", "Dive", "X-Ray Vision", "Hearts Regenerate"
        ]),
        new(75, "Bubbles", "The Powerpuff Girls",
        [
            "Flying", "Laser", "Lantern Constructs", "Rainbow LEGO Objects", "Sonar Smash",
            "Parseltongue Doors", "Super Strength", "Dive", "Atlantis Elemental", "Hearts Regenerate"
        ]),
        new(76, "Buttercup", "The Powerpuff Girls",
        [
            "Flying", "Lantern Constructs", "Super Strength", "Super Strength Handles", "Energy Shield",
            "Gyrosphere Switch", "Dive", "Spinjitzu", "Hearts Regenerate"
        ]),
        new(77, "Starfire", "Teen Titans Go!",
        [
            "Atlantis Elemental", "Acrobat", "Laser", "Rainbow LEGO Objects", "Dive", "Flying",
            "Parseltongue Doors", "Hearts Regenerate"
        ]),
        new(78, "Unknown", "Unknown", ["Unknown"]),
        new(79, "Unknown", "Unknown", ["Unknown"]),
        new(80, "Unknown", "Unknown", ["Unknown"]),

        new(81, "Supergirl Red Lantern", "DC Comics",
        [
            "Flying", "Dive", "Invulnerability", "Super Strength", "Laser", "X-Ray Vision",
            "Lantern Constructs", "Dig", "Grapple", "Freeze Breath"
        ])
    ];
}