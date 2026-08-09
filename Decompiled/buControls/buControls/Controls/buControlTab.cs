using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns39;

namespace buControls.Controls;

[TypeConverter(typeof(Class104))]
public class buControlTab
{
	public Control Parent;

	private buControlDisplay buControlDisplay_0 = new buControlDisplay();

	private buControlDisplay buControlDisplay_1 = new buControlDisplay();

	private Color color_0 = Color.Gray;

	private int int_0 = 0;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay Header
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay HeaderSelected
	{
		get
		{
			return buControlDisplay_1;
		}
		set
		{
			buControlDisplay_1 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DefaultValue(typeof(Color), "Gray")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color TabPageColor
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

	[DefaultValue(0)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int HeaderXOffset
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

	public buControlTab()
	{
		Header.Parent = Parent;
		HeaderSelected.Parent = Parent;
	}

	public buControlTab(buControlTab tab)
	{
		Header = new buControlDisplay(tab.Header);
		HeaderSelected = new buControlDisplay(tab.HeaderSelected);
		TabPageColor = tab.TabPageColor;
	}

	public override string ToString()
	{
		return TabPageColor.ToString();
	}
}
