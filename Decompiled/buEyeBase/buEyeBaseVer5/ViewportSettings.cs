using System;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class ViewportSettings : buSerilization5
{
	public bool ShowCoordinateSystemIcon = true;

	public bool ShowOrigineIcon = true;

	public bool ShowOrigineCaption = true;

	public bool MovePositionEnable = false;

	public bool ShowCubeIcon = true;

	public bool ShowToolbar = true;

	public bool ShowGrid = false;

	public bool ZoomReverse = false;

	public bool View2D = false;

	public int OrigineSize = 5;

	public double GridStepX = 10.0;

	public double GridStepY = 10.0;

	public ProjectionModeType Projection = ProjectionModeType.Perspective;

	public DisplayModeType DisplayMode = DisplayModeType.Rendered;

	public OriginIconType OrigineIcon = OriginIconType.Ball;

	public Color BottomColor = Color.DarkGray;

	public Color IntermediateColor = Color.White;

	public Color TopColor = Color.SlateGray;

	public ViewportSettings()
	{
	}

	public ViewportSettings(ViewportSettings data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
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
}
