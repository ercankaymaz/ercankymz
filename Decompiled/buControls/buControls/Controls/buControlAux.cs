using System.ComponentModel;
using System.Windows.Forms;
using ns35;

namespace buControls.Controls;

[TypeConverter(typeof(Class89))]
public class buControlAux
{
	private int int_0 = 0;

	private int int_1 = -1;

	private double double_0 = 0.0;

	private string string_0 = "";

	private string string_1 = "";

	private string string_2 = "";

	private string string_3 = "";

	private string string_4 = "";

	public Control Parent = null;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(0.0)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public double ValDouble
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
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
	public int ValInt
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

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string Explanation
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
	public string Command
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
	public string VariableName
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
	public string AuxInfo
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
	public string HelpRefKey
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
	[DefaultValue(-1)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int Index
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

	public buControlAux()
	{
	}

	public buControlAux(double valdbl, int valint, string explanation)
	{
		ValInt = valint;
		ValDouble = valdbl;
		Explanation = explanation;
	}

	public buControlAux(double valdbl, int valint, string explanation, string variablename)
	{
		ValInt = valint;
		ValDouble = valdbl;
		Explanation = explanation;
		VariableName = variablename;
	}

	public buControlAux(buControlAux separator)
	{
		ValInt = separator.ValInt;
		ValDouble = separator.ValDouble;
		Explanation = separator.Explanation;
		VariableName = separator.VariableName;
	}

	public override string ToString()
	{
		return ValDouble + " , " + Explanation.ToString();
	}
}
