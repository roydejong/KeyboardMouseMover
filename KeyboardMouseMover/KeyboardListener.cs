using System.Runtime.InteropServices;
using KeyboardInterceptor;

namespace KeyboardMouseMover;

public class KeyboardListener
{
    private MouseMover _mouseMover;
    private Interceptor _interceptor;

    public KeyboardListener(MouseMover mouseMover)
    {
        _mouseMover = mouseMover;
        _interceptor = new Interceptor(HandleInterceptedKey);
    }

    public void Start()
    {
        _interceptor.Start();
    }

    public void Stop()
    {
        _interceptor.Stop();
    }

    private void HandleInterceptedKey(Key key)
    {
        switch (key)
        {
            case Key.NumPad8:
                _mouseMover.Up();
                break;
            case Key.NumPad6:
                _mouseMover.Right();
                break;
            case Key.NumPad2:
                _mouseMover.Down();
                break;
            case Key.NumPad4:
                _mouseMover.Left();
                break;
        }
    }
}