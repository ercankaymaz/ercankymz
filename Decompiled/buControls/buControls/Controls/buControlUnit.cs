using System.ComponentModel;
using System.Windows.Forms;
using ns41;

namespace buControls.Controls;

[TypeConverter(typeof(Class95))]
public class buControlUnit
{
	private bool bool_0 = false;

	private string string_0 = "";

	private int int_0 = 30;

	private buControlDisplay buControlDisplay_0 = new buControlDisplay();

	public Control Parent;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay Display
	{
		get
		{
			return buControlDisplay_0;
		}
		set
		{
			buControlDisplay_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(false)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool Visible
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
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string Caption
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(30)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int Width
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	public buControlUnit()
	{
	}

	public buControlUnit(buControlUnit caption)
	{
		Display = new buControlDisplay(caption.Display);
		Visible = caption.Visible;
		Caption = caption.Caption;
		Width = caption.Width;
	}

	public override string ToString()
	{
		return Caption + " Width : " + Width;
	}
}
