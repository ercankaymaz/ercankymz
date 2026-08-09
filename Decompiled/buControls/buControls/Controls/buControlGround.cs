using System.ComponentModel;
using System.Windows.Forms;
using ns22;

namespace buControls.Controls;

[TypeConverter(typeof(Class99))]
public class buControlGround
{
	private int int_0 = 0;

	private int int_1 = 35;

	public Control Parent = null;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(35)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int TopHeight
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(0)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int BottomHeight
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

	public buControlGround()
	{
	}

	public buControlGround(buControlGround control)
	{
		TopHeight = control.TopHeight;
		BottomHeight = control.BottomHeight;
	}

	public override string ToString()
	{
		return TopHeight + " , " + BottomHeight;
	}
}
