using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns36;

namespace buControls.Controls;

[TypeConverter(typeof(Class101))]
public class buControlCombo
{
	public Control Parent;

	private int int_0 = 20;

	private Color color_0 = Color.DimGray;

	private Color color_1 = Color.DimGray;

	private Color color_2 = Color.LightGray;

	private Color color_3 = Color.WhiteSmoke;

	[DefaultValue(typeof(Color), "WhiteSmoke")]
	public Color ValueColor
	{
		get
		{
			return color_3;
		}
		set
		{
			color_3 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DefaultValue(typeof(Color), "LightGray")]
	public Color DropBoxColor
	{
		get
		{
			return color_2;
		}
		set
		{
			color_2 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DefaultValue(20)]
	public int ArrowButtonWidth
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

	[DefaultValue(typeof(Color), "DimGray")]
	public Color ArrowColor
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

	[DefaultValue(typeof(Color), "DimGray")]
	public Color ArrowLineColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	public buControlCombo()
	{
	}

	public buControlCombo(buControlCombo combo)
	{
		ValueColor = combo.ValueColor;
		DropBoxColor = combo.DropBoxColor;
		ArrowButtonWidth = combo.ArrowButtonWidth;
		ArrowColor = combo.ArrowColor;
	}

	public override string ToString()
	{
		return ValueColor.ToString();
	}
}
