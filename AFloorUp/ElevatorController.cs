namespace AFloorUp;

public class ElevatorController
{
    /// <summary>
    /// The floor target of the elevator.
    /// </summary>
    public int Target { get; set; }

    /// <summary>
    /// The id of the elevator.
    /// </summary>
    public required int Id { get; init; }

    /// <summary>
    /// Y position of base of the elevator in floor height unities.
    /// In other words, 0 is floor 0, 1 is floor 1 and 0.5 is 
    /// between floor 0 and 1.
    /// </summary>
    public required float YPosition { get; init; }

    /// <summary>
    /// Get if the door is open and delivering people.
    /// </summary>
    public required bool DoorIsOpen { get; init; }

    /// <summary>
    /// Access all memory of elevator calling.
    /// </summary>
    public required Memory<CallInfo> CallMemory { get; init; }
    
    /// <summary>
    /// Access all memory of elevator floor requests.
    /// </summary>
    public required Memory<RequestInfo> RequestMemory { get; init; }
}