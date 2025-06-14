﻿// Licensed to Laurent Ellerbach and contributors under one or more agreements.
// Laurent Ellerbach and contributors license this file to you under the MIT license.

using LegoDimensions;
using LegoDimensionsRunner;

Console.WriteLine("Hello, Lego Dimensions Runner");

if (args.Length == 0)
{
    Console.WriteLine("You need to specify a file");
    return;
}

if (!File.Exists(args[0]))
{
    Console.WriteLine($"File {args[0]} does not exist");
    return;
}

CancellationTokenSource cs = new();

Console.WriteLine("Press ctrl+c to exit.");
Console.CancelKeyPress += (sender, eArgs) =>
{
    eArgs.Cancel = true;
    cs.Cancel();
};

string content = File.ReadAllText(args[0]).Replace("\r", "").Replace("\n","");

ProcessRunner.CreateAllPortals();

// Just to make sure we'll keep things clean
ILegoPortal[]? portals = ProcessRunner.GetLegoPortals();
LegoPortal[] legoPortals = new LegoPortal[portals.Length];
for (int i = 0; i < portals.Length; i++)
{
    legoPortals[i] = (LegoPortal)portals[i];
    legoPortals[i].WakeUp();
}

Runner runner = ProcessRunner.Deserialize(content);
ProcessRunner.Build(runner);
ProcessRunner.Run(cs.Token);

for (int i = 0; i < portals.Length; i++)
{
    legoPortals[i].Dispose();
}

Console.WriteLine("Thank you for playing with us :-)");