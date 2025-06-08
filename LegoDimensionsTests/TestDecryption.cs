// Licensed to Laurent Ellerbach and contributors under one or more agreements.
// Laurent Ellerbach and contributors license this file to you under the MIT license.

namespace LegoDimensionsTests;

public class TestDecryption
{
    [Fact]
    public void DecryptVehicle()
    {
        // Arrange
        byte[] data = [0x63, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        ];

        // Act & Assert
        Assert.True(LegoTag.IsVehicle(data.AsSpan(8, 4).ToArray()));
        ushort id = LegoTag.GetVehicleId(data);
        Assert.Equal(1123, id);
    }

    [Fact]
    public void DecryptCharacter()
    {
        // Arrange
        byte[] data = [0x5C, 0xF7, 0x1C, 0xDE, 0x29, 0xAD, 0xEA, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        ];
        byte[] uid = [0x04, 0x47, 0x37, 0xE2, 0x48, 0x3F, 0x80];

        // Act & Assert
        Assert.False(LegoTag.IsVehicle(data.AsSpan(8, 4).ToArray()));
        ushort id = LegoTag.GetCharacterId(uid, data.AsSpan(0, 8).ToArray());
        Assert.Equal(16, id);
    }

    [Fact]
    public void EncryptCharacter()
    {
        // Arrange
        byte[] correctData = [0x5C, 0xF7, 0x1C, 0xDE, 0x29, 0xAD, 0xEA, 0x08];
        byte[] uid = [0x04, 0x47, 0x37, 0xE2, 0x48, 0x3F, 0x80];

        // Act
        byte[] data = LegoTag.EncryptCharacterId(uid, 16);
        ushort id = LegoTag.GetCharacterId(uid, data);

        // Assert
        Assert.True(data.SequenceEqual(correctData));
        Assert.Equal(16, id);
    }

    [Fact]
    public void EncryptVehicle()
    {
        // Arrange
        const ushort ID = 1123;

        byte[] data = LegoTag.EncryptVehicleId(ID); // Act

        // Assert
        Assert.True(data.SequenceEqual(new byte[] { 0x63, 0x04, 0x00, 0x00 }));
    }

    [Fact]
    public void TestPasswordGeneration()
    {
        // Arrange
        byte[] uid = [0x04, 0x27, 0x50, 0x4A, 0x50, 0x49, 0x80];
        byte[] correctPassword = [0xA1, 0x7B, 0x4C, 0x95];

        // Act
        byte[] data = LegoTag.GenerateCardPassword(uid);

        Assert.True(data.SequenceEqual(correctPassword));
    }
}