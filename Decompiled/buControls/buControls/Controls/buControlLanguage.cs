using System.ComponentModel;
using System.Windows.Forms;
using ns36;

namespace buControls.Controls;

[TypeConverter(typeof(Class84))]
public class buControlLanguage
{
	private string string_0 = "";

	private string string_1 = "";

	private string string_2 = "";

	private string string_3 = "";

	private string string_4 = "";

	private string string_5 = "";

	private bool bool_0 = false;

	private int int_0 = 0;

	public Control Parent = null;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string Language1
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
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string Language2
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

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string Language3
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

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string Language4
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

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string Language5
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
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
	public string Language6
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
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
	public bool MultiLanguageEnable
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
	public int SelectedLanguage
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

	public buControlLanguage()
	{
	}

	public buControlLanguage(buControlLanguage control)
	{
		Language1 = control.Language1;
		Language2 = control.Language2;
		Language3 = control.Language3;
		Language4 = control.Language4;
		Language5 = control.Language5;
		Language6 = control.Language1;
		MultiLanguageEnable = control.MultiLanguageEnable;
		SelectedLanguage = control.SelectedLanguage;
	}

	public override string ToString()
	{
		return MultiLanguageEnable.ToString();
	}
}
