using System.ComponentModel;
using System.Windows.Forms;
using ns36;

namespace buControls.Controls;

[TypeConverter(typeof(Class103))]
public class buControlNavigationPanel
{
	private int int_0 = 50;

	private buControlDisplay buControlDisplay_0 = new buControlDisplay();

	public Control Parent;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonDisplay
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
	[DefaultValue(50)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int ButtonSize
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

	public buControlNavigationPanel()
	{
	}

	public buControlNavigationPanel(buControlNavigationPanel navigation)
	{
		ButtonSize = navigation.ButtonSize;
	}

	public override string ToString()
	{
		return "S : " + ButtonSize;
	}
}
