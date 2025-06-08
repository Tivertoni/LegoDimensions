// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Web;
using LegoDimensions.Tag;

const string VEHICLES = "Vehicles";
const string CHARACTERS = "Characters";

const string PATH_PICTURES = @"C:\Repos\LegoDimensions.wiki\.attachments";
const string PATH_WIKI = @"C:\Repos\LegoDimensions.wiki";
const string WIKI_ABSOLUTE_PATH = "https://github.com/Ellerbach/LegoDimensions/wiki/.attachments";

List<string> listAllPictures = [];
StringBuilder sb;

// First, let's have all the images and ensure the folders are created and clean
listAllPictures.AddRange(Directory.GetFiles(PATH_PICTURES).Select(file => file[(file.LastIndexOf(Path.DirectorySeparatorChar) + 1)..]));

//if (Directory.Exists(Path.Combine(pathWiki, Vehicles)))
//{
//    Directory.Delete(Path.Combine(pathWiki, Vehicles), true);
//}

//Directory.CreateDirectory(Path.Combine(pathWiki, Vehicles));

//if (Directory.Exists(Path.Combine(pathWiki, Characters)))
//{
//    Directory.Delete(Path.Combine(pathWiki, Characters), true);
//}

//Directory.CreateDirectory(Path.Combine(pathWiki, Characters));

// Then , let's create the vehicles and characters pages

string[] themes = Vehicle.Vehicles.Select(m => m.World).Distinct().ToArray();
foreach (string theme in themes)
{
    if (theme == "Unknown")
    {
        continue;
    }

    Vehicle[] models = Vehicle.Vehicles.Where(m => m.World == theme).ToArray();
    sb = new StringBuilder();
    sb.Append($"# Vehicles - {theme}\r\n\r\n");
    sb.Append("You will find all the vehicles for this theme. The title contains the ID and the name.\r\n");

    foreach (Vehicle model in models)
    {
        sb.Append($"\r\n## {model.Id}-{model.Name}\r\n\r\n");
        sb.Append($"Rebuild: {model.Rebuild}\r\n");

        sb.Append("\r\n");

        string? pic = listAllPictures.FirstOrDefault(m => m.StartsWith($"{model.Id}-"));
        if (!string.IsNullOrWhiteSpace(pic))
        {
            sb.Append($"![{model.Id}-{model.Name}]({WIKI_ABSOLUTE_PATH}/{HttpUtility.UrlPathEncode(pic)})\r\n\r\n");
        }

        sb.Append("Abilities:\r\n\r\n");

        foreach (string cap in model.Abilities)
        {
            sb.Append($"* {cap}\r\n");
        }
    }

    File.WriteAllText(Path.Combine(PATH_WIKI, $"{VEHICLES} {theme.Replace(":", "")}.md"), sb.ToString());
}

// And the index of vehicles

sb = new StringBuilder();
sb.Append("# List of all the vehicle themes\r\n\r\n");
foreach (string theme in themes)
{
    if (theme == "Unknown")
    {
        continue;
    }

    sb.Append($"* [{theme}]({HttpUtility.UrlPathEncode($"{VEHICLES} {theme.Replace(":", "")}")})\r\n");
}

File.WriteAllText(Path.Combine(PATH_WIKI, "All vehicle themes.md"), sb.ToString());

themes = Character.Characters.Select(m => m.World).Distinct().ToArray();
foreach (string theme in themes)
{
    if (theme == "Unknown")
    {
        continue;
    }

    Character[] models = Character.Characters.Where(m => m.World == theme).ToArray();
    sb = new StringBuilder();
    sb.Append($"# Characters - {theme}\r\n\r\n");
    sb.Append("You will find all the characters for this theme. The title contains the ID and the name.\r\n");

    foreach (Character model in models)
    {
        sb.Append($"\r\n## {model.Id}-{model.Name}\r\n\r\n");

        string? pic = listAllPictures.FirstOrDefault(m => m.StartsWith($"{model.Id}-"));
        if (!string.IsNullOrWhiteSpace(pic))
        {
            sb.Append($"![{model.Id}-{model.Name}]({WIKI_ABSOLUTE_PATH}/{HttpUtility.UrlPathEncode(pic)})\r\n\r\n");
        }

        sb.Append("Abilities:\r\n\r\n");

        foreach (string cap in model.Abilities)
        {
            sb.Append($"* {cap}\r\n");
        }
    }

    File.WriteAllText(Path.Combine(PATH_WIKI, $"{CHARACTERS} {theme.Replace(":", "")}.md"), sb.ToString());
}

// And the index of characters

sb = new StringBuilder();
sb.Append("# List of all the characters themes\r\n\r\n");
foreach (string theme in themes)
{
    if (theme == "Unknown")
    {
        continue;
    }

    sb.Append($"* [{theme}]({HttpUtility.UrlPathEncode($"{CHARACTERS} {theme.Replace(":", "")}")})\r\n");
}

File.WriteAllText(Path.Combine(PATH_WIKI, "All characters themes.md"), sb.ToString());

// Third, let's create the list of all characters and vehicles
sb = new StringBuilder();
sb.Append("# List of all known Vehicles\r\n\r\n");

sb.Append("| Id | Name | Rebuild | World | Characteristics |\r\n");
sb.Append("| --- | --- | --- | --- | --- |\r\n");
foreach (Vehicle vec in Vehicle.Vehicles)
{
    if (vec.World == "Unknown")
    {
        continue;
    }

    sb.Append($"|{vec.Id}|{vec.Name}|{vec.Rebuild}|[{vec.World}]({HttpUtility.UrlPathEncode($"{VEHICLES} {vec.World}")})|{string.Join(",", vec.Abilities)}|\r\n");
}

File.WriteAllText(Path.Combine(PATH_WIKI, "All known vehicles.md"), sb.ToString());

sb = new StringBuilder();
sb.Append("# List of all known Characters\r\n\r\n");

sb.Append("| Id | Name | World | Characteristics |\r\n");
sb.Append("| --- | --- | --- | --- |\r\n");
foreach (Character car in Character.Characters)
{
    if (car.World == "Unknown")
    {
        continue;
    }

    sb.Append($"|{car.Id}|{car.Name}|[{car.World}]({HttpUtility.UrlPathEncode($"{CHARACTERS} {car.World}")})|{string.Join(",", car.Abilities)}|\r\n");
}

File.WriteAllText(Path.Combine(PATH_WIKI, "All known characters.md"), sb.ToString());

// Now let's create per ability the list of vehicles and characters

List<string> abilities = [];
foreach (List<string> ability in Vehicle.Vehicles.Select(m => m.Abilities))
{
    abilities.AddRange(ability);
}

abilities = abilities.Distinct().ToList();

sb = new StringBuilder();
sb.Append("# List of all abilities and the associates vehicles\r\n");

foreach (string ability in abilities)
{
    if (ability is "" or "Unknown")
    {
        continue;
    }

    sb.Append($"\r\n## {ability}\r\n\r\n");
    IEnumerable<Vehicle> vehicles = Vehicle.Vehicles.Where(m => m.Abilities.Contains(ability));
    foreach (Vehicle veh in vehicles)
    {
        if (ability.Contains(','))
        {
            Console.WriteLine($"Warning, ability {ability} is multiple, fix me in vehicle {veh.Id}");
        }

        sb.Append($"* {veh.Id}-{veh.Name}, {veh.Rebuild}, [{veh.World}]({HttpUtility.UrlPathEncode($"{VEHICLES} {veh.World}")})\r\n");
    }
}

File.WriteAllText(Path.Combine(PATH_WIKI, $"{VEHICLES} characteristics.md"), sb.ToString());

abilities = [];
foreach (List<string> ability in Character.Characters.Select(m => m.Abilities))
{
    abilities.AddRange(ability);
}

abilities = abilities.Distinct().ToList();
sb = new StringBuilder();
sb.Append("# List of all abilities and the associates vehicles\r\n");

foreach (string ability in abilities)
{
    if (ability is "" or "Unknown")
    {
        continue;
    }

    sb.Append($"\r\n## {ability}\r\n\r\n");
    IEnumerable<Character> cars = Character.Characters.Where(m => m.Abilities.Contains(ability));
    foreach (Character car in cars)
    {
        if (ability.Contains(","))
        {
            Console.WriteLine($"Warning, ability {ability} is multiple, fix me in character {car.Id}");
        }

        sb.Append($"* {car.Id}-{car.Name}, [{car.World}]({HttpUtility.UrlPathEncode($"{CHARACTERS} {car.World}")})\r\n");
    }
}

File.WriteAllText(Path.Combine(PATH_WIKI, $"{CHARACTERS} characteristics.md"), sb.ToString());