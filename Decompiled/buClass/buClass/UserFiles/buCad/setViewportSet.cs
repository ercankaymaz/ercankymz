using System.Drawing;
using System.Reflection;

namespace buClass.UserFiles.buCad;

public class setViewportSet : buSerilization
{
	public bool ShowCoordinateSystemIcon = true;

	public bool ShowOrigineIcon = true;

	public bool ShowOrigineCaption = true;

	public bool MovePositionEnable = false;

	public Pnt3D MovePositionValue = new Pnt3D();

	public int OrigineSize = 5;

	public OriginIconType OrigineIcon = OriginIconType.Ball;

	public bool ShowCubeIcon = true;

	public bool ShowToolbar = true;

	public bool ShowGrid = false;

	public bool ZoomReverse = false;

	public bool InitViewAsTopView = false;

	public bool View2D = false;

	public bool TopMost = true;

	public bool DisableVViewportRotate = false;

	public ProjectionModeType Projection = ProjectionModeType.Perspective;

	public Color BottomColor = Color.DarkGray;

	public Color IntermediateColor = Color.White;

	public Color TopColor = Color.SlateGray;

	public DisplayModeType DisplayMode = DisplayModeType.Rendered;

	public setViewportSet()
	{
	}

	public setViewportSet(setViewportSet data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
