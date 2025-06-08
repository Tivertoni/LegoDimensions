// Licensed to Laurent Ellerbach and contributors under one or more agreements.
// Laurent Ellerbach and contributors license this file to you under the MIT license.

namespace LegoDimensions.Portal;

internal class CommandId(byte messageId, MessageCommand messageCommand, ManualResetEvent? manualResetEvent)
{
    public MessageCommand MessageCommand { get; set; } = messageCommand;

    public byte MessageId { get; set; } = messageId;

    public ManualResetEvent? ManualResetEvent { get; set; } = manualResetEvent;

    public object? Result { get; set; }
}