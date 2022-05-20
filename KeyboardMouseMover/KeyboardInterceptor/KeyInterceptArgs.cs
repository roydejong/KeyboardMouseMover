namespace KeyboardInterceptor;

public class KeyInterceptArgs
{
    public readonly Key Key;
    public bool StopPropagation;

    public KeyInterceptArgs(Key key)
    {
        Key = key;
        StopPropagation = false;
    }
}