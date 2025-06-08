// Licensed to Laurent Ellerbach and contributors under one or more agreements.
// Laurent Ellerbach and contributors license this file to you under the MIT license.

namespace LegoDimensionsTests;

public class TestVehicle
{
    [Fact]
    public void TestRebuild()
    {
        // Arrange
        Vehicle vehicle0 = new(1000, "name", "world", null);            
        Vehicle vehicle1 = new(1001, "name", "world", null);            
        Vehicle vehicle2 = new(1002, "name", "world", null);            
        Vehicle vehicle3 = new(1003, "name", "world", null);            
        Vehicle vehicle155 = new(1155, "name", "world", null);            

        // Act            
        // Assert
        Assert.Equal(VehicleRebuild.First, vehicle0.Rebuild);
        Assert.Equal(VehicleRebuild.Second, vehicle1.Rebuild);
        Assert.Equal(VehicleRebuild.Third, vehicle2.Rebuild);
        Assert.Equal(VehicleRebuild.First, vehicle3.Rebuild);
        Assert.Equal(VehicleRebuild.First, vehicle155.Rebuild);
    }
}