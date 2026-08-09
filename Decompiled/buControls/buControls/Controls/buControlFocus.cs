using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns31;

namespace buControls.Controls;

[TypeConverter(typeof(Class98))]
public class buControlFocus
{
	private bool bool_0 = false;

	private Color color_0 = Color.LightBlue;

	public Control Parent = null;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(false)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool Enable
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "LightBlue")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color FocusColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	public buControlFocus()
	{
	}

	public buControlFocus(buControlFocus control)
	{
		Enable = control.Enable;
		FocusColor = control.FocusColor;
	}

	public override string ToString()
	{
		return Enable + " , " + FocusColor.ToString();
	}
}
