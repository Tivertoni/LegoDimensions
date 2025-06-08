using LegoDimensions.Portal;

namespace LegoDimensionsRunner;

public class Event
{
    public string? CardId { get; set; }

    public ushort? Id { get; set; }

    public Pad Pad { get; set; }

    public string Animation { get; set; }

    public int? PortalId { get; set; }
}