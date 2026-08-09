using System.ComponentModel;
using System.Windows.Forms;
using ns39;

namespace buControls.Controls;

[TypeConverter(typeof(Class97))]
public class buControlSecurity
{
	private bool bool_0 = false;

	private int int_0 = 0;

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
	[DefaultValue(0)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int Level
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

	public buControlSecurity()
	{
	}

	public buControlSecurity(buControlSecurity control)
	{
		Enable = control.Enable;
		Level = control.Level;
	}

	public override string ToString()
	{
		return Enable + " , " + Level;
	}
}
