using System.Reflection;

namespace KeyboardMouseMover.Assets;

public static class AssetAccess
{
    public static Icon? PointerIcon;
    public static Image? PointerImage;
    
    static AssetAccess()
    {
        PointerIcon = GetResourceIcon("KeyboardMouseMover.Assets.PointerIcon.ico");
        PointerImage = GetResourceImage("KeyboardMouseMover.Assets.PointerImage.png");
    }
    
    private static Icon? GetResourceIcon(string resourceName)
    {
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        return stream != null ? new Icon(stream) : null;
    }
    
    private static Image? GetResourceImage(string resourceName)
    {
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        return stream != null ? Image.FromStream(stream) : null;
    }
}