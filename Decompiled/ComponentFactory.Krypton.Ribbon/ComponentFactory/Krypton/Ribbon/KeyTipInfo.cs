using System.Drawing;

namespace ComponentFactory.Krypton.Ribbon;

internal class KeyTipInfo
{
	private bool _enabled;

	private bool _visible;

	private string _keyString;

	private Point _screenPt;

	private Rectangle _clientRect;

	private IRibbonKeyTipTarget _target;

	public bool Enabled => _enabled;

	public bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			_visible = value;
		}
	}

	public string KeyString => _keyString;

	public Point ScreenPt => _screenPt;

	public Rectangle ClientRect => _clientRect;

	public KeyTipInfo(bool enabled, string keyString, Point screenPt, Rectangle clientRect, IRibbonKeyTipTarget target)
	{
		_enabled = enabled;
		_keyString = keyString;
		_screenPt = screenPt;
		_clientRect = clientRect;
		_target = target;
		_visible = true;
	}

	public void KeyTipSelect(KryptonRibbon ribbon)
	{
		if (_target != null)
		{
			_target.KeyTipSelect(ribbon);
		}
	}
}
