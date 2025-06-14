﻿// Licensed to Laurent Ellerbach and contributors under one or more agreements.
// Laurent Ellerbach and contributors license this file to you under the MIT license.

using System.Text;

namespace LegoDimensionsTests;

public class TestMessages
{
    [Fact]
    public void TestMessageWithString()
    {
        // Arrange
        Message message = new(MessageCommand.Wake);
        byte[] goodMessage = [0x55, 0x0f, 0xb0, 0x01, 0x28, 0x63, 0x29, 0x20, 0x4c, 0x45, 0x47, 0x4f, 0x20, 0x32, 0x30, 0x31, 0x34, 0xf7, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        ];
        // Act
        message.AddPayload("(c) LEGO 2014");
        byte[] bytes = message.GetBytes(1);

        // Assert
        Assert.True(bytes.SequenceEqual(goodMessage));
    }

    [Fact]
    public void TestCreateFromMessage()
    {
        // Arrange
        // Act
        Message message = Message.CreateFromBuffer([0x55, 0x0f, 0xb0, 0x01, 0x28, 0x63, 0x29, 0x20, 0x4c, 0x45, 0x47, 0x4f, 0x20, 0x32, 0x30, 0x31, 0x34, 0xf7, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        ], MessageSource.Machine);
        string str = Encoding.ASCII.GetString(message.Payload);
        // Assert
        Assert.Equal(MessageType.Normal, message.MessageType);
        Assert.Equal(1, message.MessageId);
        Assert.Equal(MessageCommand.Wake, message.MessageCommand);
        Assert.Equal("(c) LEGO 2014", str);
    }

    [Fact]
    public void TestReceived()
    {
        // Arrange
        // Act
        Message message = Message.CreateFromBuffer([0x55, 0x01, 0x03, 0x59, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        ], MessageSource.Portal);

        // This is just a confirmation of message received
        // Assert
        Assert.Equal(MessageType.Normal, message.MessageType);
        Assert.Equal(MessageCommand.None, message.MessageCommand);
    }
    [Fact]
    public void TestReceivedInput()
    {
        // Arrange
        // Act
        Message message = Message.CreateFromBuffer([0x55, 0x12, 0x03, 0x00, 0xBC, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        ], MessageSource.Portal);

        // This is just a confirmation of message received
        // Assert
        Assert.Equal(MessageType.Normal, message.MessageType);
        Assert.Equal(MessageCommand.None, message.MessageCommand);
        Assert.Equal(17, message.Payload.Length);
    }
}