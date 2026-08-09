using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns29;

namespace buControls.Controls;

[TypeConverter(typeof(Class105))]
public class buControlProgressBarCircular
{
	private Color color_0 = Color.Gray;

	private Color color_1 = Color.Gray;

	private CircularProgressShape circularProgressShape_0 = CircularProgressShape.Flat;

	private float float_0 = 10f;

	private int int_0 = -2;

	private int int_1 = 6;

	private bool bool_0 = true;

	private int int_2 = 20;

	private Color color_2 = Color.LightGray;

	private Color color_3 = Color.LightGray;

	private Color color_4 = Color.Black;

	public Control Parent;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(20)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int TextHeight
	{
		get
		{
			return int_2;
		}
		set
		{
			if (value < 0)
			{
				value = 0;
			}
			int_2 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(10f)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public float Thickness
	{
		get
		{
			return float_0;
		}
		set
		{
			if (value < 1f)
			{
				value = 1f;
			}
			float_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(-2)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int BorderSpace
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
	[DefaultValue(6)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int InnerBorderSpace
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
	[DefaultValue(typeof(Color), "Gray")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color ProgressColor1
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

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "Gray")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color ProgressColor2
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

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "Black")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color CoreBorderColor
	{
		get
		{
			return color_4;
		}
		set
		{
			color_4 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "LightGray")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color CoreColor1
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

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "LightGray")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color CoreColor2
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

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(CircularProgressShape.Flat)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public CircularProgressShape ProgressShape
	{
		get
		{
			return circularProgressShape_0;
		}
		set
		{
			circularProgressShape_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(true)]
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

	public buControlProgressBarCircular()
	{
	}

	public buControlProgressBarCircular(buControlProgressBarCircular progress)
	{
		BorderSpace = progress.BorderSpace;
		CoreBorderColor = progress.CoreBorderColor;
		CoreColor1 = progress.CoreColor1;
		CoreColor2 = progress.CoreColor2;
		InnerBorderSpace = progress.InnerBorderSpace;
		ProgressColor1 = progress.ProgressColor1;
		ProgressColor2 = progress.ProgressColor2;
		ProgressShape = progress.ProgressShape;
		ShowPercentage = progress.ShowPercentage;
		TextHeight = progress.TextHeight;
		Thickness = progress.Thickness;
	}

	public static void Copy(buControlProgressBarCircular Source, ref buControlProgressBarCircular Target)
	{
		Target.BorderSpace = Source.BorderSpace;
		Target.CoreBorderColor = Source.CoreBorderColor;
		Target.CoreColor1 = Source.CoreColor1;
		Target.CoreColor2 = Source.CoreColor2;
		Target.InnerBorderSpace = Source.InnerBorderSpace;
		Target.ProgressColor1 = Source.ProgressColor1;
		Target.ProgressColor2 = Source.ProgressColor2;
		Target.ProgressShape = Source.ProgressShape;
		Target.ShowPercentage = Source.ShowPercentage;
		Target.TextHeight = Source.TextHeight;
		Target.Thickness = Source.Thickness;
	}

	public override string ToString()
	{
		return "Circular Progress";
	}
}
