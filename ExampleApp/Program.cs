using AFloorUp;
using AFloorUp.Buildings;

using Radiance;

var building = new Level2Building(
    ElevatorLogic.FromFunction(controller =>
    {
        controller.Target = 3;
    }
));

Window.OnLoad += () =>
{
    building.SetDrawInfo(0, Window.Height, Window.Width, Window.Height);
};

Window.OnFrame += () =>
{
    building.Simulate(Window.DeltaTime);
};

Window.OnRender += () =>
{
    building.Draw();
};

Window.ClearColor = (1f, 1f, 1f, 1f);
Window.CloseOn(Input.Escape);
Window.Open();