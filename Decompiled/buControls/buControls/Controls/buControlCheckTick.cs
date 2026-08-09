using System.ComponentModel;
using System.Windows.Forms;
using ns25;

namespace buControls.Controls;

[TypeConverter(typeof(Class96))]
public class buControlCheckTick
{
	private int int_0 = 20;

	private int int_1 = 6;

	private ShapeType shapeType_0 = ShapeType.Arc;

	private bool bool_0 = false;

	private bool bool_1 = true;

	private bool bool_2 = false;

	private buControlDisplay buControlDisplay_0 = new buControlDisplay();

	private buControlDisplay buControlDisplay_1 = new buControlDisplay();

	public Control Parent = null;

	private bool bool_3 = false;

	private int int_2 = 3;

	[DefaultValue(true)]
	public bool Visible
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

	[DefaultValue(false)]
	public bool OnlyClickMode
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

	[DefaultValue(3)]
	public int Space
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay TickDisplay
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
	public buControlDisplay ColorModeDisplay
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

	[DefaultValue(20)]
	public int BoxSize
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

	[DefaultValue(6)]
	public int ArcDiameter
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

	[DefaultValue(ShapeType.Arc)]
	public ShapeType Shape
	{
		get
		{
			return shapeType_0;
		}
		set
		{
			shapeType_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DefaultValue(false)]
	public bool RightSide
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
	public bool ColorModeEnable
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	public buControlCheckTick()
	{
	}

	public buControlCheckTick(buControlCheckTick check)
	{
		BoxSize = check.BoxSize;
		ColorModeEnable = check.ColorModeEnable;
		RightSide = check.RightSide;
		Space = check.Space;
		TickDisplay = new buControlDisplay(check.TickDisplay);
		ColorModeDisplay = new buControlDisplay(check.ColorModeDisplay);
		Visible = check.Visible;
	}

	public override string ToString()
	{
		return Visible.ToString();
	}
}
