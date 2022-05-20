using System.Reflection;
using KeyboardMouseMover.Assets;
using WindowsInput;

namespace KeyboardMouseMover;

public class TrayIcon : IDisposable
{
    private readonly ContextMenuStrip _contextMenu;
    private readonly NotifyIcon _notifyIcon;

    public TrayIcon()
    {
        _contextMenu = new ContextMenuStrip();
        
        AddContextMenuItem("Exit", FontStyle.Bold, Program.Exit);
        
        _notifyIcon = new NotifyIcon();
        _notifyIcon.Text = "KeyboardMouseMover";
        _notifyIcon.Icon = AssetAccess.PointerIcon;
        _notifyIcon.ContextMenuStrip = _contextMenu;
        _notifyIcon.Click += HandleClick;
    }

    public void Show()
    {
        _notifyIcon.Visible = true;
    }

    public void Hide()
    {
        _notifyIcon.Visible = false;
    }

    public void Dispose()
    {
        _notifyIcon.Dispose();
    }

    private void HandleClick(object? sender, EventArgs e)
    {
        typeof(NotifyIcon)
            .GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.Invoke(_notifyIcon, null);
    }

    #region Menu utils

    private ToolStripMenuItem AddContextMenuItem(string text, FontStyle fontStyle, Action onClick)
    {
        var item = new ToolStripMenuItem(text);
        item.Font = new Font(item.Font, fontStyle);
        item.Click += (sender, args) => onClick.Invoke();
        _contextMenu.Items.Add(item);
        return item;
    }
    
    #endregion
}