namespace AFloorUp.Elevators;

public class BasicElevator(
    int id,
    ElevatorLogic logic,
    Memory<CallInfo> callMemory,
    Memory<RequestInfo> requestMemory
    ) : Elevator(id, logic, callMemory, requestMemory)
{
    const float floorHei = 2.5f;
    int target = 0;
    float y = 0f;
    float t = 0f;

    public override void Simulate(float dt)
    {
        t += dt;
        if (t < 0.25f)
            return;
        t -= 0.25f;
        
        var control = new ElevatorControl(target) {
            CallMemory = CallMemory,
            RequestMemory = RequestMemory
        };
        Logic.Decide(control);
        target = control.CurrentTarget;
    }
    
    public override void Draw(float x, float y, float widArea, float heiArea)
    {
        throw new System.NotImplementedException();
    }
}