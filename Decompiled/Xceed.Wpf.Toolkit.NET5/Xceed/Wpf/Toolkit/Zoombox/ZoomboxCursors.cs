using System.Reflection;
using System.Security;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Zoombox;

public class ZoomboxCursors
{
	private static readonly Cursor _zoom;

	private static readonly Cursor _zoomRelative;

	public static Cursor Zoom => _zoom;

	public static Cursor ZoomRelative => _zoomRelative;

	static ZoomboxCursors()
	{
		_zoom = Cursors.Arrow;
		_zoomRelative = Cursors.Arrow;
		try
		{
			_zoom = new Cursor(ResourceHelper.LoadResourceStream(Assembly.GetExecutingAssembly(), "Zoombox/Resources/Zoom.cur"));
			_zoomRelative = new Cursor(ResourceHelper.LoadResourceStream(Assembly.GetExecutingAssembly(), "Zoombox/Resources/ZoomRelative.cur"));
		}
		catch (SecurityException)
		{
		}
	}
}
