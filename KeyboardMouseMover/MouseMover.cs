using System.Diagnostics;
using WindowsInput;
using Timer = System.Threading.Timer;

namespace KeyboardMouseMover;

public class MouseMover
{
    private const int PixelSpeed = 1;
    private const float AccelerationOverTime = 1.01f;
    private const float AccelerationMax = 10.0f;
    private const int TickIntervalMs = 100;
    
    private InputSimulator _inputSim;
    private Timer _tickTimer;
    private float _currentAcceleration;
    private bool _didMoveInTick;
    
    public MouseMover()
    {
        _inputSim = new();
        _tickTimer = new Timer(TimerTick, null, TickIntervalMs, Timeout.Infinite);
        _currentAcceleration = PixelSpeed;
        _didMoveInTick = false;
    }

    private void TimerTick(object? state)
    {
        _tickTimer.Change(TickIntervalMs, Timeout.Infinite);
        
        Debug.WriteLine(_currentAcceleration);
        
        if (_didMoveInTick)
        {
            _didMoveInTick = false;
            return;
        }

        _currentAcceleration = PixelSpeed;
    }

    private void MoveMouse(int deltaX, int deltaY)
    {
        if (_currentAcceleration < AccelerationMax)
            _currentAcceleration *= AccelerationOverTime;
        
        var speedBoost = (int) Math.Round(_currentAcceleration);
        
        _inputSim.Mouse.MoveMouseBy(deltaX * speedBoost, deltaY * speedBoost);

        _didMoveInTick = true;
    }
    
    public void Up() => MoveMouse(0, -1);
    public void Right() => MoveMouse(1, 0);
    public void Down() => MoveMouse(0, 1);
    public void Left() => MoveMouse(-1, 0);
}