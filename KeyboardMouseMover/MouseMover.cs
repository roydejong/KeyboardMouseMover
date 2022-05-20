using WindowsInput;

namespace KeyboardMouseMover;

public class MouseMover
{
    private InputSimulator _inputSim;
    
    public MouseMover()
    {
        _inputSim = new();
    }

    private void MoveMouse(int deltaX, int deltaY)
    {
        _inputSim.Mouse.MoveMouseBy(deltaX, deltaY);
    }
    
    public void Up() => MoveMouse(0, -1);
    public void Right() => MoveMouse(1, 0);
    public void Down() => MoveMouse(0, 1);
    public void Left() => MoveMouse(-1, 0);
}