namespace LegoDimensionsRunner.Actions;

public interface IAction
{
    string Name { get; }

    int? Duration { get; set; }
}