using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;

namespace buEyeBaseVer5;

[Serializable]
public class CreateModelProperties : buSerilization5
{
	public Color BottomColor = Color.DarkGray;

	public Color MiddleColor = Color.White;

	public Color TopColor = Color.White;

	public displayType DisplayType = displayType.Rendered;

	public projectionType ProjetionType = projectionType.Perspective;

	public originSymbolStyleType OrigineSymbol = originSymbolStyleType.Ball;

	public waitCursorType WaitCursorMode = waitCursorType.Never;

	public DockStyle Dock = DockStyle.Fill;

	public bool ShowProgress = false;

	public bool GridVisible = false;

	public double GridStepX = 10.0;

	public double GridStepY = 10.0;

	public bool OriginSymbolVisible = false;

	public bool OrigineCaptionVisible = false;

	public int OrigineSize = 12;

	public bool ViewCubeIconVisible = true;

	public bool ReverseMouseWheel = false;

	public bool CoordinateSystemIconVisible = true;

	public bool ToolBorVisible = true;

	public int Width = 0;

	public int Height = 0;

	public MouseButton PanMouseButtons = new MouseButton(MouseButtons.Middle, modifierKeys.None);

	public MouseButton RotateMouseButtons = new MouseButton(MouseButtons.Middle, modifierKeys.Ctrl);

	public MouseButton ZoomMouseButtons = new MouseButton(MouseButtons.Middle, modifierKeys.Shift);

	public CreateModelProperties()
	{
	}

	public CreateModelProperties(ViewportSettings Settings)
	{
		BottomColor = Settings.BottomColor;
		TopColor = Settings.TopColor;
		MiddleColor = Settings.IntermediateColor;
		CoordinateSystemIconVisible = Settings.ShowCoordinateSystemIcon;
		ViewCubeIconVisible = Settings.ShowCubeIcon;
		GridVisible = Settings.ShowGrid;
		OrigineCaptionVisible = Settings.ShowOrigineCaption;
		OriginSymbolVisible = Settings.ShowOrigineIcon;
		ToolBorVisible = Settings.ShowToolbar;
		DisplayType = (displayType)Convert.ToInt32(Settings.DisplayMode);
		ProjetionType = (projectionType)Convert.ToInt32(Settings.Projection);
		OrigineSymbol = (originSymbolStyleType)Convert.ToInt32(Settings.OrigineIcon);
		OrigineSize = Settings.OrigineSize;
		GridStepX = Settings.GridStepX;
		GridStepY = Settings.GridStepY;
	}

	public CreateModelProperties(CreateModelProperties data)
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
		PanMouseButtons = new MouseButton(data.PanMouseButtons.Button, data.PanMouseButtons.ModifierKey);
		RotateMouseButtons = new MouseButton(data.RotateMouseButtons.Button, data.RotateMouseButtons.ModifierKey);
		ZoomMouseButtons = new MouseButton(data.ZoomMouseButtons.Button, data.ZoomMouseButtons.ModifierKey);
	}
}
