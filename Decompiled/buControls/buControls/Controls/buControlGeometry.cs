using System.ComponentModel;
using System.Windows.Forms;
using ns35;

namespace buControls.Controls;

[TypeConverter(typeof(Class83))]
public class buControlGeometry
{
	private ShapeType shapeType_0 = ShapeType.Rectangle;

	private int int_0 = 10;

	private float float_0 = 1f;

	public Control Parent = null;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(1f)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public float Space
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(10)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int ArcDiameter
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
	[DefaultValue(ShapeType.Rectangle)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public ShapeType ShapeMode
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

	public buControlGeometry()
	{
	}

	public buControlGeometry(buControlGeometry control)
	{
		ArcDiameter = control.ArcDiameter;
		ShapeMode = control.ShapeMode;
		Space = control.Space;
	}

	public override string ToString()
	{
		return ShapeMode.ToString();
	}
}
