namespace AFloorUp;

public abstract class Elevator(
    ElevatorLogic logic,
    CallMemory memory
    )
{
    protected int target = 0;

    public readonly CallMemory Memory = memory;
    public readonly ElevatorLogic Logic = logic;
    public int CurrentFloor { get; internal set; }

    public void MoveTo(int target)
        => this.target = target;

    public abstract void Simulate(float dt);
    public abstract void Draw(float x, float y, float widArea, float heiArea);
}