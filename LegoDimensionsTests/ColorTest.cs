// Licensed to Laurent Ellerbach and contributors under one or more agreements.
// Laurent Ellerbach and contributors license this file to you under the MIT license.

namespace LegoDimensionsTests;

public class ColorTest
{
    [Fact]
    public void ColorTestBasicSerialization() 
    {
        // Arrange
        Color col = Color.Red;

        // Act
        Color col2 = Color.FromHex(col.ToString());

        // Assert
        Assert.Equal(col, col2);
    }

    [Fact]
    public void ColorTestColorSerialization()
    {
        // Arrange
        const string COL = "Red";

        // Act
        Color? col2 = Color.FromColorName(COL);

        // Assert
        Assert.NotNull(col2);
        Assert.Equal(Color.Red, col2!);
    }

    [Fact]
    public void ColorTestColorCaseSerialization()
    {
        // Arrange
        const string COL = "rEd";

        // Act
        Color? col2 = Color.FromColorName(COL);

        // Assert
        Assert.NotNull(col2);
        Assert.Equal(Color.Red, col2!);
    }

    [Fact]
    public void ColorEqualTest()
    {
        // Arrange
        Color col1 = Color.Red;
        Color col2 = Color.Red;

        Assert.Equal(col1, col2);
        Assert.True(col1 == col2);
    }
}