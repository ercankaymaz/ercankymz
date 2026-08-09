using System.ComponentModel;
using System.Windows.Forms;
using ns40;

namespace buControls.Controls;

[TypeConverter(typeof(Class90))]
public class buControlMotion
{
	private double double_0 = 0.0;

	private string string_0 = "";

	private string string_1 = "";

	private string string_2 = "";

	private int int_0 = -1;

	public Control Parent = null;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(0.0)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public double Value
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
	[DefaultValue(-1)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int AxisIndex
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
	public string Address
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
	public string Aux
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
	public string Note
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

	public buControlMotion()
	{
	}

	public buControlMotion(double val, string address, string aux)
	{
		Value = val;
		Address = address;
		Aux = aux;
	}

	public buControlMotion(buControlMotion separator)
	{
		Value = separator.Value;
		Address = separator.Address;
		Aux = separator.Aux;
		Note = separator.Note;
		AxisIndex = separator.AxisIndex;
	}

	public override string ToString()
	{
		return Address.ToString() + " , Val :" + Value;
	}
}
