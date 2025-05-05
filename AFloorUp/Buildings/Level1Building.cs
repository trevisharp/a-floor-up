namespace AFloorUp.Buildings;

using Elevators;

public class Level1Building : Building
{
    public Level1Building(ElevatorLogic logic)
    {
        var callMemory = new Memory<CallInfo>();
        var reqsMemory = new Memory<RequestInfo>();
        var elevator = new BasicElevator(
            1, logic,
            callMemory,
            reqsMemory
        );

        AddElevator(elevator);
        AddFloor(CallPanel.Simple(callMemory));
        AddFloor(CallPanel.Simple(callMemory));
        AddFloor(CallPanel.Simple(callMemory));
        AddFloor(CallPanel.Simple(callMemory));
    }
}