// Licensed to Laurent Ellerbach and contributors under one or more agreements.
// Laurent Ellerbach and contributors license this file to you under the MIT license.

using LegoDimensions.Tag;
using LegoDimensionsReadNfc;
using NStack;
using System.IO.Ports;
using Terminal.Gui;

bool alreadySetup = false;

StartAgain:
Application.Init();

// Setup wizar
Wizard wizard = new("Setup Wizard");

if (!alreadySetup)
{
    // Add 1st step
    Wizard.WizardStep firstStep = new("Setup NFC reader");
    wizard.AddStep(firstStep);
    firstStep.NextButtonText = "Continue!";
    firstStep.HelpText = "This wizard will help you to setup the NFC reader.";

    // Add 2nd step
    Wizard.WizardStep secondStep = new("Reader setup");
    wizard.AddStep(secondStep);
    secondStep.HelpText = "Please select the serial port of the PN532 NFC reader.";
    Label lbl = new("Ports:") { AutoSize = true };
    secondStep.Add(lbl);
    secondStep.NextButtonText = "Continue!";

    string[]? names = SerialPort.GetPortNames();
    ustring[] comPortsU = new ustring[names.Length];
    for (int i = 0; i < names.Length; i++)
    {
        comPortsU[i] = names[i];
    }

    RadioGroup comPortNames = new(comPortsU) { X = Pos.Right(lbl) + 1, Width = Dim.Fill() - 1 };
    secondStep.Add(comPortNames);

    wizard.Finished += args =>
    {
        // MessageBox.Query("Wizard", $"Finished. The selected port is '{names[comPortNames.SelectedItem]}' and action '{actionChoices[actionChoice.SelectedItem]}'", "Ok");
        NfcPn532.OpenComPort(names[comPortNames.SelectedItem]);
        Application.RequestStop();
        alreadySetup = true;
    };
}
else
{
    wizard.Finished += args =>
    {
        Application.RequestStop();
    };
}

// Ask what want to be done
Wizard.WizardStep thirdStep = new("Action step");
wizard.AddStep(thirdStep);
thirdStep.HelpText = "What do you want to do?";
ustring[] actionChoices = ["_Erase tag", "_Read tag", "Read _all card", "_Write tag", "_Quit"];
Label lblChoices = new("What do you want to execute?") { AutoSize = true };
thirdStep.Add(lblChoices);
RadioGroup actionChoice = new(actionChoices) { X = Pos.Right(lblChoices) + 1, Width = Dim.Fill() - 1 };
thirdStep.Add(actionChoice);

Application.Top.Add(wizard);
Application.Run();
Application.Shutdown();

// That's the write tag
switch (actionChoice.SelectedItem)
{
    case 0:
        NfcPn532.ErraseTag();
        goto StartAgain;

    case 1:
        NfcPn532.ReadLegoTag(false);
        goto StartAgain;

    case 2:
        NfcPn532.ReadLegoTag(true);
        goto StartAgain;

    case 3:
        Application.Init();
        bool okpressed = false;
        Button ok = new(3, 14, "Ok");
        Button cancel = new(10, 14, "Cancel");

        Dialog dialog = new("Lego tag ID", 60, 18, ok, cancel);
        ok.Clicked += () => { Application.RequestStop(); okpressed = true; };
        cancel.Clicked += () => Application.RequestStop();

        TextField entry = new()
        {
            X = 1,
            Y = 1,
            Width = Dim.Fill(),
            Height = 1
        };

        Label label = new("All characters and vehicules:")
        {
            X = Pos.Left(entry),
            Y = Pos.Top(entry) + 1
        };

        ListView list = new()
        {
            X = Pos.Left(entry),
            Y = Pos.Top(label) + 1,
            Width = Dim.Fill(),
            Height = Dim.Height(dialog) - 7
        };

        List<string> details = [];
        foreach (Character car in Character.Characters)
        {
            details.Add($"{car.Id}: {car.Name}-{car.World}");
        }

        foreach (Vehicle vec in Vehicle.Vehicles)
        {
            details.Add($"{vec.Id}: {vec.Name}-{vec.World}");
        }

        list.SetSource(details);
        dialog.Add(entry);
        dialog.Add(label);
        dialog.Add(list);

        Application.Top.Add(dialog);
        Application.Run();
        Application.Shutdown();
        if (okpressed)
        {
            ushort id = 0;
            if (entry.Text.IsEmpty)
            {
                if (list.SelectedItem > 0)
                {
                    id = ushort.Parse(details[list.SelectedItem].Split(":")[0]);
                }
            }
            else
            {
                id = ushort.Parse(entry.Text.ToString());
            }

            NfcPn532.WriteEmptyTag(id, id < 1000);
        }

        goto StartAgain;
}
