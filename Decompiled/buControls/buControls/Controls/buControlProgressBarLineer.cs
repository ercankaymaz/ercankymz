using System.ComponentModel;
using System.Windows.Forms;
using ns23;

namespace buControls.Controls;

[TypeConverter(typeof(Class106))]
public class buControlProgressBarLineer
{
	private int int_0 = 20;

	private bool bool_0;

	private bool bool_1 = true;

	private bool bool_2;

	private string string_0 = "";

	private bool bool_3 = true;

	private buControlDisplay buControlDisplay_0 = new buControlDisplay();

	public Control Parent;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay DoneDisplay
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

	[DefaultValue(20)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int Height
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

	[DefaultValue(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool ShowPercentage
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

	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool Vertical
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DefaultValue(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool VerticalBottomToTop
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DefaultValue("")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string DrawText
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

	[DefaultValue(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool ColorScaleFromBoxBounding
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	public override string ToString()
	{
		return "Lineer Progress";
	}
}
