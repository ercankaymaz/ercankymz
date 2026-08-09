using System.ComponentModel;
using System.Windows.Forms;
using ns26;

namespace buControls.Controls;

[TypeConverter(typeof(Class100))]
public class buControlStatus
{
	private buControlDisplay buControlDisplay_0 = new buControlDisplay();

	private buControlDisplay buControlDisplay_1 = new buControlDisplay();

	private buControlDisplay buControlDisplay_2 = new buControlDisplay();

	private buControlDisplay buControlDisplay_3 = new buControlDisplay();

	private string string_0 = "";

	private string string_1 = "";

	private string string_2 = "";

	private string string_3 = "";

	private int int_0 = 2000;

	private int int_1 = 2000;

	private bool bool_0 = false;

	private bool bool_1 = false;

	private bool bool_2 = false;

	public Control Parent;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay Status
	{
		get
		{
			return buControlDisplay_3;
		}
		set
		{
			buControlDisplay_3 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay Information
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
	public buControlDisplay Warning
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay Alarm
	{
		get
		{
			return buControlDisplay_2;
		}
		set
		{
			buControlDisplay_2 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DefaultValue(2000)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int WarningTime
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

	[DefaultValue(2000)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int InformationTime
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

	[DefaultValue("")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string StatusText
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
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
	public string InformationText
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

	[DefaultValue("")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string WarningText
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
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
	public string AlarmText
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
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
	public bool ShowAlarm
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
	public bool ShowInformation
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

	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool ShowWarning
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

	public override string ToString()
	{
		return "Status ";
	}
}
