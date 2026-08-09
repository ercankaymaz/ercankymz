using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Control.Converters;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(BorderConverter))]
public class BorderSettings
{
	private Color _color;

	private bool _visible;

	private int _cornerRadius;

	private Workspace _parentWorkspace;

	[CompilerGenerated]
	private bool _003CDirty_003Ek__BackingField;

	protected internal virtual Workspace ParentWorkspace
	{
		get
		{
			return _parentWorkspace;
		}
		set
		{
			_parentWorkspace = value;
		}
	}

	[Description("The border color.")]
	public Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
			_0023_003DzlrEqyC6UUZf8(_0023_003DzsLHxXyo_003D: true);
		}
	}

	[Description("The border visibility status.")]
	public bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			_visible = value;
			_0023_003DzlrEqyC6UUZf8(_0023_003DzsLHxXyo_003D: true);
		}
	}

	[Description("The border corner radius.")]
	public int CornerRadius
	{
		get
		{
			return _cornerRadius;
		}
		set
		{
			_cornerRadius = value;
			_0023_003DzlrEqyC6UUZf8(_0023_003DzsLHxXyo_003D: true);
		}
	}

	public BorderSettings()
		: this(_0023_003Dz3S5baIME1gm5(), _0023_003Dz8KqL1jIFXwGQ(), visible: true)
	{
	}

	public BorderSettings(Color color, int cornerRadius, bool visible)
	{
		Color = RenderContextUtility.ConvertColor(color);
		CornerRadius = cornerRadius;
		Visible = visible;
		_0023_003DzlrEqyC6UUZf8(_0023_003DzsLHxXyo_003D: true);
	}

	private static Color _0023_003Dz3S5baIME1gm5()
	{
		return Color.FromArgb(255, 130, 130, 130);
	}

	private static int _0023_003Dz8KqL1jIFXwGQ()
	{
		return 0;
	}

	internal bool _0023_003DzAU_lUOBu3f_00246()
	{
		return _003CDirty_003Ek__BackingField;
	}

	internal void _0023_003DzlrEqyC6UUZf8(bool _0023_003DzsLHxXyo_003D)
	{
		_003CDirty_003Ek__BackingField = _0023_003DzsLHxXyo_003D;
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs()
	{
		if (RenderContextUtility.ConvertColor(Color).ToArgb() == _0023_003Dz3S5baIME1gm5().ToArgb() && CornerRadius == _0023_003Dz8KqL1jIFXwGQ())
		{
			return !Visible;
		}
		return true;
	}
}
