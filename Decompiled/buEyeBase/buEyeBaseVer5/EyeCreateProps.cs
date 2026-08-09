using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;

namespace buEyeBaseVer5;

public class EyeCreateProps
{
	public Color BottomColor = Color.DarkGray;

	public Color IntermediateColor = Color.White;

	public Color TopColor = Color.SlateGray;

	public displayType DisplayType = displayType.Rendered;

	public projectionType ProjectionType = projectionType.Orthographic;

	public originSymbolStyleType OriginSymbol = originSymbolStyleType.Ball;

	public MouseButton PanMouseButton = new MouseButton(MouseButtons.Middle, modifierKeys.None);

	public MouseButton RotateMouseButton = new MouseButton(MouseButtons.Middle, modifierKeys.Ctrl);

	public MouseButton ZoomMouseButton = new MouseButton(MouseButtons.Middle, modifierKeys.Shift);

	public bool ShowGrid = false;

	public bool ShowOrigin = true;

	public bool ShowOriginCaption = false;

	public bool ShowCoordinateArrow = true;

	public bool ShowViewCube = true;

	public bool ShowToolBar = true;

	public bool ReverseMouseWheel = false;

	public int OrigineSize = 2;

	public string OriginString = "";

	public int Width = 0;

	public int Height = 0;

	public EyeCreateProps()
	{
	}

	public EyeCreateProps(bool Visible)
	{
		ShowCoordinateArrow = Visible;
		ShowGrid = Visible;
		ShowOrigin = Visible;
		ShowOriginCaption = Visible;
		ShowToolBar = Visible;
		ShowViewCube = Visible;
	}

	public EyeCreateProps(EyeCreateProps data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		PanMouseButton = new MouseButton(data.PanMouseButton.Button, data.PanMouseButton.ModifierKey);
		RotateMouseButton = new MouseButton(data.RotateMouseButton.Button, data.RotateMouseButton.ModifierKey);
		ZoomMouseButton = new MouseButton(data.ZoomMouseButton.Button, data.ZoomMouseButton.ModifierKey);
	}
}
